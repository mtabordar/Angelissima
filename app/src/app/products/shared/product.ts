import { BarCode } from '../../barcodes/shared/barcode';

export class Product {
  productId: number;
  name: string;
  description: string;
  unitPrice: number;
  salePrice: number;
  minimunQuantity: number = 1;
  barCodes: BarCode;
}