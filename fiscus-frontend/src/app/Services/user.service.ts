import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {User} from "../Models/User";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class UserService extends AbstractRestService<User> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'User');
  }
}
