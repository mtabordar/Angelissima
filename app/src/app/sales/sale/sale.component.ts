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
import { TranslateService } from 'ng2-translate';

import { AlertType } from '../../shared/enums';
import { Message } from '../../messages/shared/message';

@Component({
  selector: 'sale',
  template: require('./sale.component.html'),
})

export class SaleComponent implements OnInit {
  private saleItem: SaleItem;
  private sale: Sale;
  private alertType: string = "danger";
  private productList: Product[];
  private autocompleteList: Item[];
  private totalCash: number = 0;
  private message: Message;

  constructor(private saleService: SaleService
    , private productService: ProductService
    , private location: Location
    , private translate: TranslateService) {
  }

  ngOnInit(): void {
    this.message = new Message;

    this.clearForm();
    this.loadInfo();
  }

  loadInfo(): void {
    this.productService.getProducts()
      .subscribe(
      productList => this.mapProductsAutocomplete(productList),
      error => this.message.message = error);
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
        this.translate.get('SAVEMESSAGE').subscribe((res: string) => {
          this.message.message = res;
          this.message.alertType = AlertType.success;
        });
      },
      error => this.message.message = error)
  }

  goBack(): void {
    this.location.back();
  }

  onAdd(): void {
    if (this.saleItem.productId) {
      this.saleItem.totalPrice = this.saleItem.price * this.saleItem.quantity;
      this.sale.totalPrice += this.saleItem.totalPrice;
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
    this.sale.totalPrice -= saleItem.totalPrice;
  }

  onSubmit(): void {
    this.insertSale();
  }

  clearForm(): void {
    this.sale = new Sale;
    this.sale.totalPrice = 0;
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