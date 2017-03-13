import { Injectable } from '@angular/core';
import { Product } from './product'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import ErrorHandling from '../../shared/error-handling';
import { AppConfig } from '../../app.config.service';

@Injectable()
export class ProductService {
  urlWebApi: string;

  constructor(private http: Http, private config: AppConfig) {
      this.urlWebApi = "http://localhost:60104/api/product/";
  }

  getProducts(): Observable<Product[]> {
    return this.http.get(this.urlWebApi)
      .map((responseData) => { return responseData.json(); })
      .catch(ErrorHandling.handleError);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get(this.urlWebApi + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  insertProduct(product: Product): Observable<string> {
    return this.http.post(this.urlWebApi, JSON.stringify(product))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  updateProduct(product: Product): Observable<string> {
    return this.http.put(this.urlWebApi + product.productId, JSON.stringify(product))
      .map((responseData) => {
        return responseData.json();
      })
      .catch(ErrorHandling.handleError);
  }

  deleteProduct(id: number): Observable<string> {
    return this.http.delete(this.urlWebApi + id)
      .map((responseData) => {
        if (responseData.status == 200) {
          return "";
        }
      })
      .catch(ErrorHandling.handleError);
  }
}