import { Injectable } from '@angular/core';
import { Inventory } from './inventory'
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../shared/base.service';

@Injectable()
export class InventoryService extends BaseService<Inventory>{
  constructor(private http: Http) {
    super(http, "inventory");
  }

  getInventoryForProduct(id: number): Observable<Inventory> {
    return this.get(id);
  }

  insertInventory(inventory: Inventory): Observable<string> {
    return this.insert(inventory);
  }
}