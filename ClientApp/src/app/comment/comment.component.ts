import {Component, Inject, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit{
  @Input() postid!: string;
  public comments: Comment[] = []
  public baseUrl: string = ""
  public http: HttpClient | undefined
  public route: ActivatedRoute | undefined
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string, route: ActivatedRoute) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.route = route;
  }

  ngOnInit(): void {

    this.http?.get<Comment[]>(this.baseUrl + 'api/comment?postid=' + this.postid).subscribe(result => {
      // result.forEach(x=> x.createdat = (new Date(x.createdat)).toISOString())
       this.comments = result.map(x=> {  { x.createdat= new Date(x.createdat).toString() ;
        return x } })

      // this.comments = result;
    }, error => console.error(error));
  }

}
interface Comment {
  name : string,
  content:string,
  createdat:string,
  PostId:string
}
