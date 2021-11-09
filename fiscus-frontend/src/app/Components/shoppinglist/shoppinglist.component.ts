import {Component, OnInit} from '@angular/core';
import {Item} from "../../Models/Item";

@Component({
  selector: 'app-shoppinglist',
  templateUrl: './shoppinglist.component.html',
  styleUrls: ['./shoppinglist.component.scss']
})
export class ShoppinglistComponent implements OnInit {

  constructor() {
  }

  items: Item[] = [];

  ngOnInit(): void {
    this.items = [{
      Id: 1,
      CategoryId: 1,
      IsPurchased: false,
      Name: "AA Batterys",
      ShoppingListId: 1,
      Quantity: 12,
      UserId: 1
    },
    {
      Id: 1,
      CategoryId: 1,
      IsPurchased: false,
      Name: "AAA Batterys",
      ShoppingListId: 1,
      Quantity: 12,
      UserId: 1
    }];
  }

}
