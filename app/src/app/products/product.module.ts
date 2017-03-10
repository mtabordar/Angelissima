import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductComponent } from './product/product.component';
import { BarCodeComponent } from '../barcodes/barcodes.component';
import { MessageComponent } from '../messages/message.component';

import { ModalModule } from 'ng2-bootstrap/modal';
import { PaginationModule } from 'ng2-bootstrap/pagination';

import { ProductService } from './shared/product.service';

import { AppRoutingModule } from '../app.routing.module';
import { TranslateModule } from 'ng2-translate';

@NgModule({
    imports: [CommonModule, FormsModule, AppRoutingModule, ModalModule.forRoot(), PaginationModule.forRoot(), TranslateModule],
    declarations: [ProductListComponent, ProductComponent, BarCodeComponent, MessageComponent],
    providers: [ProductService]
})

export class ProductModule {

}