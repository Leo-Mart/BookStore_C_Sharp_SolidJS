export interface BookProps {
  book: Book;
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
  reviews: Review[];
  genres: [
    {
      name: string;
    },
  ];
  authors: [
    {
      firstName: string;
      lastName: string;
    },
  ];
}

export interface Review {
  id: number;
  title: string;
  text: string;
  score: number;
  reviewer: {
    firstName: string;
    lastName: string;
  };
}

export interface BasicBookInfo {
  isbn: string;
  title: string;
  description?: string;
  publishedDate: Date;
  price: number;
  coverImageUrl?: string;
  authors: [
    {
      firstName: string;
      lastName: string;
    },
  ];
}
