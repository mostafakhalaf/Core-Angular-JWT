import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-EditUser',
  templateUrl: './EditUser.component.html',
  styleUrls: ['./EditUser.component.css']
})
export class EditUserComponent implements OnInit {
  constructor(  private router: Router,
    private route:ActivatedRoute,public service: UserService,private fb: FormBuilder) { }

  formModel = this.fb.group({
    Gender:['', Validators.required],
    Birthday:['',Validators.required],
    Email: ['', [Validators.email,Validators.required]],
    Age:['',[Validators.required,Validators.pattern('/\-?\d*\.?\d{1,2}/')]],
    FullName: ['',Validators.required],
 
  });

id:any;
userDetail:any=[];


  ngOnInit() {
    this.id=this.route.snapshot.params['id'];
    this.service.getUser(this.id).subscribe(
      (res:any)=>{
        this.userDetail=res;
        debugger;
      }
    )

  }
  onSubmit(FullName,Age,Email,Birthday,Gender,Password){
    debugger;

let user = {
      Email:Email ,
      FullName:FullName,
      Password:Password,
      Age:Age,
      Gender:Gender,
      BirthDate:Birthday
      
    };

    this.service.edituser(user).subscribe(
      (res:any)=>{
if(res==true){
  this.router.navigateByUrl('home');
}
});

  }
}