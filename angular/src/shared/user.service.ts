import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../ApiModels/User';
import { map, catchError } from 'rxjs/operators';
import { userApp } from '../ApiModels/UserApp';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
user:User;
  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'https://localhost:44315/api';

  formModel = this.fb.group({
    Gender:['', Validators.required],
    Birthday:['',Validators.required],
    Email: ['', [Validators.email,Validators.required]],
    Age:['',[Validators.required,Validators.pattern('/\-?\d*\.?\d{1,2}/')]],
    FullName: ['',Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required,Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{9,30}$/)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  register() {
      
 this.user = {
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password,
      Age:this.formModel.value.Age,
      Gender:this.formModel.value.gender,
      BirthDate:this.formModel.value.BirthDate,
      
    };
    debugger;
    
    return this.http.post(this.BaseURI + '/UserAccount/Register', this.user);
  }

  login(formData) {
    debugger;

    return this.http.post(this.BaseURI + '/UserAccount/Login', formData);
  }
createUser(){
  this.user = {
    Email: this.formModel.value.Email,
    FullName: this.formModel.value.FullName,
    Password: this.formModel.value.Passwords.Password,
    Age:this.formModel.value.Age,
    Gender:this.formModel.value.gender,
    BirthDate:this.formModel.value.BirthDate,
    
  };
  debugger;

return this.http.post(this.BaseURI+'/User/creatUser',this.user);

}
getUser(id){
  return this.http.get(this.BaseURI+'/User/getUser?id='+id);
  debugger;

  }
edituser(useredit){
  debugger;
  return this.http.post(this.BaseURI+'/User/updateUser',useredit);

}

  deleteUser(id:string){
    debugger;

    return this.http.delete(this.BaseURI+'/User/deleteUser?id='+id);
  }
  getUserProfile() {
    return this.http.get(this.BaseURI + '/User/getAllUser');/*.
        pipe(
           map((data: userApp[]) => {
             return data;

             debugger;
           }), catchError( error => {
             return throwError( 'Something went wrong!' );
           })
        );*/
  }
}
