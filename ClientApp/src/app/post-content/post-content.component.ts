import {Component, Inject, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-post-content',
  templateUrl: './post-content.component.html',
  styleUrls: ['./post-content.component.css']
})
export class PostContentComponent implements OnInit,OnChanges{
  @Input() getmore : boolean
  public content: ContentPost[] = []
  public baseUrl: string = ""
  public http: HttpClient | undefined

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl :string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.getmore = false

  }
  ngOnChanges(changes: SimpleChanges): void {
console.log(changes)
    if (changes.getmore.currentValue===true){
      this.GetMore()
      this.getmore = false
    }

  }
  GetMore(){
    this.http?.get<ContentPost[]>(this?.baseUrl + 'api/aboutcontent?take='+this.content.length+2).subscribe(result => {
      this.content = result;
    }, error => console.error(error));
  }
  ngOnInit(): void {
    this.http?.get<ContentPost[]>(this?.baseUrl + 'api/aboutcontent').subscribe(result => {
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
