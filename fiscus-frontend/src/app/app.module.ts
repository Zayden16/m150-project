import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from './Components/login/login.component';
import {CostComponent} from './Components/cost/cost.component';
import {CardModule} from "primeng/card";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";
import {ChartModule} from 'primeng/chart';
import {PanelMenuModule} from 'primeng/panelmenu';
import {LottieModule} from "ngx-lottie";
import player from 'lottie-web';
import {PanelmenuComponent} from './Components/panelmenu/panelmenu.component';
import {DialogModule} from 'primeng/dialog';
import {DropdownModule} from 'primeng/dropdown';
import {DashboardComponent} from './Components/dashboard/dashboard.component';
import {UserComponent} from './Components/user/user.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {UserService} from "./Services/user.service";
import {JwtInterceptor} from "./Interceptors/jwt.interceptor";
import {SettingsComponent} from './Components/settings/settings.component';
import {TableModule} from "primeng/table";
import {CreateGroupComponent} from './Components/create-group/create-group.component';
import {GroupService} from './Services/group.service';
import {CostService} from './Services/cost.service';
import {CategoryService} from "./Services/category.service";
import {ItemService} from "./Services/item.service";
import {PaymentService} from "./Services/payment.service";
import {ToastModule} from 'primeng/toast';
import {MessageService} from 'primeng/api';
import { GroupComponent } from './Components/group/group.component';

export function playerFactory() {
  return player;
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CostComponent,
    PanelmenuComponent,
    DashboardComponent,
    UserComponent,
    SettingsComponent,
    CreateGroupComponent,
    GroupComponent
  ],
  imports: [
    ToastModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CardModule,
    ButtonModule,
    InputTextModule,
    FormsModule,
    ReactiveFormsModule,
    DropdownModule,
    TableModule,
    HttpClientModule,
    LottieModule.forRoot({player: playerFactory}),
    ChartModule,
    FormsModule,
    ReactiveFormsModule,
    PanelMenuModule,
    DialogModule,
    LottieModule.forRoot({player: playerFactory})
  ],
  providers: [UserService, GroupService, CostService, CategoryService, ItemService, PaymentService, MessageService, {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule {
}
