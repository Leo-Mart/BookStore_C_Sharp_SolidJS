import { Component, createResource, createSignal, For, Show } from 'solid-js';
import BookCard from '../Components/BookCard';
import { useLocation, useSearchParams } from '@solidjs/router';

const fetchBooks = async () => {
  const response = await fetch('/api/books');
  return response.json();
};

const BookList: Component = () => {
  const [currentPage, setCurrentPage] = createSignal(1);
  const [books] = createResource(currentPage, fetchBooks);

  return (
    <div class="grid grid-cols-12">
      <div class="col-span-2 dark:bg-everforest-bg-dim dark:text-everforest-fg">SIDEBAR</div>
      <Show
        when={!books.loading}
        fallback={<p class="dark:text-everforest-fg col-span-8">Loading books...</p>}
      >
        <ul class="col-span-8 grid grid-cols-6 gap-2">
          <For each={books()}>
            {(item, index) => (
              <li>
                <BookCard book={item} />
              </li>
            )}
          </For>
        </ul>
      </Show>

      <div class="col-span-2 dark:bg-everforest-bg-dim dark:text-everforest-fg">ANOTHER SIDEBAR?</div>
    </div>
  );
};

export default BookList;
