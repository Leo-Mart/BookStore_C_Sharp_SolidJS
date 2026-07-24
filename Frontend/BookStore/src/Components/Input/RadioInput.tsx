import { Component, JSX, splitProps } from "solid-js";

type RadioInputProps = {
  name: string;
  label: string;
  placeholder?: string;
  value?: string;
  error: string;
  required?: boolean;
  checked?: boolean;
  ref: (element: HTMLInputElement) => void;
  onInput: JSX.EventHandler<HTMLInputElement, InputEvent>;
  onChange: JSX.EventHandler<HTMLInputElement, Event>;
  onBlur: JSX.EventHandler<HTMLInputElement, FocusEvent>;
};

const RadioInput: Component<RadioInputProps> = (props) => {
  const [, inputProps] = splitProps(props, ["value", "label", "error"]);
  const id = () => `${props.name}-${props.value}`;

  return (
    <div>
      <input
        {...inputProps}
        id={id()}
        type="radio"
        value={props.value}
        class="peer hidden"
        checked={props.checked}
      />
      <label
        for={id()}
        class="flex items-center justify-between bg-everforest-aqua w-full my-2 p-5 rounded cursor-pointer peer-checked:bg-everforest-fg hover:bg-everforest-fg"
      >
        {props.label}
      </label>
    </div>
  );
};

export default RadioInput;
