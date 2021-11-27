import { CostService } from './../../service/cost.service';
import { CategoryService } from './../../service/category.service';
import { Cost } from './../../Models/cost';
import { Category } from './../../Models/Category';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
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
    this.costs = await this.costService.getAllCostsPerGroup('egal');
    this.categories = await this.categoryService.getAll();
  }

  async createCost(): Promise<void> {
    this.submitted = true;
    const date = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    if(date != null) {
      this.newCost.date = date;
    }
    
    if (this.newCostForm.invalid) {
      return;
    }

    await this.costService.createCost(this.newCost);
    this.hideAddCost();
  }

  onRowEditInit(cost: Cost): void {
    this.clonedCosts[cost.id] = {...cost};
  }

  async onRowEditSave(cost: Cost): Promise<void> {
    await this.costService.updateCost(cost);
  }

  onRowEditCancel(cost: Cost, index: number): void {
    this.costs[index] = this.clonedCosts[cost.id];
    delete this.clonedCosts[cost.id];
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