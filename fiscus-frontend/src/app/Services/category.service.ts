import { Category } from './../Models/Category';
import { AppSettings } from 'src/appsettings';
import { Observable } from 'rxjs';
import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class CategoryService extends AbstractRestService<Category> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Category');
  }

  async getCategoryForCost(categoryId: number): Promise<Category> {
    const categories: Category[] = await this.GetAll().toPromise();
    for(const category of categories) {
      if(category.categoryId === categoryId) {
        return category;
      }
    }
    return categories[0];
  }
}
