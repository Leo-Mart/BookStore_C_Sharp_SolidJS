import {
  Component,
  createEffect,
  createMemo,
  createResource,
  createSignal,
  For,
} from "solid-js";
import Percent from "lucide-solid/icons/percent";
import Gift from "lucide-solid/icons/gift";
import { useCart } from "../Context/CartContext";
import CheckoutItem from "../Components/CheckoutItem";
import ModalDiscountCode from "../Components/ModalDiscountCode";
import ModalGiftCard from "../Components/ModalGiftCard";
import { useAuth } from "../Context/AuthContext";
import { useNavigate } from "@solidjs/router";
import {
  NewOrderPayload,
  OrderItemPayload,
  ShippingMethod,
} from "../Types/checkout";
import TextInput from "../Components/Input/TextInput";
import Divider from "../Components/Divider";
import RadioInput from "../Components/Input/RadioInput";
import {
  createForm,
  Field,
  Form,
  getInput,
  setInput,
  SubmitHandler,
} from "@formisch/solid";
import { ParseExpiryDate } from "../Utils/Datehelpers";
import { OrderFormSchema } from "../Types/validation-schemas";
import { Address } from "../Types/User/address";
import { useToast } from "../Context/ToastContext";

const fetchShippingMethods = async () => {
  const response = await fetch("api/shipping-methods");
  return response.json();
};

