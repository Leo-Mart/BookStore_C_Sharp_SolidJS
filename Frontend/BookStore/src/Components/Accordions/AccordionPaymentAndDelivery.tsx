import { Component } from "solid-js";
import Accordion from "./Accordion";
import { A } from "@solidjs/router";

const AccordionPaymentAndDelivery: Component = () => {
  return (
    <Accordion title={"Payment and Delivery"}>
      <div>
        <h4 class="text-xl">Devlivery Information</h4>
        <div>
          Free shipping for persons above 250 kr. We offer deliver to pick-up
          points, home-delivery, parcel-boxes. Procced to checkout to see the
          available shipping methods. Shipping time will depend on address,
          shipping method and wether the order contains items with longer
          shipping times. The total delivery time will be shown in checkout.
        </div>
      </div>
      <div class="my-2">
        <h4 class="text-xl">Payment Information</h4>
        <div>
          Pay by card, Invoice, or Swish. When Clicking order you agree to
          BookStores general terms. Find more information about how BookStore
          handles your private data in our{" "}
          <A
            class="underline hover:cursor-pointer hover:text-everforest-aqua"
            href="#"
          >
            privacy-policy
          </A>
          .
        </div>
      </div>
      <div>
        <h4 class="text-xl">Returns</h4>
        <div>
          When buying from BookStore you have 28 days right of return from the
          day you recive your product. The fee for returns are 59kr.
          Downloadable products are not covered by this right of return since
          they are delivered instantly. For more information see the{" "}
          <A
            class="underline hover:cursor-pointer hover:text-everforest-aqua"
            href="#"
          >
            terms-of-purchase
          </A>
        </div>
      </div>
    </Accordion>
  );
};

export default AccordionPaymentAndDelivery;
