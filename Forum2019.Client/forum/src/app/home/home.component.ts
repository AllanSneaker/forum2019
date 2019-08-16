import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    title = 'Angular 8 - Forum 2019';
    // lead = 'This is a simple blog example created with Angular 2 (Angular-cli)';
  // userClaims: any;
 
  constructor(private router: Router, private userService: UserService) { }
 
  ngOnInit() {
    // this.userService.getUserClaims().subscribe((data: any) => {
    //   this.userClaims = data;
 
    // });
  }
 
  // Logout() {
  //   localStorage.removeItem('userToken');
  //   this.router.navigate(['/login']);
  // }

}
