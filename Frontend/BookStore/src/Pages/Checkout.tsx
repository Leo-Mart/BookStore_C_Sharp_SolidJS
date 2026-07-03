import { Component, createResource, createSignal, For } from 'solid-js';
import { createStore, produce } from 'solid-js/store';
import Percent from 'lucide-solid/icons/percent';
import Gift from 'lucide-solid/icons/gift';
import { useCart } from '../Context/CartContext';
import CheckoutItem from '../Components/CheckoutItem';
import ModalDiscountCode from '../Components/ModalDiscountCode';
import ModalGiftCard from '../Components/ModalGiftCard';
import { useAuth } from '../Context/AuthContext';
import { useNavigate } from '@solidjs/router';
import {
  type OrderInformation,
  NewOrderPayload,
  OrderItemPayload,
  ShippingMethod,
} from '../Types/checkout';

const fetchShippingMethods = async () => {
  const response = await fetch('api/shipping-methods');
  return response.json();
};

const Checkout: Component = () => {
  const [discountModalOpen, setDiscountModalOpen] = createSignal(false);
  const [giftcardModalOpen, setGiftcardModalOpen] = createSignal(false);
  const [shippingMethods] = createResource<ShippingMethod[]>(fetchShippingMethods);

  const cart = useCart();
  const auth = useAuth();
  const nav = useNavigate();

  const [formData, setFormData] = createStore<OrderInformation>({
    email: '',
    phoneNumber: '',
    socialSecurityNumber: '',
    firstName: '',
    lastName: '',
    street: '',
    postalCode: '',
    city: '',
    shippingMethod: {
      identifier: 'postnord-pick',
      type: 'pick-up',
      price: 49,
    },
    paymentMethod: {
      type: 'card',
      cardInfo: {
        cardNumber: 4242424242424242,
        expiryDate: '',
        cvv: 123,
      },
    },
  });

  

  const handleInputChange = (
    e: Event & {
      currentTarget: HTMLInputElement;
    },
  ) => {
    const { name, value, type } = e.currentTarget;
    const coercedValue = type === 'number' ? Number(value) : value;
    const path = name.split('.') as any;

    setFormData(
      produce((task) => {
        let node: any = task;
        for (let i = 0; i < path.length - 1; i++) {
          node = node[path[i]];
        }
        node[path[path.length - 1]] = coercedValue;

        if (name == 'shippingMethod.identifier'){
          const foundMethod = shippingMethods.latest!.find(sm => sm.identifier == coercedValue)
          task.shippingMethod.price = foundMethod!.price
          task.shippingMethod.type = foundMethod!.type
        }

        if (name === 'paymentMethod.type' && coercedValue !== 'card') {
          task.paymentMethod.cardInfo = {
            cardNumber: 4242424242424242,
            expiryDate: '',
            cvv: 123,
          };
        }
      }),
    );
  };

  const handleFetchAdress = () => {
    console.log('Fetch the address based on social security number');
  };

  const handleOrderSubmit = async (e: Event) => {
    e.preventDefault();

    let date = new Date();
    if (formData.paymentMethod.cardInfo?.expiryDate) {
      let time: number = Date.parse(
        formData.paymentMethod.cardInfo?.expiryDate,
      );
      date = new Date(time);
    }

    const payload: NewOrderPayload = {
      orderStatus: 1,
      orderTotalCost: cart.total(),
      address: {
        street: formData.street,
        city: formData.city,
        postalCode: formData.postalCode,
      },
      guestEmail: auth.isAuthenticated() ? '' : formData.email,
      shippingMethod: {
        identifier: formData.shippingMethod.identifier,
        type: formData.shippingMethod.type,
        price: formData.shippingMethod.price
      },
      paymentMethod: {
        type: formData.paymentMethod.type,
        cardLastFour: formData.paymentMethod.cardInfo?.cardNumber
          ?.toString()
          .slice(-4),
        cardNumber: formData.paymentMethod.cardInfo?.cardNumber?.toString(),
        cvv: formData.paymentMethod.cardInfo?.cvv?.toString(),
        expiryDate: date,
      },
      items: cart.items.map((item) => {
        var items: OrderItemPayload = {
          bookId: item.id,
          unitPrice: item.price,
          quantity: item.quantity,
        };
        return items;
      }),
    };

    const resp = await fetch('/api/orders', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${auth.token()}`,
      },
      body: JSON.stringify({
        items: payload.items,
        address: payload.address,
        guestEmail: payload.guestEmail,
        shippingMethod: payload.shippingMethod,
        paymentMethod: payload.paymentMethod,
        orderTotalCost: payload.orderTotalCost,
        orderStatus: payload.orderStatus,
      }),
    });
    const result = await resp.json();
    cart.clearCart();
    nav('/order/confirmation', { state: result.items });
  };

  return (
    <div class="max-w-7xl lg:max-w-7xl mx-auto">
      <div class="flex w-full flex-col gap-20 pb-48 lg:flex-row-reverse">
        <div class="lg:w-1/2">
          <div class="flex flex-col gap-3 bg-everforest-bg-3 p-4 lg:p-5">
            <div class="flex flex-col gap-2 text-everforest-fg">
              <h3 class="text-xl m-0">Your Order ({cart.count()})</h3>
            </div>
            <div class="flex flex-col gap-2">
              <div class="border px-12 py-8 text-xs text-everforest-fg">
                <p>You have {250 - cart.total() > 0 ? `${(250 - cart.total()).toFixed(1)} kr remaining for free shipping!`: `unlocked free shipping!` } </p>
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
                      style={`width: ${(cart.total() / 250) * 100 > 100 ? 100 : (cart.total() / 250) * 100}%`}
                    ></div>
                  </div>
                </div>
              </div>
            </div>
            <ul class="flex flex-col gap-2 divide">
              <For each={cart.items}>
                {(item, _) => (
                  <li>
                    <CheckoutItem cartItem={item} />
                  </li>
                )}
              </For>
              <div class="flex flex-col gap-2">
                <div class="flex items-baseline justify-between font-medium text-xs">
                  <span>Total before discount</span>
                  <span>{cart.total().toFixed(2)} kr</span>
                </div>
                <div class="flex items-baseline justify-between font-medium text-xs">
                  <span>Total discount</span>
                  <span class="text-everforest-red">-xxx kr</span>
                </div>
                <div class="flex items-baseline justify-between font-medium text-xs">
                  <span>Shipping</span>
                  <span>{cart.total() > 250 ? 'Free!' : `${formData.shippingMethod.price} kr`}</span>
                </div>
                <div class="flex items-baseline justify-between font-bold text-lg">
                  <span>Total</span>
                  <span>{(formData.shippingMethod.price + cart.total()).toFixed(2)}</span>
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
          <form
            onSubmit={handleOrderSubmit}
            class="flex flex-col gap-3 bg-everforest-bg-3 p-4 lg:p-5"
          >
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
                        value={formData.email}
                        onInput={handleInputChange}
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="md:col-span-2">
                    <label
                      for="phone"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Phone number
                      </span>
                      <input
                        type="text"
                        name="phone"
                        placeholder="0123-456789"
                        id="phone_number"
                        value={formData.phoneNumber}
                        onInput={handleInputChange}
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="flex gap-2 md:col-span-2">
                    <div class="grow">
                      <label
                        for="socialSecurityNumber"
                        class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                      >
                        <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                          Social Security number
                        </span>
                        <input
                          type="text"
                          name="socialSecurityNumber"
                          placeholder="100101-1111"
                          id="socialsecurity_number"
                          value={formData.socialSecurityNumber}
                          onInput={handleInputChange}
                          class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        />
                      </label>
                      <span class="text-xs text-everforest-fg">
                        Add Social-security number to automatically fetch
                        address and pay by invoice.
                      </span>
                    </div>

                    <button
                      type="button"
                      onClick={handleFetchAdress}
                      class="bg-everforest-aqua px-1 h-1/2 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2"
                    >
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
                        name="firstName"
                        placeholder="John"
                        id="first_name"
                        value={formData.firstName}
                        onInput={handleInputChange}
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div>
                    <label
                      for="lastName"
                      class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Last name
                      </span>
                      <input
                        type="text"
                        name="lastName"
                        placeholder="Doe"
                        id="last_name"
                        value={formData.lastName}
                        onInput={handleInputChange}
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
                        name="street"
                        placeholder="The Street 123 A"
                        id="address"
                        value={formData.street}
                        onInput={handleInputChange}
                        class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                        required
                      />
                    </label>
                  </div>
                  <div class="md:col-span-2 flex gap-2">
                    <label
                      for="postalCode"
                      class="w-1/2 block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
                    >
                      <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                        Postal Code
                      </span>
                      <input
                        type="text"
                        name="postalCode"
                        placeholder="123 45"
                        id="postal_code"
                        value={formData.postalCode}
                        onInput={handleInputChange}
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
                        value={formData.city}
                        onInput={handleInputChange}
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
                <h3 class="text-xl m-0 pb-2">Shipping Method</h3>
              </div>
              <div>
                <fieldset>
                  <legend class="sr-only">Shipping Methods</legend>

                  <For each={shippingMethods()}>
                    {(item, _) => (
                        <div class="flex flex-col items-center mb-4">
                          <input
                            id={item.identifier}
                            type="radio"
                            name="shippingMethod.identifier"
                            value={item.identifier}
                            class="peer hidden"
                            checked={
                              formData.shippingMethod.identifier ===
                              item.identifier
                            }
                            onChange={handleInputChange}
                          />
                          <label
                            for={item.identifier}
                            class="flex items-center justify-between bg-everforest-aqua w-full p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
                          >
                            {item.identifier}
                          </label>
                          <div
                            class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                              formData.shippingMethod.identifier ===
                              item.identifier
                                ? 'grid-rows-[1fr] opacity-100'
                                : 'grid-rows-[0fr] opacity-0'
                            }`}
                          >
                            <div class="overflow-hidden w-full flex justify-between">
                              <p>{item.description}</p>
                              <span>{item.price} kr</span>
                            </div>
                          </div>
                        </div>
                    )}
                  </For>         
                </fieldset>
              </div>
            </div>
            <div class="border-b border-everforest-fg">
              <div class="flex flex-col gap-2 text-everforest-fg">
                <h3 class="text-xl m-0">Payment Method</h3>
              </div>

              <fieldset>
                <legend class="sr-only">Payment methods</legend>

                <div class="flex flex-col items-center mb-4">
                  <input
                    id="card"
                    type="radio"
                    name="paymentMethod.type"
                    value="card"
                    class="peer hidden"
                    checked={formData.paymentMethod.type === 'card'}
                    onChange={handleInputChange}
                  />
                  <label
                    for="card"
                    class="flex items-center justify-between bg-everforest-aqua w-full p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
                  >
                    Card
                  </label>
                  <div
                    class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                      formData.paymentMethod.type === 'card'
                        ? 'grid-rows-[1fr] opacity-100'
                        : 'grid-rows-[0fr] opacity-0'
                    }`}
                  >
                    <div class="overflow-hidden w-full flex justify-between">
                      <div class="max-w-sm mx-auto mt-4">
                        <label for="card-number-input" class="sr-only">
                          Card number:
                        </label>
                        <div class="relative">
                          <input
                            type="text"
                            id="card-number-input"
                            name="paymentMethod.cardInfo.number"
                            class="border border-everforest-bg-dim dark:bg-everforest-bg-0 text-sm block w-full px-3 py-2.5 shadow-xs placeholder:dark:text-everforest-fg pe-9"
                            placeholder="4242 4242 4242 4242"
                            pattern="^4[0-9]{12}(?:[0-9]{3})?$"
                            value={formData.paymentMethod.cardInfo?.cardNumber}
                            onChange={handleInputChange}
                          />
                          <div class="absolute inset-y-0 inset-e-0 top-0 flex items-center pe-3.5 pointer-events-none">
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
                            <div class="absolute inset-y-0 inset-s-0 flex items-center ps-3.5 pointer-events-none">
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
                              name="paymentMethod.cardInfo.expiry"
                              type="text"
                              class="border border-everforest-bg-dim dark:bg-everforest-bg-0 text-sm rounded-base block w-full ps-9 pe-3 py-2.5 shadow-xs placeholder:dark:text-everforest-fg"
                              placeholder="12/23"
                              value={
                                formData.paymentMethod.cardInfo?.expiryDate
                              }
                              onChange={handleInputChange}
                            />
                          </div>
                          <div class="col-span-1">
                            <label for="cvv-input" class="sr-only">
                              Card CVV code:
                            </label>
                            <input
                              type="number"
                              id="cvv-input"
                              name="paymentMethod.cardInfo.cvv"
                              aria-describedby="helper-text-explanation"
                              class="border border-everforest-bg-dim dark:bg-everforest-bg-0 text-sm rounded-base block w-full px-3 py-2.5 shadow-xs placeholder:dark:text-everforest-fg [appearance:textfield] [&::-webkit-outer-spin-button]:appearance-none [&::webkit-inner-spin-button]:appearance-none"
                              placeholder="CVV"
                              value={formData.paymentMethod.cardInfo?.cvv}
                              onChange={handleInputChange}
                            />
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="flex flex-col items-center mb-4">
                  <input
                    id="invoice"
                    type="radio"
                    name="paymentMethod.type"
                    value="invoice"
                    class="peer hidden"
                    checked={formData.paymentMethod.type === 'invoice'}
                    onChange={handleInputChange}
                  />
                  <label
                    for="invoice"
                    class="flex items-center justify-between bg-everforest-aqua w-full p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
                  >
                    Invoice
                  </label>
                </div>
                <div
                  class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                    formData.paymentMethod.type === 'invoice'
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden w-full flex justify-between">
                    Pay by invoice
                  </div>
                </div>
                <div class="flex flex-col items-center mb-4">
                  <input
                    id="swish"
                    type="radio"
                    name="paymentMethod.type"
                    value="swish"
                    class="peer hidden"
                    checked={formData.paymentMethod.type === 'swish'}
                    onChange={handleInputChange}
                  />
                  <label
                    for="swish"
                    class="flex items-center justify-between bg-everforest-aqua w-full p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
                  >
                    Swish
                  </label>
                </div>
                <div
                  class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                    formData.paymentMethod.type === 'swish'
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden w-full flex justify-between">
                    Pay by swish
                  </div>
                </div>
              </fieldset>
            </div>
            <button
              type="submit"
              class="flex items-center justify-center bg-everforest-aqua w-full p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
            >
              Place Order
            </button>
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
