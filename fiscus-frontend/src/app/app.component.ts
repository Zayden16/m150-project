import {Component, OnInit} from '@angular/core';
import {PrimeNGConfig} from "primeng/api";
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'fiscus-frontend';

  constructor(private primeNgConfig: PrimeNGConfig, public router: Router) {}

  ngOnInit(): void {
    this.primeNgConfig.ripple = true;
  }
}
