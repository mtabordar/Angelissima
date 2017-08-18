import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { Inventory } from '../shared/inventory';
import { Product } from '../../products/shared/product';
import { BarCode } from '../../barcodes/shared/barcode';
import { Message } from '../../messages/shared/message';

import { InventoryService } from '../shared/inventory.service';
import { ProductService } from '../../products/shared/product.service';

@Component({
  selector: 'inventory',
  templateUrl: './inventory.component.html',
})

export class InventoryComponent implements OnInit {
  inventory: Inventory;
  private message: Message;
  private sub: any;
  private productId: number;

  constructor(private inventoryService: InventoryService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location,
    private productService: ProductService) {
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.productId = +params['id'];
      if (this.productId) {
        this.getInventory(this.productId);
      }
    },
      error => this.message = <Message>error);
  }

  getInventory(productId: number): void {
    this.inventoryService.getInventoryForProduct(productId)
      .subscribe(
      inventory => this.setInventory(inventory),
      error => this.message = <Message>error);
  }

  setInventory(inventory: Inventory): void {
    if (inventory) {
      this.inventory = inventory;
    }
    else {
      this.inventory = new Inventory;
      this.getProduct(this.productId);
    }
  }

  getProduct(id: number): void {
    this.productService.getProduct(id)
      .subscribe(
      product => this.inventory.product = product,
      error => this.message = <Message>error);
  }

  goBack(): void {
    this.location.back();
  }

  onSubmit() {
    this.inventoryService.insertInventory(this.inventory)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.message = <Message>error);
  }
}