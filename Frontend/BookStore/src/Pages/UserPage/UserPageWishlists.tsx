import {
  Component,
  createEffect,
  createResource,
  createSignal,
  For,
  Show,
} from "solid-js";
import { useAuth } from "../../Context/AuthContext";
import {
  Wishlist,
  WishlistInput,
  WishlistItem,
} from "../../Types/User/wishlist";
import HeartX from "lucide-solid/icons/heart-x";
import ChevronRight from "lucide-solid/icons/chevron-right";
import X from "lucide-solid/icons/x";
import Plus from "lucide-solid/icons/plus";
import { A } from "@solidjs/router";
import ModalCreateWishlist from "../../Components/ModalCreateWishlist";
import { useToast } from "../../Context/ToastContext";

const UserPageWishlists: Component = () => {
  const auth = useAuth();
  const toast = useToast();

  const fetchUserWishlists = async () => {
    const resp = await fetch("/api/wishlists", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return resp.json();
  };
  const [userWishlists, { mutate }] =
    createResource<Wishlist[]>(fetchUserWishlists);
  const [listOverviewOpen, setListOverviewOpen] = createSignal<boolean>(false);
  const [selectedList, setSelectedList] = createSignal<Wishlist>();
  const [createWishlistModalOpen, setCreateWishlistModalOpen] =
    createSignal<boolean>(false);

  const [loading, setLoading] = createSignal<boolean>(false);
  const [error, setError] = createSignal<string | null>(null);

  createEffect(() => {
    if (!userWishlists.loading && !userWishlists.error) {
      setSelectedList(userWishlists()?.find((w) => w.isDefault === true));
    }
  });

  const removeItemFromWishlist = async (id: number) => {
    setSelectedList((prev) => {
      if (!prev) return prev;
      return {
        ...prev,
        wishlistItems: prev?.wishlistItems.filter(
          (item): item is WishlistItem & { id: number } =>
            item.id !== undefined && item.id !== id,
        ),
      };
    });

    const resp = await fetch(
      `/api/wishlists/${selectedList()!.id}/remove-item/${id}`,
      {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${auth.token()}`,
        },
      },
    );

    toast.add("Item removed!", { type: "success" });
  };

  const createNewWishlist = async (input: WishlistInput) => {
    setLoading(true);
    setError(null);
    try {
      const resp = await fetch("/api/wishlists", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",

          Authorization: `Bearer ${auth.token()}`,
        },
        body: JSON.stringify(input),
      });

      if (!resp.ok) {
        throw new Error(`Failed to create wishlist (${resp.status})`);
      }

      const created: Wishlist = await resp.json();
      mutate((prev = []) => [...prev, created]);
      setCreateWishlistModalOpen(false);
    } catch (err) {
      setError(err instanceof Error ? err.message : "Something went wrong");
    } finally {
      setLoading(false);

      toast.add("Wishlist Created!", { type: "success" });
    }
  };

  const selectWishlist = (wishlistId: number) => {
    const foundList = userWishlists()?.find((list) => list.id === wishlistId);
    setSelectedList(foundList);

    toast.add("Switched wishlist!", { type: "success" });
  };

  const deleteWishlist = async (wishlistId: number, e: Event) => {
    e.stopPropagation();
    mutate((prev) => prev?.filter((w) => w.id !== wishlistId));

    const resp = await fetch(`/api/wishlists/${wishlistId}`, {
      method: "DELETE",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    if (!resp.ok) throw new Error("Delete Failed");
    toast.add("Wishlist deleted!", { type: "success" });
  };

  return (
    <Show
      when={!userWishlists.loading && !userWishlists.error}
      fallback={
        <div class="text-center text-everforest-fg">No wishlists found!</div>
      }
    >
      <div class="grid grid-cols-12">
        <div class="col-span-2"></div>
        <section class="col-span-8 flex-col my-3 mx-2">
          <button
            onClick={() => setListOverviewOpen(!listOverviewOpen())}
            class="text-2xl flex justify-between p-2 w-full hover:cursor-pointer text-everforest-fg"
          >
            <span>Your wishlists</span>
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
                  listOverviewOpen() && "rotate-180!"
                }`}
              />
              <rect
                y="7"
                width="8"
                height="2"
                rx="1"
                class={`transform origin-center rotate-90 transition duration-200 ease-out ${
                  listOverviewOpen() && "rotate-180!"
                }`}
              />
            </svg>
          </button>
          <div
            class={` text-everforest-fg overflow-hidden p-2 ${listOverviewOpen() ? "" : "hidden"}`}
          >
            <div class="w-full flex justify-start p-3 hover:underline">
              <button
                class="inline-flex items-center p-2 justify-between w-full text-sm text-everforest-fg hover:cursor-pointer"
                onClick={() => setCreateWishlistModalOpen(true)}
              >
                <span>Create new wishlist</span>
                <Plus />
              </button>
            </div>
            <ul class="w-full">
              <For each={userWishlists()}>
                {(item) => (
                  <li>
                    <div
                      onClick={() => selectWishlist(item.id)}
                      class="grid grid-cols-4 justify-between items-center hover:cursor-pointer hover:animate-pulse"
                    >
                      <div>{item.name}</div>
                      <div class="truncate">{item.description}</div>
                      <div class="flex flex-row justify-between">
                        Wishlisted items: {item.wishlistItems.length}
                        <span class="border-everforest-fg">
                          <ChevronRight />
                        </span>
                      </div>
                      <Show when={item.isDefault === false}>
                        <button
                          type="button"
                          onClick={[deleteWishlist, item.id]}
                          class="my-auto ml-auto max-h-20 text-everforest-bg-dim dark:text-everforest-red dark:hover:text-everforest-bg-red hover:cursor-pointer font-medium leading-5 rounded text-xs px-3 py-1.5"
                        >
                          <X />
                        </button>
                      </Show>
                    </div>
                    <hr class="my-6 h-px border-t-0 bg-linear-to-r from-transparent via-everforest-fg to-transparent opacity-75 dark:via-everforest-fg" />
                  </li>
                )}
              </For>
            </ul>
          </div>

          <ul class="flex flex-col p-2">
            <h3 class="text-xl text-everforest-fg">
              Viewing list: {selectedList()?.name}
            </h3>
            <h4 class="text-lg text-everforest-fg">
              {selectedList()?.description
                ? `Description: ${selectedList()?.description}`
                : ""}
            </h4>
            <Show
              when={
                selectedList() !== undefined &&
                selectedList()!.wishlistItems.length > 0
              }
              fallback={
                <div class="text-everforest-fg text-center p-2">
                  No items in the wishlist, go add some!
                </div>
              }
            >
              <For each={selectedList()?.wishlistItems}>
                {(item, _) => (
                  <>
                    <li class="flex text-everforest-fg my-2">
                      {item.book?.coverImageUrl !== "" ? (
                        <img
                          class="mr-2 object-cover w-full rounded-base h-64 md:h-auto md:w-48 mb-4 md:mb-0"
                          src="{item.book.coverImageUrl}"
                        />
                      ) : (
                        <img
                          class="mr-2 object-cover w-full rounded-base h-64 md:h-auto md:w-48 mb-4 md:mb-0"
                          src="/images/atbqj8.jpg"
                        />
                      )}
                      <div class="flex flex-col p-2">
                        <A
                          class="hover:underline"
                          href={`/books/${item.bookId}`}
                        >
                          <h5 class="text-xl">{item.book?.title}</h5>
                        </A>
                        <div>
                          {item.book?.authors[0].firstName}{" "}
                          {item.book?.authors[0].lastName}
                        </div>
                        <div>
                          {new Date(item.book!.publishedDate)
                            .getFullYear()
                            .toString()}
                        </div>
                      </div>

                      <button
                        type="button"
                        onClick={[removeItemFromWishlist, item.id]}
                        class="ml-auto my-auto max-h-20 text-everforest-bg-dim dark:text-everforest-red dark:hover:text-everforest-bg-red hover:cursor-pointer focus:ring-4 font-medium leading-5 rounded text-xs px-3 py-1.5 focus:outline-none"
                      >
                        <HeartX />
                      </button>
                    </li>
                    <hr class="my-6 h-px border-t-0 bg-linear-to-r from-transparent via-everforest-fg to-transparent opacity-75 dark:via-everforest-fg" />
                  </>
                )}
              </For>
            </Show>
          </ul>
        </section>

        <div class="col-span-2"></div>

        <ModalCreateWishlist
          open={createWishlistModalOpen()}
          loading={loading()}
          error={error()}
          createNewWishlist={createNewWishlist}
          onClose={() => setCreateWishlistModalOpen(false)}
        />
      </div>
    </Show>
  );
};

export default UserPageWishlists;
