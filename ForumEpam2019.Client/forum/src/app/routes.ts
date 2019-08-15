import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { UserComponent } from './user/user/user.component';
import { AuthGuard } from './auth/auth.guard';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ProfileComponent } from './profile/profile.component';
import { PostComponent } from './posts/post/post.component';
import { PostAddComponent } from './posts/post-add/post-add.component';
import { PostEditComponent } from './posts/post-edit/post-edit.component';
import { PostListComponent } from './posts/post-list/post-list.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'profile', component: ProfileComponent },
    {
        path: 'post/:Id', component: PostComponent
    },
    {
        path: 'home/post/create',
        component: PostAddComponent
    },
    {
        path: 'edit/:Id',
        component: PostEditComponent
    },
    {
        path: 'posts',
        component: PostListComponent
    },
    {
        path: 'signup', component: UserComponent,
        children: [{ path: '', component: SignUpComponent }]
    },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: SignInComponent }]
    },
    { path: 'adminPanel', component: AdminPanelComponent, canActivate: [AuthGuard], data: { roles: ['Admin'] } },
    { path: 'forbidden', component: ForbiddenComponent, canActivate: [AuthGuard] },
    { path: '', redirectTo: '/login', pathMatch: 'full' }

];