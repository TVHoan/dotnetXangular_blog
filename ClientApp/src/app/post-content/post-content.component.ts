import {Component, EventEmitter, Inject, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import { Subject } from 'rxjs';

@Component({
  selector: 'app-post-content',
  templateUrl: './post-content.component.html',
  styleUrls: ['./post-content.component.css']
})
export class PostContentComponent implements OnInit,OnChanges{
  @Input() eventEmitter: EventEmitter<void> | undefined
  @Input('clickSubject')
    clickSubject!: Subject<any>;
  public content: ContentPost[] = []
  public baseUrl: string = ""
  public http: HttpClient | undefined

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl :string) {
    this.http = http;
    this.baseUrl = baseUrl;

  }
  ngOnChanges(changes: SimpleChanges): void {
/*console.log(changes)
    if (changes.getmore.currentValue===true){
      this.GetMore()
    }*/

  }
  GetMore(): void {
    let lengthpost = this.content.length + 2;
    this.http?.get<ContentPost[]>(this?.baseUrl + 'api/aboutcontent?take=' + lengthpost).subscribe(result => {
      this.content = result;
      console.log("get")
    }, error => console.error(error));
  }
  ngOnInit(): void {
    this.http?.get<ContentPost[]>(this?.baseUrl + 'api/aboutcontent').subscribe(result => {
      this.content = result;
    }, error => console.error(error));
/*    this.eventEmitter?.subscribe(() => this.GetMore())
*/    this.clickSubject.subscribe(e => this.GetMore());

  }


}
interface ContentPost {
  id: string,
  title : string,
  createdat :string,
  content:string,
  imageurl:string
}
