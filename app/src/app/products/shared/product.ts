import { BarCode } from '../../barcodes/shared/barcode';

export class Product {
  productId: number;
  name: string;
  description: string;
  unitPrice: number;
  salePrice: number;
  minimunQuantity: number;
  barCodes: BarCode;
}