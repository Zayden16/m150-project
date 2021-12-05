import { Cost } from './../Models/Cost';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/appsettings';
import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class CostService extends AbstractRestService<Cost> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Cost');

  }
}
