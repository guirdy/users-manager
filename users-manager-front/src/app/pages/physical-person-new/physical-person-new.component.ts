import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';

@Component({
  selector: 'app-physical-person-new',
  standalone: true,
  imports: [
    SidebarComponent,
    RouterModule
  ],
  templateUrl: './physical-person-new.component.html'
})
export class PhysicalPersonNewComponent {

}
