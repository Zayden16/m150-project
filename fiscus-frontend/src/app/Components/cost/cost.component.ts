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
  costs: Cost[] = [
    {
      id: '1',
      description: '3 Brote',
      date: '18.08.20',
      category: 'Essen',
      price: '12.95'
    },
    {
      id: '2',
      description: '3 Kasten Bier',
      date: '20.09.20',
      category: 'Trinken',
      price: '37.65'
    }
  ];

  clonedCosts: { [s: string]: Cost; } = {};

  constructor(private costService: CostService) { }

  ngOnInit(): void {
    // this.costs = await this.costService.getAllCostsPerGroup(this.authService.currentUserValue.id);
  }

  onRowEditInit(cost: Cost) {
    this.clonedCosts[cost.id] = {...cost};
  }

  onRowEditSave(cost: Cost) {
    // if (cost.price > 0) {
    //   delete this.clonedProducts[cost.id];
    //   this.messageService.add({severity:'success', summary: 'Success', detail:'Product is updated'});
    // }
    // else {
    //   this.messageService.add({severity:'error', summary: 'Error', detail:'Invalid Price'});
    // }
  }

  onRowEditCancel(cost: Cost, index: number) {
    this.costs[index] = this.clonedCosts[cost.id];
    delete this.clonedCosts[cost.id];
  }
}
