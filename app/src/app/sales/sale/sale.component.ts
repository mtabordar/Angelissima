import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { SaleItem } from '../shared/saleItem';
import { Sale } from '../shared/sale';
import { Product } from '../../products/shared/product';
import { Item } from '../../shared/item';
import { BarCode } from '../../barcodes/shared/barcode';

import { SaleService } from '../shared/sale.service';
import { ProductService } from '../../products/shared/product.service';

@Component({
  selector: 'sale',
  template: require('./sale.component.html'),
})

export class SaleComponent implements OnInit {
  private saleItem: SaleItem;
  private sale: Sale;
  private errorMessage: string;
  private message: string;
  private productList: Product[];
  private autocompleteList: Item[];
  private totalPrice: number = 0;
  private totalCash: number = 0;

  constructor(private saleService: SaleService
    , private productService: ProductService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location) {
  }

  ngOnInit(): void {
    this.clearForm();
    this.loadInfo();
  }

  loadInfo(): void {
    this.productService.getProducts()
      .subscribe(
      productList => this.mapProductsAutocomplete(productList),
      error => this.errorMessage = <any>error);
  }

  mapProductsAutocomplete(productList: Product[]): void {
    this.productList = new Array<Product>();
    this.autocompleteList = new Array<Item>()

    this.productList = productList;
    this.autocompleteList = this.productList.map(function (product: Product): Item {
      return { id: product.productId, value: product.name }
    })
  }

  insertSale(): void {
    this.saleService.insertSale(this.sale)
      .subscribe((data) => {
        this.clearForm();
      },
      error => this.errorMessage = <any>error);
  }

  goBack(): void {
    this.location.back();
  }

  onAdd(): void {
    if (this.saleItem) {
      this.saleItem.totalPrice = this.saleItem.price * this.saleItem.quantity;
      this.totalPrice += this.saleItem.totalPrice;
      let reg = this.sale.saleItems.find(r => r.productId == this.saleItem.productId);
      if (reg) {
        reg.quantity += this.saleItem.quantity;
        reg.totalPrice += this.saleItem.price * this.saleItem.quantity;
      }
      else {
        this.sale.saleItems.push(this.saleItem);
      }
      this.saleItem = new SaleItem;
      this.saleItem.product = new Product;
      this.saleItem.product.barCodes = new BarCode;
    }
  }

  onDelete(saleItem: SaleItem): void {
    let index = this.sale.saleItems.indexOf(saleItem);
    this.sale.saleItems.splice(index, 1);
    this.totalPrice -= saleItem.totalPrice;
  }

  onSubmit(): void {
    this.insertSale();
  }

  clearForm(): void {
    this.sale = new Sale;
    this.sale.saleDate = new Date();
    this.sale.saleItems = new Array<SaleItem>();
    this.saleItem = new SaleItem;
    this.saleItem.product = new Product;
    this.saleItem.product.barCodes = new BarCode;
  }

  onValueChanged(event: any): void {
    let product: Product = this.productList.find(p => p.productId == event.id)
    this.mapProduct(product);
  }

  onBarcodeSearch(): void {
    let product: Product = this.productList.find(p => p.barCodes.barCode == this.saleItem.product.barCodes.barCode)

    this.mapProduct(product);
  }

  mapProduct(product: Product): void {
    if (product) {
      this.saleItem.product = product;
      this.saleItem.productId = this.saleItem.product.productId;
      this.saleItem.price = this.saleItem.product.salePrice;
      this.saleItem.quantity = 1;
    }
  }
}