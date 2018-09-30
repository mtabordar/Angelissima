import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../shared/product';
import { BarCode } from '../../barcodes/shared/barcode';
import { Message } from '../../messages/shared/message';

import Operations from '../../shared/operations'

import { ProductService } from '../shared/product.service';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
})

export class ProductComponent implements OnInit {
  private product: Product;
  private message: Message;
  private sub: any;

  constructor(private productService: ProductService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location) {
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      let productId: number = +params['id'];
      if (productId) {
        this.getProduct(productId);
      }
      else{
        this.product = new Product;
        this.product.barCodes = Array<BarCode>();
      }
    },
      error => this.message = <Message>error);
  }

  getProduct(id: number): void {
    this.productService.getProduct(id)
      .subscribe(
      product => this.setProduct(product),
      error => this.message = <Message>error);
  }

  setProduct(product: Product): void {
    if(!product.barCodes){
      product.barCodes = Array<BarCode>();
    }

    this.product = product;
  }

  updateProduct(): void {
    this.productService.updateProduct(this.product)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.message = <Message>error);
  }

  insertProduct(): void {
    this.productService.insertProduct(this.product)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.message = <Message>error);
  }

  goBack(): void {
    this.location.back();
  }

  onSubmit(): void {
    if (this.product.productId) {
      this.updateProduct();
    }
    else {
      this.insertProduct();
    }
  }

  calculateSalePrice(): void {
    this.product.salePrice = Operations.calculateAfterPercentage(this.product.unitPrice);
  }
}