import { Component, createResource, createSignal, For } from 'solid-js';
import BookCard from '../Components/BookCard';

const fetchBooks = async () => {
  const response = await fetch('/api/books');
  return response.json();
};

const BookList: Component = () => {
  const [currentPage, setCurrentPage] = createSignal(1);
  const [books] = createResource(currentPage, fetchBooks);

  return (
    <div class="grid grid-cols-12">
      <div class="col-span-3 bg-green-700">
        FILTERS
      </div>
        <ul class="col-span-6">
          <For each={books()}>
            {(item, index) => (
              <li>
                <BookCard book={item} />
              </li>
            )}
          </For>
        </ul>
        <div class="col-span-3 bg-red-700">
          ANOTHER SIDEBAR?
        </div>
    </div>
  );
};

export default BookList;
