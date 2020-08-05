import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnotherModuleComponent } from './anotherModule.component';
import { Lazy2Component } from './lazy2/lazy2.component';
import { Lazy1Component } from './lazy1/lazy1.component';


const routes: Routes = [
  {path:'', component: AnotherModuleComponent},
    {path:"lazy1",component:Lazy2Component},
    {path:'lazy2', component: Lazy1Component},
 
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class anotherRoutingModule { }
