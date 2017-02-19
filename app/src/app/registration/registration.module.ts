import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RegistryComponent } from './registry/registry.component';
import { RegistrationService } from './shared/registration.service';

import { AppRoutingModule } from '../app.routing.module';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';
import { Ng2AutoCompleteModule } from 'ng2-auto-complete';

@NgModule({
    imports: [CommonModule
        , FormsModule
        , AppRoutingModule
        , NKDatetimeModule
        , Ng2AutoCompleteModule],
    declarations: [RegistryComponent],
    providers: [RegistrationService]
})

export class RegistrationModule {

}