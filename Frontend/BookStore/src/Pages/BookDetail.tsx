import { useParams } from '@solidjs/router';
import { Component, createResource, Show } from 'solid-js';

const fetchBook = async (bookId: string) => {
  const response = await fetch(`/api/books/${bookId}`);
  return response.json();
};

const BookDetail: Component = () => {
  const params = useParams();
  const [book] = createResource(() => params.bookId, fetchBook);

  return (
    <div class="grid grid-cols-12">
      {/* Image container */}
      <div class="col-span-1 bg-green-700"></div>
      <div class="col-span-2">
        <img src="./images/atbqj8.jpg" />
      </div>
      {/* Main info container */}
      <div class="col-span-8 grid grid-cols-6">
        <div class='col-span-6'>
          <Show when={!book.loading} fallback={<p>Loading...</p>}>
            <div>
              <h1>{book().title}</h1>
              <p>Author: {book().authors[0].firstName} {book().authors[0].lastName}</p>
              <p>{book().publishedDate}</p>
              {/* Myabe language? */}
              {/* aggregated score/amount of reviews/ratings */}

              <div>
                <label for="quantity">Quantity:</label>
                <input type="number" id="quantity" name="quantity" min="1" />
                <button class="block rounded-md px-5 py-2.5 text-sm font-medium text-emerald-600 transition hover:bg-amber-600">Add to cart</button>
                <button class="block rounded-md px-5 py-2.5 text-sm font-medium text-emerald-600 transition hover:bg-amber-600">Add to Wishlist</button>
              </div>

              <div>
                <p>{book().description}</p>
              </div>
              

            </div>
          </Show>
        </div>

        {/* reviews container */}
        <div></div>
      </div>
      <div class="col-span-1 bg-green-700"></div>
      {/* maybe some other stuff, tags? a list of similar books (based on tags or some such) etc etc */}
    </div>
  );
};

export default BookDetail;
