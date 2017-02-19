import { Injectable } from '@angular/core';
import { Registry } from './registry'
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class RegistrationService {
  constructor(private http: Http) {

  }

  getProducts(): Observable<Registry[]> {
    return this.http.get('http://localhost:60104/api/registration')
      .map((responseData) => { return responseData.json(); })
      .catch(this.handleError);
  }

  getProduct(id: number): Observable<Registry> {
    return this.http.get('http://localhost:60104/api/registration/' + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  insertRegistry(registry: Registry[]): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.post('http://localhost:60104/api/registration', JSON.stringify(registry), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  private handleError(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }

    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}