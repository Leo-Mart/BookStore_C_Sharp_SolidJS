import { Component } from "solid-js";
import Accordion from "./Accordion";
import { AccordionProductInfoProps } from "../../Types/accordion";

const AccordionProductInfo: Component<AccordionProductInfoProps> = (props) => {
  return (
    <Accordion title={"Product Info"}>
      <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
        <div>
          <dt class='inline-block after:mr-2 after:content-[":"]'>Author</dt>
          <dd class="inline-block">
            {props.book.authors[0].firstName} {props.book.authors[0].lastName}
          </dd>
        </div>
        <div>
          <dt class='inline-block after:mr-2 after:content-[":"]'>ISBN</dt>
          <dd class="inline-block">{props.book.isbn}</dd>
        </div>
        <div>
          <dt class='inline-block after:mr-2 after:content-[":"]'>
            Published Date
          </dt>
          <dd class="inline-block">
            {new Date(props.book.publishedDate).toLocaleDateString()}
          </dd>
        </div>
        <div>
          <dt class='inline-block after:mr-2 after:content-[":"]'>Publisher</dt>
          <dd class="inline-block">{props.book.publisher}</dd>
        </div>
      </dl>
    </Accordion>
  );
};

export default AccordionProductInfo;
