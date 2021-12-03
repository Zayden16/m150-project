import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";
import {Observable} from "rxjs";
import {ShoppingList} from "../Models/ShoppingList";

@Injectable()
export class ShoppingListService extends AbstractRestService<ShoppingList> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'ShoppingList');
  }

  GetOneByGroupId(groupId: number):  Observable<ShoppingList> {
    return this.httpClient.get<ShoppingList>(`${AppSettings.BASE_URL}ShoppingList/ByGroupId/${groupId}`);
  }
}
