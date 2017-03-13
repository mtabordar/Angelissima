import { Injectable } from '@angular/core';
import { Sale } from './sale'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';

@Injectable()
export class SaleService {
  private urlWebApi: string;

  constructor(private http: Http) {
    this.urlWebApi = "http://localhost:60104/api/sale/";
  }

  insertSale(sale: Sale): Observable<string> {
    return this.http.post(this.urlWebApi, JSON.stringify(sale))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }
}