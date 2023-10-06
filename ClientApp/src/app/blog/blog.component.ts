import { Component } from '@angular/core';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent {
  public getmore : boolean = false


  constructor() {
  }
  Getmore(){
    this.getmore = true;
  }
}
