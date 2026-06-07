import { A } from '@solidjs/router';
import { Component } from 'solid-js';

interface bookProps {
  book: {
    id: number;
    isbn: string;
    title: string;
    publisher: string;
    publishedDate: Date;
    description?: string;
    price: number;
    coverImageUrl?: string;
    authors: [
      {
        firstName: string;
        lastName: string;
      },
    ];
  };
}

const BookCard: Component<bookProps> = (bookProps) => {
  return (
    <div class="flex flex-col items-center p-6 border-b-2 border-slate-400 min-w-full md:flex-row md:max-w-xl">
      <A href={`/books/${bookProps.book.id}`}>
        <img
          class="object-cover w-full rounded-base h-64 md:h-auto md:w-48 mb-4 md:mb-0"
          src="./images/atbqj8.jpg"
        />
      </A>

      <div class="flex flex-col justify-between md:p-4 leading-normal">
        <A href={`/books/${bookProps.book.id}`}>
          <h5 class="mb-2 text-2xl font-bold tracking-tight text-heading">
            {bookProps.book.title}
          </h5>
        </A>

        <A href={`/books/${bookProps.book.id}`}>
          <p class="mb-6 text-body">
            {bookProps.book.authors[0].firstName}{' '}
            {bookProps.book.authors[0].lastName}
          </p>
        </A>

        <div>
          <button
            type="button"
            class="inline-flex items-center w-auto text-body bg-neutral-secondary-medium box-border border border-default-medium hover:bg-neutral-tertiary-medium hover:text-heading focus:ring-4 focus:ring-neutral-tertiary shadow-xs font-medium leading-5 rounded-base text-sm px-4 py-2.5 focus:outline-none"
          >
            {bookProps.book.price} kr
            <svg
              width="24px"
              height="24px"
              viewBox="0 -2.5 17 17"
              xmlns="http://www.w3.org/2000/svg"
              fill="#000000"
            >
              <g id="SVGRepo_bgCarrier" stroke-width="0"></g>
              <g
                id="SVGRepo_tracerCarrier"
                stroke-linecap="round"
                stroke-linejoin="round"
              ></g>
              <g id="SVGRepo_iconCarrier">
                {' '}
                <path
                  id="Path_7"
                  data-name="Path 7"
                  d="M246.973,826.978l-1.594,6.42c-.7,1.993-1.188,2.6-2.656,2.6h-8.5c-1.467,0-2.05-.463-2.656-2.6l-1.594-6.42h8.163l3.03-2.982.751.735-2.282,2.247Zm-15.638,1.009,1.295,5.443a1.677,1.677,0,0,0,1.594,1.561h8.5c.88,0,1.382-.605,1.594-1.561l1.295-5.443ZM240.973,830h1v2.969h-1Zm-2,0h1v2.969h-1Zm-2,0h1v2.969h-1Zm-2,0h1v2.969h-1Z"
                  transform="translate(-229.973 -823.996)"
                  fill="#444"
                ></path>
              </g>
            </svg>
          </button>
        </div>
      </div>
    </div>
  );
};

export default BookCard;
