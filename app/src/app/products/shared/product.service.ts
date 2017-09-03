import { Injectable } from '@angular/core';
import { Product } from './product'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../shared/base.service';

@Injectable()
export class ProductService extends BaseService<Product>{
  constructor(private http: Http) {
    super(http, "Product");
  }

  getProducts(): Observable<Product[]> {
    return this.getAll();
  }

  getProduct(id: number): Observable<Product> {
    return this.get(id);
  }

  insertProduct(product: Product): Observable<string> {
    return this.insert(product);
  }

  updateProduct(product: Product): Observable<string> {
    return this.update(product, product.productId);
  }

  deleteProduct(id: number): Observable<string> {
    return this.delete(id);
  }
}