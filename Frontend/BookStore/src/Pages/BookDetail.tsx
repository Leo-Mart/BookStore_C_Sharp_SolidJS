import { A, useParams } from "@solidjs/router";
import {
  Component,
  createEffect,
  createResource,
  createSignal,
  Match,
  Show,
  Switch,
} from "solid-js";
import HeartMinus from "lucide-solid/icons/heart-minus";
import HeartPlus from "lucide-solid/icons/heart-plus";
import ShoppingBasket from "lucide-solid/icons/shopping-basket";
import { useCart } from "../Context/CartContext";
import { useAuth } from "../Context/AuthContext";
import { useToast } from "../Context/ToastContext";
import { type Wishlist, WishlistItem } from "../Types/User/wishlist";
import ModalAddToWishlist from "../Components/ModalAddToWishlist";
import Accordion from "../Components/Accordions/Accordion";
import AccordionProductInfo from "../Components/Accordions/AccordionProductInfo";
import AccordionPaymentAndDelivery from "../Components/Accordions/AccordionPaymentAndDelivery";
import AccordionDiscoverMore from "../Components/Accordions/AccordionDiscoverMore";
import AccordionReviews from "../Components/Accordions/AccordionReviews";

const BookDetail: Component = () => {
  const params = useParams();

  const cart = useCart();
  const auth = useAuth();
  const toast = useToast();

  const fetchWishlist = async () => {
    const response = await fetch("/api/wishlists", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return response.json();
  };

  const fetchBook = async (bookId: string) => {
    const response = await fetch(`/api/books/${bookId}`);
    return response.json();
  };

  const [book] = createResource(() => params.bookId, fetchBook);
  const [wishlists] = createResource<Wishlist[], boolean>(
    () => auth.isAuthenticated() === true,
    fetchWishlist,
  );

  createEffect(() => {
    if (!wishlists.loading && !book.loading) {
      if (selectedWishlist() === undefined) {
        const defaultWishlist = wishlists()?.find(
          (wl) => wl.isDefault === true,
        );
        setSelectedWishlist(defaultWishlist!);
      }

      const found = wishlists()?.find((list) => {
        const foundItem = list.wishlistItems.find(
          (item) => item.bookId === book().id,
        );
        if (foundItem) {
          setWishlisted(true);
          return true;
        }
        return false;
      });
      setFoundInList(found);
    }
  });

  const [wishlisted, setWishlisted] = createSignal(false);
  const [selectedWishlist, setSelectedWishlist] = createSignal<Wishlist>();
  const [addToWishlistModalOpen, setAddToWishlistModalOpen] =
    createSignal<boolean>(false);
  const [foundInList, setFoundInList] = createSignal<Wishlist>();

  const [amount, setAmount] = createSignal(1);

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
  const handleRemoveFromWishlist = async () => {
    if (auth.isAuthenticated()) {
      setWishlisted(false);
      toast.add(`Removed from the ${foundInList()?.name} wishlist!`, {
        type: "success",
      });

      const itemToRemove = foundInList()?.wishlistItems.find(
        (item) => item.bookId === book().id,
      );
      if (itemToRemove === undefined) {
        console.log("oh no");
        return;
      }

      await fetch(
        `/api/wishlists/${+foundInList()!.id!}/remove-item/${itemToRemove.id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${auth.token()}`,
          },
        },
      );
    } else {
      toast.add("You need to be registered to remove books from wishlist!", {
        type: "error",
      });
    }
  };
  const handleWishlistSelect = async (selectedList: Wishlist) => {
    setWishlisted(true);
    toast.add("Added to wishlist!", { type: "success" });

    if (selectedList) {
      setSelectedWishlist(selectedList);
    } else {
      const defaultWishlist = wishlists()?.find((wl) => wl.isDefault === true);
      setSelectedWishlist(defaultWishlist!);
    }
    const newWishlisteItem: WishlistItem = {
      bookId: book().id,
      wishlistId: +selectedWishlist()?.id!,
    };
    selectedWishlist()?.wishlistItems.push(newWishlisteItem);

    await fetch(`/api/wishlists/${+selectedWishlist()!.id!}/add-item`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${auth.token()}`,
      },
      body: JSON.stringify(newWishlisteItem),
    });
    setAddToWishlistModalOpen(false);
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
                  Author: {book().authors[0].firstName}{" "}
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
                      title: book().title,
                      author: book().author,
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
                <Switch>
                  <Match when={wishlisted()}>
                    <button
                      class="flex gap-0.5 py-2.5 grow-0 text-sm font-medium text-everforest-fg hover:cursor-pointer"
                      onclick={async () => await handleRemoveFromWishlist()}
                    >
                      <HeartMinus /> Remove
                    </button>
                  </Match>
                  <Match when={!wishlisted()}>
                    <button
                      class="flex gap-0.5 py-2.5 grow-0 text-sm font-medium text-everforest-fg hover:cursor-pointer"
                      onclick={() =>
                        auth.isAuthenticated()
                          ? setAddToWishlistModalOpen(true)
                          : toast.add(
                              "You need to be registered to add books to wishlist!",
                              { type: "error" },
                            )
                      }
                    >
                      <HeartPlus /> Wishlist
                    </button>
                  </Match>
                </Switch>
              </div>

              <div class="flex max-w-3/4 justify-between gap-1 border">
                <div class="p-1">Inventory status goes here</div>
              </div>
              <div class="py-8 max-w-3/4 flex flex-col gap-3">
                <Accordion
                  title={"Description"}
                  children={book().description}
                />
                <AccordionProductInfo book={book()} />
                <AccordionPaymentAndDelivery />
                <AccordionDiscoverMore book={book()} />
                <Switch fallback={<div></div>}>
                  <Match when={book().reviews.length !== 0}>
                    <AccordionReviews book={book()} />
                  </Match>
                </Switch>
              </div>
            </div>
          </Show>
        </div>
      </div>
      <div class="col-span-1"></div>
      <ModalAddToWishlist
        open={addToWishlistModalOpen()}
        selectWishlist={handleWishlistSelect}
        wishlists={wishlists()!}
        onClose={() => setAddToWishlistModalOpen(false)}
      />
    </div>
  );
};

export default BookDetail;
