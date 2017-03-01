import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, Http } from '@angular/http';
import { AppRoutingModule } from './app.routing.module';
import { ProductModule } from './products/product.module';
import { SaleModule } from './sales/sale.module';
import { InventoryModule } from './inventory/Inventory.module';
import { AlertModule } from 'ng2-bootstrap/alert';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';
import { Ng2AutoCompleteModule } from 'ng2-auto-complete';
import { TranslateModule, TranslateStaticLoader, TranslateLoader } from 'ng2-translate';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';

export function exportTranslateStaticLoader(http: Http) {
  return new TranslateStaticLoader(http, 'assets/i18n', '.json');
}

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
    SaleModule,
    InventoryModule,
    AlertModule.forRoot(),
    NKDatetimeModule,
    Ng2AutoCompleteModule,
    TranslateModule.forRoot({
      provide: TranslateLoader,
      useFactory: exportTranslateStaticLoader,
      deps: [Http]
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
