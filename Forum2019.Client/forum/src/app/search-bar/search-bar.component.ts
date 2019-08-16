import { Component, OnInit, Inject } from '@angular/core';
import { Post } from '../posts/post.model';
import { FormControl } from '@angular/forms';
import { PostService } from '../posts/post.service';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {

  constructor(){}
  ngOnInit(){}
  // defaultPosts: Array<Post>;
  // postFormControl: FormControl;
  // filteredPosts: any;

  // constructor(private postService: PostService) {
  //   this.defaultPosts = [];
  //   this.postFormControl = new FormControl();
  // }

  // ngOnInit() {
  //   this.postService.getPosts().subscribe((posts: any) => {
  //     this.defaultPosts = posts.filter(post => post.default);

  //     this.postFormControl.valueChanges.pipe(
  //       startWith(null as string),
  //       map(value => this.filterPosts(value)))
  //       .subscribe(heroesFiltered => {
  //         this.filteredPosts = heroesFiltered;
  //       });
  //   });
  // }

  // filterPosts(val: string): Post[] {
  //   return val ? this.defaultPosts.filter(post => post.HashTag.toLowerCase().indexOf(val.toLowerCase()) === 0 && post.default)
  //     : this.defaultPosts;
  // }

}
