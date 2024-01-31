import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';

@Component({
  selector: 'app-profile-edit',
  standalone: true,
  imports: [SidebarComponent, RouterModule],
  templateUrl: './profile-edit.component.html'
})
export class ProfileEditComponent {

}
