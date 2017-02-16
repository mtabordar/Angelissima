import { Component, Input } from '@angular/core';

import { BarCode } from './shared/barcode';

@Component({
    selector: 'barcodes',
    template: require('./barcodes.component.html'),
})

export class BarCodeComponent {
    @Input() barcode: BarCode;
}