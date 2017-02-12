import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InventoryComponent } from './inventory/inventory/inventory.component';
import { RegistryComponent } from './registration/registry/registry.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductComponent } from './products/product/product.component';

const routes: Routes = [
    { path: '', redirectTo: 'registration', pathMatch: 'full' },
    { path: 'products', component: ProductListComponent },
    { path: 'product/:id/edit', component: ProductComponent },
    { path: 'product', component: ProductComponent },
    { path: 'registration', component: RegistryComponent },
    { path: 'inventory', component: InventoryComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }