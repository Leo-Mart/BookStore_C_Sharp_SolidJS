import { Component, createResource, createSignal, For } from "solid-js";
import Percent from "lucide-solid/icons/percent";
import Gift from "lucide-solid/icons/gift";
import { useCart } from "../Context/CartContext";
import CheckoutItem from "../Components/CheckoutItem";
import ModalDiscountCode from "../Components/ModalDiscountCode";
import ModalGiftCard from "../Components/ModalGiftCard";
import { useAuth } from "../Context/AuthContext";
import { useNavigate } from "@solidjs/router";
import {
  type OrderFormData,
  NewOrderPayload,
  OrderItemPayload,
  ShippingMethod,
} from "../Types/checkout";
import {
  createForm,
  email,
  getValue,
  required,
  setValues,
  SubmitHandler,
} from "@modular-forms/solid";
import TextInput from "../Components/Input/TextInput";
import Divider from "../Components/Divider";
import RadioInput from "../Components/Input/RadioInput";

const fetchShippingMethods = async () => {
  const response = await fetch("api/shipping-methods");
  return response.json();
};

const Checkout: Component = () => {
  const [discountModalOpen, setDiscountModalOpen] = createSignal(false);
  const [giftcardModalOpen, setGiftcardModalOpen] = createSignal(false);
  const [orderForm, { Form, Field }] = createForm<OrderFormData>();
  setValues(orderForm, {
    email: "booklover88@gmail.com",
    phoneNumber: "0123456",
    socialSecurityNumber: "010101-0101",
    firstName: "Book",
    lastName: "Lover",
    street: "The Street 123",
    postalCode: "12345",
    city: "The City",
    shippingMethod: {
      identifier: "postnord",
      type: "pick-up",
      price: 49,
    },
    paymentMethod: {
      type: "card",
      cardInfo: {
        cardNumber: 4242424242424242,
        expiryDate: "",
        cvv: 123,
      },
    },
  });
  const [shippingMethods] =
    createResource<ShippingMethod[]>(fetchShippingMethods);

  const cart = useCart();
  const auth = useAuth();
  const nav = useNavigate();

  const handleFetchAdress = () => {
    console.log("Fetch the address based on social security number");
  };

  const handleOrderSubmit: SubmitHandler<OrderFormData> = async (values) => {
    console.log("submitted");
    console.log(values);
    //
    //   let date = new Date();
    //   if (formData.paymentMethod.cardInfo?.expiryDate) {
    //     let time: number = Date.parse(
    //       formData.paymentMethod.cardInfo?.expiryDate,
    //     );
    //     date = new Date(time);
    //   }
    //
    //   const payload: NewOrderPayload = {
    //     orderStatus: 1,
    //     orderTotalCost: cart.total(),
    //     address: {
    //       street: formData.street,
    //       city: formData.city,
    //       postalCode: formData.postalCode,
    //     },
    //     guestEmail: auth.isAuthenticated() ? "" : formData.email,
    //     shippingMethod: {
    //       identifier: formData.shippingMethod.identifier,
    //       type: formData.shippingMethod.type,
    //       price: formData.shippingMethod.price,
    //     },
    //     paymentMethod: {
    //       type: formData.paymentMethod.type,
    //       cardLastFour: formData.paymentMethod.cardInfo?.cardNumber
    //         ?.toString()
    //         .slice(-4),
    //       cardNumber: formData.paymentMethod.cardInfo?.cardNumber?.toString(),
    //       cvv: formData.paymentMethod.cardInfo?.cvv?.toString(),
    //       expiryDate: date,
    //     },
    //     items: cart.items.map((item) => {
    //       var items: OrderItemPayload = {
    //         bookId: item.id,
    //         unitPrice: item.price,
    //         quantity: item.quantity,
    //       };
    //       return items;
    //     }),
    //   };
    //
    //   const resp = await fetch("/api/orders", {
    //     method: "POST",
    //     headers: {
    //       "Content-Type": "application/json",
    //       Authorization: `Bearer ${auth.token()}`,
    //     },
    //     body: JSON.stringify({
    //       items: payload.items,
    //       address: payload.address,
    //       guestEmail: payload.guestEmail,
    //       shippingMethod: payload.shippingMethod,
    //       paymentMethod: payload.paymentMethod,
    //       orderTotalCost: payload.orderTotalCost,
    //       orderStatus: payload.orderStatus,
    //     }),
    //   });
    //   const result = await resp.json();
    //   cart.clearCart();
    //   nav("/order/confirmation", { state: result.items });
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
                <p>
                  You have{" "}
                  {250 - cart.total() > 0
                    ? `${(250 - cart.total()).toFixed(1)} kr remaining for free shipping!`
                    : `unlocked free shipping!`}{" "}
                </p>
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
                  <span>
                    {cart.total() > 250
                      ? "Free!"
                      : `${getValue(orderForm, "shippingMethod.price")} kr`}
                  </span>
                </div>
                <div class="flex items-baseline justify-between font-bold text-lg">
                  <span>Total</span>
                  <span>
                    {getValue(orderForm, "shippingMethod.price") +
                      cart.total().toFixed(2)}
                  </span>
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
          <Form
            onSubmit={handleOrderSubmit}
            class="flex flex-col gap-3 bg-everforest-bg-0 p-4 lg:p-5"
          >
            <div class="flex flex-col gap-2 text-everforest-fg">
              <h3 class="text-xl m-0">Your information</h3>
            </div>
            <div>
              <div>
                <div class="grid gap-6 mb-6 md:grid-cols-2">
                  <div class="md:col-span-2">
                    <Field
                      name="email"
                      validate={[
                        required("Please enter a valid email"),
                        email("Invalid email"),
                      ]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="email"
                          label="Email"
                          placeholder="Email"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="md:col-span-2">
                    <Field
                      name="phoneNumber"
                      validate={[required("Please fill out this field")]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="tel"
                          label="Phone"
                          placeholder="Phone"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="flex gap-2 md:col-span-2">
                    <div class="grow">
                      <Field name="socialSecurityNumber">
                        {(field, props) => (
                          <TextInput
                            {...props}
                            type="text"
                            label="Social-security number"
                            placeholder="Social-security number"
                            value={field.value}
                            error={field.error}
                            required
                          />
                        )}
                      </Field>
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
                    <Field
                      name="firstName"
                      validate={[required("Please fill out this field")]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="First name"
                          placeholder="First name"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div>
                    <Field
                      name="lastName"
                      validate={[required("Please fill out this field")]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="Last name"
                          placeholder="Last name"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="md:col-span-2">
                    <Field
                      name="street"
                      validate={[required("Please fill out this field")]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="Street"
                          placeholder="Street 123"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="md:col-span-2 flex gap-2">
                    <Field
                      name="postalCode"
                      validate={[required("Please fill out this field")]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="Postal Code"
                          placeholder="123 45"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                    <Field
                      name="city"
                      validate={[required("Please fill out this field")]}
                    >
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="City"
                          placeholder="The City"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                </div>
              </div>
            </div>
            <Divider />
            <div>
              <div class="flex flex-col gap-2 text-everforest-fg">
                <h3 class="text-xl m-0 pb-2">Shipping Method</h3>
              </div>
              <div>
                <fieldset>
                  <legend class="sr-only">Shipping Methods</legend>

                  <For each={shippingMethods()}>
                    {(item, _) => (
                      <>
                        <Field
                          name="shippingMethod.identifier"
                          validate={[required("Please select an option")]}
                        >
                          {(field, props) => (
                            <RadioInput
                              {...props}
                              label={`${item.identifier} ${item.type}`}
                              value={`${item.identifier}-${item.type}`}
                              checked={field.value === item.identifier}
                              error={field.error}
                              required
                            />
                          )}
                        </Field>
                        <div
                          class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                            getValue(orderForm, "shippingMethod.identifier") ===
                            `${item.identifier}-${item.type}`
                              ? "grid-rows-[1fr] opacity-100"
                              : "grid-rows-[0fr] opacity-0"
                          }`}
                        >
                          <div class="overflow-hidden w-full flex justify-between">
                            <p>{item.description}</p>
                            <span>{item.price} kr</span>
                          </div>
                        </div>
                      </>
                    )}
                  </For>
                </fieldset>
              </div>
            </div>
            <Divider />
            <div>
              <div class="flex flex-col gap-2 text-everforest-fg">
                <h3 class="text-xl m-0">Payment Method</h3>
              </div>
              <fieldset>
                <legend class="sr-only">Payment methods</legend>

                <For
                  each={[
                    { label: "Card", value: "card" },
                    { label: "Invoice", value: "invoice" },
                    { label: "Swish", value: "swish" },
                  ]}
                >
                  {({ label, value }) => (
                    <Field
                      name="paymentMethod.type"
                      type="string"
                      validate={[required("Please select an option")]}
                    >
                      {(field, props) => (
                        <RadioInput
                          {...props}
                          label={label}
                          value={value}
                          checked={field.value === value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  )}
                </For>
              </fieldset>
              <div
                class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                  getValue(orderForm, "paymentMethod.type") === "card"
                    ? "grid-rows-[1fr] opacity-100"
                    : "grid-rows-[0fr] opacity-0"
                }`}
              >
                <div class="overflow-hidden w-full mt-2 p-1 flex flex-col justify-between">
                  <div>
                    <Field name="paymentMethod.cardInfo.cardNumber">
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="Card Number"
                          placeholder="4242 4242 4242 4242"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="flex flex-row justify-between gap-2">
                    <Field name="paymentMethod.cardInfo.expiryDate">
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="Expiry Date"
                          placeholder="01/30"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                    <Field name="paymentMethod.cardInfo.cvv">
                      {(field, props) => (
                        <TextInput
                          {...props}
                          type="text"
                          label="CVV"
                          placeholder="123"
                          value={field.value}
                          error={field.error}
                          required
                        />
                      )}
                    </Field>
                  </div>
                </div>
              </div>
            </div>
            <div class="flex flex-col items-center mb-4"></div>
            <div
              class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                getValue(orderForm, "paymentMethod.type") === "invoice"
                  ? "grid-rows-[1fr] opacity-100"
                  : "grid-rows-[0fr] opacity-0"
              }`}
            >
              <div class="overflow-hidden w-full flex justify-between">
                Pay by invoice
              </div>
            </div>
            <div
              class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                getValue(orderForm, "paymentMethod.type") === "swish"
                  ? "grid-rows-[1fr] opacity-100"
                  : "grid-rows-[0fr] opacity-0"
              }`}
            >
              <div class="overflow-hidden w-full flex justify-between">
                Pay by swish
              </div>
            </div>
            <Divider />
            <button
              type="submit"
              class="flex items-center justify-center bg-everforest-aqua w-full p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
            >
              Place Order
            </button>
          </Form>
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
