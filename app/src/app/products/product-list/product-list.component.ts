import { Component } from '@angular/core';
import { Product } from '../shared/product';

import { ProductService } from '../shared/product.service';
import { OnInit } from '@angular/core';

@Component({
  selector: 'products-list',
  template: require('./product-list.component.html'),
  providers: [ProductService]
})

export class ProductListComponent implements OnInit {
  products: Product[];
  selectedProduct: Product;
  errorMessage: string;
  message: string;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts().subscribe(
      products => this.products = products,
      error => this.errorMessage = <any>error);
  }

  onSelect(product: Product): void {
    this.selectedProduct = product;
  }

   onDelete(id: number): void{
    this.productService.deleteProduct(id)
    .subscribe(message => this.message = message,
      error => this.errorMessage = <any>error);
  }
}



