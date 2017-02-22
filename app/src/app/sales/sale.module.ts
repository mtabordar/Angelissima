import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SaleComponent } from './sale/sale.component';
import { SaleService } from './shared/sale.service';

import { AppRoutingModule } from '../app.routing.module';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';
import { Ng2AutoCompleteModule } from 'ng2-auto-complete';

@NgModule({
    imports: [CommonModule
        , FormsModule
        , AppRoutingModule
        , NKDatetimeModule
        , Ng2AutoCompleteModule],
    declarations: [SaleComponent],
    providers: [SaleService]
})

export class SaleModule {

}