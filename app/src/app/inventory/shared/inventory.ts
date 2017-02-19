import { Product } from '../../products/shared/product';

export class Inventory {
  registrationDate: Date;
  quantity: number;
  totalQuantity: number;
  productId: number;
  product: Product;
}