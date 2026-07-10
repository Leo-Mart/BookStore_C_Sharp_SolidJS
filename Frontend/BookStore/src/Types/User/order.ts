import { BasicBookInfo } from "../book";
import { ShippingMethod } from "../checkout";

export interface Order {
  orderStatus: OrderStatus;
  orderTotalCost: number;
  items: OrderItem[];
  shippingMethod: ShippingMethod;
  createdAt: string;
  orderNumber: number;
}

export interface OrderItem {
  unitPrice: number;
  quantity: number;
  Book: BasicBookInfo;
}

export enum OrderStatus {
  Pending = 1,
  Confirmed,
  Shipped,
  Delivered,
  Cancelled,
}
