import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { CreateGroupComponent } from './Components/create-group/create-group.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import {LoginComponent} from "./Components/login/login.component";
import {UserComponent} from "./Components/user/user.component";
import {SettingsComponent} from "./Components/settings/settings.component";
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'login' },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'users', component: UserComponent, canActivate: [AuthGuard] },
  { path: 'dashboard', component: DashboardComponent},
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] },
  { path: 'group/create', component: CreateGroupComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
