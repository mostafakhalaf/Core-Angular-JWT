import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnotherModuleComponent } from './anotherModule.component';
import { Lazy1Component } from './lazy1/lazy1.component';
import { Lazy2Component } from './lazy2/lazy2.component';
import { anotherRoutingModule } from './anotherRouting';

@NgModule({
  imports: [
    CommonModule,
    anotherRoutingModule
  ],
  declarations: [AnotherModuleComponent,
  Lazy1Component,
  Lazy2Component
  ]
})
export class AnotherModuleModule { }
