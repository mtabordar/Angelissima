import { Injectable } from '@angular/core';
import { Sale } from './sale'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../shared/base.service';

@Injectable()
export class SaleService extends BaseService<Sale>{
  constructor(private http: Http) {
    super(http, "sale");
  }

  insertSale(sale: Sale): Observable<string> {
    return this.insert(sale);
  }
}