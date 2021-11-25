import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.scss']
})
export class CreateGroupComponent implements OnInit {
  groupName = '';
  groupDescription = '';
  
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
    if (this.groupName.length < 1) {
      console.log('No group created!')
    } else {
      console.log('create group....' + this.groupName + this.groupDescription);
      //const groupId = this.groupService.createGroup(this.groupName, this.groupDescription);
      for (const username in this.users) {
        //this.userService.updateUserGroup(this.groupId, username)
      }
      this.groupName = '';
      this.groupDescription = '';
    }
  }

}
