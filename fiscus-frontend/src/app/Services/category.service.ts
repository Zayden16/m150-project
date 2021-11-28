import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {Category} from "../Models/Category";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class CategoryService extends AbstractRestService<Category> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Category');
  }
}
