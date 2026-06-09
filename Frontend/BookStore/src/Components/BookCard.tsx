import { A } from '@solidjs/router';
import { Component } from 'solid-js';
import ShoppingBasket from 'lucide-solid/icons/shopping-basket';

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
    <div class="bg-everforest-bg-0 block p-6 text-everforest-fg min-w-full md:max-w-xl shadow-xs">
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
          <p class="mb-6 text-sm">
            {bookProps.book.authors[0].firstName}{' '}
            {bookProps.book.authors[0].lastName}
          </p>
        </A>

        <div>
          <button
            type="button"
            class="inline-flex gap-2 items-center w-auto text-body border hover:border-everforest-aqua hover:cursor-pointer font-medium leading-5 text-sm px-4 py-2.5 focus:outline-none"
          >
            {bookProps.book.price} kr
            <ShoppingBasket color='#D3C6AA' />
          </button>
        </div>
      </div>
    </div>
  );
};

export default BookCard;
