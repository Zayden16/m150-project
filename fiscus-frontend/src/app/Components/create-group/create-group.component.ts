import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.scss']
})
export class CreateGroupComponent implements OnInit {
  username: string = '';
  users: string[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  addUser() {
    console.log('add user ' + this.username);
    this.users.push(this.username);
    this.username = '';
  }

  createGroup() {
    console.log('create group....');
  }

}
