import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-detail-blog-content',
  templateUrl: './detail-blog-content.component.html',
  styleUrls: ['./detail-blog-content.component.css']
})
export class DetailBlogContentComponent implements  OnInit {
  public content: ContentPost | undefined
  public id: string = "";
  public baseUrl: string = ""
  public http: HttpClient | undefined
  public route: ActivatedRoute | undefined

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string, route: ActivatedRoute) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.route = route;
  }

  ngOnInit() {
    this.route?.queryParams
      .subscribe(params => {
          console.log(params); // { orderby: "price" }
          this.id = params.id;
          console.log(this.id); // price
        }
      );
    this.http?.get<ContentPost>(this.baseUrl + 'api/blogdetailcontent?id=' + this.id).subscribe(result => {
      this.content = result;
    }, error => console.error(error));
  }
}
interface ContentPost {
  title : string,
  createdat :string,
  content:string,
  imageurl:string
}
