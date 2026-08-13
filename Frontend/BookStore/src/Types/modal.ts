import { JSX } from "solid-js";
import { Wishlist, WishlistInput } from "./User/wishlist";
import { ReviewInput } from "./User/review";

export type ModalProps = {
  open: boolean;
  onClose: () => void;
  title?: string;
  children: JSX.Element;
  footer?: JSX.Element;
};

export type DiscountCodeModalProps = {
  open: boolean;
  onClose: () => void;
};

export type GiftCardModalProps = {
  open: boolean;
  onClose: () => void;
};

export type AddToWishlistModalProps = {
  open: boolean;
  onClose: () => void;
  wishlists: Wishlist[];
  selectWishlist: (wishlist: Wishlist) => void;
};

export type CreateWishlistModalProps = {
  open: boolean;
  loading: boolean;
  error: string | null;
  createNewWishlist: (input: WishlistInput) => void;
  onClose: () => void;
};

export type CreateNewReviewModalProps = {
  open: boolean;
  loading: boolean;
  error: string | null;
  bookId: number;
  createNewReview: (input: ReviewInput) => void;
  onClose: () => void;
};
