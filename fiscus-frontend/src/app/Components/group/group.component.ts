import {Component, OnInit} from '@angular/core';
import {User} from "../../Models/User";
import {Group} from "../../Models/Group";
import {AuthService} from "../../Services/auth.service";
import {GroupService} from "../../Services/group.service";
import {UserService} from "../../Services/user.service";

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.scss']
})
export class GroupComponent implements OnInit {
  currentUser: User = {} as User;
  group: Group = {} as Group;
  groupMembers: User[] = [];

  constructor(private authService: AuthService, private groupService: GroupService, private userService: UserService) {
  }

  ngOnInit(): void {
    this.currentUser = this.authService.currentUserValue;
    this.userService.GetOne(this.currentUser.userId).subscribe(userWithGroupId => {
      this.currentUser = userWithGroupId

      this.groupService.GetOne(this.currentUser.groupId).subscribe(group => this.group = group);
      this.userService.GetAllByGroup(this.currentUser.groupId).subscribe(members => this.groupMembers = members);
    });
  }

}
