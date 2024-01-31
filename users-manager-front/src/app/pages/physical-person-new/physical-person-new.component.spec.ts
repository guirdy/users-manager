import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysicalPersonNewComponent } from './physical-person-new.component';

describe('PhysicalPersonNewComponent', () => {
  let component: PhysicalPersonNewComponent;
  let fixture: ComponentFixture<PhysicalPersonNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PhysicalPersonNewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PhysicalPersonNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
