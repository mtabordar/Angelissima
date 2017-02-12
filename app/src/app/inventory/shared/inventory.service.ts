import { Injectable } from '@angular/core';
import { Inventory } from './inventory'
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class InventoryService {
  constructor(private http: Http) {

  }

  getProducts(): Observable<Inventory[]> {
    return this.http.get('http://localhost:60104/api/inventory')
      .map((responseData) => { return responseData.json(); })
      .catch(this.handleError);
  }

  getProduct(id: number): Observable<Inventory> {
    return this.http.get('http://localhost:60104/api/inventory/' + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  insertProduct(product: Inventory): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.post('http://localhost:60104/api/inventory', JSON.stringify(product), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  updateProduct(product: Inventory): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.put('http://localhost:60104/api/inventory/' + product.id, JSON.stringify(product), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  deleteProduct(id: number): Observable<string> {
    return this.http.delete('http://localhost:60104/api/inventory/' + id)
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