import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {Item} from "../Models/Item";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class ItemService extends AbstractRestService<Item> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Item');
  }
}
