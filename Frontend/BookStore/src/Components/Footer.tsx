import { Component } from 'solid-js';

const Footer: Component = () => {
  return (
    <footer class="bg-white dark:bg-everforest-bg-dim">
      <div class="px-4 pb-6 pt-16 sm:px-6 lg:px-8 lg:pt-24">
        <div class="divider divider-accent"></div>
        <div class="flex justify-between">
          <div>
            <span class='dark:text-everforest-fg'>The Book Store</span>
          </div>
          <div class="text-center sm:flex sm:justify-between sm:text-left">
            <p class="text-sm text-everforest-fg dark:text-everforest-fg">
              <span class="block sm:inline">All rights reserved.</span>

            </p>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
