import {Component, OnInit} from '@angular/core';
import {Item} from "../../Models/Item";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ItemService} from "../../Services/item.service";
import {AuthService} from "../../Services/auth.service";
import {UserService} from "../../Services/user.service";
import {ShoppingListService} from "../../Services/shopping-list.service";
import {ShoppingList} from "../../Models/ShoppingList";
import {User} from "../../Models/User";

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.scss']
})
export class ShoppingListComponent implements OnInit {
  currentUser: User = {} as User;
  itemForm: FormGroup;
  shoppingList: ShoppingList = {} as ShoppingList;
  items: Item[] = [];
  purchasedItems: Item[] = [];

  constructor(private authService: AuthService, private itemService: ItemService, private shoppingListService: ShoppingListService, private userService: UserService, private formBuilder: FormBuilder) {
    this.itemForm = this.formBuilder.group({
      name: [null, Validators.required],
      quantity: [null, [Validators.required, Validators.min(1)]],
      categoryId: [null, [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit(): void {
    this.userService.GetOne(this.authService.currentUserValue.userId).subscribe(user => {
      this.currentUser = user;
      this.shoppingListService.GetOneByGroupId(user.groupId).subscribe(shoppingList => {
        if (shoppingList == null) {
          let newShoppingList = {groupId: user.groupId} as ShoppingList;
          this.shoppingListService.Create(newShoppingList).subscribe(data => this.shoppingList = data);
        } else {
          this.shoppingList = shoppingList;
          this.itemService.GetAllByShoppingListId(shoppingList.shoppingListId).subscribe(items => {
            this.items = items.filter(x => !x.isPurchased);
            this.purchasedItems = items.filter(x => x.isPurchased);
          });
        }
      });
    });
  }

  async createItem() {
    if (this.itemForm.invalid) {
      return;
    }

    let newItem = this.itemForm.value as Item;
    newItem.userId = this.currentUser.userId;
    newItem.shoppingListId = this.shoppingList.shoppingListId;
    newItem.isPurchased = false;

    await this.itemService.Create(newItem).toPromise();
    this.itemForm.reset();
    location.reload();
  }

  async setIsPurchaseItem(item: Item){
    await this.itemService.Update(item).toPromise();
    location.reload();
  }
}
