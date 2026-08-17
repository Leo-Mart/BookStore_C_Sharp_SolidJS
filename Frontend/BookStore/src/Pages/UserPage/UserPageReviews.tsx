import {
  Component,
  createEffect,
  createResource,
  createSignal,
  For,
  Show,
} from "solid-js";
import { useAuth } from "../../Context/AuthContext";
import { UserInfo } from "../../Types/User/userinfo";
import { OrderItem, OrderStatus } from "../../Types/User/order";
import ModalCreateNewReview from "../../Components/ModalCreateNewReview";
import { ReviewInput } from "../../Types/User/review";
import { useToast } from "../../Context/ToastContext";

const UserPageReviews: Component = () => {
  const auth = useAuth();
  const toast = useToast();

  const fetchUserOrders = async () => {
    const resp = await fetch("/api/user/orders", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return resp.json();
  };

  const fetchUserReviews = async () => {
    const resp = await fetch("/api/user/reviews", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${auth.token()}`,
      },
    });
    return resp.json();
  };

  const [userOrders] = createResource<UserInfo>(fetchUserOrders);
  const [userReviews] = createResource<UserInfo>(fetchUserReviews);
  const [boughtItems, setBoughtItems] = createSignal<OrderItem[]>();
  const [selectedBook, setSelectedBook] = createSignal<number>();
  const [createReviewModalOpen, setCreateReviewModalOpen] =
    createSignal<boolean>(false);

  const [loading, setLoading] = createSignal<boolean>(false);
  const [error, setError] = createSignal<string | null>(null);

  createEffect(() => {
    if (!userOrders.loading && !userOrders.error) {
      const completedOrders = userOrders()?.orders.filter(
        (o) =>
          o.orderStatus === OrderStatus["Delivered"] ||
          o.orderStatus === OrderStatus["Shipped"],
      );

      const orderItems: OrderItem[] = [];

      completedOrders?.forEach((order) =>
        order.items.forEach((item) => {
          orderItems.push(item);
        }),
      );

      const filterOutAlreadyReviewedBooks = orderItems.filter((oi) =>
        userReviews()?.reviews.every((r) => oi.bookInfo.id !== r.bookId),
      );

      setBoughtItems(filterOutAlreadyReviewedBooks);
    }
  });

  const handleOpenModal = (e: Event & { currentTarget: HTMLButtonElement }) => {
    setCreateReviewModalOpen(true);
    if (e.currentTarget.dataset.bookId === undefined) {
      setSelectedBook(0);
      return;
    }
    setSelectedBook(+e.currentTarget.dataset.bookId);
  };

  const createNewReview = async (input: ReviewInput) => {
    setLoading(true);
    setError(null);

    try {
      const resp = await fetch(`/api/books/${selectedBook()}/reviews`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${auth.token()}`,
        },
        body: JSON.stringify(input),
      });
      if (!resp.ok) {
        throw Error(await resp.text());
      }
      return resp.json();
    } catch (error) {
      setError(
        error instanceof Error ? error.message : "Something went wrong.",
      );
    } finally {
      setLoading(false);
      toast.add("You successfully left a review!", { type: "success" });
    }
  };

  return (
    <Show
      when={!userOrders.loading && !userOrders.error}
      fallback={
        <div class="text-center text-everforest-fg">No orders found!</div>
      }
    >
      <div class="grid grid-cols-12">
        <div class="hidden lg:flex lg:col-span-2"></div>
        <section class="text-everforest-fg col-span-12 lg:col-start-3 lg:col-span-8 flex-col mb-3 mx-2">
          <h2 class="text-2xl">Your purchased items</h2>
          <p>Use the button on the item to leave a reviw.</p>
          <div class="flex gap-5">
            <For
              each={boughtItems()}
              fallback={
                <div>
                  You've reviewed all the books you've bought. Much appreciated!
                </div>
              }
            >
              {(item, _) => (
                <>
                  <div class="flex flex-col justify-between size-60 border border-everforest-aqua/50 bg-everforest-bg-1 p-3">
                    <h3 class="text-xl">{item.bookInfo.title}</h3>
                    <div class="flex flex-col gap-3">
                      <span>
                        {item.bookInfo.authors[0].firstName}{" "}
                        {item.bookInfo.authors[0].lastName}
                      </span>
                      <span>Price: {item.bookInfo.price} kr</span>
                    </div>
                    <div class="flex mx-auto max-w-2/3">
                      <button
                        data-book-id={`${item.bookInfo.id}`}
                        type="button"
                        onClick={handleOpenModal}
                        class="bg-white block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
                      >
                        Review
                      </button>
                    </div>
                  </div>
                </>
              )}
            </For>
          </div>
        </section>
        <ModalCreateNewReview
          open={createReviewModalOpen()}
          onClose={() => setCreateReviewModalOpen(false)}
          loading={loading()}
          bookId={selectedBook()!}
          error={error()}
          createNewReview={createNewReview}
        />

        <div class="hidden lg:flex lg:col-span-2"></div>
      </div>
    </Show>
  );
};

export default UserPageReviews;
