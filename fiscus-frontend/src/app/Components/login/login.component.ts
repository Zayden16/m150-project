import {Component, OnInit} from '@angular/core';
import {AnimationItem} from 'lottie-web';
import {AnimationOptions} from 'ngx-lottie';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  options: AnimationOptions = {
    path: '/assets/money-lottie.json',
  };

  constructor() {
  }

  ngOnInit(): void {
  }

  animationCreated(animationItem: AnimationItem): void {
    console.log(animationItem);
  }
}
