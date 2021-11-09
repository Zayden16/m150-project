import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-panelmenu',
  templateUrl: './panelmenu.component.html',
  styleUrls: ['./panelmenu.component.scss']
})
export class PanelmenuComponent implements OnInit {

  items: MenuItem[];

  constructor() {
    this.items = [
      {
        label: 'Dashboard',
        icon: 'pi pi-fw pi-home',
      },
      {
        label: 'Groups',
        icon: 'pi pi-fw pi-users',
        items: [
          //Temporäre Beispiel-Daten... Hier müssen alle Gruppen des Users geladen werden.
          {
            label: 'Group 1',
            icon: 'pi pi-fw pi-users'
          },
          {
            label: 'Group 2',
            icon: 'pi pi-fw pi-users'
          },
          {
            label: 'New Group',
            icon: 'pi pi-fw pi-plus'
          }
        ]
      },
      {
        label: 'Settings',
        icon: 'pi pi-fw pi-ellipsis-h',
      }
    ];
  }

  ngOnInit() {
  }

}
