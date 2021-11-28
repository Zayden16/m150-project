import {Component, OnInit} from '@angular/core';
import {AnimationItem} from 'lottie-web';
import {AnimationOptions} from 'ngx-lottie';
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../Services/auth.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {first} from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  options: AnimationOptions = {
    path: '/assets/money-lottie.json',
  };

  userForm: FormGroup;
  username: string = "";
  password: string = "";

  constructor(private router: Router, private authService: AuthService, private formBuilder: FormBuilder, private route: ActivatedRoute) {
    this.userForm = this.formBuilder.group({
      username: [null, Validators.required],
      password: [null, [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {

  }

  animationCreated(animationItem: AnimationItem): void {
    console.log(animationItem);
  }

  login() {
    this.authService.login(this.username, this.password)
      .pipe(first()).subscribe({
      next: () => {
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || 'dashboard';
        this.router.navigate([returnUrl]);
      }
    })
  }
}
