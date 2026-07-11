import {
  Component,
  createEffect,
  createResource,
  createSignal,
  For,
  Show,
} from "solid-js";
import { useAuth } from "../../Context/AuthContext";
import { type UserInfo } from "../../Types/User/userinfo";
import { Order, OrderStatus } from "../../Types/User/order";
import { FormatDate } from "../../Utils/Datehelpers";
import OrderItemDetailsAccordion from "../../Components/AccordionOrderDetails";

const UserPageOrders: Component = () => {
  const auth = useAuth();

  const fetchUserOrders = async () => {
    const resp = await fetch("/api/user/orders", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return resp.json();
  };
  const [userOrders] = createResource<UserInfo>(fetchUserOrders);
  const [activeOrders, setActiveOrders] = createSignal<Order[]>();
  const [completedOrders, setCompletedOrders] = createSignal<Order[]>();
  // const [open, setOpen] = createSignal<boolean>(false);

  createEffect(() => {
    if (!userOrders.loading && !userOrders.error) {
      setActiveOrders(
        userOrders()?.orders.filter(
          (o) =>
            o.orderStatus === OrderStatus["Pending"] ||
            o.orderStatus === OrderStatus["Confirmed"],
        ),
      );
      setCompletedOrders(
        userOrders()?.orders.filter(
          (o) =>
            o.orderStatus === OrderStatus["Delivered"] ||
            o.orderStatus === OrderStatus["Shipped"],
        ),
      );
    }
  });

  return (
    <Show
      when={!userOrders.loading && !userOrders.error}
      fallback={
        <div class="text-center text-everforest-fg">No orders found!</div>
      }
    >
      <div class="grid grid-cols-12">
        <div class="col-span-2"></div>
        <section class="col-span-8 flex-col my-3 mx-2">
          <h2 class="text-2xl text-everforest-fg">
            Active orders ({activeOrders()?.length})
          </h2>

          <ul class="flex flex-col">
            <li class="flex justify-between text-everforest-fg">
              <div class="grow">Date</div>
              <div class="basis-3xs">Order Number</div>
              <div class="basis-3xs">Order Status</div>
              <div class="basis-3xs">Order value</div>
              <div class="basis-22.5"></div>
            </li>

            <For each={activeOrders()}>
              {(item, _) => <OrderItemDetailsAccordion Order={item} />}
            </For>
          </ul>
        </section>
        <section class="col-start-3 col-span-8 flex-col mb-3 mx-2">
          <h2 class="text-2xl text-everforest-fg">
            Completed orders ({completedOrders()?.length})
          </h2>
          <ul>
            <li class="flex justify-between text-everforest-fg">
              <div class="grow">Date</div>
              <div class="basis-3xs">Order Number</div>
              <div class="basis-3xs">Order Status</div>
              <div class="basis-3xs">Order value</div>
              <div class="basis-22.5"></div>
            </li>

            <For each={completedOrders()}>
              {(item, _) => <OrderItemDetailsAccordion Order={item} />}
            </For>
          </ul>
        </section>

        <div class="col-span-2"></div>
      </div>
    </Show>
  );
};

export default UserPageOrders;
