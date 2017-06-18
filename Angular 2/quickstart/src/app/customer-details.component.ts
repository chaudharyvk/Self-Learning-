import {Component,Input } from "@angular/core";
import { Customer } from './customer';
@Component({

selector : 'customer-details',
template:`<div *ngIf="customer">
      <h2>{{customer.name}} Details</h2>
      <div><label>id: </label>{{customer.id}}</div>
      <div>
        <label>name: </label>
        <input [(ngModel)]="customer.name" placeholder="name"/>
      </div>
    </div>`
 })

export class customerdetailsComponent {
    @Input () customer  : Customer;
}