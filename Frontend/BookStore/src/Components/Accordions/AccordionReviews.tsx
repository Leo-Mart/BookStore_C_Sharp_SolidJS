import { Component, For } from "solid-js";
import Accordion from "./Accordion";
import { AccordionReviewsProps } from "../../Types/accordion";
import Score from "../Score";

const AccordionReviews: Component<AccordionReviewsProps> = (props) => {
  return (
    <Accordion title={"Reviews"}>
      <For each={props.book.reviews}>
        {(item, _) => (
          <div class="py-2">
            <div>
              <div class="text-xl">
                {item.reviewer.firstName} {item.reviewer.lastName}
              </div>

              <Score score={item.score} />

              <div>{item.score}</div>
            </div>
            <div>
              <div>{item.text}</div>
            </div>
          </div>
        )}
      </For>
    </Accordion>
  );
};

export default AccordionReviews;
