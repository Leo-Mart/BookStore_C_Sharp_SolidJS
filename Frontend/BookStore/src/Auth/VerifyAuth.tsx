import { Component, Match, Switch } from 'solid-js';
import { useAuth } from '../Context/AuthContext';
import Login from '../Pages/Login';

const VerifyAuth = (Component: Component) => {
  return () => {
    const auth = useAuth();

    return (
      <Switch fallback={<Login />}>
        <Match when={auth.isAuthenticated()}>
          <Component />
        </Match>
      </Switch>
    );
  };
};

export default VerifyAuth;
