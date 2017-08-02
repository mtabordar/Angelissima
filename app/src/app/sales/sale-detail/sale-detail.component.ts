import { Component, Input } from '@angular/core';
import { Sale } from '../shared/sale';

@Component({
    selector: 'sale-detail',
    templateUrl: './sale-detail.component.html'
})

export class SaleDetail {
   @Input() sale: Sale;

   constructor(){

   }
}