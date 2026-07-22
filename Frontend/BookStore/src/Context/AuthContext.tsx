import {
  createContext,
  useContext,
  ParentComponent,
  createSignal,
  createEffect,
} from "solid-js";
import { type AuthContextValue, LoginResponse } from "../Types/auth";
import { ErrorResponse } from "../Types/error";

const AuthContext = createContext<AuthContextValue>();

export const AuthProvider: ParentComponent = (props) => {
  const [token, setToken] = createSignal<string | null>("");

  createEffect(() => {
    const t = token();
    if (t) {
      localStorage.setItem("jwt", t); //TODO: probably some other choice for persistence here, but this suffices for now.
    } else {
      localStorage.removeItem("jwt");
    }
  });

  const login = async (
    email: string,
    password: string,
  ): Promise<LoginResponse> => {
    const response = await fetch("/api/account/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    });

    if (response.status === 401) {
      const error: ErrorResponse = await response.json();
      throw new Error(error.message);
    }

    const result: LoginResponse = await response.json();
    setToken(result.token);
    return result;
  };

  const logout = () => {
    setToken(null);
  };

  const isTokenExpired = (token: string): boolean => {
    const payload = JSON.parse(atob(token.split(".")[1]));
    return Date.now() >= payload.exp * 1000;
  };

  const auth: AuthContextValue = {
    token,
    login,
    logout,
    isAuthenticated: () => {
      const t = token();
      return !!t && !isTokenExpired(t);
    },
  };

  return (
    <AuthContext.Provider value={auth}>{props.children}</AuthContext.Provider>
  );
};

export const useAuth = (): AuthContextValue => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth must be used within a AuthProvider");
  return ctx;
};
