import {
  createContext,
  useContext,
  ParentComponent,
  createMemo,
} from 'solid-js';
import { createStore } from 'solid-js/store';

interface CartItem {
  id: number;
  name: string;
  price: number;
  quantity: number;
  imageUrl?: string;
}

interface CartContextValue {
  items: CartItem[];
  addItem: (item: CartItem) => void;
  removeItem: (id: number) => void;
  updateQty: (id: number, qty: number) => void;
  clearCart: () => void;
  total: () => number;
  count: () => number;
}

const defaultState: CartItem[] = [
  { id: 1, name: 'Book1', price: 149, quantity: 1 },
  { id: 2, name: 'another book', price: 59, quantity: 2 },
];

const CartContext = createContext<CartContextValue>();

export const CartProvider: ParentComponent = (props) => {
  const [cartItems, setCartItems] = createStore<CartItem[]>(defaultState);

  const addItem = (product: CartItem) => {
    const existing = cartItems.find((i) => i.id === product.id);
    if (existing) {
      setCartItems(
        cartItems.map((i) =>
          i.id === product.id ? { ...i, quantity: product.quantity } : i,
        ),
      );
    } else {
      setCartItems((items) => [...items, { ...product, quantity: product.quantity }]);
    }
  };
  const removeItem = (id: number) =>
    setCartItems(cartItems.filter((i) => i.id !== id));
  const updateQty = (id: number, qty: number) =>
    setCartItems(
      cartItems.map((i) => (i.id === id ? { ...i, quantity: qty } : i)),
    );
  const clearCart = () => setCartItems([]);

  const total = createMemo(() =>
    cartItems.reduce((sum, i) => sum + i.price * i.quantity, 0),
  );
  const count = createMemo(() =>
    cartItems.reduce((sum, i) => sum + i.quantity, 0),
  );

  const cart: CartContextValue = {
    items: cartItems,
    addItem,
    removeItem,
    updateQty,
    clearCart,
    total,
    count,
  };
  return (
    <CartContext.Provider value={cart}>{props.children}</CartContext.Provider>
  );
};

export function useCart(): CartContextValue {
  const ctx = useContext(CartContext)
  if (!ctx) throw new Error("useCart must be used within a CartProvider")
    return ctx
}
