export interface BookProps {
  book: Book
}

export interface Book {
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
}