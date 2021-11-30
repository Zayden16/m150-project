import { CostService } from '../../Services/cost.service';
import { CategoryService } from '../../Services/category.service';
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

  constructor(private costService: CostService, private formBuilder: FormBuilder, private datePipe: DatePipe, private categoryService: CategoryService) {
    this.newCostForm = this.formBuilder.group({
      description: [null, Validators.required],
      price: [null, Validators.required],
      category: [null, Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    this.costs = await this.costService.GetAll().toPromise();
    this.categories = await this.categoryService.GetAll().toPromise();
  }

  async createCost(): Promise<void> {
    this.submitted = true;
    const date = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    if(date != null) {
      this.newCost.Date = date;
    }

    if (this.newCostForm.invalid) {
      return;
    }

    await this.costService.Create(this.newCost);
    this.hideAddCost();
  }

  onRowEditInit(cost: Cost): void {
    this.clonedCosts[cost.CostId] = {...cost};
  }

  async onRowEditSave(cost: Cost): Promise<void> {
    await this.costService.Update(cost);
  }

  onRowEditCancel(cost: Cost, index: number): void {
    this.costs[index] = this.clonedCosts[cost.CostId];
    delete this.clonedCosts[cost.CostId];
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
