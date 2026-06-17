import { Component, createSignal, For } from 'solid-js';
import Percent from 'lucide-solid/icons/percent';
import Gift from 'lucide-solid/icons/gift';
import { useCart } from '../Context/CartContext';
import CheckoutItem from '../Components/CheckoutItem';
import ModalDiscountCode from '../Components/ModalDiscountCode';
import ModalGiftCard from '../Components/ModalGiftCard';

const Checkout: Component = () => {
  const [discountModalOpen, setDiscountModalOpen] = createSignal(false);
  const [giftcardModalOpen, setGiftcardModalOpen] = createSignal(false);

  const cart = useCart();

  return (
    <div class="max-w-7xl lg:max-w-7xl mx-auto">
      <div class="flex w-full flex-col gap-20 pb-48 lg:flex-row-reverse">
        <div class="lg:w-1/2">
          {/* Product info */}
          <div class="flex flex-col gap-3 bg-everforest-bg-3 p-4 lg:p-5">
            {/* header */}
            <div class="flex flex-col gap-2 text-everforest-fg">
              <h3 class="text-xl m-0">Your Order ({cart.count()})</h3>
            </div>
            {/* buy more for free shipping */}
            <div class="flex flex-col gap-2">
              <div class="border px-12 py-8 text-xs text-everforest-fg">
                <p>You have xxx kr remaining for shipping!</p>
                <div>
                  <div class="flex justify-between mb-1">
                    <span class="text-sm font-medium text-everforest-fg">
                      0 kr
                    </span>
                    <span class="text-sm font-medium text-everforest-fg">
                      250 kr
                    </span>
                  </div>
                  <div class="w-full bg-everforest-bg-5 rounded-full h-2">
                    <div
                      class="bg-everforest-aqua h-2 rounded-full"
                      style="width: 45%"
                    ></div>
                  </div>
                </div>
              </div>
            </div>
            {/* the actual items */}
            <ul class="flex flex-col gap-2 divide">
              <For each={cart.items}>
                {(item, index) => (
                  <li>
                    <CheckoutItem cartItem={item} />
                  </li>
                )}
              </For>
              <div class="flex flex-col gap-2">
                <div class="flex items-baseline justify-between font-medium text-xs">
                  <span>Total before discount</span>
                  <span>{cart.total()} kr</span>
                </div>
                <div class="flex items-baseline justify-between font-medium text-xs">
                  <span>Total discount</span>
                  <span class="text-everforest-red">-xxx kr</span>
                </div>
                <div class="flex items-baseline justify-between font-medium text-xs">
                  <span>Shipping</span>
                  <span>xxx kr</span>
                </div>
                <div class="flex items-baseline justify-between font-bold text-lg">
                  <span>Total</span>
                  <span>{cart.total()}</span>
                </div>
              </div>
              <div class="flex gap-2 flex-col md:flex-row">
                <button
                  onclick={() => setDiscountModalOpen(true)}
                  class="inline-flex items-center py-2 justify-center w-1/2 text-sm text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
                >
                  <Percent size={16} /> Add coupon-code
                </button>
                <button
                  onClick={() => setGiftcardModalOpen(true)}
                  class="inline-flex items-center py-2 justify-center w-1/2 text-sm text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
                >
                  <Gift size={16} /> Add gift-card
                </button>
              </div>
            </ul>
          </div>
        </div>
        <div class="lg:w-1/2">
          {/* Adress, paymentinfo and shipping selection */}
        </div>
      </div>
      <ModalDiscountCode
        open={discountModalOpen()}
        onClose={() => setDiscountModalOpen(false)}
      />
      <ModalGiftCard
        open={giftcardModalOpen()}
        onClose={() => setGiftcardModalOpen(false)}
      />
    </div>
  );
};

export default Checkout;
