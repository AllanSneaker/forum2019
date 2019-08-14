import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  appTitle: string = 'Forum';
  userClaims: any;
 
  constructor(private router: Router, private userService : UserService) { }
 
  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.userClaims = data;
 
    });
  }
 
  Logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }

}
