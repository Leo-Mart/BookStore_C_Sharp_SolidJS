import { useParams } from "@solidjs/router";
import { Component, createResource, Show } from "solid-js";

const fetchBook = async (bookId: string) => {
  const response = await fetch(`/api/books/${bookId}`);
  return response.json();
}

const BookDetail: Component = () => {
  const params = useParams()
  const [book] = createResource(() => params.bookId, fetchBook)

  return <div>
    Details for a book.
    {params.bookId}
    {JSON.stringify(book())}
    <Show when={!book.loading} fallback={<p>Loading...</p>}>
      <div>{book().title}</div>
    </Show>
  </div>;
};

export default BookDetail;