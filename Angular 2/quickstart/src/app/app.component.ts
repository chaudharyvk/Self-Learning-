import { Component } from '@angular/core';
import {Customer} from './customer';

@Component({
  selector: 'my-app',
  templateUrl: `./Customer.html`,
 
})
export class AppComponent  
{
  title = 'First Angular App'; 
  customer = CustomerDetails ; 
  selectedcustomer : Customer;
  onSelect(customer:Customer) : void {

  this.selectedcustomer=customer;

  } 

  }

const CustomerDetails : Customer[]=[
  { id: 11, name: 'Mr. Nice',age:5,Address:'mb 89',postcode:212121,city:'Delhi',country:'India' },
   { id: 12, name: 'Mr. 1',age:5,Address:'mb 89',postcode:212121,city:'Delhi',country:'India' },
    { id: 13, name: 'Mr. 2 Nice',age:5,Address:'mb 89',postcode:212121,city:'Delhi',country:'India' },
     { id: 14, name: 'Mr. 3 .Nice',age:5,Address:'mb 89',postcode:212121,city:'Delhi',country:'India' },
      { id: 15, name: 'Mr. 4. Nice',age:5,Address:'mb 89',postcode:212121,city:'Delhi',country:'India' },
       { id: 16, name: 'Mr. 5.  Nice',age:5,Address:'mb 89',postcode:212121,city:'Delhi',country:'India' },
];

