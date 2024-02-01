import { Component } from '@angular/core';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-physical-person-edit',
  standalone: true,
  imports: [
    SidebarComponent,
    RouterModule
  ],
  templateUrl: './physical-person-edit.component.html'
})
export class PhysicalPersonEditComponent {

}
