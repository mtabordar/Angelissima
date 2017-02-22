import { Product } from '../../products/shared/product';

export class SaleItem {
  quantity: number;
  price: number;
  totalPrice: number;
  productId: number;
  product: Product;
}