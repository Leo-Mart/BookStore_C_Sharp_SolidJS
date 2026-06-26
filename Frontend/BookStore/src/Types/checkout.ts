export type ShippingMethod =
  | 'postnord'
  | 'instabox'
  | 'budbee'
  | 'dhl'
  | 'pigeon'
  | 'paper-plane';

export type PaymentMethod = 'card' | 'invoice' | 'swish';

export type OrderInformation = {
  email: string;
  phoneNumber: string;
  socialSecurityNumber?: string;
  firstName: string;
  lastName: string;
  street: string;
  postalCode: string;
  city: string;
  shippingMethod: {
    type: ShippingMethod;
    price: number;
  };
  paymentMethod: {
    type: PaymentMethod;
    cardInfo?: {
      cardNumber?: number;
      expiryDate?: string;
      cvv?: number;
    };
  };
};

export type NewOrderPayload = {
  orderStatus: number;
  orderTotalCost: number;
  guestEmail: string;
  address: OrderAddressPayload;
  paymentMethod: OrderPaymentMethodPayload;
  items: OrderItemPayload[];
};

export type OrderItemPayload = {
  bookId: number;
  unitPrice: number;
  quantity: number;
};

export type OrderAddressPayload = {
  street: string
  city: string
  postalCode: string
}

export type OrderPaymentMethodPayload = {
  type: string
  cardLastFour?: string
  cardNumber?: string
  cvv?: string
  expiryDate?: Date
}