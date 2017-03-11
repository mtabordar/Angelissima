import { Injectable } from '@angular/core';
import { Sale } from './sale'
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';

@Injectable()
export class SaleService {
  constructor(private http: Http) {

  }

  insertSale(sale: Sale): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.post('http://localhost:60104/api/sale', JSON.stringify(sale), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }
}