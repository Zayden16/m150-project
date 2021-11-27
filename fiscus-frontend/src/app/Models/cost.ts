import { Category } from './Category';
export interface Cost {
    id: string;
    description: string;
    date: string;
    category: Category;
    price: string;
}