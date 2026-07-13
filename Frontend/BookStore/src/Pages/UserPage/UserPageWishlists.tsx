import {
  Component,
  createEffect,
  createResource,
  createSignal,
  For,
  Show,
} from "solid-js";
import { useAuth } from "../../Context/AuthContext";
import { Wishlist, WishlistItem } from "../../Types/User/wishlist";
import HeartX from "lucide-solid/icons/heart-x";
import { A } from "@solidjs/router";

const UserPageWishlists: Component = () => {
  const auth = useAuth();

  const fetchUserWishlists = async () => {
    const resp = await fetch("/api/wishlists", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return resp.json();
  };
  const [userWishlists] = createResource<Wishlist[]>(fetchUserWishlists);
  const [selectedList, setSelectedList] = createSignal<Wishlist>();

  createEffect(() => {
    if (!userWishlists.loading && !userWishlists.error) {
      setSelectedList(userWishlists()?.find((w) => w.isDefault === true));
    }
  });

  const handleRemoveClick = async (id: number) => {
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
  };

  return (
    <Show
      when={!userWishlists.loading && !userWishlists.error}
      fallback={
        <div class="text-center text-everforest-fg">No orders found!</div>
      }
    >
      <div class="grid grid-cols-12">
        <div class="col-span-2"></div>
        <section class="col-span-8 flex-col my-3 mx-2">
          <h2 class="text-2xl text-everforest-fg">Your wishlists</h2>
          <div>
            <h5 class="text-lg text-everforest-fg">Select List</h5>
          </div>

          <h3 class="text-xl text-everforest-fg">
            Viewing list: {selectedList()?.name}
          </h3>
          <ul class="flex flex-col">
            <For each={selectedList()?.wishlistItems}>
              {(item, _) => (
                <li class="flex text-everforest-fg">
                  {item.book.coverImageUrl !== "" ? (
                    <img
                      class="mr-2 object-cover w-full rounded-base h-64 md:h-auto md:w-48 mb-4 md:mb-0"
                      src="{item.book.coverImageUrl}"
                    />
                  ) : (
                    <img
                      class="mr-2 object-cover w-full rounded-base h-64 md:h-auto md:w-48 mb-4 md:mb-0"
                      src="../../../public/images/atbqj8.jpg"
                    />
                  )}
                  <div class="flex flex-col p-2">
                    <A class="hover:underline" href={`/books/${item.bookId}`}>
                      <h5 class="text-xl">{item.book.title}</h5>
                    </A>
                    <div>
                      {item.book.authors[0].firstName}{" "}
                      {item.book.authors[0].lastName}
                    </div>
                    <div>
                      {new Date(item.book.publishedDate)
                        .getFullYear()
                        .toString()}
                    </div>
                  </div>

                  <button
                    type="button"
                    onClick={[handleRemoveClick, item.id]}
                    class="ml-auto my-auto max-h-20 text-everforest-bg-dim dark:text-everforest-red dark:hover:text-everforest-bg-red hover:cursor-pointer focus:ring-4 font-medium leading-5 rounded text-xs px-3 py-1.5 focus:outline-none"
                  >
                    <HeartX />
                  </button>
                </li>
              )}
            </For>
          </ul>
        </section>

        <div class="col-span-2"></div>
      </div>
    </Show>
  );
};

export default UserPageWishlists;
