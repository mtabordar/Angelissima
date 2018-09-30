import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { Inventory } from '../shared/inventory';
import { Message } from '../../messages/shared/message';

import { InventoryService } from '../shared/inventory.service';
import { ProductService } from '../../products/shared/product.service';
import { Product } from '../../products/shared/product';

@Component({
  selector: 'inventory',
  templateUrl: './inventory.component.html',
})

export class InventoryComponent implements OnInit {
  inventory: Inventory;
  product: Product;
  private message: Message;
  private productId: number;

  constructor(private inventoryService: InventoryService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location,
    private productService: ProductService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
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
      this.inventory = inventory;
      this.inventory.productId = this.productId;
      this.getProduct(this.productId); 
  }

  getProduct(id: number): void {
    this.productService.getProduct(id)
      .subscribe(
      product => this.product = product,
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