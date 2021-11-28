import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../Services/auth.service";
import {UserService} from "../../Services/user.service";
import {User} from "../../Models/User";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  CurrentUser: User = {} as User;
  userForm: FormGroup;

  constructor(private authService: AuthService, private userService: UserService, private formBuilder: FormBuilder) {
    this.userForm = this.formBuilder.group({
      username: [null, Validators.required],
      email: [null, Validators.required],
      password: [null, [Validators.required, Validators.minLength(6)]],
      groupId: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.CurrentUser = this.authService.currentUserValue;
  }

  logout(){
    this.authService.logout();
  }

  createUser() {


    if (this.userForm.invalid) {
      return;
    }


    console.log(this.userForm.value);
    let newUser = this.userForm.value;
    this.userService.Create(this.CurrentUser.userId, newUser);
  }

}
