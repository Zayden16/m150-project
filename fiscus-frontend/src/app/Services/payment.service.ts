import {Injectable} from "@angular/core";
import {AbstractrestService} from "./abstractrest.service";
import {Payment} from "../Models/Payment";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";

@Injectable()
export class PaymentService extends AbstractrestService<Payment> {
  constructor(http: HttpClient,) {
    super(http, AppSettings.BASE_URL + 'Payment');
  }
}
