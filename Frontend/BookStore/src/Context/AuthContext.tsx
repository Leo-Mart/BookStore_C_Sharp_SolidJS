import {
  createContext,
  useContext,
  ParentComponent,
  createSignal,
  createEffect,
  onCleanup,
} from "solid-js";
import { type AuthContextValue, LoginResponse } from "../Types/auth";
import { ErrorResponse } from "../Types/error";
import { redirect } from "@solidjs/router";

const AuthContext = createContext<AuthContextValue>();

export const AuthProvider: ParentComponent = (props) => {
  const [token, setToken] = createSignal<string>("");
  const [refreshToken, setRefreshToken] = createSignal<string>("");

  createEffect(() => {
    const jwt = token();
    if (!jwt) return;

    const checkExpiry = () => {
      if (isTokenExpired(jwt)) {
        try {
          refreshJWT();
        } catch (error) {
          if (error instanceof Error) {
            setToken("");
            setRefreshToken("");
            redirect("/login");
          }
        }
      }
    };

    checkExpiry();

    const interval = setInterval(checkExpiry, 60 * 1000);

    onCleanup(() => clearInterval(interval));
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
    if (response.status === 400) {
      const error: ErrorResponse = await response.json();
      throw new Error(error.message);
    }

    const result: LoginResponse = await response.json();
    setToken(result.accessToken);
    setRefreshToken(result.refreshToken);
    localStorage.setItem("jwt", result.accessToken);
    localStorage.setItem("refresh", result.refreshToken);
    return result;
  };

  const logout = async () => {
    const response = await fetch("/api/account/logout", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        refreshToken: refreshToken(),
      }),
    });

    if (response.status === 401) {
      const error: ErrorResponse = await response.json();
      throw new Error(error.message);
    }

    setToken("");
    setRefreshToken("");
    localStorage.removeItem("jwt");
    localStorage.removeItem("refresh");
  };

  const isTokenExpired = (token: string): boolean => {
    const payload = JSON.parse(atob(token.split(".")[1]));
    return Date.now() >= payload.exp * 1000;
  };

  const refreshJWT = async () => {
    console.log("Refreshing jwt...");
    const response = await fetch("/api/account/refresh", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        refreshToken: refreshToken(),
      }),
    });

    if (!response.ok) {
      const error: ErrorResponse = await response.json();
      setToken("");
      setRefreshToken("");
      localStorage.removeItem("jwt");
      localStorage.removeItem("refresh");
      throw new Error(error.message);
    }
    const authResponse: LoginResponse = await response.json();

    setToken(authResponse.accessToken);
    setRefreshToken(authResponse.refreshToken);
    localStorage.setItem("jwt", authResponse.accessToken);
    localStorage.setItem("refresh", authResponse.refreshToken);
  };

  const auth: AuthContextValue = {
    token,
    refreshToken,
    login,
    logout,
    isAuthenticated: () => !!token(),
    isTokenExpired,
    refreshJWT,
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
