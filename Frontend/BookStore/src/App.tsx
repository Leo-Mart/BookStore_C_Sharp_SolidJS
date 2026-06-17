import type { Component } from 'solid-js';
import { Router, Route } from '@solidjs/router';
import Home from './Pages/Home';
import BookList from './Pages/BookList';
import Layout from './Layouts/Layout';
import BookDetail from './Pages/BookDetail';
import NotFound from './Pages/NotFound';
import { CartProvider } from './Context/CartContext';
import Login from './Pages/Login';
import { AuthProvider } from './Context/AuthContext';
import UserPage from './Pages/UserPage';
import VerifyAuth from './Auth/VerifyAuth';
import RegisterPage from './Pages/RegisterPage';
import Checkout from './Pages/Checkout';

const App: Component = () => {
  return (
    <AuthProvider>
      <CartProvider>
        <Router root={Layout}>
          <Route path="/" component={Home} />
          <Route path="/books" component={BookList} />
          <Route path="/books/:bookId" component={BookDetail} />
          <Route path="/login" component={Login} />
          <Route path="/register" component={RegisterPage} />
          <Route path="/user-profile" component={VerifyAuth(UserPage)} />
          <Route path="/checkout" component={Checkout} />
          <Route path="*" component={NotFound} />
        </Router>
      </CartProvider>
    </AuthProvider>
  );
};

export default App;
