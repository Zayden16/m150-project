import {Injectable} from "@angular/core";
import {AbstractrestService} from "./abstractrest.service";
import {Group} from "../Models/Group";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class GroupService extends AbstractrestService<Group> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Group');
  }
}
