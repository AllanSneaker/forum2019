import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AdminService {

  readonly baseUrl = 'http://localhost:8080/api/users/';
  constructor(private http : HttpClient) { }

  getPostList() {
    return this
           .http
           .get(`${this.baseUrl}`);
  }
}
