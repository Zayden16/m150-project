import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {User} from "../Models/User";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";
import { Observable } from "rxjs";

@Injectable()
export class UserService extends AbstractRestService<User> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'User');
  }

  GetOneByUsername(username: string):  Observable<User> {
    return this.httpClient.get<User>(`${AppSettings.BASE_URL}User/byUsername/${username}`);
  }
}
