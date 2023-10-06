import {Component, Inject, Input} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-post-content',
  templateUrl: './post-content.component.html',
  styleUrls: ['./post-content.component.css']
})
export class PostContentComponent {
  public content: ContentPost[] = []

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl :string) {
    http.get<ContentPost[]>(baseUrl + 'api/aboutcontent').subscribe(result => {
      this.content = result;
    }, error => console.error(error));
  }
}
interface ContentPost {
  id: string,
  title : string,
  createdat :string,
  content:string,
  imageurl:string
}
