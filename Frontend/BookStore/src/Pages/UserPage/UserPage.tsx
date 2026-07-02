import { Component, createResource, For } from 'solid-js';
import ClipboardList from 'lucide-solid/icons/clipboard-list';
import User from 'lucide-solid/icons/user';
import Heart from 'lucide-solid/icons/heart';
import Star from 'lucide-solid/icons/star';
import { useAuth } from '../../Context/AuthContext';
import { A } from '@solidjs/router';
import { ShippingMethod } from '../../Types/checkout';
import { BasicBookInfo } from '../../Types/book';



interface UserInfo {
  email: string
  firstName: string
  lastName: string
  addresses: Address[]
  orders: Order[]
  reviews: Review[]
}

interface Address {
  street: string
  city: string
  postalCode: string
  isDefault: boolean
}

interface Order {
  orderStatus: number
  orderTotalCost: number
  orderItems: OrderItem[]
  shippingMethod: ShippingMethod
}

interface Review {
  title: string
  text: string
  score: number
}

interface OrderItem {
  unitPrice: number
  quantity: number
  Book: BasicBookInfo
}
const UserPage: Component = () => {
  const auth = useAuth();

  const fetchUserInfo = async () => {
  const resp = await fetch("/api/user", {
    method: 'GET',
    headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
  })
  return resp.json();
}
  const [userInfo] = createResource<UserInfo>(fetchUserInfo)

  return (
    <div class="grid grid-cols-12">
      <div class="col-span-2"></div>
      <section class="col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <User />
          <span class="text-nowrap px-2">User-info</span>
          <hr class="border w-full mx-1"></hr>
          <A href='/user-profile/user-info' class='text-nowrap underline hover:text-everforest-aqua'>View info</A>
        </div>
        <div class='bg-everforest-bg-2 text-everforest-fg'>
          <p>
            {userInfo()?.firstName}
          </p>
        </div>
  
      </section>

      <section class="col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <ClipboardList />
          <span class="text-nowrap px-2">Orders</span>
          <hr class="border w-full mx-1"></hr>
          <A href='/user-profile/user-orders' class='text-nowrap underline hover:text-everforest-aqua'>View all</A>
        </div>
        <div class='bg-everforest-bg-2 text-everforest-fg'>
          <p>
            Orders go here
          </p>
        </div>
      </section>

      <section class="col-start-3 col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <Heart />
          <span class="text-nowrap px-2">Wishlists</span>
          <hr class="border w-full mx-1"></hr>
          <A href='/user-profile/user-wishlists' class='text-nowrap underline hover:text-everforest-aqua'>View all</A>
        </div>
        <div class='bg-everforest-bg-2 text-everforest-fg'>
          <p>
            Not yet implemented, coming soon!
          </p>
        </div>
      </section>

      <section class="col-span-4 flex-col mb-3 mx-2">
        <div class="text-everforest-fg flex justify-around items-center mb-2">
          <Star />
          <span class="text-nowrap px-2">Reviews</span>
          <hr class="border w-full mx-1"></hr>
          <A href='/user-profile/user-reviews' class='text-nowrap underline hover:text-everforest-aqua'>View all</A>
        </div>
        <div class='bg-everforest-bg-2 text-everforest-fg'>
          <p>
            Reviews go here
          </p>
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
