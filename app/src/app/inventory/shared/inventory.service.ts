import { Injectable } from '@angular/core';
import { Inventory } from './inventory'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';

@Injectable()
export class InventoryService {
  private urlWebApi: string;

  constructor(private http: Http) {
    this.urlWebApi = "http://localhost:60104/api/inventory/";
  }

  getInventoryForProduct(id: number): Observable<Inventory> {
    return this.http.get(this.urlWebApi + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  insertInventory(product: Inventory): Observable<string> {
    return this.http.post(this.urlWebApi, JSON.stringify(product))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }
}