import { Component, Input } from '@angular/core';
import { Product } from '../shared/product';

@Component({
    selector: 'product-detail',
    template: require('./product-detail.component.html')
})

export class ProductDetailComponent {
    @Input() product: Product;

    constructor() {
        this.product = new Product;
    }
}