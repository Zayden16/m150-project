import { Injectable } from '@angular/core';
import { Cost } from './../Models/cost';
import { HttpClient } from  '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CostService {

  constructor(private http: HttpClient) { }

  async getAllCostsPerGroup(groupId: string): Promise<Cost[]> {
    const costs: Cost[] = [
      {
        id: '1',
        description: '3 Brote',
        date: '18.08.20',
        category: {
          categoryId: '1',
          name: 'Grocery'
        },
        price: '12.95'
      },
      {
        id: '2',
        description: '3 Kasten Bier',
        date: '20.09.20',
        category: {
          categoryId: '2',
          name: 'Bar/Party'
        },
        price: '37.65'
      }
    ];
    return costs;
  }

  async updateCost(cost: Cost): Promise<void> {
  }

  async createCost(cost: Cost): Promise<void> {
  }
}
