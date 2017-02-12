import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { InventoryComponent } from './inventory/inventory.component';
import { InventoryService } from './shared/inventory.service';

import { AppRoutingModule } from '../app.routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, AppRoutingModule],
    declarations: [InventoryComponent],
    providers: [InventoryService]
})

export class InventoryModule {

}