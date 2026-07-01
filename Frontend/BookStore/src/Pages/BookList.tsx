import { Component, createResource, createSignal, For, Show } from 'solid-js';
import BookCard from '../Components/BookCard';
import { useLocation, useSearchParams } from '@solidjs/router';

interface PaginationMetaData {
  TotalItemCount: number
  TotalPageCount: number
  PageSize: number
  CurrentPage: number
}

const BookList: Component = () => {
  const [currentPage, setCurrentPage] = createSignal(1);
  const [paginationMetaData, setpaginationMetaData] = createSignal<
    PaginationMetaData | null
  >(null);

  const handlePageClick = (e: Event & {currentTarget: HTMLButtonElement}) => {

    console.log(paginationMetaData())
    if (e.currentTarget.name === 'next'){
      setCurrentPage((prev) => prev + 1);
    } else if(e.currentTarget.name === 'previous'){
      setCurrentPage((prev) => {
        if(prev <= 1){
          return paginationMetaData()!.TotalPageCount
        } 
        return prev - 1
      })
    }
  }

  const fetchBooks = async (pageNumber: number) => {
    const response = await fetch(`/api/books?pageNumber=${pageNumber}`);
    setpaginationMetaData(JSON.parse(response.headers.get('x-pagination')!));
    return response.json();
  };
  const [books] = createResource(currentPage, fetchBooks);

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
                name='previous'
                  class="flex items-center justify-center text-everforest-fg border hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm px-3 h-9 focus:outline-none"
                  onClick={handlePageClick}
                >
                  Previous
                </button>
              </li>
              <li>
                <button
                  class="flex items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none"
                >
                  1
                </button>
              </li>
              <li>
                <button
                  class="flex items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none"
                >
                  2
                </button>
              </li>
              <li>
                <button
                  class="flex items-center justify-center text-everforest-fg border hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none"
                >
                  3
                </button>
              </li>
              <li>
                <button
                  class="flex items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none"
                >
                  4
                </button>
              </li>
              <li>
                <button
                  class="flex items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm w-9 h-9 focus:outline-none"
                  onClick={handlePageClick}
                >
                  5
                </button>
              </li>
              <li>
                <button
                name='next'
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
