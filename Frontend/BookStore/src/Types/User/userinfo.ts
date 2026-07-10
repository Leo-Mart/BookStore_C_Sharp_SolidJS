import { Address } from "./address";
import { Order } from "./order";
import { Review } from "./review";
import { Wishlist } from "./wishlist";

export interface UserInfo {
  email: string;
  firstName: string;
  lastName: string;
  addresses: Address[];
  orders: Order[];
  reviews: Review[];
  wishlists: Wishlist[];
}
