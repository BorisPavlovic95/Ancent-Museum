import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourCompletedComponent } from './tour-completed.component';

describe('TourCompletedComponent', () => {
  let component: TourCompletedComponent;
  let fixture: ComponentFixture<TourCompletedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourCompletedComponent]
    });
    fixture = TestBed.createComponent(TourCompletedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
