import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from './Components/login/login.component';
import {CostComponent} from './Components/cost/cost.component';
import {CardModule} from "primeng/card";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";
import {FormsModule, ReactiveFormsModule}    from '@angular/forms';
import {TableModule} from 'primeng/table';
import {ChartModule} from 'primeng/chart';
import {PanelMenuModule} from 'primeng/panelmenu';
import {LottieModule} from "ngx-lottie";
import player from 'lottie-web';
import { PanelmenuComponent } from './Components/panelmenu/panelmenu.component'; 
import { HttpClientModule } from '@angular/common/http';
import {DialogModule} from 'primeng/dialog';
import {DropdownModule} from 'primeng/dropdown';

import { DashboardComponent } from './Components/dashboard/dashboard.component';

export function playerFactory() {
  return player;
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CostComponent,
    PanelmenuComponent,
    DashboardComponent
  ],
  imports: [
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
    LottieModule.forRoot({ player: playerFactory }),
    ChartModule,
    PanelMenuModule,
    DialogModule,
    LottieModule.forRoot({ player: playerFactory })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
