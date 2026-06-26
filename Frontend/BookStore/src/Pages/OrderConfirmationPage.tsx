import { useLocation } from "@solidjs/router";
import { Component } from "solid-js";

const OrderConfirmationPage: Component = () => {
  const location = useLocation()
  
  return (
    <main class="fixed flex bg-everforest-bg-dim h-full w-full items-center justify-center">
          <article>
            <h1
              class="text-7xl text-everforest-fg"
            >
              Order Confirmed!
            </h1>

          </article>
        </main>
  )
};

export default OrderConfirmationPage;