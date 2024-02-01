import { Component } from '@angular/core';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-physical-person-view',
  standalone: true,
  imports: [
    SidebarComponent,
    RouterModule
  ],
  templateUrl: './physical-person-view.component.html'
})
export class PhysicalPersonViewComponent {

}
