import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InventoryComponent } from './inventory/inventory/inventory.component';
import { SaleComponent } from './sales/sale/sale.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductComponent } from './products/product/product.component';

const routes: Routes = [
    { path: '', redirectTo: 'sale', pathMatch: 'full' },
    { path: 'products', component: ProductListComponent },
    { path: 'product/:id/edit', component: ProductComponent },
    { path: 'product', component: ProductComponent },
    { path: 'sale', component: SaleComponent },
    { path: 'inventory/:id', component: InventoryComponent },
    // { path: 'reports', component: }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }