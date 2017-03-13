import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { Http } from '@angular/http';
import { AppRoutingModule } from './app.routing.module';
import { ProductModule } from './products/product.module';
import { SaleModule } from './sales/sale.module';
import { InventoryModule } from './inventory/Inventory.module';
import { CollapseDirective } from 'ng2-bootstrap';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';
import { Ng2AutoCompleteModule } from 'ng2-auto-complete';
import { TranslateModule, TranslateStaticLoader, TranslateLoader } from 'ng2-translate';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component'

import { requestOptionsProvider } from './shared/default-request-options.service';
import { AppConfig } from './app.config.service';

export function exportTranslateStaticLoader(http: Http) {
  return new TranslateStaticLoader(http, 'assets/i18n', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    CollapseDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProductModule,
    SaleModule,
    InventoryModule,
    NKDatetimeModule,
    Ng2AutoCompleteModule,
    TranslateModule.forRoot({
      provide: TranslateLoader,
      useFactory: exportTranslateStaticLoader,
      deps: [Http]
    })
  ],
  providers: [requestOptionsProvider,
    AppConfig, { provide: APP_INITIALIZER, useFactory: (config: AppConfig) => () => config.load(), deps: [AppConfig], multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
