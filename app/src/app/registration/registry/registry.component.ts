import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { Registry } from '../shared/registry';
import { Product } from '../../products/shared/product';
import { Item } from '../../shared/item';
import { BarCode } from '../../barcodes/shared/barcode';

import { RegistrationService } from '../shared/registration.service';
import { ProductService } from '../../products/shared/product.service';

@Component({
  selector: 'registry',
  template: require('./registry.component.html'),
})

export class RegistryComponent implements OnInit {
  private registry: Registry;
  private errorMessage: string;
  private message: string;
  private productList: Product[];
  private registryList: Registry[];
  private autocompleteList: Item[];
  private selectedproductName: string;
  private totalPrice: number = 0;
  private totalCash: number = 0;

  constructor(private registryService: RegistrationService
    , private productService: ProductService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location) {

  }

  ngOnInit(): void {
    this.registry = new Registry;
    this.registry.product = new Product;
    this.registry.saleDate = new Date();
    this.registryList = new Array<Registry>();
    this.productList = new Array<Product>();
    this.autocompleteList = new Array<Item>()

    this.loadInfo();
  }

  loadInfo(): void {
    this.productService.getProducts()
      .subscribe(
      productList => this.mapProductsAutocomplete(productList),
      error => this.errorMessage = <any>error);
  }

  mapProductsAutocomplete(productList: Product[]): void {
    this.productList = productList;
    this.autocompleteList = this.productList.map(function (product: Product): Item {
      return { id: product.productId, value: product.name }
    })
  }

  insertRegistry(): void {
    this.registryService.insertRegistry(this.registryList)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.errorMessage = <any>error);
  }

  goBack(): void {
    this.location.back();
  }

  onAdd(): void {
    this.registry.totalPrice = this.registry.price * this.registry.quantity;
    this.totalPrice += this.registry.totalPrice;
    this.registryList.push(this.registry);
    this.registry = new Registry;
    this.registry.product = new Product;
    this.selectedproductName = "";
  }

  // onSubmit(): void {
  //   this.insertRegistry();
  // }

  onValueChanged(event: any): void {
    var item = this.productList.filter(p => p.productId == event.id)[0]
    if (item) {
      this.registry.product = item;
      this.registry.productId = this.registry.product.productId;
      this.registry.price = this.registry.product.salePrice;
      this.registry.quantity = 1;
    }
  }
}