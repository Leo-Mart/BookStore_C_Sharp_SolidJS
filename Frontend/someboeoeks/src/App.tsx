import type { Component } from 'solid-js';
import { Router, Route } from '@solidjs/router';
import Home from './Pages/Home';
import BookList from './Pages/BookList';
import Layout from './Layouts/Layout';
import BookDetail from './Pages/BookDetail';

const App: Component = () => {
  return (
    <Router root={Layout}>
      <Route path="/" component={Home} />
      <Route path="/books" component={BookList} />
      <Route path="/books/:bookId" component={BookDetail} />
    </Router>
  );
};

export default App;
