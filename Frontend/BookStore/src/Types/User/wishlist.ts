import { BasicBookInfo } from "../book";

export interface Wishlist {
  id: number;
  name: string;
  isDefault: boolean;
  description?: string;
  wishlistItems: WishlistItem[];
}

export interface WishlistItem {
  id?: number;
  bookId: number;
  wishlistId?: number;
  book?: BasicBookInfo;
}

export interface WishlistInput {
  name: string;
  description: string;
  isDefault: boolean;
}
