import type { Component } from "solid-js";
import { Router, Route } from "@solidjs/router";
import Home from "./Pages/Home";
import BookList from "./Pages/BookList";
import Layout from "./Layouts/Layout";
import BookDetail from "./Pages/BookDetail";
import NotFound from "./Pages/NotFound";
import { CartProvider } from "./Context/CartContext";
import Login from "./Pages/Login";
import { AuthProvider } from "./Context/AuthContext";
import UserPage from "./Pages/UserPage/UserPage";
import VerifyAuth from "./Auth/VerifyAuth";
import RegisterPage from "./Pages/RegisterPage";
import Checkout from "./Pages/Checkout";
import { ToastProvider } from "./Context/ToastContext";
import OrderConfirmationPage from "./Pages/OrderConfirmationPage";
import UserPageWishlists from "./Pages/UserPage/UserPageWishlists";
import UserPageOrders from "./Pages/UserPage/UserPageOrders";
import UserPageReviews from "./Pages/UserPage/UserPageReviews";
import UserPageUserInfo from "./Pages/UserPage/UserPageUserInfo";
import FindPage from "./Pages/Find";

const App: Component = () => {
  return (
    <AuthProvider>
      <ToastProvider>
        <CartProvider>
          <Router root={Layout}>
            <Route path="/" component={Home} />
            <Route path="/books" component={BookList} />
            <Route path="/books/:bookId" component={BookDetail} />
            <Route path="/find" component={FindPage} />
            <Route path="/login" component={Login} />
            <Route path="/register" component={RegisterPage} />
            <Route path="/user-profile">
              <Route path="/" component={VerifyAuth(UserPage)} />
              <Route
                path="/user-wishlists"
                component={VerifyAuth(UserPageWishlists)}
              />
              <Route
                path="/user-orders"
                component={VerifyAuth(UserPageOrders)}
              />
              <Route
                path="/user-reviews"
                component={VerifyAuth(UserPageReviews)}
              />
              <Route
                path="/user-info"
                component={VerifyAuth(UserPageUserInfo)}
              />
            </Route>
            <Route path="/checkout" component={Checkout} />
            <Route
              path="/order/confirmation"
              component={OrderConfirmationPage}
            />
            <Route path="*" component={NotFound} />
          </Router>
        </CartProvider>
      </ToastProvider>
    </AuthProvider>
  );
};

export default App;
