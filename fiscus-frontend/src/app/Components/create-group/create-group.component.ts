import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/Models/Group';
import { User } from 'src/app/Models/User';
import { GroupService } from 'src/app/Services/group.service';
import { UserService } from 'src/app/Services/user.service';
import {MessageService} from 'primeng/api';

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
  users: User[] = [];

  constructor(private groupService: GroupService, private userService: UserService, private messageService: MessageService) { }

  ngOnInit(): void {
  }

  addUser() {
    this.userService.GetOneByUsername(this.username).subscribe(user => {
      if (user != null) {
        this.users.push(user);
      } else {
        this.messageService.add({severity:'error', summary:'Username not found', detail:'Please fill in a user that already exists'});
      }    
    });
   
    this.username = '';
  }

  createGroup() {
    if (this.group.Name.length < 1) {
      this.messageService.add({severity:'error', summary:'Could not create group', detail:'Make sure that all fields marked with * are filled in'});
    } else {
      this.groupService.Create(this.group).subscribe(group => {
        console.log('This is the group ' + JSON.stringify(group))        
        for (const user of this.users) {
          user.groupId = this.group.GroupId.toString();
          this.userService.Update(user);
        }
        this.group = {
          GroupId: 0,
          Name: '',
          Description: '',
        };
        this.messageService.add({severity:'success', summary:'Create Group Successful', detail:`Group has been created.`});
      });
    }
  }

}