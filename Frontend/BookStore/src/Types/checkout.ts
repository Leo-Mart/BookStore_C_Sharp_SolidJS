export type ShippingIdentifier =
  | 'postnord-pick' 
  | 'postnord-home'
  | 'instabox-box'
  | 'budbee-box'
  | 'dhl-pick'

export type ShippingType = 'pick-up' | 'home' | 'box'

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
  shippingMethod: ShippingMethod
  paymentMethod: {
    type: PaymentMethod;
    cardInfo?: {
      cardNumber?: number;
      expiryDate?: string;
      cvv?: number;
    };
  };
};

export type ShippingMethod = {
  identifier: ShippingIdentifier;
  type: ShippingType;
  price: number;
  description?: string
}

export type NewOrderPayload = {
  orderStatus: number;
  orderTotalCost: number;
  guestEmail: string;
  address: OrderAddressPayload;
  shippingMethod: OrderShippingMethodPayload;
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

export type OrderShippingMethodPayload = {
  company: string
  type: string
  price: number
}