import { Component, For } from "solid-js";
import Accordion from "./Accordion";
import { A } from "@solidjs/router";
import { AccordionDiscoverMoreProps } from "../../Types/accordion";

const AccordionDiscoverMore: Component<AccordionDiscoverMoreProps> = (
  props,
) => {
  return (
    <Accordion title={"Discover More"}>
      <ul class="flex gap-2">
        <For each={props.book.genres}>
          {(item, _) => (
            <A
              class="w-auto border hover:border-everforest-aqua hover:cursor-pointer font-medium leading-5 text-sm px-4 py-2.5 focus:outline-none"
              href={`/category/${item.name}`}
            >
              {item.name}
            </A>
          )}
        </For>
      </ul>
    </Accordion>
  );
};

export default AccordionDiscoverMore;
