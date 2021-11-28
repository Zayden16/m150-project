import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {Group} from "../Models/Group";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class GroupService extends AbstractRestService<Group> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Group');
  }
}
