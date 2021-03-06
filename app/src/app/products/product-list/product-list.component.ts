import { Component } from '@angular/core';
import { Product } from '../shared/product';

import { ProductService } from '../shared/product.service';
import { OnInit } from '@angular/core';

import { Message } from '../../messages/shared/message';

@Component({
  selector: 'products-list',
  templateUrl: './product-list.component.html'
})

export class ProductListComponent implements OnInit {
  private products: Product[];
  private filteredProducts: Product[];  
  private message: Message;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts().subscribe(
      products => this.loadInfo(products),
      error => this.message = <Message>error);
  }

  loadInfo(products: Product[]): void {
    this.products = products;    
    this.filteredProducts = products.slice(0, 10);
  }

  onDelete(product: Product): void {
    this.productService.deleteProduct(product.productId)
      .subscribe((data) => {
        var index = this.filteredProducts.indexOf(product);
        this.filteredProducts.splice(index, 1);
      },
      error => this.message = <Message>error);
  }

  public pageChanged(event: any): void {
    let initialIndex = ((event.page - 1) * event.itemsPerPage);
    let finalIndex = (event.page * event.itemsPerPage);

    this.filteredProducts = this.products.slice(initialIndex, finalIndex);
  }
}



