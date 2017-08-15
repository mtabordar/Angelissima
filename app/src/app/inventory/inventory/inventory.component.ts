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

  constructor(private inventoryService: InventoryService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location,
    private productService: ProductService) {
  }

  ngOnInit(): void {
    this.inventory = new Inventory;
    this.inventory.product = new Product;
    this.inventory.product.barCodes = new BarCode;
    this.inventory.registrationDate = new Date();

    this.sub = this.route.params.subscribe(params => {
      let productId: number = +params['id'];
      if (productId) {
        this.inventory.productId = productId;
        this.getInventory(productId);
        this.getProduct(productId);
      }
    },
      error => this.message = <Message>error);
  }

  getInventory(productId: number): void {
    this.inventoryService.getInventoryForProduct(productId)
      .subscribe(
      inventory => this.inventory = (inventory) ? inventory : this.inventory,
      error => this.message = <Message>error);
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