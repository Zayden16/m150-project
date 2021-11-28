import {Injectable} from "@angular/core";
import {AbstractRestService} from "./abstractRestService";
import {Payment} from "../Models/Payment";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class PaymentService extends AbstractRestService<Payment> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Payment');
  }
}
