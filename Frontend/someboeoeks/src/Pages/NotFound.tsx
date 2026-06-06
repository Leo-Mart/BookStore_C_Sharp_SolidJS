import { A } from "@solidjs/router";
import { Component } from "solid-js";

const NotFound: Component = () => {
  
  return (
    <main class="fixed flex bg-gray-900 h-full w-full items-center justify-center">
      <article>
        <A
          href="/"
          class="text-7xl text-white underline"
        >
          Page not found - 404
        </A>
      </article>
    </main>
  )
};

export default NotFound;