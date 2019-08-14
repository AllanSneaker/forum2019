import { Injectable } from '@angular/core';
import { Post } from './post.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import {  Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/toPromise';


@Injectable({
  providedIn: 'root'
})
export class PostService {

  readonly baseUrl = 'http://localhost:8080/api/posts/';
  selectedPost : Post;
  postList : Post[];
  constructor(private http : HttpClient) { }
 
  // postEmployee(post : Post){
  //   var body = JSON.stringify(post);
  //   var headerOptions = new Headers({'Content-Type':'application/json'});
  //   var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
  //   return this.http.post('http://localhost:8080/api/posts/',body,requestOptions).map(x => x.json());
  // }
 
  createUser(
    post: Post
  ): Observable<Post> {
    return this.http.post<Post>(this.baseUrl, post);
  }

  // putEmployee(id, emp) {
  //   var body = JSON.stringify(emp);
  //   var headerOptions = new Headers({ 'Content-Type': 'application/json' });
  //   var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
  //   return this.http.put('http://localhost:8080/api/posts/' + id,
  //     body,
  //     requestOptions).map(res => res.json());
  // }
 
  putPost(post: Post): Observable<Post> {
    return this.http.put<Post>(this.baseUrl + post.Id, post);
  }

  // getEmployeeList(){
  //   this.http.get('http://localhost:8080/api/posts/')
  //   .map((data : Response) =>{
  //     return data.json() as Post[];
  //   }).toPromise().then(x => {
  //     this.postList = x;
  //   })
  // }
 
  // getPostList(): Observable<Post> {
  //   const url = `${this.baseUrl}`;
  //   return this.http.get<Post>(url);
  // }

  getPostList() {
    return this
           .http
           .get(`${this.baseUrl}`);
  }

  // deleteEmployee(id: number) {
  //   return this.http.delete('http://localhost:8080/api/posts/' + id).map(res => res.json());
  // }

  deletePost(id: number): Observable<string> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<string>(url);
  }
}
