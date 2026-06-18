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
          <form class="flex flex-col gap-3 bg-everforest-bg-3 p-4 lg:p-5">
            {/* Adress, paymentinfo and shipping selection */}
            <div class="flex flex-col gap-2 text-everforest-fg">
              <h3 class="text-xl m-0">Your information</h3>
            </div>
            <div class="border-b border-everforest-fg">
              <div>
                <div class="grid gap-6 mb-6 md:grid-cols-2">
                  <div class="md:col-span-2">
                    <label
                      for="email"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Email address
                      </span>
                      <input
                        type="text"
                        name="email"
                        placeholder="johndoe@youremail.com"
                        id="email"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="md:col-span-2">
                    <label
                      for="phone_number"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Phone number
                      </span>
                      <input
                        type="text"
                        name="phone_number"
                        placeholder="0123-456789"
                        id="phone_number"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="flex gap-2 md:col-span-2">
                    <div class="grow">
                      <label
                        for="socialsecurity_number"
                        class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                      >
                        <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                          Social Security number
                        </span>
                        <input
                          type="text"
                          name="socialsecurity_number"
                          placeholder="100101-1111"
                          id="socialsecurity_number"
                          class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                          required
                        />
                      </label>
                      <span class="text-xs text-everforest-fg">
                        Add Social-security number to automatically fetch
                        address and pay by invoice.
                      </span>
                    </div>

                    <button class="bg-everforest-aqua px-1 h-1/2 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2">
                      Fetch Address
                    </button>
                  </div>

                  <div>
                    <label
                      for="first_name"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        First name
                      </span>
                      <input
                        type="text"
                        name="first_name"
                        placeholder="John"
                        id="first_name"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div>
                    <label
                      for="first_name"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Last name
                      </span>
                      <input
                        type="text"
                        name="last_name"
                        placeholder="Doe"
                        id="last_name"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="md:col-span-2">
                    <label
                      for="address"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Address
                      </span>
                      <input
                        type="text"
                        name="address"
                        placeholder="The Street 123 A"
                        id="address"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="md:col-span-2 flex gap-2">
                    <label
                      for="postal_code"
                      class="w-1/2 block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Postal Code
                      </span>
                      <input
                        type="text"
                        name="postal_code"
                        placeholder="123 45"
                        id="postal_code"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                    <label
                      for="city"
                      class="w-1/2 block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        City
                      </span>
                      <input
                        type="text"
                        name="city"
                        placeholder="The City"
                        id="city"
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                </div>
              </div>
            </div>
            <div class="border-b border-everforest-fg">
              <div class="flex flex-col gap-2 text-everforest-fg">
                <h3 class="text-xl m-0">Shipping Method</h3>
              </div>
              <div>
                <fieldset>
                  <legend class="sr-only">Shipping Methods</legend>

                  <div class="flex items-center mb-4">
                    <input
                      id="shipping-option-1"
                      type="radio"
                      name="shipping-methods"
                      value="instabox"
                      class="w-4 h-4 rounded-full checked:border-everforest-fg focus:ring-2 focus:outline-none border appearance-none"
                      checked
                    />
                    <label
                      for="country-option-1"
                      class="select-none ms-2 text-sm font-medium"
                    >
                      Instabox
                    </label>
                  </div>

                  <div class="flex items-center mb-4">
                    <input
                      id="shipping-option-2"
                      type="radio"
                      name="shipping-methods"
                      value="budbee"
                      class="w-4 h-4 rounded-full focus:ring-2 focus:outline-none border appearance-none"
                    />
                    <label
                      for="country-option-2"
                      class="select-none ms-2 text-sm font-medium"
                    >
                      Budbee
                    </label>
                  </div>

                  <div class="flex items-center mb-4">
                    <input
                      id="shipping-option-3"
                      type="radio"
                      name="shipping-methods"
                      value="postnord"
                      class="w-4 h-4 rounded-full focus:ring-2 focus:outline-none border appearance-none"
                    />
                    <label
                      for="country-option-3"
                      class="select-none ms-2 text-sm font-medium"
                    >
                      Postnord
                    </label>
                  </div>

                  <div class="flex items-center mb-4">
                    <input
                      id="shipping-option-4"
                      type="radio"
                      name="shipping-methods"
                      value="dhl"
                      class="w-4 h-4 rounded-full focus:ring-2 focus:outline-none border appearance-none"
                    />
                    <label
                      for="country-option-4"
                      class="select-none ms-2 text-sm font-medium"
                    >
                      DHL
                    </label>
                  </div>

                  <div class="flex items-center mb-4">
                    <input
                      id="shipping-option-4"
                      type="radio"
                      name="shipping-methods"
                      value="pigeon"
                      class="w-4 h-4 rounded-full focus:ring-2 focus:outline-none border appearance-none"
                    />
                    <label
                      for="country-option-4"
                      class="select-none ms-2 text-sm font-medium"
                    >
                      Pigeon
                    </label>
                  </div>
                </fieldset>
              </div>
            </div>
            <div>
              <div class="flex flex-col gap-2 text-everforest-fg">
                <h3 class="text-xl m-0">Payment Method</h3>
              </div>

              <div class="max-w-sm mx-auto mt-4">
                <label for="card-number-input" class="sr-only">
                  Card number:
                </label>
                <div class="relative">
                  <input
                    type="text"
                    id="card-number-input"
                    class="border border-everforest-bg-dim dark:bg-everforest-bg-0 text-sm block w-full px-3 py-2.5 shadow-xs placeholder:dark:text-everforest-fg pe-9"
                    placeholder="4242 4242 4242 4242"
                    pattern="^4[0-9]{12}(?:[0-9]{3})?$"
                    required
                  />
                  <div class="absolute inset-y-0 end-0 top-0 flex items-center pe-3.5 pointer-events-none">
                    <svg
                      fill="none"
                      class="h-6 dark:text-everforest-fg"
                      viewBox="0 0 36 21"
                    >
                      <path
                        fill="currentColor"
                        d="M23.315 4.773c-2.542 0-4.813 1.3-4.813 3.705 0 2.756 4.028 2.947 4.028 4.332 0 .583-.676 1.105-1.832 1.105-1.64 0-2.866-.73-2.866-.73l-.524 2.426s1.412.616 3.286.616c2.78 0 4.966-1.365 4.966-3.81 0-2.913-4.045-3.097-4.045-4.383 0-.457.555-.957 1.708-.957 1.3 0 2.36.53 2.36.53l.514-2.343s-1.154-.491-2.782-.491zM.062 4.95L0 5.303s1.07.193 2.032.579c1.24.442 1.329.7 1.537 1.499l2.276 8.664h3.05l4.7-11.095h-3.043l-3.02 7.543L6.3 6.1c-.113-.732-.686-1.15-1.386-1.15H.062zm14.757 0l-2.387 11.095h2.902l2.38-11.096h-2.895zm16.187 0c-.7 0-1.07.37-1.342 1.016L25.41 16.045h3.044l.589-1.68h3.708l.358 1.68h2.685L33.453 4.95h-2.447zm.396 2.997l.902 4.164h-2.417l1.515-4.164z"
                      />
                    </svg>
                  </div>
                </div>
                <div class="grid grid-cols-3 gap-4 my-4">
                  <div class="relative max-w-sm col-span-2">
                    <div class="absolute inset-y-0 start-0 flex items-center ps-3.5 pointer-events-none">
                      <svg
                        class="w-4 h-4 dark:text-everforest-fg"
                        aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg"
                        width="24"
                        height="24"
                        fill="none"
                        viewBox="0 0 24 24"
                      >
                        <path
                          stroke="currentColor"
                          stroke-linecap="round"
                          stroke-linejoin="round"
                          stroke-width="2"
                          d="M4 10h16m-8-3V4M7 7V4m10 3V4M5 20h14a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H5a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1Zm3-7h.01v.01H8V13Zm4 0h.01v.01H12V13Zm4 0h.01v.01H16V13Zm-8 4h.01v.01H8V17Zm4 0h.01v.01H12V17Zm4 0h.01v.01H16V17Z"
                        />
                      </svg>
                    </div>
                    <label for="card-expiration-input" class="sr-only">
                      Card expiration date:
                    </label>
                    <input
                      id="card-expiration-input"
                      type="text"
                      class="border border-everforest-bg-dim dark:bg-everforest-bg-0 text-sm rounded-base block w-full ps-9 pe-3 py-2.5 shadow-xs placeholder:dark:text-everforest-fg"
                      placeholder="12/23"
                      required
                    />
                  </div>
                  <div class="col-span-1">
                    <label for="cvv-input" class="sr-only">
                      Card CVV code:
                    </label>
                    <input
                      type="number"
                      id="cvv-input"
                      aria-describedby="helper-text-explanation"
                      class="border border-everforest-bg-dim dark:bg-everforest-bg-0 text-sm rounded-base block w-full px-3 py-2.5 shadow-xs placeholder:dark:text-everforest-fg [appearance:textfield] [&::-webkit-outer-spin-button]:appearance-none [&::webkit-inner-spin-button]:appearance-none"
                      placeholder="CVV"
                      required
                    />
                  </div>
                </div>
              </div>
            </div>
          </form>
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
