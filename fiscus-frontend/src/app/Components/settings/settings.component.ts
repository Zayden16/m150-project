import {Component, OnInit} from '@angular/core';
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
  currentUser: User = {} as User;
  users: User[] = [];
  userForm: FormGroup;

  constructor(private authService: AuthService, private userService: UserService, private formBuilder: FormBuilder) {
    this.userForm = this.formBuilder.group({
      username: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(6)]],
      groupId: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.currentUser = this.authService.currentUserValue;
    this.userService.GetAll().toPromise().then(data => this.users = data);

  }

  async createUser() {
    if (this.userForm.invalid) {
      return;
    }

    let newUser = this.userForm.value;
    await this.userService.Create(newUser).toPromise();
    this.userForm.reset();
    location.reload();
  }

}
