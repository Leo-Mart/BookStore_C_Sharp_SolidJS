import { Component, createSignal } from "solid-js";
import { AccordionProps } from "../../Types/accordion";

const Accordion: Component<AccordionProps> = (props) => {
  const [open, setOpen] = createSignal<boolean>(false);
  return (
    <>
      <button
        type="button"
        onClick={() => setOpen(!open())}
        class="flex justify-between w-full hover:cursor-pointer"
      >
        <span class="text-2xl font-bold">{props.title}</span>
        <svg
          class="fill-everforest-fg shrink-0 ml-8 my-auto"
          width="8"
          height="16"
          xmlns="http://www.w3.org/2000/svg"
        >
          <rect
            y="7"
            width="8"
            height="2"
            rx="1"
            class={`transform origin-center transition duration-200 ease-out ${
              open() && "rotate-180!"
            }`}
          />
          <rect
            y="7"
            width="8"
            height="2"
            rx="1"
            class={`transform origin-center rotate-90 transition duration-200 ease-out ${
              open() && "rotate-180!"
            }`}
          />
        </svg>
      </button>
      <div
        class={`grid overflow-hidden transition-all duration-300 ease-in-out text-everforest-fg text-md ${
          open() ? "grid-rows-[1fr] opacity-100" : "grid-rows-[0fr] opacity-0"
        }`}
      >
        <div class="overflow-hidden">{props.children}</div>
      </div>
    </>
  );
};

export default Accordion;
