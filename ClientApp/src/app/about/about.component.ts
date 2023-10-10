import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  public page: aboutpage | undefined
  public baseUrl: string = ""
  public http: HttpClient | undefined
  public route: ActivatedRoute | undefined
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string, route: ActivatedRoute) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.route = route;
  }

  ngOnInit(): void {

    this.http?.get<aboutpage>(this.baseUrl + 'api/aboutpage').subscribe(result => {
      // result.forEach(x=> x.createdat = (new Date(x.createdat)).toISOString())
      this.page = result;
    }, error => console.error(error));
  }

}
interface aboutpage {
  content: string
}
