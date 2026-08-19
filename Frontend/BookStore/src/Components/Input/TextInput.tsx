import { FieldElementProps } from "@formisch/solid";
import { Component, splitProps } from "solid-js";

interface TextInputProps extends FieldElementProps {
  type: "text" | "email" | "tel" | "password";
  label?: string;
  placeholder?: string;
  input: string | undefined;
  errors: [string, ...string[]] | null;
  required?: boolean;
}

const TextInput: Component<TextInputProps> = (props) => {
  const [, inputProps] = splitProps(props, ["input", "label", "errors"]);

  return (
    <div>
      <label
        for={props.name}
        class="block mb-3 overflow-hidden px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3"
      >
        <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
          {props.label}{" "}
          {props.required && <span class="text-everforest-red">*</span>}
        </span>
        <input
          {...inputProps}
          id={props.name}
          value={props.input || ""}
          aria-invalid={!!props.errors}
          aria-errormessage={`${props.name}-error`}
          class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
        />
      </label>
      {props.errors && (
        <div id={`${props.name}-error`} class="text-everforest-red pb-1">
          {props.errors[0]}
        </div>
      )}
    </div>
  );
};

export default TextInput;
