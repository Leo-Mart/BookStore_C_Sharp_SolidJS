import { Component, createResource, createSignal, For, JSX, Show } from 'solid-js';
import { createStore } from 'solid-js/store';
import BookCard from '../Components/BookCard';
import { useLocation, useSearchParams } from '@solidjs/router';
import { Book } from '../Types/book';
import { type PaginationMetaData, FetchParams } from '../Types/pagination';

const BookList: Component = () => {
  const [pageNumber, setPageNumber] = createSignal<number>(1);
  const [pageSize, setPageSize] = createSignal<number>(10);
  const [pageButtons, setPageButtons] = createStore<JSX.Element[]>([])
  const [paginationMetaData, setpaginationMetaData] =
    createSignal<PaginationMetaData | null>(null);  

  const handlePageClick = (e: Event & { currentTarget: HTMLButtonElement }) => {
    if (e.currentTarget.name === 'next') {
      setPageNumber((prev) => {
        if (prev >= paginationMetaData()!.TotalPageCount) {
          return 1;
        }
        return prev + 1;
      });
    } else if (e.currentTarget.name === 'previous') {
      setPageNumber((prev) => {
        if (prev <= 1) {
          return paginationMetaData()!.TotalPageCount;
        }
        return prev - 1;
      });
    } else {
      setPageNumber(+e.currentTarget.name);
    }
  };

  const fetchBooks = async ({
    pageNumber,
    pageSize,
  }: FetchParams): Promise<Book[]> => {
    const params = new URLSearchParams({
      pageNumber: String(pageNumber),
      pageSize: String(pageSize),
    });
    const response = await fetch(`/api/books?${params.toString()}`);
    setpaginationMetaData(JSON.parse(response.headers.get('x-pagination')!));
    setPageButtons([])
    for (let index = 0; index < paginationMetaData()!.TotalPageCount; index++) {
      setPageButtons((buttons: JSX.Element[]) => [...buttons, 
        <li>
          <button
            class={`flex items-center justify-center  border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none ${index === pageNumber - 1 ? 'border-everforest-aqua text-everforest-aqua bg-everforest-bg-5' : 'text-everforest-fg'}`}
            name={String(index + 1)}
            onClick={handlePageClick}
          >
            {index + 1}
          </button>
        </li>,
      ]);
    }
    return response.json() as Promise<Book[]>;
  };

  for (let index = 0; index < 12; index++) {
      setPageButtons((buttons: JSX.Element[]) => [...buttons, 
        <li>
          <button
            class={`flex items-center justify-center  border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none ${index === pageNumber() - 1 ? 'border-everforest-aqua text-everforest-aqua bg-everforest-bg-5' : 'text-everforest-fg'}`}
            name={String(index + 1)}
            onClick={handlePageClick}
          >
            {index + 1}
          </button>
        </li>,
      ]);
    }

  const [books] = createResource<Book[], FetchParams>(
    () => ({ pageNumber: pageNumber(), pageSize: pageSize() }),
    fetchBooks,
  );

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

          <nav
            aria-label="page-navigation"
            class="col-span-4 col-start-3 justify-center flex items-center space-x-4"
          >
            <ul class="flex -space-x-px text-sm bg-everforest-bg-0">
              <li>
                <button
                  name="previous"
                  class="flex items-center justify-center text-everforest-fg border hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm px-3 h-9 focus:outline-none"
                  onClick={handlePageClick}
                >
                  Previous
                </button>
              </li>
              {pageButtons.slice(-3)}
              {pageButtons.slice(pageNumber() - 1, 4)}
              <li>
                <button
                  name="next"
                  class="flex items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 rounded-e-base text-sm px-3 h-9 focus:outline-none"
                  onClick={handlePageClick}
                >
                  Next
                </button>
              </li>
            </ul>
            <form class="w-32 mx-auto">
              <label for="books" class="sr-only">
                Select an option
              </label>
              <select
                id="books"
                class="block w-full px-3 py-2.5 border border-everforest-fg text-sm leading-4 text-everforest-fg focus:border-everforest-aqua shadow-xs placeholder:text-everforest-fg"
                onChange={(e) => setPageSize(+e.target.value)}
              >
                <option selected>10 per page</option>
                <option value="25">25 per page</option>
                <option value="50">50 per page</option>
                <option value="100">100 per page</option>
              </select>
            </form>
          </nav>
        </div>
      </Show>

      <div class="col-span-2 col-start-11 dark:bg-everforest-bg-dim dark:text-everforest-fg">
        ANOTHER SIDEBAR?
      </div>
    </div>
  );
};

export default BookList;
