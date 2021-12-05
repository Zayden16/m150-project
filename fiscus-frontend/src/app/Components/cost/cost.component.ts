import { CategoryService } from './../../Services/category.service';
import { CostService } from '../../Services/cost.service';
import { Cost } from '../../Models/Cost';
import { Category } from '../../Models/Category';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-cost',
  templateUrl: './cost.component.html',
  styleUrls: ['./cost.component.scss'],
  providers: [DatePipe]
})
export class CostComponent implements OnInit {
  costs: Cost[] = [];
  displayAddCost: boolean = false;
  clonedCosts: { [s: string]: Cost; } = {};
  newCost = {} as Cost;
  newCostForm: FormGroup;
  submitted = false;
  categories: Category[] = [];
  newCostCategory: Category = {categoryId: 0, name: ''};

  constructor(private costService: CostService, private formBuilder: FormBuilder, private datePipe: DatePipe, private categoryService: CategoryService) {
    this.newCostForm = this.formBuilder.group({
      description: [null, Validators.required],
      price: [null, Validators.required],
      category: [null, Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    this.costs = await this.costService.GetAll().toPromise();
    await this.makeCostsShowable();
    this.categories = await this.categoryService.GetAll().toPromise();
    this.newCostCategory = this.categories[0];
  }

  private async makeCostsShowable() {
    for (let i = 0; i < this.costs.length; i++) {
      const showableDate = this.datePipe.transform(new Date(this.costs[i].date), 'dd.MM.yyyy');
      if(showableDate != null) {
        this.costs[i].date = showableDate;
      }
      this.costs[i].category = await this.categoryService.GetOne(this.costs[i].categoryId).toPromise();
    }
  }

  async createCost(): Promise<void> {
    this.submitted = true;
    const date = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    if(date != null) {
      this.newCost.date = date;
    }
    this.newCost.categoryId = this.newCostCategory.categoryId;
    this.newCost.groupId = 1;
    if (this.newCostForm.invalid) {
      return;
    }
    this.costService.Create(this.newCost).toPromise()
    this.hideAddCost();
    location.reload();
  }

  deleteCost(cost: Cost): void {
    this.costService.Delete(cost.costId).toPromise();
    location.reload();
  }

  onRowEditInit(cost: Cost): void {
    this.clonedCosts[cost.costId] = {...cost};
  }

  async onRowEditSave(cost: Cost): Promise<void> {
    const date = this.datePipe.transform(new Date(cost.date), 'yyyy-MM-dd');
    if(date != null) {
      cost.date = date;
    }
    await this.costService.Update(cost).toPromise();
    location.reload();
  }

  onRowEditCancel(cost: Cost, index: number): void {
    this.costs[index] = this.clonedCosts[cost.costId];
    delete this.clonedCosts[cost.costId];
  }

  showAddCost(): void {
    this.displayAddCost = true;
  }

  hideAddCost(): void {
    this.displayAddCost = false;
  }

  get newCostFormControls() {
    return this.newCostForm.controls;
  }
}
