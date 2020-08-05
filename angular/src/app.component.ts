import { Component } from '@angular/core';
import { NgImageSliderComponent } from 'ng-image-slider';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  mySlideImages = ['../assets/images/1.jpg','../assets/images/2.jpg','../assets/images/3.png'];
myCarouselImages =['../assets/images/image1.jpg','../assets/images/image2.jpeg','../assets/images/image3.jpg'];
 
mySlideOptions={items: 1, dots: true, nav: true};
myCarouselOptions={items: 3, dots: true, nav: true};
  title = 'Angular7';
}
