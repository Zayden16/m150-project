import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {Item} from "../Models/Item";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";
import {Observable} from "rxjs";
import {User} from "../Models/User";

@Injectable()
export class ItemService extends AbstractRestService<Item> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Item');
  }

  GetAllByShoppingListId(shoppingListId: number):  Observable<Item[]> {
    return this.httpClient.get<Item[]>(`${AppSettings.BASE_URL}Item/ByShoppingListId/${shoppingListId}`);
  }
}
