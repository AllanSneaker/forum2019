import { Injectable } from '@angular/core';
import { Post } from './post.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import {  Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/toPromise';
import { retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PostService {

  readonly baseUrl = 'http://localhost:8080/api/posts/';
  selectedPost : Post;
  postList : Post[];
  constructor(private http : HttpClient) { }
 
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  getPosts(): Observable<Post> {
    return this.http.get<Post>(this.baseUrl)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }


  getPost(Id): Observable<Post> {
    return this.http.get<Post>(this.baseUrl + Id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  createPost(post): Observable<Post> {
    return this.http.post<Post>(this.baseUrl, JSON.stringify(post), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  updatePost(Id, post): Observable<Post> {
    return this.http.put<Post>(this.baseUrl + Id, JSON.stringify(post), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  deletePost(Id){
    return this.http.delete<Post>(this.baseUrl +  Id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }


  handleError(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
 }  
 
}
