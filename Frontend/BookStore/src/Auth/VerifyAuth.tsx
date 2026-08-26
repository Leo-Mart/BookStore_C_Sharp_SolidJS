import { Match, ParentComponent, Switch } from "solid-js";
import { useAuth } from "../Context/AuthContext";
import Login from "../Pages/Login";

const VerifyAuth: ParentComponent = (props) => {
  const auth = useAuth();

  return (
    <Switch fallback={<Login />}>
      <Match when={auth.user()}>{props.children}</Match>
    </Switch>
  );
};

export default VerifyAuth;
