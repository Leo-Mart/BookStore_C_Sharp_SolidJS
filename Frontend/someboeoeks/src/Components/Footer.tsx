import { Component } from 'solid-js';
import { A } from '@solidjs/router';

const Footer: Component = () => {
  return (
    <footer class="bg-white dark:bg-gray-900">
      <div class="px-4 pb-6 pt-16 sm:px-6 lg:px-8 lg:pt-24">
        <div class="divider divider-accent"></div>
        <div class="flex justify-between">
          <div class="text-center sm:flex sm:justify-between sm:text-left">
            <p class="text-sm text-gray-500 dark:text-gray-400">
              <span class="block sm:inline">All rights reserved.</span>
              <a
                class="inline-block text-gray-600 underline transition hover:text-emerald-600/75 dark:text-emerald-500 dark:hover:text-emerald-500/75"
                href="#"
              >
                Terms & Conditions
              </a>
              <span>&middot;</span>
              <a
                class="inline-block text-gray-600 underline transition hover:text-emerald-600/75 dark:text-emerald-500 dark:hover:text-emerald-500/75"
                href="#"
              >
                Privacy Policy
              </a>
            </p>
          </div>
          <div>
            <ul class="flex justify-center gap-6 sm:justify-start md:gap-8">
              <li>
                <A
                  href="/"
                  rel="noreferrer"
                  target="_blank"
                  class="text-gray-500 transition hover:text-emerald-900 "
                >
                  Github
                </A>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
