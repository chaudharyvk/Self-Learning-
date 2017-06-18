"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var AppComponent = (function () {
    function AppComponent() {
        this.title = 'First Angular App';
        this.customer = CustomerDetails;
    }
    AppComponent.prototype.onSelect = function (customer) {
        this.selectedcustomer = customer;
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        templateUrl: "./Customer.html",
    })
], AppComponent);
exports.AppComponent = AppComponent;
var CustomerDetails = [
    { id: 11, name: 'Mr. Nice', age: 5, Address: 'mb 89', postcode: 212121, city: 'Delhi', country: 'India' },
    { id: 12, name: 'Mr. 1', age: 5, Address: 'mb 89', postcode: 212121, city: 'Delhi', country: 'India' },
    { id: 13, name: 'Mr. 2 Nice', age: 5, Address: 'mb 89', postcode: 212121, city: 'Delhi', country: 'India' },
    { id: 14, name: 'Mr. 3 .Nice', age: 5, Address: 'mb 89', postcode: 212121, city: 'Delhi', country: 'India' },
    { id: 15, name: 'Mr. 4. Nice', age: 5, Address: 'mb 89', postcode: 212121, city: 'Delhi', country: 'India' },
    { id: 16, name: 'Mr. 5.  Nice', age: 5, Address: 'mb 89', postcode: 212121, city: 'Delhi', country: 'India' },
];
//# sourceMappingURL=app.component.js.map