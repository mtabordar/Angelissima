import { Injectable } from '@angular/core';
import { Inventory } from './inventory'
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';

@Injectable()
export class InventoryService {
  constructor(private http: Http) {

  }

  getInventoryForProduct(id: number): Observable<Inventory> {
    return this.http.get('http://localhost:60104/api/inventory/' + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  insertInventory(product: Inventory): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.post('http://localhost:60104/api/inventory', JSON.stringify(product), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }
}