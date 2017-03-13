import { Injectable } from '@angular/core';
import { Sale } from './sale'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';
var config = require('../../app.config.json');

@Injectable()
export class SaleService {
  private webApiUrl: string;
  private controllerName: string;

  constructor(private http: Http) {
    this.controllerName = "sale";
    this.webApiUrl = `${config.webApiUrl}${this.controllerName}/`;
  }

  insertSale(sale: Sale): Observable<string> {
    return this.http.post(this.webApiUrl, JSON.stringify(sale))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }
}