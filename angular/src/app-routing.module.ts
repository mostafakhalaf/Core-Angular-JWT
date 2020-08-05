import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { CreateUserComponent } from './home/createUser/createUser.component';
import { EditUserComponent } from './home/EditUser/EditUser.component';


const routes: Routes = [
  {path: 'another',loadChildren: ()=>import('src/anotherModule/anotherModule.module').then(m=>m.AnotherModuleModule)},
  {path:'creatuser',component:CreateUserComponent},
  {path:'edituser/:id',component:EditUserComponent},

  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'**',component:LoginComponent},


  {path:'',redirectTo:'/user/login',pathMatch:'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
