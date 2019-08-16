import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { CommentService } from 'src/app/comments/comment.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Comment } from 'src/app/comments/comment.model';
import { Post } from '../post.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  
  comments: Array<Comment> = [];
  post: Post[];
  
  postData: any = {};
  Id = this.route.snapshot.params['Id'];

  constructor(private postService: PostService, 
    private commentService: CommentService, private route: ActivatedRoute) { }

  onIdInput(value: number) {
    this.Id = value;
  }

  onLoadClick() {

    this.postService.getPost(this.Id).subscribe((data: {}) => {
      this.postData = data;
    })

    // this.postService.getPost(this.Id).subscribe(r => {
    //   this.post = r.data;
    // });
  }


  ngOnInit() {
    this.onLoadClick();
    // this.route.params.forEach((params: Params) => {
    //   let Id = +params['Id'];

      // this.postService.getPost(Id).subscribe(
      //   r => this.posts = r,
      //   error => console.error('Error: ' + error)
      // );
// this.postService.getPost(this.Id).subscribe((data: Post) => {
//   this.posts = data,
//   error => console.error('Error: ' + error)
// });



    //   this.commentService.getComments(Id).subscribe(
    //     r => this.comments = r,
    //     error => console.error('Error: ' + error)
    // );

    // this.commentService.getComments(this.Id).subscribe((data: Comment[]) => {
    //   this.comments = data,
    //   error => console.error('Error: ' + error)
    // });

      
   // });
  }
}