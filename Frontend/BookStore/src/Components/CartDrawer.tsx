import { For, Show } from 'solid-js';
import Drawer from './Drawer';
import { Component } from 'solid-js';
import { A } from '@solidjs/router';
import { type CartDrawerProps } from '../Types/cart';

const CartDrawer: Component<CartDrawerProps> = (props: CartDrawerProps) => {
  const footer = (
    <div class="space-y-3">
      <div class="flex justify-between text-sm font-medium text-everforest-fg">
        <span>Subtotal</span>
        <span class="text-everforest-fg">{props.total.toFixed(2)} kr</span>
      </div>
      <A
        href="/checkout"
        class="w-full rounded-lg bg-everforest-aqua py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2"
      >
        <button onClick={props.onClose} class="w-full rounded-lg bg-everforest-aqua py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2">
          Checkout
        </button>
      </A>
    </div>
  );

  return (
    <Drawer
      open={props.open}
      onClose={props.onClose}
      title={`Cart (${props.count})`}
      footer={footer}
    >
      <Show
        when={props.items.length > 0}
        fallback={
          <div class="flex flex-col items-center justify-center gap-3 py-20 text-everforest-fg">
            <svg
              class="h-10 w-10"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="1.5"
                d="M2.25 3h1.386c.51 0 .955.343 1.087.835l.383 1.437M7.5 14.25a3 3 0 0 0-3 3h15.75m-12.75-3h11.218c1.121-2.3 2.1-4.684 2.924-7.138a60.114 60.114 0 0 0-16.536-1.84M7.5 14.25 5.106 5.272M6 20.25a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0Zm12.75 0a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0Z"
              />
            </svg>
            <p class="text-sm">Your cart is empty</p>
          </div>
        }
      >
        <ul class="divide-y divide-everforest-fg">
          <For each={props.items}>
            {(item) => (
              <li class="flex gap-4 py-4">
                <Show when={item.imageUrl}>
                  <img
                    src={item.imageUrl}
                    alt={item.title}
                    class="h-16 w-16 rounded-md object-cover bg-neutral-100"
                  />
                </Show>
                <div class="flex flex-1 flex-col gap-1">
                  <div class="flex justify-between">
                    <span class="text-m font-medium text-everforest-aqua">
                      {item.title}
                    </span>
                    <span class="text-sm text-everforest-fg">
                      {(item.price * item.quantity).toFixed(2)} kr
                    </span>
                  </div>
                  <span class="text-xs text-everforest-fg">{item.author}</span>
                  <span class="text-xs text-everforest-fg">
                    {item.price.toFixed(2)} kr each
                  </span>
                  <div class="mt-1 flex items-center gap-2">
                    <div class="flex items-center rounded-md border border-everforest-fg">
                      <button
                        onClick={() =>
                          props.onUpdateQuantity(item.id, item.quantity - 1)
                        }
                        class="px-2 py-1 text-everforest-fg hover:text-everforest-aqua disabled:opacity-30"
                        disabled={item.quantity <= 1}
                      >
                        −
                      </button>
                      <span class="min-w-8 text-center text-everforest-fg text-sm">
                        {item.quantity}
                      </span>
                      <button
                        onClick={() =>
                          props.onUpdateQuantity(item.id, item.quantity + 1)
                        }
                        class="px-2 py-1 text-everforest-fg hover:text-everforest-aqua"
                      >
                        +
                      </button>
                    </div>
                    <button
                      onClick={() => props.onRemove(item.id)}
                      class="text-xs text-everforest-statusline-3 hover:text-red-600 hover:cursor-pointer"
                    >
                      Remove
                    </button>
                  </div>
                </div>
              </li>
            )}
          </For>
        </ul>
      </Show>
    </Drawer>
  );
};

export default CartDrawer;
