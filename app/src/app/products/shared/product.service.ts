import { Injectable } from '@angular/core';
import { Product } from './product'
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

@Injectable()
export class ProductService {
  constructor(private http: Http) {

  }

  getProducts(): Observable<Product[]> {
    return this.http.get('http://localhost:60104/api/product')
      .map((responseData) => { return responseData.json(); })
      .catch(this.handleError);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get('http://localhost:60104/api/product/' + id)
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  insertProduct(product: Product): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.post('http://localhost:60104/api/product', JSON.stringify(product), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  updateProduct(product: Product): Observable<string> {
    let headers = new Headers;
    headers.append('Content-Type', 'application/json')

    return this.http.put('http://localhost:60104/api/product/' + product.productId, JSON.stringify(product), { headers: headers })
      .map((responseData) => {
        return responseData.json();
      })
      .catch(this.handleError);
  }

  deleteProduct(id: number): Observable<string> {
    return this.http.delete('http://localhost:60104/api/product/' + id)
      .map((responseData) => {
        if (responseData.status == 200) {
          return "";
        }
      })
      .catch(this.handleError);
  }

  private handleError(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      if (error.status == 0) {
        errMsg = "Could not stablish conection with api.";
      }
      else {
        errMsg = 'Server Error';
        const body = error.json() || errMsg;
        const err = `${body.message} - ${body.innerException || ''}`;
        console.log(`${error.status} - ${error.statusText || ''} ${err}`);
      }
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    
    return Observable.throw(errMsg);
  }
}