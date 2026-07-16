import { JSX } from "solid-js";
import { Book } from "./book";

export interface AccordionProps {
  title: string;
  children: JSX.Element;
}

export interface AccordionDiscoverMoreProps {
  book: Book;
}

export interface AccordionProductInfoProps {
  book: Book;
}

export interface AccordionReviewsProps {
  book: Book;
}
