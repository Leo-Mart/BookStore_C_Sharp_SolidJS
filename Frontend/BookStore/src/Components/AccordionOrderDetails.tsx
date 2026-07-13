import { Component, createSignal, For } from "solid-js";
import { FormatDate } from "../Utils/Datehelpers";
import { Order, OrderStatus } from "../Types/User/order";

export interface ItemDetailsProps {
  Order: Order;
}

const AccordionOrderDetails: Component<ItemDetailsProps> = (
  props: ItemDetailsProps,
) => {
  const [open, setOpen] = createSignal<boolean>(false);

  return (
    <div class="bg-everforest-bg-0 p-1 ">
      <li class="flex justify-between text-everforest-fg">
        <div class="grow basis-20">{FormatDate(props.Order.createdAt)}</div>
        <div class="basis-3xs">{props.Order.orderNumber}</div>
        <div class="basis-3xs">{OrderStatus[props.Order.orderStatus]}</div>
        <div class="basis-3xs">{props.Order.orderTotalCost} kr</div>

        <button
          type="button"
          onClick={() => setOpen(!open())}
          class="flex hover:cursor-pointer"
        >
          <span class="text-sm font-bold">Details</span>
          <svg
            class="fill-everforest-fg shrink-0 ml-8 my-auto"
            width="8"
            height="16"
            xmlns="http://www.w3.org/2000/svg"
          >
            <rect
              y="7"
              width="8"
              height="2"
              rx="1"
              class={`transform origin-center transition duration-200 ease-out ${
                open() && "rotate-180!"
              }`}
            />
            <rect
              y="7"
              width="8"
              height="2"
              rx="1"
              class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                open() && "rotate-180!"
              }`}
            />
          </svg>
        </button>
      </li>
      <div
        class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg border-b border-t border-everforest-aqua py-2 text-md ${
          open() ? "grid-rows-[1fr]" : "grid-rows-[0fr] hidden"
        }`}
      >
        <h3 class="text-lg mt-2">Shipping Method</h3>
        <div>{props.Order.shippingMethod.identifier}</div>
        <h3 class="text-lg mt-2">Products</h3>
        <ul class="flex flex-col overflow-hidden">
          <li class="flex justify-between text-everforest-fg">
            <div class="grow">ISBN</div>
            <div class="basis-3xs">Title</div>
            <div class="basis-3xs">Author</div>
            <div class="basis-3xs">Quantity</div>
            <div class="basis-3xs">Price</div>
          </li>

          <For each={props.Order.items}>
            {(book, _) => (
              <li>
                <div class="flex">
                  <div class="grow">{book.bookInfo.isbn}</div>
                  <div class="basis-3xs">{book.bookInfo.title}</div>

                  <div class="basis-3xs">
                    {book.bookInfo.authors[0].firstName}{" "}
                    {book.bookInfo.authors[0].lastName}
                  </div>
                  <div class="basis-3xs">{book.quantity}</div>
                  <div class="basis-3xs">{book.unitPrice}</div>
                </div>
              </li>
            )}
          </For>
        </ul>
      </div>
    </div>
  );
};

export default AccordionOrderDetails;
