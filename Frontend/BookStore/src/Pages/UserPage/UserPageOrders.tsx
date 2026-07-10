import { Component, createResource, For, Show } from "solid-js";
import { useAuth } from "../../Context/AuthContext";
import { type UserInfo } from "../../Types/User/userinfo";

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

  return (
    <Show
      when={!userOrders.loading && !userOrders.error}
      fallback={
        <div class="text-center text-everforest-fg">No orders found!</div>
      }
    >
      <ul>
        <li>
          <span>Date</span>
          <span>Order-Number</span>
          <span>Order Status</span>
          <span>Order value</span>
        </li>

        <For each={userOrders()?.orders}>
          {(item, _) => (
            <li>
              <div>{item.orderNumber}</div>
            </li>
          )}
        </For>
      </ul>
    </Show>
  );
};

export default UserPageOrders;
