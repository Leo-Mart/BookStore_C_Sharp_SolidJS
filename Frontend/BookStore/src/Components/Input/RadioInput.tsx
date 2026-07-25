import { FieldElementProps } from "@formisch/solid";
import { Component, JSX, splitProps } from "solid-js";

interface RadioInputProps extends FieldElementProps {
  label: string;
  placeholder?: string;
  input: string | undefined;
  errors: [string, ...string[]] | null;
  required?: boolean;
  checked?: boolean;
}

const RadioInput: Component<RadioInputProps> = (props) => {
  const [, inputProps] = splitProps(props, ["input", "label", "errors"]);
  const id = () => `${props.name}-${props.input}`;

  return (
    <div>
      <input
        {...inputProps}
        id={id()}
        type="radio"
        value={props.input}
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
