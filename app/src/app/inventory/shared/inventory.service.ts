import { Injectable } from '@angular/core';
import { Inventory } from './inventory'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';
var config = require('../../app.config.json');

@Injectable()
export class InventoryService {
  private webApiUrl: string;
  private controllerName: string;

  constructor(private http: Http) {
    this.controllerName = "inventory";
    this.webApiUrl = `${config.webApiUrl}${this.controllerName}/`;
  }

  getInventoryForProduct(id: number): Observable<Inventory> {
    return this.http.get(this.webApiUrl + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  insertInventory(product: Inventory): Observable<string> {
    return this.http.post(this.webApiUrl, JSON.stringify(product))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }
}