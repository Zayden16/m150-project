import {Injectable} from "@angular/core";
import {AbstractrestService} from "./abstractrest.service";
import {Category} from "../Models/Category";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class CategoryService extends AbstractrestService<Category> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Category');
  }
}
