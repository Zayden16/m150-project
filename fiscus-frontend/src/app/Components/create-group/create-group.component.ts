import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/Models/Group';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.scss']
})
export class CreateGroupComponent implements OnInit {
  group: Group = {
    GroupId: 0,
    Name: '',
    Description: '',
  }
  
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
    if (this.group.Name.length < 1) {
      console.log('No group created!')
    } else {
      console.log('create group....' + this.group.Name + this.group.Description);
      //const this.group.GroupId = this.groupService.createGroup(this.groupName, this.groupDescription);
      for (const username in this.users) {
        //this.userService.updateUserGroup(this.group.GroupId, username)
      }
      this.group.Name = '';
      this.group.Description = '';
    }
  }

}