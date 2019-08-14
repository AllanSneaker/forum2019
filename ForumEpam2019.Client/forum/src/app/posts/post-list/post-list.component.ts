import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../post.model';
import { filter, tap } from 'rxjs/operators';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  isLoading = false;

  posts: Post[];
  constructor(private postService : PostService) { }


  ngOnInit() {
    this.postService
      .getPostList()
      .subscribe((data: Post[]) => {
        this.posts = data;
    });
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

}
