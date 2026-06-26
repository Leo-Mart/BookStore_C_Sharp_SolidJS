import { Component } from 'solid-js';
import Trash2 from 'lucide-solid/icons/trash-2';
import { useCart } from '../Context/CartContext';

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

const CheckoutItem: Component<cartItemProps> = (cartItemProps) => {
  const cart = useCart();
  return (
    <article class="border-everforest-fg flex flex-col gap-2 border p-2">
      <div class="flex gap-2 items-center">
        <div class="w-15.75 flex items-center justify-center">
          <img
            class="h-full w-auto object-contain"
            src="./images/atbqj8.jpg"
          ></img>
        </div>
        <div class="flex flex-1 flex-col justify-center gap-2">
          <h5 class="text-xl line-clamp-2">{cartItemProps.cartItem.title}</h5>
          <p class="text-xs">{cartItemProps.cartItem.author}</p>
        </div>
      </div>
      <div class="text-xs">SHIPPING AVAILABILITY</div>
      <div class="flex justify-between items-center h-4">
        <div class="flex flex-col">
          <span>{cartItemProps.cartItem.price} kr</span>
        </div>
        <div class="flex gap-2">
          <button class="flex items-center justify-center bg-white w-full rounded-md text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer">
            Change amount
          </button>
          <button onClick={() => cart.removeItem(cartItemProps.cartItem.id)} class="flex items-center justify-center text-sm font-medium text-everforest-fg hover:cursor-pointer">
            <Trash2 />
          </button>
        </div>
      </div>
    </article>
  );
};

export default CheckoutItem;
