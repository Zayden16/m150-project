import { Injectable } from '@angular/core';
import { Cost } from './../Models/cost';
import { HttpClient } from  '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CostService {
  // let costs: Cost[] = [
  //   {
  //     id: '1',
  //     description: '3 Brote',
  //     date: '18.08.20',
  //     category: 'Essen',
  //     price: '12.95'
  //   },
  //   {
  //     id: '2',
  //     description: '3 Kasten Bier',
  //     date: '20.09.20',
  //     category: 'Trinken',
  //     price: '37.65'
  //   }
  // ];

  constructor(private http: HttpClient) { }

  async getAllCostsPerGroup(groupId: string): Promise<Cost[]> {
    // try {
    //   return this.http.get<Cost[]>(`http://localhost:8080/cost/${groupId}`).toPromise();
    // } catch (e) {
    //   return Promise.reject();
    // }
    const costs: Cost[] = [
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
    return costs;
  }

  async updateCost(cost: Cost): Promise<void> {
    // try {

    //   this.http.put(`http://localhost:8080/cost/${cost}`).toPromise();
    // } catch (e) {

    // }
  }
}
