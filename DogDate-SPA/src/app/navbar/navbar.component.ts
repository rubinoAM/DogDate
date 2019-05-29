import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model)
      .subscribe(next => {
        this.alertify.success('Logged in successfully.');
      }, err => {
        this.alertify.error(err);
      });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // returns a boolean
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Logged out succesfully.');
  }

}
