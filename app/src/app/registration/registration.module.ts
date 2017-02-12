import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RegistryComponent } from './registry/registry.component';
import { RegistrationService } from './shared/registration.service';

import { AppRoutingModule } from '../app.routing.module';
import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';

@NgModule({
    imports: [CommonModule
    , FormsModule
    , AppRoutingModule,
    NKDatetimeModule],
    declarations: [RegistryComponent],
    providers: [RegistrationService]
})

export class RegistrationModule {

}