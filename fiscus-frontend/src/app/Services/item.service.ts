import {Injectable} from "@angular/core";
import {AbstractrestService} from "./abstractrest.service";
import {Item} from "../Models/Item";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class ItemService extends AbstractrestService<Item> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Item');
  }
}
