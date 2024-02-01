import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysicalPersonEditComponent } from './physical-person-edit.component';

describe('PhysicalPersonEditComponent', () => {
  let component: PhysicalPersonEditComponent;
  let fixture: ComponentFixture<PhysicalPersonEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PhysicalPersonEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PhysicalPersonEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
