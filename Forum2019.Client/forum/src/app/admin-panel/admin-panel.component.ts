import { Component, OnInit } from '@angular/core';
import { User } from '../user/user.model';
import { AdminService } from './admin.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  users: User[];
  constructor(private adminService : AdminService) { }


  ngOnInit() {
    this.adminService
      .getPostList()
      .subscribe((data: User[]) => {
        this.users = data;
    });
  }

}
