import { Routes } from '@angular/router';
import { AuthComponent } from './pages/auth/auth.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { PhysicalPersonComponent } from './pages/physical-person/physical-person.component';
import { ProfileEditComponent } from './pages/profile-edit/profile-edit.component';
import { PhysicalPersonNewComponent } from './pages/physical-person-new/physical-person-new.component';
import { PhysicalPersonViewComponent } from './pages/physical-person-view/physical-person-view.component';
import { PhysicalPersonEditComponent } from './pages/physical-person-edit/physical-person-edit.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    component: AuthComponent
  },
  {
    path: 'profile',
    component: ProfileComponent
  },
  {
    path: 'profile/edit',
    component: ProfileEditComponent
  },
  {
    path: 'physical-person',
    component: PhysicalPersonComponent
  },
  {
    path: 'physical-person/view',
    component: PhysicalPersonViewComponent
  },
  {
    path: 'physical-person/edit',
    component: PhysicalPersonEditComponent
  },
  {
    path: 'physical-person/new',
    component: PhysicalPersonNewComponent
  }
];
