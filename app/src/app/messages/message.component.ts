import { Component, Input } from '@angular/core';
import { AlertType } from '../shared/enums';
import { Message } from './shared/message';

@Component({
    selector: 'message',
    template: './message.component.html',
    styles: ['./message.component.css'],
})

export class MessageComponent {
    @Input() message: Message;
    alertType: typeof AlertType = AlertType;

    constructor() {
    }

    onAlertClose(event: any): void {
        this.message.message = "";
    }
}