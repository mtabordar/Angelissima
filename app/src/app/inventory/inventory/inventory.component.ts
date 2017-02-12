import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { Inventory } from '../shared/inventory';

import { InventoryService } from '../shared/inventory.service';

@Component({
  selector: 'inventory',
  template: require('./inventory.component.html'),
})

export class InventoryComponent implements OnInit {
  inventory: Inventory;
  errorMessage: string;
  message: string;
  private sub: any;

  constructor(private inventoryService: InventoryService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location) {
    this.inventory = new Inventory;
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      let productId: number = +params['id'];
      if (productId) {
        this.getProduct(productId);
      }
    },
      error => console.log(error));
  }

  getProduct(id: number): void {
    this.inventoryService.getProduct(id)
      .subscribe(
      inventory => this.inventory = inventory,
      error => this.errorMessage = <any>error);
  }

  updateProduct(): void {
    this.inventoryService.updateProduct(this.inventory)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.errorMessage = <any>error);
  }

  insertProduct(): void {
    this.inventoryService.insertProduct(this.inventory)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.errorMessage = <any>error);
  }

  goBack(): void {
    this.location.back();
  }

  onSubmit(): void {
    if (this.inventory.id) {
      this.updateProduct();
    }
    else {
      this.insertProduct();
    }
  }
}