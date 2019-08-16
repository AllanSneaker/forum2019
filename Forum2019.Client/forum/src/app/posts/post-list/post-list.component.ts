import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../post.model';
import { filter, tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  isLoading = false;

  posts: any = [];
  constructor(private postService : PostService, private router: Router) { }


  ngOnInit() {
    // this.postService
    //   .getPostList()
    //   .subscribe((data: Post[]) => {
    //     this.posts = data;
    // });
    this.loadPosts();
  }

  loadPosts() {
    return this.postService.getPosts().subscribe((data: {}) => {
      this.posts = data;
    })
  }

  // Delete employee
  deletePost(id) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postService.deletePost(id).subscribe(data => {
        //this.loadPosts()
        this.router.navigate(['/home']);
      })
    }
  }  


  // onLoadClick() {
  //   this.isLoading = true;
  //   this.postService.getPostList()
  //     .pipe(
  //       filter(posts => !!posts),
  //       tap(console.log)
  //     ).subscribe((p: Post) => {
  //     this.isLoading = false;
  //     this.posts.push(...p.data);
  //   },
  //     e => {
  //       console.log(e);
  //     },
  //   );
  // }

  // deleteProduct(id) {
  //   this.postService.deletePost(id).subscribe(res => {
  //     this.posts.splice(id, 1);
  //     this.router.navigate(['/home']);
  //   });
    
//}

}
