import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RasaComponent } from './rasa.component';

describe('RasaComponent', () => {
  let component: RasaComponent;
  let fixture: ComponentFixture<RasaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RasaComponent]
    });
    fixture = TestBed.createComponent(RasaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
