import { A } from "@solidjs/router";
import { Component } from "solid-js";

const NotFound: Component = () => {
  
  return (
    <main class="fixed flex bg-everforest-bg-dim h-full w-full items-center justify-center">
      <article>
        <A
          href="/"
          class="text-7xl text-everforest-fg"
        >
          Page not found - 404
        </A>
      </article>
    </main>
  )
};

export default NotFound;