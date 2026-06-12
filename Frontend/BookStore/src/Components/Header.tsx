import { A, useNavigate } from '@solidjs/router';
import { createSignal, Match, Show, Switch } from 'solid-js';

import House from 'lucide-solid/icons/house';
import User from 'lucide-solid/icons/user';
import UserCog from 'lucide-solid/icons/user-cog';
import ShoppingBasket from 'lucide-solid/icons/shopping-basket';
import CartDrawer from './CartDrawer';
import { useCart } from '../Context/CartContext';
import { useAuth } from '../Context/AuthContext';
// seems like Lucide-icons imports all ~1700 icons if I use the import { House } from 'lucide-solid' syntax. Check https://github.com/lucide-icons/lucide/issues/1944#issuecomment-3704423258 maybe use https://github.com/WarningImHack3r/vite-plugin-lucide-preprocess or try the other Icon package

function Header() {
  const [searchTerm, setSearchTerm] = createSignal('');
  const [cartOpen, setCartOpen] = createSignal(false);

  const cart = useCart();
  const auth = useAuth();

  const navigate = useNavigate();

  const handleSubmit = (event: Event) => {
    event.preventDefault();
    navigate(`/books?searchQuery=${searchTerm()}`);
  };

  return (
    <header class="bg-white dark:bg-everforest-bg-dim shadow">
      <div class="p-2 flex justify-around">
        <A href="/" class="flex-none flex flex-col items-center">
          <House size={24} color="#D3C6AA" />
          <p class="dark:text-everforest-fg">THE LOGO</p>
        </A>
        <form class="grow px-3" onSubmit={handleSubmit}>
          <label for="search" class="block mb-2.5 text-sm font-medium sr-only">
            Search
          </label>
          <div class="relative">
            <div class="absolute inset-y-0 inset-s-0 flex items-center ps-3 pointer-events-none">
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
                  stroke-width="2"
                  d="m21 21-3.5-3.5M17 10a7 7 0 1 1-14 0 7 7 0 0 1 14 0Z"
                />
              </svg>
            </div>
            <input
              type="search"
              id="search"
              class="block w-full p-3 ps-9 bg-everforest-bg-3 text-everforest-fg text-sm shadow-xs"
              placeholder="Search"
              value={searchTerm()}
              onChange={(e) => setSearchTerm(e.target.value)}
              required
            />
            <button
              type="submit"
              class="absolute inset-e-1.5 bottom-1.5 text-everforest-bg-dim dark:bg-everforest-aqua dark:hover:bg-everforest-fg box-border border border-transparent focus:ring-4 shadow-xs font-medium leading-5 rounded text-xs px-3 py-1.5 focus:outline-none"
            >
              Search
            </button>
          </div>
        </form>
        <div class="flex-none flex gap-7 px-2">
          <Switch>
            <Match when={auth.token()}>
              <A href="/user-profile" class="flex flex-col items-center">
                <UserCog color="#D3C6AA" />
                <span class="dark:text-everforest-fg">Account</span>
              </A>
            </Match>
            <Match when={!auth.token()}>
              <A href="/login" class="flex flex-col items-center">
                <User color="#D3C6AA" />
                <span class="dark:text-everforest-fg">Log in</span>
              </A>
            </Match>
          </Switch>

          <button
            onClick={() => setCartOpen(true)}
            class="flex flex-col items-center hover:cursor-pointer"
          >
            <ShoppingBasket color="#D3C6AA" />
            <span class="dark:text-everforest-fg">Basket</span>
          </button>
        </div>
      </div>
      <div class="flex h-16 items-center gap-8 px-4 sm:px-6 lg:px-8">
        <nav class="flex-auto flex items-center justify-between">
          <ul class="flex items-center gap-6 text-sm">
            <li>
              <A
                class="block rounded-md px-5 py-2.5 text-sm font-medium text-everforest-fg transition hover:bg-everforest-aqua"
                href="/category"
              >
                Categories
              </A>
            </li>
            <li>
              <A
                class="block rounded-md px-5 py-2.5 text-sm font-medium text-everforest-fg transition hover:bg-everforest-aqua"
                href="/books"
              >
                Books
              </A>
            </li>
          </ul>
        </nav>
      </div>
      <CartDrawer
        open={cartOpen()}
        onClose={() => setCartOpen(false)}
        items={cart.items}
        onRemove={cart.removeItem}
        total={cart.total()}
        count={cart.count()}
        onUpdateQuantity={cart!.updateQty}
      />
    </header>
  );
}
export default Header;
