export type ReviewInput = {
  title: string;
  text: string;
  score: number;
  bookId: number;
};

export type Review = {
  id: number;
  title: string;
  text: string;
  score: number;
  bookId: number;
};
