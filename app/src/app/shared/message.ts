import { AlertType } from './enums';

export class Message {
    message: string;
    alertType: AlertType = AlertType.danger;
}