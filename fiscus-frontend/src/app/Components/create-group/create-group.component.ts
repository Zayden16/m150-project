import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/Models/Group';
import { User } from 'src/app/Models/User';
import { GroupService } from 'src/app/Services/group.service';
import { UserService } from 'src/app/Services/user.service';

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

  constructor(private groupService: GroupService, private userService: UserService) { }

  ngOnInit(): void {
  }

  addUser() {
    //Optional: Falls user nicht gefunden --> Toastr Message "username not found"
    this.userService.GetOneByUsername(this.username).subscribe(user => this.users.push(user));
    this.username = '';
  }

  createGroup() {
    if (this.group.Name.length < 1) {
      //Optional: Falls kein Groupname --> Toastr Message "Could not create group. Please insert groupname"
      console.log('No group created!')
    } else {
      this.groupService.Create(this.group).subscribe(group => this.group = group);
      for (const user of this.users) {
        user.groupId = this.group.GroupId.toString();
        this.userService.Update(user);
      }
    }
  }

}