import { A } from '@solidjs/router';

function Header() {
  return (
    <header class="bg-white dark:bg-gray-900 shadow">
      <div class="flex h-16 items-center gap-8 px-4 sm:px-6 lg:px-8">
        <nav class="flex-auto flex items-center justify-between">
          <ul class="flex items-center gap-6 text-sm">
            <li>
              <A
                class="block rounded-md px-5 py-2.5 text-sm font-medium text-emerald-600 transition"
                href="/"
              >
                Home
              </A>
            </li>
            <li>
              <A
                class="block rounded-md px-5 py-2.5 text-sm font-medium text-emerald-600 transition hover:bg-amber-600"
                href="/books"
              >
                Books
              </A>
            </li>
          </ul>
        </nav>
        <form class="flex-auto max-w-md mx-auto">
          <label
            for="search"
            class="block mb-2.5 text-sm font-medium sr-only"
          >
            Search
          </label>
          <div class="relative">
            <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
              <svg
                class="w-4 h-4 text-white"
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
              class="block w-full p-3 ps-9 bg-gray-500 border text-sm shadow-xs"
              placeholder="Search"
              required
            />
            <button
              type="button"
              class="absolute end-1.5 bottom-1.5 text-white bg-amber-500 hover:bg-amber-950 box-border border border-transparent focus:ring-4 shadow-xs font-medium leading-5 rounded text-xs px-3 py-1.5 focus:outline-none"
            >
              Search
            </button>
          </div>
        </form>
      </div>
    </header>
  );
}
export default Header;
