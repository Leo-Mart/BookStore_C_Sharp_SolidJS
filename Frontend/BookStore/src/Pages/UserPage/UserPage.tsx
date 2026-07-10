import {
  Component,
  createEffect,
  createResource,
  createSignal,
  For,
  Show,
} from "solid-js";
import ClipboardList from "lucide-solid/icons/clipboard-list";
import User from "lucide-solid/icons/user";
import Heart from "lucide-solid/icons/heart";
import Star from "lucide-solid/icons/star";
import { useAuth } from "../../Context/AuthContext";
import { A } from "@solidjs/router";
import { FormatDate } from "../../Utils/Datehelpers";
import { OrderStatus } from "../../Types/User/order";
import { type UserInfo } from "../../Types/User/userinfo";
import { Address } from "../../Types/User/address";

const UserPage: Component = () => {
  const auth = useAuth();
  const [defaultAddress, setDefaultAddress] = createSignal<Address>();

  const fetchUserInfo = async () => {
    const resp = await fetch("/api/user", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return resp.json();
  };
  const [userInfo] = createResource<UserInfo>(fetchUserInfo);

  createEffect(() => {
    if (!userInfo.loading && !userInfo.error) {
      setDefaultAddress(
        userInfo()?.addresses.find((a) => a.isDefault === true),
      );
    }
  });
  return (
    <div class="grid grid-cols-12">
      <div class="col-span-2"></div>
      <section class="col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <User />
          <span class="text-nowrap px-2">User-info</span>
          <hr class="border w-full mx-1"></hr>
          <A
            href="user-info"
            class="text-nowrap underline hover:text-everforest-aqua"
          >
            View info
          </A>
        </div>
        <div class="bg-everforest-bg-2 text-everforest-fg p-2">
          <div>
            <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
              <div>
                <dt class='inline-block after:mr-2 after:content-[":"]'>
                  Name
                </dt>
                <dd class="inline-block">
                  {userInfo()?.firstName} {userInfo()?.lastName}
                </dd>
              </div>
              <div>
                <dt class='inline-block after:mr-2 after:content-[":"]'>
                  Email
                </dt>
                <dd class="inline-block">{userInfo()?.email}</dd>
              </div>
            </dl>
          </div>

          <Show
            when={!userInfo.loading && defaultAddress !== undefined}
            fallback={
              <div class="my-2">
                No default address set, set one in user options.
              </div>
            }
          >
            <div class="mt-2">
              <span class="text-nowrap underline">Default Address</span>
              <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
                <div>
                  <dt class='inline-block after:mr-2 after:content-[":"]'>
                    Street
                  </dt>
                  <dd class="inline-block">{defaultAddress()?.street}</dd>
                </div>
                <div>
                  <dt class='inline-block after:mr-2 after:content-[":"]'>
                    City
                  </dt>
                  <dd class="inline-block">{defaultAddress()?.city}</dd>
                </div>
                <div>
                  <dt class='inline-block after:mr-2 after:content-[":"]'>
                    Postal Code
                  </dt>
                  <dd class="inline-block">{defaultAddress()?.postalCode}</dd>
                </div>
              </dl>
            </div>
          </Show>
        </div>
      </section>

      <section class="col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <ClipboardList />
          <span class="text-nowrap px-2">Orders</span>
          <hr class="border w-full mx-1"></hr>
          <A
            href="user-orders"
            class="text-nowrap underline hover:text-everforest-aqua"
          >
            View all
          </A>
        </div>
        <div class="bg-everforest-bg-2 text-everforest-fg p-2">
          <Show
            when={userInfo()?.orders !== undefined}
            fallback={<div class="my-2">Found no orders!</div>}
          >
            <For each={userInfo()?.orders}>
              {(item) => (
                <div class="flex justify-between border-b border-everforest-fg">
                  <div>{FormatDate(item.createdAt)}</div>
                  <div>{item.orderNumber}</div>
                  <div>{OrderStatus[item.orderStatus]}</div>
                  <div>{item.orderTotalCost} kr</div>
                </div>
              )}
            </For>
          </Show>
        </div>
      </section>

      <section class="col-start-3 col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <Heart />
          <span class="text-nowrap px-2">Wishlists</span>
          <hr class="border w-full mx-1"></hr>
          <A
            href="user-wishlists"
            class="text-nowrap underline hover:text-everforest-aqua"
          >
            View all
          </A>
        </div>
        <div class="bg-everforest-bg-2 text-everforest-fg p-2">
          <For each={userInfo()?.wishlists}>
            {(item) => (
              <div class="flex justify-between border-b border-everforest-fg">
                <div>{item.name}</div>
                <div class="truncate">{item.description}</div>
                <div>{item.wishlistItems.length}</div>
              </div>
            )}
          </For>
        </div>
      </section>

      <section class="col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <Star />
          <span class="text-nowrap px-2">Reviews</span>
          <hr class="border w-full mx-1"></hr>
          <A
            href="user-reviews"
            class="text-nowrap underline hover:text-everforest-aqua"
          >
            View all
          </A>
        </div>
        <div class="bg-everforest-bg-2 text-everforest-fg p-2">
          <Show
            when={userInfo() !== undefined && userInfo()!.reviews.length > 0}
            fallback={<div>No reviews found</div>}
          >
            <div>A list of the users reviews/reviewed objects</div>
          </Show>
        </div>
      </section>
      <div class="col-start-3 mt-2 col-span-8 flex justify-center">
        <button
          onclick={auth.logout}
          class="col-start-3 bg-white block w-1/3 rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
        >
          Logout
        </button>
      </div>

      <div class="col-span-2"></div>
    </div>
  );
};

export default UserPage;
