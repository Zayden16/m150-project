import {Injectable} from "@angular/core";
import {AbstractrestService} from "./abstractrest.service";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";
import {Cost} from "../Models/Cost";

@Injectable()
export class CostService extends AbstractrestService<Cost> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Cost');

    function getCostByGroupId() {

    }
  }
}
