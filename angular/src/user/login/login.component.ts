//import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  formModel = {
    Email: '',
    Password: ''
  }
  constructor(private service: UserService, private router: Router/* , private toastr: ToastrService */) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home');
  }
  onSubmit(form: NgForm) {
    console.log("yes");
    this.service.login(form.value).subscribe(
      (res: any) => {
        debugger;
        localStorage.setItem('token', res.token);
        console.log(localStorage.getItem('token'));
        this.router.navigateByUrl('/home');
      },
      err => {
        if (err.status == 400)
        console.log("Incorrect username or password.', 'Authentication failed.")
/*           this.toastr.error('Incorrect username or password.', 'Authentication failed.');
 */        else
          console.log(err);
      }
    );
  }
}
