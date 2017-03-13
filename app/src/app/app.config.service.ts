import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { environment } from '../environments/environment';
import ErrorHandling from './shared/error-handling';

@Injectable()
export class AppConfig {
    private config: Object = null;

    constructor(private http: Http) { }

    public getKey(key: string) {
        return this.config[key];
    }

    public load() {
        let env = "development";
        if (environment.production) {
            env = "production";
        }

        return this.http.get("http://localhost:4200/src/environments/config.development.json")
            .map((responseData) => responseData.json())
            .catch(ErrorHandling.handleError)
            .subscribe((responsData) =>{
                this.config = responsData; }
            );
    }
}

