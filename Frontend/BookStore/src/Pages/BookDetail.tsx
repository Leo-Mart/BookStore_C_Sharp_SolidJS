import { useParams } from '@solidjs/router';
import {
  Component,
  createResource,
  createSignal,
  For,
  Match,
  Show,
  Switch,
} from 'solid-js';
import Heart from 'lucide-solid/icons/heart';
import ShoppingBasket from 'lucide-solid/icons/shopping-basket';

const fetchBook = async (bookId: string) => {
  const response = await fetch(`/api/books/${bookId}`);
  return response.json();
};

const BookDetail: Component = () => {
  const params = useParams();
  const [book] = createResource(() => params.bookId, fetchBook);

  const [amount, setAmount] = createSignal(1);
  const [descOpen, setDescOpen] = createSignal(false);
  const [prodInfoOpen, setProdInfoOpen] = createSignal(false);
  const [paymenAndDeliveryOpen, setPaymentAndDeliveryOpen] = createSignal(false);
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
      <div class="col-span-1 bg-green-700"></div>
      <div class="col-span-10 grid grid-cols-1 lg:grid-cols-6 text-white gap-2">
        <aside class="self-start flex flex-col gap-20">
          <div class="pointer-events-none py-16">
            <div class="mx-auto flex">
              <img
                class="h-full w-full object-contain"
                src="./images/atbqj8.jpg"
                alt="bööks bröther"
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
                <span>{book().price} monies</span>
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

                <button class="flex gap-1 grow justify-center bg-emerald-700 px-5 py-2.5 text-sm font-medium text-black transition hover:bg-amber-600 hover:cursor-pointer">
                  Add to cart
                  <ShoppingBasket />
                </button>
                <button class="flex gap-0.5 py-2.5 text-sm font-medium text-black hover:cursor-pointer">
                  <Heart /> Add to Wishlist
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
                  <span>Description</span>
                  {descOpen() ? <span>-</span> : <span>+</span>}
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-slate-600 text-sm ${
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
                  <span>Product Info</span>
                  {prodInfoOpen() ? <span>-</span> : <span>+</span>}
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-slate-600 text-sm ${
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
                          {new Date(book().publishedDate).getDate()}
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
                  onClick={() => setPaymentAndDeliveryOpen(!paymenAndDeliveryOpen())}
                  class="flex justify-between w-full hover:cursor-pointer"
                >
                  <span>Payment and Delivery</span>
                  {paymenAndDeliveryOpen() ? <span>-</span> : <span>+</span>}
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-slate-600 text-sm ${
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
                  <span>Discover More</span>
                  {discoverOpen() ? <span>-</span> : <span>+</span>}
                </button>
                <div
                  class={`grid overflow-hidden transition-all duration-300 ease-in-out text-slate-600 text-sm ${
                    discoverOpen()
                      ? 'grid-rows-[1fr] opacity-100'
                      : 'grid-rows-[0fr] opacity-0'
                  }`}
                >
                  <div class="overflow-hidden">
                    <ul>
                      <For each={book().genres}>
                        {(item, index) => <li>{item.name}</li>}
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
                      <span>Reviews</span>
                      {reviewsOpen() ? <span>-</span> : <span>+</span>}
                    </button>
                    <div
                      class={`grid overflow-hidden transition-all duration-300 ease-in-out text-slate-600 text-sm ${
                        reviewsOpen()
                          ? 'grid-rows-[1fr] opacity-100'
                          : 'grid-rows-[0fr] opacity-0'
                      }`}
                    >
                      <div class="overflow-hidden">
                        <For each={book().reviews}>
                          {(item, index) => (
                            <div>
                              <div>
                                <div>Reviewer</div>
                                <div>{item.score}</div>
                              </div>
                              <div>
                                <div>{item.title}</div>
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
      <div class="col-span-1 bg-green-700"></div>
    </div>
  );
};

export default BookDetail;
