import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductComponent } from './product/product.component';
import { BarCodeComponent } from '../barcodes/barcodes.component';

import { ProductService } from './shared/product.service';

import { AppRoutingModule } from '../app.routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, AppRoutingModule],
    declarations: [ProductListComponent, ProductComponent, BarCodeComponent],
    providers: [ProductService]
})

export class ProductModule {

}