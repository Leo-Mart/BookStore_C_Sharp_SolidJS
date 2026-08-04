import { createEffect, Match, ParentComponent, Switch } from "solid-js";
import { useAuth } from "../Context/AuthContext";
import Login from "../Pages/Login";

const VerifyAuth: ParentComponent = (props) => {
  const auth = useAuth();

  createEffect(() => {
    const jwt = auth.token();
    if (jwt && auth.isTokenExpired(jwt)) {
      auth.refreshJWT();
    }
  });

  return (
    <Switch fallback={<Login />}>
      <Match when={auth.isAuthenticated()}>{props.children}</Match>
    </Switch>
  );
};

export default VerifyAuth;
