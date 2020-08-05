import { UserService } from './../../shared/user.service';
import { Component, OnInit } from '@angular/core';
//import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService/* , private toastr: ToastrService */) { }

  ngOnInit() {
    this.service.formModel.reset();
  }
  onDateSelect(event){}
  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res==true) {
          debugger;
          this.service.formModel.reset();
          console.log("New user created!', 'Registration successful.")
/*           this.toastr.success('New user created!', 'Registration successful.');
 */        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                console.log("Username is already taken','Registration failed.")
                //this.toastr.error('Username is already taken','Registration failed.');
                break;

              default:
                console.log("element.description,'Registration failed.")
              //this.toastr.error(element.description,'Registration failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
