import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { InventoryComponent } from './inventory/inventory.component';
import { InventoryService } from './shared/inventory.service';

import { ProductDetailComponent } from '../products/product-detail/product-detail.component';

import { AppRoutingModule } from '../app.routing.module';

import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';

@NgModule({
    imports: [CommonModule, FormsModule, AppRoutingModule, NKDatetimeModule],
    declarations: [InventoryComponent, ProductDetailComponent],
    providers: [InventoryService]
})

export class InventoryModule {

}