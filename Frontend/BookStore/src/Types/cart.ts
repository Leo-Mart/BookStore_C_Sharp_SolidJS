export interface CartItem {
  id: number;
  title: string;
  author: string;
  price: number;
  quantity: number;
  imageUrl?: string;
}

export interface CartDrawerProps {
  open: boolean;
  onClose: () => void;
  items: CartItem[];
  total: number;
  count: number;
  onRemove: (id: number) => void;
  onUpdateQuantity: (id: number, qty: number) => void;
}

export interface cartItemProps {
  cartItem: {
    id: number
    title: string
    author: string
    price: number
    quantity: number
    imageUrl?: string
  }
}

export interface CartContextValue {
  items: CartItem[];
  addItem: (item: CartItem) => void;
  removeItem: (id: number) => void;
  updateQty: (id: number, qty: number) => void;
  clearCart: () => void;
  total: () => number;
  count: () => number;
}