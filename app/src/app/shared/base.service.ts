import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from './error-handling';
var config = require('../app.config.json');

@Injectable()
export class BaseService<T> {
    private webApiUrl: string;

    constructor(private baseHttp: Http, private controllerName: string) {
        this.webApiUrl = `${config.webApiUrl}${this.controllerName}/`;
    }

    getAll(): Observable<T[]> {
        return this.baseHttp.get(this.webApiUrl)
            .map((responseData) => { return responseData.json(); })
            .catch(ErrorHandling.handleError);
    }

    get(id: number): Observable<T> {
        return this.baseHttp.get(this.webApiUrl + id)
            .map((responseData) => {
                return responseData.json();
            })
            .catch(ErrorHandling.handleError);
    }

    insert(item: T): Observable<string> {
        return this.baseHttp.post(this.webApiUrl, JSON.stringify(item))
            .map((responseData) => {
                return responseData.json();
            })
            .catch(ErrorHandling.handleError);
    }

    update(item: T, id: number): Observable<string> {
        return this.baseHttp.put(this.webApiUrl + id, JSON.stringify(item))
            .map((responseData) => {
                return responseData.json();
            })
            .catch(ErrorHandling.handleError);
    }

    delete(id: number): Observable<string> {
        return this.baseHttp.delete(this.webApiUrl + id)
            .map((responseData) => {
                if (responseData.status == 200) {
                    return responseData.json();
                }
            })
            .catch(ErrorHandling.handleError);
    }
}
