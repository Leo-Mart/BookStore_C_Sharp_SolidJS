import { Component } from 'solid-js';
import Modal from './Modal';
import { type DiscountCodeModalProps } from '../Types/modal';

const ModalDiscountCode: Component<DiscountCodeModalProps> = (
  props: DiscountCodeModalProps,
) => {
  const footer = (
    <div class=" flex flex-row items-center justify-center gap-1">
      <button
        onClick={props.onClose}
        class="w-full bg-everforest-aqua py-3 text-sm font-semibold text-everforest-bg-dim transition hover:bg-everforest-fg hover:cursor-pointer focus:outline-none focus:ring-2 focus:ring-everforest-aqua focus:ring-offset-2"
      >
        Apply Code
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
      title={`Add Discount Code`}
      footer={footer}
    >
      <div>
        <label
          for="discount-code"
          class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-0"
        >
          <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
            Discount Code
          </span>
          <input
            type="text"
            name="discount-code"
            placeholder="Enter Discount Code"
            id="discount-code"
            class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
          />
        </label>
      </div>
    </Modal>
  );
};

export default ModalDiscountCode;
