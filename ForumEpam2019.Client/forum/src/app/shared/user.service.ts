import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  HttpResponse } from "@angular/common/http";
import {Observable} from 'rxjs';
import { filter } from 'rxjs/operators';
// import 'rxjs/add/operator/map';
import { User } from './user.model';
 
@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:8080';
  constructor(private http: HttpClient) { }
 
  registerUser(user : User){
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    return this.http.post(this.rootUrl + '/api/User/Register', body);
  }
 
}