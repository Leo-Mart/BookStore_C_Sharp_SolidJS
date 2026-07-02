import { Component, createResource, createSignal, For, Show } from 'solid-js';
import BookCard from '../Components/BookCard';
import { useLocation, useSearchParams } from '@solidjs/router';

interface PaginationMetaData {
  TotalItemCount: number;
  TotalPageCount: number;
  PageSize: number;
  CurrentPage: number;
}

const BookList: Component = () => {
  const [currentPage, setCurrentPage] = createSignal(1);
  const [paginationMetaData, setpaginationMetaData] =
    createSignal<PaginationMetaData | null>(null);

  const handlePageClick = async () => {
    const newBooks = await fetchBooks(paginationMetaData()!.CurrentPage + 1)
    mutate((books = []) => [...books, ...newBooks])
  };

  const fetchBooks = async (pageNumber: number) => {
    const response = await fetch(`/api/books?pageNumber=${pageNumber}`);
    setpaginationMetaData(JSON.parse(response.headers.get('x-pagination')!));
    return response.json();
  };
  const [books, {mutate}] = createResource(currentPage, fetchBooks);

  return (
    <div class="grid grid-cols-12">
      <div class="col-span-2 dark:bg-everforest-bg-dim dark:text-everforest-fg">
        SIDEBAR
      </div>
      <Show
        when={!books.loading}
        fallback={
          <p class="dark:text-everforest-fg col-span-8">Loading books...</p>
        }
      >
        <div class="col-span-8 grid grid-cols-subgrid gap-2">
          <ul class="col-span-8 grid grid-cols-6 gap-2">
            <For each={books()}>
              {(item, _) => (
                <li>
                  <BookCard book={item} />
                </li>
              )}
            </For>
          </ul>
          <div class='col-span-8 flex flex-col items-center'>
            <p class='text-everforest-fg text-sm'>
              Currently displaying{' '}
              {books().length} books of a total of {paginationMetaData()?.TotalItemCount} books
            </p>
            <button
              name="load-more"
              class={`flex w-1/3 mt-3 items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm px-3 h-9 focus:outline-none ${books.loading ? "pointer-events-none cursor-not-allowed disabled": ""}`}
              onClick={handlePageClick}
            >
              Load More
            </button>
          </div>
        </div>
      </Show>

      <div class="col-span-2 col-start-11 dark:bg-everforest-bg-dim dark:text-everforest-fg">
        ANOTHER SIDEBAR?
      </div>
    </div>
  );
};

export default BookList;
