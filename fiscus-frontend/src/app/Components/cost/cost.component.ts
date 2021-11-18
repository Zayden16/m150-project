import { CostService } from './../../service/cost.service';
import { Cost } from './../../Models/cost';
import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-cost',
  templateUrl: './cost.component.html',
  styleUrls: ['./cost.component.scss']
})
export class CostComponent implements OnInit {
  costs: Cost[] = [];

  clonedCosts: { [s: string]: Cost; } = {};

  constructor(private costService: CostService) { }

  async ngOnInit(): Promise<void> {
    this.costs = await this.costService.getAllCostsPerGroup('egal');
  }

  onRowEditInit(cost: Cost): void {
    this.clonedCosts[cost.id] = {...cost};
  }

  async onRowEditSave(cost: Cost): Promise<void> {
    if (this.validate(cost)) {
      await this.costService.updateCost(cost);
      alert(`Cost updated successfully!`);
    } else {
      alert(`Error while updating cost!`);
    }
  }

  onRowEditCancel(cost: Cost, index: number): void {
    this.costs[index] = this.clonedCosts[cost.id];
    delete this.clonedCosts[cost.id];
  }

  validate(cost: Cost): boolean {
    return true;
  }
}