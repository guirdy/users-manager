import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';

interface Address {
  street: string;
  number: string;
  postalCode: string;
  complement?: string;
  city: string;
  state: string;
}

interface Contact {
  name: string;
  contactType: "Phone" | "Email";
  emailOrPhone: string;
}

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
  addresses: Address[] = [{
    city: 'bla',
    number: 'bla',
    postalCode: 'bla',
    state: 'bla',
    street: 'bla',
    complement: 'bla'
  }]
  contacts: Contact[] = []

  addAddress(newAddress: Address) {
    this.addresses.push(newAddress);
  }

  addContact(newContact: Contact) {
    this.contacts.push(newContact);
  }
}
