import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  opened = false;
  loggedIn = false;

  constructor() { }

  toggleSidenav() {
    this.opened = true;
  }

  ngOnInit() {
  }

}
