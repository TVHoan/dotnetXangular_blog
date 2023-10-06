import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-banner-slide',
  templateUrl: './banner-slide.component.html',
  styleUrls: ['./banner-slide.component.css']
})
export class BannerSlideComponent implements OnInit{
    public slide: Side[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Side[]>(baseUrl + 'api/bannerslide').subscribe(result => {
      this.slide = result;
    }, error => console.error(error));
  }
  ngOnInit(): void {
    // while (true){
    //   setTimeout(()=>this.Next(),1000)
    // }
    setInterval(()=>this.Next(),2000)
  }
  Next(){
    let activeitem = this.slide.filter(x=>x.active===true)[0]
    let index = this.slide.indexOf(activeitem)
    let nextitem = index+1;

    if (index+1>this.slide.length-1){
      nextitem = 0;
    }
    this.slide[index].active = false
    this.slide[nextitem].active = true
  }
  Prev(){
    let activeitem = this.slide.filter(x=>x.active===true)[0]
    let index = this.slide.indexOf(activeitem)
    let previtem = index-1;

    if (previtem<0){
      previtem = this.slide.length-1;
    }
    this.slide[index].active = false
    this.slide[previtem].active = true
  }
  SetSlide(index:number){
    this.slide.map(x=>x.active=false);
    this.slide[index].active= true;
  }


}
interface Side {
  urlimage : string,
  active: boolean

}
