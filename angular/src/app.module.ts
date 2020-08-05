import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';

import { 
   
   MatButtonModule, 
   MatCardModule, 
   MatMenuModule, 
   MatToolbarModule, 
   MatIconModule, 
   MatInputModule, 
   MatDatepickerModule, 
   MatNativeDateModule, 
   MatProgressSpinnerModule,
   MatTableModule, 
   MatExpansionModule, 
   MatSelectModule,
   MatSnackBarModule, 
   MatTooltipModule, 
   MatChipsModule, 
   MatListModule, 
   MatSidenavModule, 
   MatTabsModule, 
   MatProgressBarModule,
   MatCheckboxModule,
   MatSliderModule,
   MatRadioModule,
   MatDialogModule,
   MatGridListModule,
   MatPaginatorModule
} from '@angular/material';
import { SlickCarouselModule } from 'ngx-slick-carousel';  
import { NgImageSliderModule } from 'ng-image-slider';
import { OwlModule } from 'ngx-owl-carousel';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { CreateUserComponent } from './home/createUser/createUser.component';
import { EditUserComponent } from './home/EditUser/EditUser.component';


@NgModule({
   declarations: [
  
      AppComponent,
      UserComponent,
      RegistrationComponent,
      LoginComponent,
      HomeComponent,
     
      CreateUserComponent,
      EditUserComponent,
   
      ConfirmationDialogComponent
   ],
   imports: [
      OwlModule,
      NgImageSliderModule,
      BrowserModule,
      AppRoutingModule,
      ReactiveFormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      SlickCarouselModule,
      MatButtonModule,
      MatCardModule,
      MatMenuModule,
      MatToolbarModule,
      MatIconModule,
      MatInputModule,
      MatDatepickerModule,
      MatNativeDateModule,
      MatProgressSpinnerModule,
      MatTableModule,
      MatExpansionModule,
      MatSelectModule,
      MatSnackBarModule,
      MatTooltipModule,
      MatChipsModule,
      MatListModule,
      MatSidenavModule,
      MatTabsModule,
      MatProgressBarModule,
      MatCheckboxModule,
      MatSliderModule,
      MatRadioModule,
      MatDialogModule,
      MatGridListModule,
      MatPaginatorModule,
      BrowserAnimationsModule,
    MatDialogModule,
    MatButtonModule,
      /*ToastrModule.forRoot(\\nprogressBar
   ]
}) ,*/
//NgbModule,
    FormsModule
    
  ],
  entryComponents: [
   ConfirmationDialogComponent
 ],
  providers: [UserService,{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
