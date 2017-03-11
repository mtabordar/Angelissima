import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductComponent } from './product/product.component';
import { BarCodeComponent } from '../barcodes/barcodes.component';

import { PaginationModule } from 'ng2-bootstrap/pagination';

import { ProductService } from './shared/product.service';

import { AppRoutingModule } from '../app.routing.module';

@NgModule({
    imports: [SharedModule, AppRoutingModule, PaginationModule.forRoot()],
    declarations: [ProductListComponent, ProductComponent, BarCodeComponent],
    providers: [ProductService]
})

export class ProductModule {

}