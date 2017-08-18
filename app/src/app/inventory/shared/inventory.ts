import { Product } from '../../products/shared/product';

export class Inventory {
  registrationDate: Date;
  quantity: number;
  productId: number;
  product: Product;
}