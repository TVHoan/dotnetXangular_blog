import { Component, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent {
  parentEmitter = new EventEmitter<void>(); 
  clickSubject: Subject<any> = new Subject();

  constructor() {
  }
  Getmore(){
    this.parentEmitter.emit()
    this.clickSubject.next(1);
  }
}
