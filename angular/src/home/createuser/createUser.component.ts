import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-createUser',
  templateUrl: './createUser.component.html',
  styleUrls: ['./createUser.component.css']
})
export class CreateUserComponent implements OnInit {
  constructor(public service: UserService) { }
  ngOnInit() {
  }
  onSubmit(){
    debugger;

    this.service.createUser().subscribe(
      (res:any)=>{
if(res==true){

}

      }
    );

    



  }

}
