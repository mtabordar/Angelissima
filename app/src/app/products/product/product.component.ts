import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { Product } from '../shared/product';
import { BarCode } from '../../barcodes/shared/barcode';

import { ProductService } from '../shared/product.service';

import Operations from '../../shared/operations'

@Component({
  selector: 'product',
  template: require('./product.component.html'),
})

export class ProductComponent implements OnInit {
  product: Product;
  errorMessage: string;
  message: string;
  private sub: any;

  constructor(private productService: ProductService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location) {
  }

  ngOnInit(): void {
    this.product = new Product;
    this.product.barCodes = new BarCode;
    this.product.minimunQuantity = 1;

    this.sub = this.route.params.subscribe(params => {
      let productId: number = +params['id'];
      if (productId) {
        this.getProduct(productId);
      }
    },
      error => console.log(error));
  }

  getProduct(id: number): void {
    this.productService.getProduct(id)
      .subscribe(
      product => this.product = product,
      error => this.errorMessage = <any>error);
  }

  updateProduct(): void {
    this.productService.updateProduct(this.product)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.errorMessage = <any>error);
  }

  insertProduct(): void {
    this.productService.insertProduct(this.product)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.errorMessage = <any>error);
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