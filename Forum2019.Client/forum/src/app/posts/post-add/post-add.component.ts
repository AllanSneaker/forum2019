import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PostService } from '../post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-add',
  templateUrl: './post-add.component.html',
  styleUrls: ['./post-add.component.css']
})
export class PostAddComponent implements OnInit {

  @Input() postDetails = { Title: '', Content: '', HashTag: '' }

  angForm: FormGroup;
  constructor(private fb: FormBuilder, private ps: PostService, private router: Router) {
    this.createForm();
  }

  createForm() {
    this.angForm = this.fb.group({
      Title: ['', Validators.required ],
      Content: ['', Validators.required ],
      HashTag: ['', Validators.required ]
    });
  }

  // createPost(Title, Content) {
  //   this.ps.createPost(Title, Content);
  // }

  addPost(dataPost) {
    this.ps.createPost(this.postDetails).subscribe((data: {}) => {
      this.router.navigate(['home'])
    })
  }

  ngOnInit() {
  }
}
