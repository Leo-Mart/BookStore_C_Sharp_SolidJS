export interface BookProps {
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