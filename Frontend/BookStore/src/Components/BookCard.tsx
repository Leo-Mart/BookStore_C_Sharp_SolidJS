import { A } from '@solidjs/router';
import { Component } from 'solid-js';
import ShoppingBasket from 'lucide-solid/icons/shopping-basket';
import { useCart } from '../Context/CartContext';
import { useToast } from '../Context/ToastContext';
import { type BookProps } from '../Types/book';

const BookCard: Component<BookProps> = (bookProps) => {
  const cart = useCart();
  const toast = useToast();

  const handleClick = () => {
  cart.addItem({
    id: bookProps.book.id,
    title: bookProps.book.title,
    author: `${bookProps.book.authors[0].firstName} ${bookProps.book.authors[0].lastName}`,
    price: bookProps.book.price,
    quantity: 1,
    imageUrl: bookProps.book.coverImageUrl,
  });
  toast.add('Added to cart!');
};

  return (
    <div class="flex flex-col bg-everforest-bg-0 p-6 text-everforest-fg min-h-full min-w-full md:max-w-xl shadow-xs">
      <A href={`/books/${bookProps.book.id}`}>
        <img
          class="object-cover w-full rounded-base h-64 md:h-auto md:w-48 mb-4 md:mb-0"
          src="./images/atbqj8.jpg"
        />
      </A>

      <div class="flex flex-col grow md:p-4 leading-normal">
        <div class="grow">
          <A href={`/books/${bookProps.book.id}`}>
            <h5 class="mb-2 text-2xl font-bold tracking-tight text-heading">
              {bookProps.book.title}
            </h5>
          </A>

          <A href={`/books/${bookProps.book.id}`}>
            <p class="mb-6 text-sm">
              {`${bookProps.book.authors[0].firstName} ${bookProps.book.authors[0].lastName}`}
            </p>
          </A>
        </div>

        <div class="justify-end">
          <button
            onClick={handleClick}
            type="button"
            class="inline-flex gap-2 items-center w-auto text-body border hover:border-everforest-aqua hover:cursor-pointer font-medium leading-5 text-sm px-4 py-2.5 focus:outline-none"
          >
            {bookProps.book.price} kr
            <ShoppingBasket color="#D3C6AA" />
          </button>
        </div>
      </div>
    </div>
  );
};

export default BookCard;
