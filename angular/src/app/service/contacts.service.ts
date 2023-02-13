import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { contacts } from '../models/contacts.model';
@Injectable({
  providedIn: 'root'
})
export class contactsService {

  baseUrl='https://localhost:7093/api/Contacts';
  constructor(private http:HttpClient) { }

  //get all contacts
  getAllContacts(): Observable<contacts[]>{
    return this.http.get<contacts[]>(this.baseUrl);

  }

  addContact(contacts:contacts): Observable<contacts>{
    contacts.id='00000000-0000-0000-0000-000000000000';
    return this.http.post<contacts>(this.baseUrl, contacts);
  }
  deleteContact(id:string) :Observable<contacts>{
    return this.http.delete<contacts>(this.baseUrl + '/' + id); 
  }

  updateContact(contact:contacts) :Observable<contacts>{
    return this.http.put<contacts>(this.baseUrl + '/' +contact.id,contact ); 
  }
}
