import { Category } from './Category';

export interface Cost{
  CostId: number,
  Price: number,
  Description: string,
  Date: string,
  Category: Category,
  GroupId: number
}
