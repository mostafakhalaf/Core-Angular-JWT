
import { UserService } from './../shared/user.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../ApiModels/User';

import { userApp } from '../ApiModels/UserApp';
import { MatDialog } from '@angular/material';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  userDetails=[];
 
  stringifiedData: any;
  parsedJson: any;
  userDetails1:userApp[]=new Array<userApp>();
  selectedColor:any={};
  cc:any='red';
  filter:any={};
  constructor(public dialog: MatDialog,private router: Router, private service: UserService) { }
  
  openDialog(id): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: "Do you confirm the deletion of this data?"
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.service.deleteUser(id).subscribe(
          (res)=>{
            if(res==true){
              this.router.navigateByUrl('home');

            console.log("user deleted");
            debugger;
          }
          }

        )
        console.log('Yes clicked');
        // DO SOMETHING
      }
    });
  }
  
  cc1(){
    return this.cc;
    debugger;
  }
color:any;
  colors = [
    {
      name: 'yellow',
      value: '#ffff00'
    },
    {
      name: 'red',
      value: '#ff3300'
    },
    {
      name: 'blue',
      value: '#0000ff'
    }
  ];

  onChange(){
   this.cc= this.selectedColor;
   debugger;
  }
  changColor(){
    return this.selectedColor ;

  }
  ngOnInit() {
    this.service.getUserProfile().subscribe(
      (data:any)=>{
        debugger;
        //this.userDetails=[data];
        console.log("userdetailesjson==   "+[data] );

        this.userDetails=data;
      
      this.userDetails1=this.userDetails;
        
    
console.log("userdetailes000"+ this.userDetails);
debugger;

      },
      err => {
        console.log(err);
      },
    );
  }
data(data){
 this.userDetails1=data;
return data;

}
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
