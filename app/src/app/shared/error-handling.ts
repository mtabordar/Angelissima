import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';

export default class ErrorHandling {
    static handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            if (error.status == 0) {
                errMsg = "Could not stablish conection with api.";
            }
            else {
                errMsg = 'Server Error';
                const body = error.json() || errMsg;
                const err = `${body.message} - ${body.innerException || ''}`;
                console.error(`${error.status} - ${error.statusText || ''} ${err}`);
            }
        } else {
            errMsg = error.message ? error.message : error.toString();
        }

        return Observable.throw(errMsg);
    }
}


