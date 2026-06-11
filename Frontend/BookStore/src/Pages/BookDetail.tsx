import { A, useParams } from '@solidjs/router';
import {
  Component,
  createResource,
  createSignal,
  For,
  Match,
  Show,
  Switch,
} from 'solid-js';
import HeartMinus from 'lucide-solid/icons/heart-minus';
import HeartPlus from 'lucide-solid/icons/heart-plus';
import ShoppingBasket from 'lucide-solid/icons/shopping-basket';
import { useCart } from '../Context/CartContext';

const fetchBook = async (bookId: string) => {
  const response = await fetch(`/api/books/${bookId}`);
  return response.json();
};

const BookDetail: Component = () => {
  const params = useParams();
  const [book] = createResource(() => params.bookId, fetchBook);
  const cart = useCart();

  const [wishlisted, setWishlisted] = createSignal(false);

  const [amount, setAmount] = createSignal(1);
  const [descOpen, setDescOpen] = createSignal(false);
  const [prodInfoOpen, setProdInfoOpen] = createSignal(false);
  const [paymenAndDeliveryOpen, setPaymentAndDeliveryOpen] =
    createSignal(false);
  const [discoverOpen, setDiscoverOpen] = createSignal(false);
  const [reviewsOpen, setReviewsOpen] = createSignal(false);

  const increaseAmount = () => {
    setAmount((prev) => prev + 1);
  };

  const decreaseAmount = () => {
    setAmount((prev) => {
      if (prev <= 0) {
        return 1;
      }
      return prev - 1;
    });
  };

  return (
    <div class="grid grid-cols-12 gap-4 pt-3">
      <div class="col-span-1"></div>
      <div class="col-span-10 grid grid-cols-1 lg:grid-cols-6 text-everforest-fg gap-2">
        <aside class="self-start flex flex-col gap-20">
          <div class="pointer-events-none py-16">
            <div class="mx-auto flex">
              <img
                class="h-full w-full object-contain"
                src="./images/atbqj8.jpg"
                alt="book cover"
              />
            </div>
          </div>
        </aside>

        <div class="lg:col-span-5">
          <Show when={!book.loading} fallback={<p>Loading...</p>}>
            <div>
              <h1 class="text-4xl pb-2">{book().title}</h1>
              <div>
                <span>
                  Author: {book().authors[0].firstName}{' '}
                  {book().authors[0].lastName}
                </span>
              </div>
              <div class="pb-2">
                <span>{new Date(book().publishedDate).getFullYear()}</span>
              </div>
              <div class="text-xl font-bold leading-none">
                <span>{book().price} kr</span>
              </div>

              <div class="flex max-w-3/4 justify-between gap-2 border p-2 mt-2">
                <div class="border flex h-13 md:h-auto">
                  <span class="w-full rounded flex justify-between font-bold">
                    <button
                      class="font-normal w-7.5 select-none hover:cursor-pointer"
                      type="button"
                      onClick={decreaseAmount}
                    >
                      -<span class="sr-only">Reduce Amount</span>
                    </button>
                    <label class="flex">
                      <span class="sr-only">Amount</span>
                      <input
                        class="[appearance:textfield] [&::-webkit-outer-spin-button]:appearance-none [&::webkit-inner-spin-button]:appearance-none w-7.5 text-center"
                        type="number"
                        max="150"
                        min="1"
                        pattern="[0-9]*"
                        value={amount()}
                        onChange={(e) => setAmount(parseInt(e.target.value))}
                      />
                    </label>

                    <button
                      class="font-normal w-7.5 select-none hover:cursor-pointer"
                      type="button"
                      onClick={increaseAmount}
                    >
                      +<span class="sr-only">Increase Amount</span>
                    </button>
                  </span>
                </div>

                <button
                  onClick={() =>
                    cart.addItem({
                      id: book().id,
                      name: book().title,
                      price: book().price,
                      quantity: amount(),
                      imageUrl: book().coverImageUrl,
                    })
                  }
                  class="flex gap-1 grow justify-center bg-everforest-aqua px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer"
                >
                  Add to cart
                  <ShoppingBasket />
                </button>
                <button
                  class="flex gap-0.5 py-2.5 grow-0 text-sm font-medium text-everforest-fg hover:cursor-pointer"
                  onclick={() => setWishlisted(!wishlisted())}
                >
                  <Switch>
                    <Match when={wishlisted()}>
                      <HeartMinus /> Remove from Wishlist
                    </Match>
                    <Match when={!wishlisted()}>
                      <HeartPlus /> Add to Wishlist
                    </Match>
                  </Switch>
                </button>
              </div>

              <div class="flex max-w-3/4 justify-between gap-1 border">
                <div class="p-1">Inventory status goes here</div>
              </div>
              {/* Accordion with various info. Addiotional format, Description, More info (author, isbn, language, weight, exact publishdate, publisher, page number ), Shipping and payment, A list of tags, reviews go here as well */}
              <div class="py-8 max-w-3/4 flex flex-col gap-3">
                <button
                  type="button"
                  onClick={() => setDescOpen(!descOpen())}
                  class="flex justify-between w-full hover:cursor-pointer"
                >
                  <span class="text-2xl font-bold">Description</span>
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
                        descOpen() && 'rotate-180!'
                      }`}
                    />
                    <rect
                      y="7"
                      width="8"
                      height="2"
                      rx="1"
                      class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                        descOpen() && 'rotate-180!'
                      }`}
                    />
                  </svg>
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                    descOpen()
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden">{book().description}</div>
                </div>
                <button
                  type="button"
                  onClick={() => setProdInfoOpen(!prodInfoOpen())}
                  class="flex justify-between w-full hover:cursor-pointer"
                >
                  <span class="text-2xl font-bold">Product Info</span>
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
                        prodInfoOpen() && 'rotate-180!'
                      }`}
                    />
                    <rect
                      y="7"
                      width="8"
                      height="2"
                      rx="1"
                      class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                        prodInfoOpen() && 'rotate-180!'
                      }`}
                    />
                  </svg>
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg0 text-md ${
                    prodInfoOpen()
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden">
                    <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
                      <div>
                        <dt class='inline-block after:mr-2 after:content-[":"]'>
                          Author
                        </dt>
                        <dd class="inline-block">
                          {book().authors[0].firstName}{' '}
                          {book().authors[0].lastName}
                        </dd>
                      </div>
                      <div>
                        <dt class='inline-block after:mr-2 after:content-[":"]'>
                          ISBN
                        </dt>
                        <dd class="inline-block">{book().isbn}</dd>
                      </div>
                      <div>
                        <dt class='inline-block after:mr-2 after:content-[":"]'>
                          Published Date
                        </dt>
                        <dd class="inline-block">
                          {new Date(book().publishedDate).toLocaleDateString()}
                        </dd>
                      </div>
                      <div>
                        <dt class='inline-block after:mr-2 after:content-[":"]'>
                          Publisher
                        </dt>
                        <dd class="inline-block">{book().publisher}</dd>
                      </div>
                    </dl>
                  </div>
                </div>
                <button
                  type="button"
                  onClick={() =>
                    setPaymentAndDeliveryOpen(!paymenAndDeliveryOpen())
                  }
                  class="flex justify-between w-full hover:cursor-pointer"
                >
                  <span class="text-2xl font-bold">Payment and Delivery</span>
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
                        paymenAndDeliveryOpen() && 'rotate-180!'
                      }`}
                    />
                    <rect
                      y="7"
                      width="8"
                      height="2"
                      rx="1"
                      class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                        paymenAndDeliveryOpen() && 'rotate-180!'
                      }`}
                    />
                  </svg>
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                    paymenAndDeliveryOpen()
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden">
                    <div>
                      <h4 class="text-xl">Devlivery Information</h4>
                      <div>Lorem ipsum adlkjadkljakdlj</div>
                    </div>
                    <div>
                      <h4 class="text-xl">Payment Information</h4>
                      <div>Lorem ipsum adlkjadkljakdlj</div>
                    </div>
                    <div>
                      <h4 class="text-xl">Returns</h4>
                      <div>Lorem ipsum adlkjadkljakdlj</div>
                    </div>
                  </div>
                </div>

                <button
                  type="button"
                  onClick={() => setDiscoverOpen(!discoverOpen())}
                  class="flex justify-between w-full hover:cursor-pointer"
                >
                  <span class="text-2xl font-bold">Discover More</span>
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
                        discoverOpen() && 'rotate-180!'
                      }`}
                    />
                    <rect
                      y="7"
                      width="8"
                      height="2"
                      rx="1"
                      class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                        discoverOpen() && 'rotate-180!'
                      }`}
                    />
                  </svg>
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                    discoverOpen()
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden">
                    <ul class='flex gap-2'>
                      <For each={book().genres}>
                        {(item, index) => (
                          <A
                            class="w-auto border hover:border-everforest-aqua hover:cursor-pointer font-medium leading-5 text-sm px-4 py-2.5 focus:outline-none"
                            href={`/category/${item.name}`}
                          >
                            {item.name}
                          </A>
                        )}
                      </For>
                    </ul>
                  </div>
                </div>
                <Switch>
                  <Match when={book().reviews.length !== 0}>
                    <button
                      type="button"
                      onClick={() => setReviewsOpen(!reviewsOpen())}
                      class="flex justify-between w-full hover:cursor-pointer"
                    >
                      <span class="text-2xl font-bold">Reviews</span>
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
                            reviewsOpen() && 'rotate-180!'
                          }`}
                        />
                        <rect
                          y="7"
                          width="8"
                          height="2"
                          rx="1"
                          class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                            reviewsOpen() && 'rotate-180!'
                          }`}
                        />
                      </svg>
                    </button>
                    <div
                      class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
                        reviewsOpen()
                          ? 'grid-rows-[1fr] opacity-100'
                          : 'grid-rows-[0fr] opacity-0'
                      }`}
                    >
                      <div class="overflow-hidden">
                        <For each={book().reviews}>
                          {(item, index) => (
                            <div class="py-2">
                              <div>
                                <div class="text-xl">
                                  {item.reviewer.firstName}{' '}
                                  {item.reviewer.lastName}
                                </div>

                                <div class="flex items-center space-x-1">
                                  <svg
                                    class={`w-3 h-3 ${item.score >= 1 ? 'text-everforest-aqua' : 'text-everforest-bg-1'}`}
                                    aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="24"
                                    height="24"
                                    fill="currentColor"
                                    viewBox="0 0 24 24"
                                  >
                                    <path d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                  </svg>
                                  <svg
                                    class={`w-3 h-3 ${item.score >= 2 ? 'text-everforest-aqua' : 'text-everforest-bg-1'}`}
                                    aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="24"
                                    height="24"
                                    fill="currentColor"
                                    viewBox="0 0 24 24"
                                  >
                                    <path d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                  </svg>
                                  <svg
                                    class={`w-3 h-3 ${item.score >= 3 ? 'text-everforest-aqua' : 'text-everforest-bg-1'}`}
                                    aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="24"
                                    height="24"
                                    fill="currentColor"
                                    viewBox="0 0 24 24"
                                  >
                                    <path d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                  </svg>
                                  <svg
                                    class={`w-3 h-3 ${item.score >= 4 ? 'text-everforest-aqua' : 'text-everforest-bg-1'}`}
                                    aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="24"
                                    height="24"
                                    fill="currentColor"
                                    viewBox="0 0 24 24"
                                  >
                                    <path d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                  </svg>
                                  <svg
                                    class={`w-3 h-3 ${item.score >= 5 ? 'text-everforest-aqua' : 'text-everforest-bg-1'}`}
                                    aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="24"
                                    height="24"
                                    fill="currentColor"
                                    viewBox="0 0 24 24"
                                  >
                                    <path d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                  </svg>
                                </div>

                                <div>{item.score}</div>
                              </div>
                              <div>
                                <div>{item.text}</div>
                              </div>
                            </div>
                          )}
                        </For>
                      </div>
                    </div>
                  </Match>
                  <Match when={book().reviews.length === 0}>
                    <div></div>
                  </Match>
                </Switch>
              </div>

              {/* a list of books from the same author, a list of similar books (based on tags or some such) etc etc */}
            </div>
          </Show>
        </div>
      </div>
      <div class="col-span-1"></div>
    </div>
  );
};

export default BookDetail;
