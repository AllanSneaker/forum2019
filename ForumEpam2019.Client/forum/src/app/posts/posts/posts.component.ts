import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css'],
  providers :[PostService]
})
export class PostsComponent implements OnInit {

  constructor(private postService : PostService) { }

  ngOnInit() {
  }

}
