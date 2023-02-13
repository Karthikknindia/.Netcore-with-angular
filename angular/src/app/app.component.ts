import { Component, OnInit } from '@angular/core';
import { contacts } from './models/contacts.model';
import { contactsService } from './service/contacts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'angular';
  contacts:contacts[]=[];
  
    contact:contacts={
      id:'',
      firstName: '',
      lastName: '',
      email: '',
      contact: '',
      address: '',
      city: '',
      state: '',
      pincode:'',
    }


  constructor(private contactsService: contactsService) {

  }
  ngOnInit(): void {
    this.getAllContacts();
    
    
  }

  getAllContacts(){
    this.contactsService.getAllContacts()
    .subscribe(
      response=>{
        this.contacts=response;
        this.contact ={
          id:'',
          firstName: '',
          lastName: '',
          email: '',
          contact: '',
          address: '',
          city: '',
          state: '',
          pincode:'',
        }
      }
    )
  }
  onSubmit (){

    if (this.contact.id===''){

      this.contactsService.addContact(this.contact)
    .subscribe(
      response => {
        this.getAllContacts();
        this.contact={
          id:'',
          firstName: '',
          lastName: '',
          email: '',
          contact: '',
          address: '',
          city: '',
          state: '',
          pincode:'',
        }
      }
    );
    } else {
      this.updateContact(this.contact);
    }


    
  }
  deleteContact(id:string){
    this.contactsService.deleteContact(id)
    .subscribe(
      response=>{
        this.getAllContacts();
      }
    );
  }

  populateForm(contact:contacts){
this.contact=contact;
  }

  updateContact(contact:contacts){
    this.contactsService.updateContact(contact)
    .subscribe(
      response=>{
        this.getAllContacts();
      }
    );
  }
}``