const Checkout: Component = () => {
  const [discountModalOpen, setDiscountModalOpen] = createSignal(false);
  const [giftcardModalOpen, setGiftcardModalOpen] = createSignal(false);
  const orderForm = createForm({
    schema: OrderFormSchema,
    validate: "submit",
    revalidate: "input",
  });
  const [shippingMethods] =
    createResource<ShippingMethod[]>(fetchShippingMethods);

  const cart = useCart();
  const toast = useToast();
  const auth = useAuth();
  const nav = useNavigate();

  const fetchLoggedInUserDefaultAddress = async () => {
    const response = await fetch("api/user/addresses/default", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return response.json();
  };

  const [userDefaultAddress] = createResource<Address, boolean>(
    () => auth.isAuthenticated() === true,
    fetchLoggedInUserDefaultAddress,
  );
  const costWithShipping = createMemo(
    () =>
      cart.total() +
      getInput(orderForm, { path: ["shippingMethod", "price"] })!,
  );

  const updateShippingInfo = () => {
    if (!shippingMethods.loading && !shippingMethods.error) {
      const foundMethod = shippingMethods.latest?.find(
        (sm) =>
          sm.identifier ==
          getInput(orderForm, { path: ["shippingMethod", "identifier"] }),
      );
      if (foundMethod === undefined) {
        return;
      }
      setInput(orderForm, {
        path: ["shippingMethod", "price"],
        input: foundMethod!.price,
      });

      setInput(orderForm, {
        path: ["shippingMethod", "type"],
        input: foundMethod!.type,
      });
    }
  };

  createEffect(() => {
    if (cart.count() === 0) {
      toast.add("Found no books in cart, sending to books...", {
        type: "info",
      });
      nav("/books");
    }
    updateShippingInfo();
  });

  const handleFetchAdress = () => {
    console.log("Fetch the address based on social security number");
  };

  const handleOrderSubmit: SubmitHandler<typeof OrderFormSchema> = async (
    values,
  ) => {
    let date = new Date();
    if (values.paymentMethod.type === "card") {
      date = ParseExpiryDate(values.paymentMethod.cardInfo.expiryDate);
    }

    const payload: NewOrderPayload = {
      orderStatus: 1,
      orderTotalCost: cart.total(),
      address: {
        firstName: values.firstName,
        lastName: values.lastName,
        city: values.city,
        postalCode: values.postalCode,
        street: values.street,
      },
      guestEmail: auth.isAuthenticated() ? "" : values.email,
      shippingMethod: values.shippingMethod,
      paymentMethod:
        values.paymentMethod.type === "card"
          ? {
              type: values.paymentMethod.type,
              cardNumber: values.paymentMethod.cardInfo.cardNumber,
              cvv: values.paymentMethod.cardInfo.cvv,
              cardLastFour: values.paymentMethod.cardInfo.cardNumber
                .toString()
                .slice(-4),
              expiryDate: date,
            }
          : values.paymentMethod,
      items: cart.items.map((item) => {
        var items: OrderItemPayload = {
          bookId: item.id,
          unitPrice: item.price,
          quantity: item.quantity,
        };
        return items;
      }),
    };

    const resp = await fetch("/api/orders", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
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
    nav("/order/confirmation", { state: result.items });
  };

  return (
    <div class="max-w-7xl lg:max-w-7xl mx-auto">
      <div class="flex w-full flex-col gap-20 pb-48 lg:flex-row-reverse">
        <div class="lg:w-1/2">
          <div class="flex flex-col gap-3 bg-everforest-bg-0 p-4 lg:p-5">
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
              <div class="flex flex-col gap-2 text-everforest-fg">
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
                      : `${getInput(orderForm, { path: ["shippingMethod", "price"] }) ?? 0} kr`}
                  </span>
                </div>
                <div class="flex items-baseline justify-between font-bold text-lg">
                  <span>Total</span>
                  <span class="text-xs md:text-lg">
                    {costWithShipping().toFixed(2) === "NaN"
                      ? "Select a shipping method to see total cost"
                      : costWithShipping().toFixed(2)}
                  </span>
                </div>
              </div>
              <div class="flex gap-2 md:flex-row">
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
            of={orderForm}
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
                    <Field of={orderForm} path={["email"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="email"
                          label="Email"
                          placeholder="Email"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.email
                              : field.input
                          }
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="md:col-span-2">
                    <Field of={orderForm} path={["phoneNumber"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="tel"
                          label="Phone"
                          placeholder="Phone"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.phoneNumber
                              : field.input
                          }
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="flex gap-2 md:col-span-2">
                    <div class="grow">
                      <Field of={orderForm} path={["socialSecurityNumber"]}>
                        {(field) => (
                          <TextInput
                            {...field.props}
                            type="text"
                            label="Social-security number"
                            placeholder="Social-security number"
                            input={field.input}
                            errors={field.errors}
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
                    <Field of={orderForm} path={["firstName"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="First name"
                          placeholder="First name"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.firstName
                              : field.input
                          }
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div>
                    <Field of={orderForm} path={["lastName"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="Last name"
                          placeholder="Last name"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.lastName
                              : field.input
                          }
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="md:col-span-2">
                    <Field of={orderForm} path={["street"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="Street"
                          placeholder="Street 123"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.street
                              : field.input
                          }
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="md:col-span-2 flex gap-2">
                    <Field of={orderForm} path={["postalCode"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="Postal Code"
                          placeholder="123 45"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.postalCode
                              : field.input
                          }
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                    <Field of={orderForm} path={["city"]}>
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="City"
                          placeholder="The City"
                          input={
                            !userDefaultAddress.loading
                              ? userDefaultAddress()?.city
                              : field.input
                          }
                          errors={field.errors}
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
                          of={orderForm}
                          path={["shippingMethod", "identifier"]}
                        >
                          {(field) => (
                            <RadioInput
                              {...field.props}
                              label={item.identifier}
                              input={item.identifier}
                              checked={field.input === item.identifier}
                              errors={field.errors}
                              required
                            />
                          )}
                        </Field>
                        <div
                          class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                            getInput(orderForm, {
                              path: ["shippingMethod", "identifier"],
                            }) === item.identifier
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
                    <Field of={orderForm} path={["paymentMethod", "type"]}>
                      {(field) => (
                        <RadioInput
                          {...field.props}
                          label={label}
                          input={value}
                          checked={field.input === value}
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  )}
                </For>
              </fieldset>
              <div
                class={`w-full grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                  getInput(orderForm, { path: ["paymentMethod", "type"] }) ===
                  "card"
                    ? "grid-rows-[1fr] opacity-100"
                    : "grid-rows-[0fr] opacity-0"
                }`}
              >
                <div class="overflow-hidden w-full mt-2 p-1 flex flex-col justify-between">
                  <div>
                    <Field
                      of={orderForm}
                      path={["paymentMethod", "cardInfo", "cardNumber"]}
                    >
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="Card Number"
                          placeholder="4242 4242 4242 4242"
                          input={field.input}
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                  </div>
                  <div class="flex flex-row justify-between gap-2">
                    <Field
                      of={orderForm}
                      path={["paymentMethod", "cardInfo", "expiryDate"]}
                    >
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="Expiry Date"
                          placeholder="MM/YY"
                          input={field.input}
                          errors={field.errors}
                          required
                        />
                      )}
                    </Field>
                    <Field
                      of={orderForm}
                      path={["paymentMethod", "cardInfo", "cvv"]}
                    >
                      {(field) => (
                        <TextInput
                          {...field.props}
                          type="text"
                          label="CVV"
                          placeholder="123"
                          input={String(field.input)}
                          errors={field.errors}
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
                getInput(orderForm, { path: ["paymentMethod", "type"] }) ===
                "invoice"
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
                getInput(orderForm, { path: ["paymentMethod", "type"] }) ===
                "swish"
                  ? "grid-rows-[1fr] opacity-100"
                  : "grid-rows-[0fr] opacity-0"
              }`}
            >
              <div class="overflow-hidden w-1/2 p-1  flex flex-col mx-auto">
                <p class="pb-1">Pay by swish</p>
                <Field of={orderForm} path={["paymentMethod", "phoneNumber"]}>
                  {(field) => (
                    <TextInput
                      {...field.props}
                      type="text"
                      label="Phone"
                      placeholder="0123 456789"
                      input={String(field.input)}
                      errors={field.errors}
                      required
                    />
                  )}
                </Field>
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
