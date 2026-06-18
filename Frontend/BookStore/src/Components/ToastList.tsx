import { Component, For } from 'solid-js';

interface Toast {
  id: string;
  message: string;
  type: ToastType;
  duration: number;
}

type ToastType = 'info' | 'success' | 'error' | 'warning';

const ToastList: Component<{ toasts: Toast[]; onDismiss: (id: string) => void }> = (props: {
  toasts: Toast[];
  onDismiss: (id: string) => void
}) => {
  return (
    <div class="fixed top-1.5 right-1.5 flex flex-col gap-0.5 z-9999 pointer-events-none">
      <For each={props.toasts}>
        {(toast) => (
          <div class='p-2 flex items-center gap-3 min-w-60 max-w-80 rounded-lg bg-everforest-aqua text-everforest-bg-dim shadow-xl text-sm animate-toast-in'>
            <span class='flex-1'>{toast.message}</span>
            <button class='bg-transparent border-none text-everforest-bg-dim text-lg leading-1 cursor-pointer hover:border-8 opacity-70' aria-label="dismiss notification" onClick={() => props.onDismiss(toast.id)}>
              &times;
            </button>
          </div>
        )}
      </For>
    </div>
  );
};

export default ToastList;
