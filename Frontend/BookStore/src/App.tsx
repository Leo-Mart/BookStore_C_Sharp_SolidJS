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

const App: Component = () => {
  return (
    <AuthProvider>
      <CartProvider>
        <Router root={Layout}>
          <Route path="/" component={Home} />
          <Route path="/books" component={BookList} />
          <Route path="/books/:bookId" component={BookDetail} />
          <Route path="/login" component={Login} />
          <Route path="*" component={NotFound} />
        </Router>
      </CartProvider>
    </AuthProvider>
  );
};

export default App;
