import { JSX, Show, onCleanup, createEffect } from 'solid-js';
import { Portal } from 'solid-js/web';
import { Component } from 'solid-js';

interface DrawerProps {
  open: boolean;
  onClose: () => void;
  title?: string;
  children: JSX.Element;
  footer?: JSX.Element;
}


const Drawer: Component<DrawerProps> = (props: DrawerProps) => {
  createEffect(() => {
    document.body.style.overflow = props.open ? 'hidden' : '';
  });

  onCleanup(() => {
    document.body.style.overflow = '';
  });
  return (
    <Portal>
      <Show when={props.open}>
        <div
          class="fixed inset-0 z-40 bg-everforest-bg-dim/40 backdrop-blur-sm transition-opacity"
          onClick={props.onClose}
          aria-hidden="true"
        ></div>
      </Show>

      <div
        role="dialog"
        aria-modal="true"
        aria-label={props.title}
        class={`fixed inset-y-0 right-0 z-50 flex w-full max-w-md flex-col bg-everforest-bg-dim shadow-2xl transition-transform duration-300 ease-in-out ${props.open ? 'translate-x-0' : 'translate-x-full'}`}
      >
        <div class="flex items-center justify-between border-b border-everforest-fg px-5 py-4">
          <h2 class="text-lg font-semibold tracking-tight text-everforest-fg">
            {props.title}
          </h2>
          <button
            onClick={props.onClose}
            class="rounded-md p-1.5 text-everforest-fg transition hover:bg-everforest-bg-5 hover:text-everforest-fg focus:outline-none focus:ring-2 focus:ring-everforest-bg-5 hover:cursor-pointer"
            aria-label="Close drawer"
          >
            <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
              <path d="M6.28 5.22a.75.75 0 0 0-1.06 1.06L8.94 10l-3.72 3.72a.75.75 0 1 0 1.06 1.06L10 11.06l3.72 3.72a.75.75 0 1 0 1.06-1.06L11.06 10l3.72-3.72a.75.75 0 0 0-1.06-1.06L10 8.94 6.28 5.22Z" />
            </svg>
          </button>
        </div>

        <div class="flex-1 overflow-y-auto px-5 py-4">{props.children}</div>

        <Show when={props.footer}>
          <div class="border-t border-everforest-fg px-5 py-4">
            {props.footer}
          </div>
        </Show>
      </div>
    </Portal>
  );
};

export default Drawer;
