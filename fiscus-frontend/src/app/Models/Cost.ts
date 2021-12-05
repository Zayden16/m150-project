import { Category } from './Category';

export interface Cost{
  costId: number,
  price: number,
  description: string,
  date: string,
  category: Category
  categoryId: number,
  groupId: number,
}
