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
}

