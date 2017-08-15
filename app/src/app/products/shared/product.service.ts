import { Injectable } from '@angular/core';
import { Product } from './product'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';
var config = require('../../app.config.json');

@Injectable()
export class ProductService {
  private webApiUrl: string;
  private controllerName: string;

  constructor(private http: Http) {
      this.controllerName = "product";
      this.webApiUrl = `${config.webApiUrl}${this.controllerName}/`;
  }

  getProducts(): Observable<Product[]> {
    return this.http.get(this.webApiUrl)
      .map((responseData) => { return responseData.json(); })
      .catch(ErrorHandling.handleError);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get(this.webApiUrl + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  insertProduct(product: Product): Observable<string> {
    return this.http.post(this.webApiUrl, JSON.stringify(product))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  updateProduct(product: Product): Observable<string> {
    return this.http.put(this.webApiUrl + product.productId, JSON.stringify(product))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  deleteProduct(id: number): Observable<string> {
    return this.http.delete(this.webApiUrl + id)
      .map((responseData) => {
        if (responseData.status == 200) {
          return responseData.json();
        }
      })
      .catch(ErrorHandling.handleError);
  }
}