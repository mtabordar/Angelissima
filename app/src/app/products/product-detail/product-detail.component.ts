import { Component, Input } from '@angular/core';
import { Product } from '../shared/product';
import { BarCode } from '../../barcodes/shared/barcode';

@Component({
    selector: 'product-detail',
    template: require('./product-detail.component.html')
})

export class ProductDetailComponent {
    @Input() product: Product;

    constructor() {
    }
}