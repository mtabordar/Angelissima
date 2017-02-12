import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { Registry } from '../shared/registry';

import { RegistrationService } from '../shared/registration.service';

@Component({
  selector: 'registry',
  template: require('./registry.component.html'),
})

export class RegistryComponent {
  registry: Registry;
  errorMessage: string;
  message: string;
  showDatePicker: boolean;
  minDate: Date;
  private sub: any;

  constructor(private productService: RegistrationService
    , private route: ActivatedRoute
    , private router: Router
    , private location: Location) {
    this.registry = new Registry;
  }

  getProduct(id: number): void {
    this.productService.getProduct(id)
      .subscribe(
      registry => this.registry = registry,
      error => this.errorMessage = <any>error);
  }

  insertProduct(): void {
    this.productService.insertProduct(this.registry)
      .subscribe((data) => {
        this.router.navigate(['products']);
      },
      error => this.errorMessage = <any>error);
  }

  goBack(): void {
    this.location.back();
  }

  onSubmit(): void {
    this.insertProduct();
  }

  onSelectionDone($event) {
    this.showDatePicker = false;
  }
}