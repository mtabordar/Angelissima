import { Message } from '../messages/shared/message';
import { AlertType } from '../shared/enums';

import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';

export default class ErrorHandling {
    static handleError(error: Response | any) : Observable<Message> {
        let errMsg: string;
        let message = new Message;
        if (error instanceof Response) {
            if (error.status == 0) {
                errMsg = "Could not stablish conection with api.";
            }
            else {
                errMsg = 'Server Error';
                const body = error.json() || errMsg;
                const err = `${body.value || ''}`;
                errMsg += " - " + err;
                console.error(`${error.status} - ${error.statusText || ''} ${err}`);
            }
        } else {
            errMsg = error.message ? error.message : error.toString();
        }

        message.message = errMsg;
        message.alertType = AlertType.danger;

        return Observable.throw(message);
    }
}


