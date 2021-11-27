import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  constructor() { }

  async getAll(): Promise<Category[]> {
    const categories: Category[] = [
      {
        "categoryId": 1,
        "name": "Grocery"
      },
      {
        "categoryId": 2,
        "name": "Bar/Party"
      },
      {
        "categoryId": 3,
        "name": "Rent"
      },
      {
        "categoryId": 4,
        "name": "Bill"
      },
      {
        "categoryId": 5,
        "name": "Excursion/Culture"
      },
      {
        "categoryId": 6,
        "name": "Health"
      },
      {
        "categoryId": 7,
        "name": "Shopping"
      },
      {
        "categoryId": 8,
        "name": "Restaurant"
      },
      {
        "categoryId": 9,
        "name": "Accommodation"
      },
      {
        "categoryId": 10,
        "name": "Transport"
      },
      {
        "categoryId": 11,
        "name": "Sport"
      },
      {
        "categoryId": 12,
        "name": "Reimbursement"
      }
    ]
    return categories;
  }
}
