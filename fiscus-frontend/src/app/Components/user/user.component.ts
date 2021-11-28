import { Component, OnInit } from '@angular/core';
import {UserService} from "../../Services/user.service";
import {User} from "../../Models/User";
import {AuthService} from "../../Services/auth.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  User: User = {} as User;
  userForm: FormGroup;

  constructor(protected userService: UserService, private formBuilder: FormBuilder, private authService: AuthService) {
    this.userForm = this.formBuilder.group({
      username: [null, Validators.required],
      email: [null, Validators.required],
      password: [null, [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
    this.User = this.authService.currentUserValue;
  }

  updateUser() {
    let newUser = this.userForm.value;
    this.userService.Update(this.User.userId, newUser);
  }
}
