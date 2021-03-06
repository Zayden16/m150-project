import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CreateGroupComponent} from './Components/create-group/create-group.component';
import {DashboardComponent} from './Components/dashboard/dashboard.component';
import {LoginComponent} from "./Components/login/login.component";
import {UserComponent} from "./Components/user/user.component";
import {SettingsComponent} from "./Components/settings/settings.component";
import {AuthGuard} from './guards/auth.guard';
import {CostComponent} from "./Components/cost/cost.component";
import {GroupComponent} from "./Components/group/group.component";
import {ShoppingListComponent} from "./Components/shopping-list/shopping-list.component";

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'login'},
  {path: 'login', component: LoginComponent},
  {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
  {path: 'users', component: UserComponent, canActivate: [AuthGuard]},
  {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
  {path: 'cost', component: CostComponent, canActivate: [AuthGuard]},
  {path: 'settings', component: SettingsComponent, canActivate: [AuthGuard]},
  {path: 'group', component: GroupComponent, canActivate: [AuthGuard]},
  {path: 'group/create', component: CreateGroupComponent, canActivate: [AuthGuard]},
  {path: 'shopping-list', component: ShoppingListComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
