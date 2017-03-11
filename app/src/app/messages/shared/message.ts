import { AlertType } from '../../shared/enums';

export class Message {
    message: string;
    alertType: AlertType = AlertType.danger;
}