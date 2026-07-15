import { Component, createEffect, createSignal } from "solid-js";
import Modal from "./Modal";
import { CreateWishlistModalProps } from "../Types/modal";

const ModalCreateWishlist: Component<CreateWishlistModalProps> = (
  props: CreateWishlistModalProps,
) => {
  const [wishlistName, setWishlistName] = createSignal<string>("");
  const [wishlistDescription, setWishlistDescription] =
    createSignal<string>("");

  const reset = () => {
    setWishlistName("");
    setWishlistDescription("");
  };

  const handleCreate = () => {
    if (!wishlistName().trim() || props.loading) return;
    props.createNewWishlist({
      name: wishlistName(),
      description: wishlistDescription(),
      isDefault: false,
    });
  };

  const handleClose = () => {
    if (props.loading) return;
    props.onClose();
  };

  createEffect(() => {
    if (!props.open) reset();
  });

  const footer = (
    <div class=" flex flex-row items-center justify-center gap-1">
      <button
        onClick={handleCreate}
        disabled={props.loading}
        class="w-full bg-everforest-aqua py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2"
      >
        {props.loading ? "Creating..." : "Create wishlist"}
      </button>
      <button
        onClick={handleClose}
        disabled={props.loading}
        class="w-full bg-everforest-red py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2"
      >
        Cancel
      </button>
    </div>
  );

  return (
    <Modal
      open={props.open}
      onClose={props.onClose}
      title={`Create new Wishlist`}
      footer={footer}
    >
      <div>
        <label
          for="wishlist-name"
          class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
        >
          <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
            Wishlist name
          </span>
          <input
            type="text"
            name="wishlist-name"
            placeholder="Enter a name for the wishlist"
            id="wishlist-name"
            value={wishlistName()}
            onChange={(e) => setWishlistName(e.target.value)}
            class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
          />
        </label>

        <label
          for="wishlist-desc"
          class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
        >
          <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
            Wishlist description
          </span>
          <input
            type="text"
            name="wishlist-desc"
            placeholder="Enter a description for the wishlist"
            id="wishlist-desc"
            value={wishlistDescription()}
            onChange={(e) => setWishlistDescription(e.target.value)}
            class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
          />
        </label>
      </div>
    </Modal>
  );
};

export default ModalCreateWishlist;
