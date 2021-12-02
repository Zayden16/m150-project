import {Component, OnInit} from '@angular/core';
import {MenuItem} from 'primeng/api';
import {AuthService} from "../../Services/auth.service";

@Component({
  selector: 'app-panelmenu',
  templateUrl: './panelmenu.component.html',
  styleUrls: ['./panelmenu.component.scss']
})
export class PanelmenuComponent implements OnInit {

  items: MenuItem[] = [];

  constructor(private authService: AuthService) {
    this.items = [
      {
        label: 'Dashboard',
        icon: 'pi pi-fw pi-home',
        routerLink: "/dashboard"
      },
      {
        label: 'Cost',
        icon: 'pi pi-fw pi-dollar',
        routerLink: "/cost"
      },
      {
        label: 'Shopping List',
        icon: 'pi pi-fw pi-shopping-cart',
        routerLink: "/shopping-list"
      },
      {
        label: 'Group',
        icon: 'pi pi-fw pi-users',
        routerLink: '/group'
      },
      {
        label: 'Settings',
        icon: 'pi pi-fw pi-ellipsis-h',
        items: [
          {
            label: 'Users',
            icon: 'pi pi-fw pi-user',
            routerLink: "/settings"
          },
          {
            label: 'Logout',
            icon: 'pi pi-fw pi-sign-out',
            command: () => this.logout()
          },
        ]
      }
    ];
  }

  ngOnInit() {
  }

  logout() {
    this.authService.logout();
    location.reload();
  }
}
