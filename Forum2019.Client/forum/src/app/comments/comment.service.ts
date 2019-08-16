import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/toPromise';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  readonly baseUrl = 'http://localhost:8080/api/posts/{id}/comments';
  
  //postList : Post[];
  constructor(private http : HttpClient) { }

  getComments(id : number) {
    return this
           .http
           .get(('http://localhost:8080/api/posts/' + id + '/comments'));
  }
}
