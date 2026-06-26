import { Component, For } from 'solid-js';
import { type Toast } from '../Types/toasts';
import { Dynamic } from 'solid-js/web';

const infoToast = (props: { toast: Toast; onDismiss: (id: string) => void }) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 rounded-lg bg-everforest-bg-5 text-everforest-bg-dim shadow-xl text-sm animate-toast-in">
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none text-everforest-bg-dim text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      &times;
    </button>
  </div>
);

const successToast = (props: { toast: Toast; onDismiss: (id: string) => void }) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 rounded-lg bg-everforest-aqua text-everforest-bg-dim shadow-xl text-sm animate-toast-in">
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none text-everforest-bg-dim text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      &times;
    </button>
  </div>
);

const errorToast = (props: { toast: Toast; onDismiss: (id: string) => void }) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 rounded-lg bg-everforest-red text-everforest-bg-dim shadow-xl text-sm animate-toast-in">
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none text-everforest-bg-dim text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      &times;
    </button>
  </div>
);

const warningToast = (props: { toast: Toast; onDismiss: (id: string) => void }) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 rounded-lg bg-everforest-yellow text-everforest-bg-dim shadow-xl text-sm animate-toast-in">
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none text-everforest-bg-dim text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      &times;
    </button>
  </div>
);

const options = {
  info: infoToast,
  success: successToast,
  error: errorToast,
  warning: warningToast
}

const ToastList: Component<{
  toasts: Toast[];
  onDismiss: (id: string) => void;
}> = (props: { toasts: Toast[]; onDismiss: (id: string) => void }) => {
  return (
    <div class="fixed top-1.5 right-1.5 flex flex-col gap-0.5 z-9999 pointer-events-none">
      <For each={props.toasts}>
        {(toast) => (
          <Dynamic component={options[toast.type]} toast={toast} onDismiss={props.onDismiss} />
        )}
      </For>
    </div>
  );
};

export default ToastList;
