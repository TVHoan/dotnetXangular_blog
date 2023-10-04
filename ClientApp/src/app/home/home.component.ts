import { Component } from '@angular/core';
import {faAngleLeft} from "@fortawesome/free-solid-svg-icons";
import {faAngleRight} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  faAngleLeft = faAngleLeft;
  faAngleRight = faAngleRight;
}
