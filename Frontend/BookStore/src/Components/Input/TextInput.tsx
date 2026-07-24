import { Component, JSX, splitProps } from "solid-js";

type TextInputProps = {
  name: string;
  type: "text" | "email" | "tel" | "password";
  label: string;
  placeholder?: string;
  value: string | undefined;
  error: string;
  required?: boolean;
  ref: (element: HTMLInputElement) => void;
  onInput: JSX.EventHandler<HTMLInputElement, InputEvent>;
  onChange: JSX.EventHandler<HTMLInputElement, Event>;
  onBlur: JSX.EventHandler<HTMLInputElement, FocusEvent>;
};

const TextInput: Component<TextInputProps> = (props) => {
  const [, inputProps] = splitProps(props, ["value", "label", "error"]);

  return (
    <div>
      <label
        for={props.name}
        class="block mb-3 overflow-hidden px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3"
      >
        <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
          {props.label}
        </span>
        <input
          {...inputProps}
          id={props.name}
          value={props.value || ""}
          aria-invalid={!!props.error}
          aria-errormessage={`${props.name}-error`}
          class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
        />
      </label>
      {props.error && (
        <div id={`${props.name}-error`} class="text-everforest-red pb-1">
          {props.error}
        </div>
      )}
    </div>
  );
};

export default TextInput;
