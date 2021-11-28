import { Component, OnInit } from '@angular/core';
import {UserService} from "../../Services/user.service";
import {User} from "../../Models/User";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(protected _userService: UserService) { }

  users: User[] = [];

  ngOnInit(): void {
    this._userService.GetAll().subscribe(users => this.users = users);
  }

}
