import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AlertModule } from 'ng2-bootstrap/alert';
import { TranslateModule } from 'ng2-translate';

import { MessageComponent } from '../messages/message.component';

@NgModule({
    imports: [CommonModule, AlertModule.forRoot()],
    declarations: [MessageComponent],
    exports: [CommonModule, MessageComponent, FormsModule, TranslateModule]
})

export class SharedModule {

}