import { Injectable } from '@angular/core';
import { Cost } from './../Models/cost';
import { HttpClient } from  '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CostService {

  constructor(private http: HttpClient) { }

  async getAllCostsPerGroup(groupId: string): Promise<Cost[]> {
    try {
      return this.http.get<Cost[]>(`http://localhost:8080/cost/${groupId}`).toPromise();
    } catch (e) {
      return Promise.reject();
    }
  }
}
