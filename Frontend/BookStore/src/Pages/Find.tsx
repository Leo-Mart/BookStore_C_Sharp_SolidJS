import {
  Component,
  createEffect,
  createResource,
  createSignal,
  For,
  Show,
} from "solid-js";
import BookCard from "../Components/BookCard";
import { PaginationMetaData } from "../Types/metadata";
import { Book } from "../Types/book";
import { useSearchParams } from "@solidjs/router";
import Spinner from "../Components/Spinner";

const FindPage: Component = () => {
  const [searchParams, setSearchParams] = useSearchParams();
  // const [currentPage, setCurrentPage] = createSignal(1);
  const [paginationMetaData, setpaginationMetaData] =
    createSignal<PaginationMetaData | null>(null);

  // const handlePageClick = async () => {
  //   const newBooks = await fetchBooks(paginationMetaData()!.CurrentPage + 1);
  //   mutate((books = []) => [...books, ...newBooks]);
  // };
  //
  createEffect(async () => {
    console.log(searchParams.searchQuery);
    const newResults = await fetchBooks(searchParams.searchQuery as string);
    mutate(() => [...newResults]);
  });

  const fetchBooks = async (searchQuery: string): Promise<Book[]> => {
    const response = await fetch(`/api/find?searchQuery=${searchQuery}`);
    setpaginationMetaData(JSON.parse(response.headers.get("x-pagination")!));
    return response.json();
  };
  const [books, { mutate }] = createResource<Book[], string>(
    searchParams.searchQuery as string,
    fetchBooks,
  );

  return (
    <div class="grid grid-cols-12">
      {/*<aside id="default-sidebar" class="col-span-2" aria-label="Sidebar">
        <div class="h-full px-3 py-4 overflow-y-auto dark:text-everforest-fg">
          <ul class="space-y-2 font-medium">
            <li>
              <button class="flex items-center px-2 py-1.5 text-body rounded-base hover:bg-neutral-tertiary hover:text-fg-brand group">
                <span class="ms-3">Genre</span>
              </button>
            </li>
            <li>
              <button class="flex items-center px-2 py-1.5 text-body rounded-base hover:bg-neutral-tertiary hover:text-fg-brand group">
                <span class="flex-1 ms-3 whitespace-nowrap">Format</span>
              </button>
            </li>
            <li>
              <button class="flex items-center px-2 py-1.5 text-body rounded-base hover:bg-neutral-tertiary hover:text-fg-brand group">
                <span class="flex-1 ms-3 whitespace-nowrap">Author</span>
              </button>
            </li>

            <li>
              <button class="flex items-center px-2 py-1.5">
                <span class="flex-1 ms-3 whitespace-nowrap">Clear filters</span>
              </button>
            </li>
          </ul>
        </div>
      </aside> */}

      <Show when={books.loading}>
        <div class="min-h-screen col-span-8 flex items-center">
          <Spinner />
        </div>
      </Show>
      <Show
        when={!books.loading && books()!.length > 0}
        fallback={
          <p class="dark:text-everforest-fg col-span-8">No books found...</p>
        }
      >
        <div class="col-span-8 flex flex-col gap-2 p-3">
          <h3 class="text-2xl dark:text-everforest-fg">Search Results:</h3>
          <p class="text-sm dark:text-everforest-fg">{`Found ${books()?.length} potential matches`}</p>
          <ul class="col-span-8 grid grid-cols-6 gap-2">
            <For each={books()}>
              {(book: Book, _) => (
                <li>
                  <BookCard book={book} />
                </li>
              )}
            </For>
          </ul>
          {/* <div class="col-span-8 flex flex-col items-center"> */}
          {/*   <p class="text-everforest-fg text-sm"> */}
          {/*     Currently displaying {books.length} books of a total of{" "} */}
          {/*     {paginationMetaData()?.TotalItemCount} books */}
          {/*   </p> */}
          {/*   <button */}
          {/*     name="load-more" */}
          {/*     class={`flex w-1/3 mt-3 items-center justify-center text-everforest-fg border  hover:border-everforest-aqua hover:cursor-pointer shadow-xs font-medium leading-5 text-sm px-3 h-9 focus:outline-none ${books.loading ? "pointer-events-none cursor-not-allowed disabled" : ""}`} */}
          {/*     onClick={handlePageClick} */}
          {/*   > */}
          {/*     Load More */}
          {/*   </button> */}
          {/* </div> */}
        </div>
      </Show>

      <div class="col-span-2 col-start-11 dark:bg-everforest-bg-dim dark:text-everforest-fg">
        ANOTHER SIDEBAR?
      </div>
    </div>
  );
};

export default FindPage;
