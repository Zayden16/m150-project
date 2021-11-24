import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { CreateGroupComponent } from './Components/create-group/create-group.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import {LoginComponent} from "./Components/login/login.component";

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'group/create', component: CreateGroupComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
