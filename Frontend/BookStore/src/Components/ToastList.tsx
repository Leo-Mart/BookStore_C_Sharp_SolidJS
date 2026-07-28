import { Component, For } from "solid-js";
import { type Toast } from "../Types/toasts";
import { Dynamic } from "solid-js/web";
import TriangleAlert from "lucide-solid/icons/triangle-alert";
import SquareX from "lucide-solid/icons/square-x";
import LucideSquareCheckBig from "lucide-solid/icons/square-check-big";
import Info from "lucide-solid/icons/info";
import X from "lucide-solid/icons/x";

const infoToast = (props: {
  toast: Toast;
  onDismiss: (id: string) => void;
}) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 dark:bg-everforest-bg-3 border dark:border-everforest-aqua dark:text-everforest-fg shadow-xl text-sm animate-toast-in">
    <span class="text-everforest-aqua">
      <Info />
    </span>
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none dark:text-everforest-fg text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      <X />
    </button>
  </div>
);

const successToast = (props: {
  toast: Toast;
  onDismiss: (id: string) => void;
}) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 dark:bg-everforest-bg-3 border dark:border-everforest-green dark:text-everforest-fg shadow-xl text-sm animate-toast-in">
    <span class="text-everforest-green">
      <LucideSquareCheckBig />
    </span>
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none dark:text-everforest-fg text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      <X />
    </button>
  </div>
);

const errorToast = (props: {
  toast: Toast;
  onDismiss: (id: string) => void;
}) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 dark:bg-everforest-bg-3 border dark:border-everforest-red dark:text-everforest-fg shadow-xl text-sm animate-toast-in">
    <span class="text-everforest-red">
      <SquareX />
    </span>
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none dark:text-everforest-fg text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      <X />
    </button>
  </div>
);

const warningToast = (props: {
  toast: Toast;
  onDismiss: (id: string) => void;
}) => (
  <div class="flex pointer-events-auto items-center p-4 gap-3 min-w-60 max-w-80 dark:bg-everforest-bg-3 border dark:border-everforest-yellow dark:text-everforest-fg shadow-xl text-sm animate-toast-in">
    <span class="dark:text-everforest-yellow">
      <TriangleAlert />
    </span>
    <span class="flex-1">{props.toast.message}</span>
    <button
      class="bg-transparent border-none dark:text-everforest-fg text-lg leading-1 cursor-pointer opacity-70 hover:opacity-100"
      aria-label="dismiss notification"
      onClick={() => props.onDismiss(props.toast.id)}
    >
      <X />
    </button>
  </div>
);

const options = {
  info: infoToast,
  success: successToast,
  error: errorToast,
  warning: warningToast,
};

const ToastList: Component<{
  toasts: Toast[];
  onDismiss: (id: string) => void;
}> = (props: { toasts: Toast[]; onDismiss: (id: string) => void }) => {
  return (
    <div class="fixed top-1.5 right-1.5 flex flex-col gap-0.5 z-9999 pointer-events-none">
      <For each={props.toasts}>
        {(toast) => (
          <Dynamic
            component={options[toast.type]}
            toast={toast}
            onDismiss={props.onDismiss}
          />
        )}
      </For>
    </div>
  );
};

export default ToastList;
