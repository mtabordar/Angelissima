import { Component } from '@angular/core';
import { Product } from '../shared/product';
import { Router } from '@angular/router';

import { ProductService } from '../shared/product.service';
import { OnInit } from '@angular/core';

@Component({
  selector: 'products-list',
  template: require('./product-list.component.html'),
  providers: [ProductService]
})

export class ProductListComponent implements OnInit {
  products: Product[];
  filteredProducts: Product[];
  errorMessage: string;
  message: string;
  public totalItems: number;
  public currentPage: number;
  public smallnumPages: number;

  constructor(private productService: ProductService,
    private router: Router) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts().subscribe(
      products => this.loadInfo(products),
      error => this.errorMessage = <any>error);
  }

  loadInfo(products: Product[]): void {
    this.products = products;
    this.totalItems = products.length;
    this.filteredProducts = products.slice(0, 10);
  }

  onDelete(id: number): void {
    this.productService.deleteProduct(id)
      .subscribe((data) => {
        var index = this.products.indexOf(this.products.filter(p => p.productId == id)[0]);
        this.products.splice(index, this.products.length < 10 ? this.products.length : 10);
      },
      error => this.errorMessage = <any>error);
  }

  public setPage(pageNo: number): void {
    this.currentPage = pageNo;
  }

  public pageChanged(event: any): void {
    let initialIndex = ((event.page - 1) * event.itemsPerPage);
    let finalIndex = (event.page * event.itemsPerPage);

    this.filteredProducts = this.products.slice(initialIndex, finalIndex);
  }
}



