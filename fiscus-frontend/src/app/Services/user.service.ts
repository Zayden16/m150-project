import {Injectable} from "@angular/core";
import {AbstractrestService} from "./abstractrest.service";
import {User} from "../Models/User";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class UserService extends AbstractrestService<User> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'User');
  }
}
