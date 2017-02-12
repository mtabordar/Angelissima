import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './app.routing.module';
import { ProductModule } from './products/product.module';
import { RegistrationModule } from './registration/registration.module';
import { InventoryModule } from './inventory/Inventory.module';
import { AlertModule } from 'ng2-bootstrap/alert';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    ProductModule,
    RegistrationModule,
    InventoryModule,
    AlertModule.forRoot(),
    NKDatetimeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
