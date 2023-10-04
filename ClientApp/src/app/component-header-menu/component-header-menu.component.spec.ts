import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentHeaderMenuComponent } from './component-header-menu.component';

describe('ComponentHeaderMenuComponent', () => {
  let component: ComponentHeaderMenuComponent;
  let fixture: ComponentFixture<ComponentHeaderMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComponentHeaderMenuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentHeaderMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
