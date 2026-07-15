import { Component, createSignal, For } from "solid-js";
import Modal from "./Modal";
import { AddToWishlistModalProps } from "../Types/modal";
import { Wishlist } from "../Types/User/wishlist";

const ModalAddToWishlist: Component<AddToWishlistModalProps> = (props) => {
  const [selectedList, setSelectedList] = createSignal<string>("");

  const handleListSelect = (e: Event & { currentTarget: HTMLInputElement }) => {
    const { value } = e.currentTarget;
    setSelectedList(value);
  };

  const onSelect = () => {
    const list = props.wishlists.find(
      (list) =>
        list.name.toLocaleLowerCase() === selectedList().toLocaleLowerCase(),
    );
    if (list === undefined) {
      throw new Error("Could not find list");
    }
    props.selectWishlist(list);
  };
  const footer = (
    <div class=" flex flex-row items-center justify-center gap-1">
      <button
        onClick={onSelect}
        class="w-full bg-everforest-aqua py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2"
      >
        Add to wishlist
      </button>
      <button
        onClick={props.onClose}
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
      title={`Add to wishlist`}
      footer={footer}
    >
      <div>
        <ul class="flex flex-col">
          <For each={props.wishlists}>
            {(item, _) => (
              <li>
                <input
                  class="hidden peer"
                  type="radio"
                  id={`wl-${item.name}`}
                  name="list-select"
                  value={`${item.name}`}
                  checked={selectedList() === `${item.name}`}
                  onChange={handleListSelect}
                  required
                />
                <label
                  for={`wl-${item.name}`}
                  class="w-full p-2 flex justify-around cursor-pointer text-everforest-fg peer-checked:bg-everforest-bg-blue hover:bg-everforest-bg-blue"
                >
                  {item.name}
                </label>
              </li>
            )}
          </For>
        </ul>
      </div>
    </Modal>
  );
};

export default ModalAddToWishlist;
