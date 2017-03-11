import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { InventoryComponent } from './inventory/inventory.component';
import { InventoryService } from './shared/inventory.service';

import { ProductDetailComponent } from '../products/product-detail/product-detail.component';

import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';

@NgModule({
    imports: [SharedModule, NKDatetimeModule],
    declarations: [InventoryComponent, ProductDetailComponent],
    providers: [InventoryService]
})

export class InventoryModule {

}