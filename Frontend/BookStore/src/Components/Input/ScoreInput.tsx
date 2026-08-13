import { FieldElementProps } from "@formisch/solid";
import { Component, createSignal, For } from "solid-js";

interface ScoreInputProps extends Omit<FieldElementProps, "onChange"> {
  label: string;
  value: number;
  errors?: [string, ...string[]] | null;
  onChange: (value: number) => void;
}

const ScoreInput: Component<ScoreInputProps> = (props) => {
  const [hovered, setHovered] = createSignal<number | null>(null);

  return (
    <>
      <fieldset
        onMouseLeave={() => setHovered(null)}
        aria-label="rating"
        class="flex justify-center items-center mb-2 gap-2"
        role="radiogroup"
      >
        <span class="dark:text-everforest-fg">Leave your score: </span>

        <For each={[1, 2, 3, 4, 5]}>
          {(star) => {
            const filled = () => star <= (hovered() ?? props.value);
            return (
              <button
                type="button"
                role="radio"
                onMouseEnter={() => setHovered(star)}
                onClick={() => props.onChange(star)}
                class="hover:cursor-pointer"
              >
                <svg
                  class={
                    filled() ? "text-everforest-yellow" : "text-everforest-bg-3"
                  }
                  aria-hidden="true"
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                </svg>
              </button>
            );
          }}
        </For>
      </fieldset>

      {props.errors && (
        <div class="mb-2 text-everforest-red">{props.errors}</div>
      )}
    </>
  );
};

export default ScoreInput;
