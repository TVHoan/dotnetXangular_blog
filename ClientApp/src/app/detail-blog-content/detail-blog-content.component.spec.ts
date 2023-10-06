import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailBlogContentComponent } from './detail-blog-content.component';

describe('DetailBlogContentComponent', () => {
  let component: DetailBlogContentComponent;
  let fixture: ComponentFixture<DetailBlogContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailBlogContentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailBlogContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
