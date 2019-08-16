import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../post.service';
import { Observable } from 'rxjs';
import { Post } from '../post.model';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.css']
})
export class PostEditComponent implements OnInit {

  Id = this.actRoute.snapshot.params['Id'];
  postData: any = {};


  angForm: FormGroup;
  post: Observable<Post>[];//any = {};

  dataSaved = false;    
  massage:string;    
  FromPost: any;    
  //Id:number;    
 // allPosts:Observable<Post[]>;    

  constructor(private route: ActivatedRoute, private router: Router, 
    private ps: PostService, private fb: FormBuilder, public actRoute: ActivatedRoute) {
      this.createForm();
 }

  createForm() {
    this.angForm = this.fb.group({
      Title: ['', Validators.required ],
      Content: ['', Validators.required ],
      HashTag: ['', Validators.required ]
    });
  }

  // ngOnInit(){}

  ngOnInit() {
    // this.route.params.subscribe(params => {
    //     this.ps.editPost(params['Id']).subscribe(res => {
    //       this.post = res;
    //   });
    // });
    this.ps.getPost(this.Id).subscribe((data: {}) => {
      this.postData = data;
    })
  }

  updatePost() {
    if(window.confirm('Are you sure, you want to update?')){
      this.ps.updatePost(this.Id, this.postData).subscribe(data => {
        this.router.navigate(['/home'])
      })
    }
  }

//   postEdit(Id: number) {  
//     debugger;  
//     this.ps.getPostById(Id).subscribe(Response => {  
//         this.massage = null;  
//         this.dataSaved = false;  
//         debugger;  
//         this.Id = Response.Id;  
//         this.FromPost.controls['Title'].setValue(Response.Title);  
//         this.FromPost.controls['Content'].setValue(Response.Content);  
//         this.router.navigate(['/home']);
//     });  
// }  

  // updatePost(Id, Title, Content) {
  //   this.route.params.subscribe(params => {
  //     this.ps.updatePost(Title, Content, params.Id);
  //     this.router.navigate(['/home']);
  //   });
  // }


}
