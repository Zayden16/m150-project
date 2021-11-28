import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";
import {Cost} from "../Models/Cost";

@Injectable()
export class CostService extends AbstractRestService<Cost> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Cost');

    function getCostByGroupId() {

    }
  }
}
