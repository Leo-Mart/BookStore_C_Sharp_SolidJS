import { JSX, Setter } from "solid-js";
import { Wishlist, WishlistInput } from "./User/wishlist";

export interface ModalProps {
  open: boolean;
  onClose: () => void;
  title?: string;
  children: JSX.Element;
  footer?: JSX.Element;
}

export interface DiscountCodeModalProps {
  open: boolean;
  onClose: () => void;
}

export interface GiftCardModalProps {
  open: boolean;
  onClose: () => void;
}

export interface AddToWishlistModalProps {
  open: boolean;
  onClose: () => void;
  wishlists: Wishlist[];
  selectWishlist: (wishlist: Wishlist) => void;
}

export interface CreateWishlistModalProps {
  open: boolean;
  loading: boolean;
  error: string | null;
  createNewWishlist: (input: WishlistInput) => void;
  onClose: () => void;
}
