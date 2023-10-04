import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import {ComponentHeaderMenuComponent} from "./component-header-menu/component-header-menu.component";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {PostContentComponent} from "./post-content/post-content.component";
import {AboutComponent} from "./about/about.component";
import {FooterComponent} from "./footer/footer.component";
import {MarketingComponent} from "./marketing/marketing.component";
import {BlogComponent} from "./blog/blog.component";
import {ContactComponent} from "./contact/contact.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ComponentHeaderMenuComponent,
    PostContentComponent,
    AboutComponent,
    FooterComponent,
    MarketingComponent,
    BlogComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent , canActivate: [AuthorizeGuard]},
      { path: 'about', component: AboutComponent},
      { path: 'marketing', component: MarketingComponent },
      { path: 'blog', component: BlogComponent },
      { path: 'contact', component: ContactComponent },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
