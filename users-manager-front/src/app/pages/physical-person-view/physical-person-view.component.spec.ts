import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysicalPersonViewComponent } from './physical-person-view.component';

describe('PhysicalPersonViewComponent', () => {
  let component: PhysicalPersonViewComponent;
  let fixture: ComponentFixture<PhysicalPersonViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PhysicalPersonViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PhysicalPersonViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});