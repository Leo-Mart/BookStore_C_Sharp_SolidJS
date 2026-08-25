import {
  createContext,
  useContext,
  ParentComponent,
  createResource,
} from "solid-js";
import { type AuthContextValue } from "../Types/auth";
import { ErrorResponse } from "../Types/error";
import { UserInfoBasic } from "../Types/User/userinfo";

const checkIfUser = async (): Promise<UserInfoBasic | null> => {
  const response = await fetch("/api/account/me", {
    method: "GET",
    credentials: "include",
  });

  if (response.status === 401) {
    return null;
  }

  if (!response.ok) throw new Error("Failed to fetch user");

  return response.json();
};

const AuthContext = createContext<AuthContextValue>();

export const AuthProvider: ParentComponent = (props) => {
  const [user, { mutate }] = createResource<UserInfoBasic | null>(checkIfUser);

  const login = async (email: string, password: string) => {
    try {
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

      const data = await response.json();
      mutate(data);
    } catch (error) {
      if (error instanceof Error) {
        console.error(error.message);
        return;
      }
    }
  };

  const logout = async () => {
    const response = await fetch("/api/account/logout", {
      method: "POST",
      credentials: "include",
    });

    if (response.status === 401) {
      const error: ErrorResponse = await response.json();
      throw new Error(error.message);
    }

    mutate(null);
  };

  const authenticatedRequest = async (
    url: string,
    options: RequestInit = {},
  ): Promise<Response> => {
    try {
      let res = await fetch(url, {
        ...options,
        credentials: "include",
        headers: {
          ...options.headers,
        },
      });

      if (res.status === 401) {
        console.log("JWT is not valid, fetching new one");
        await refreshJWT();

        res = await fetch(url, {
          ...options,
          credentials: "include",
          headers: {
            ...options.headers,
          },
        });
        if (res.status === 401) {
          console.log("refetch failed, destroying cookies, clearing user");
          logout(); //TODO: not sure calling logout is the best approach here. But the cookie/tokens should be revoked id guess, so some form of "kill the tokens" request to the backend
        }
        console.log("Retry succedded, returning info");
        return res;
      }

      return res;
    } catch (error) {
      if (error instanceof Error) {
        console.error(error.message);
      }
    }
    throw new Error("but y tho?");
  };

  const refreshJWT = async () => {
    try {
      console.log("Refreshing jwt...");
      const response = await fetch("/api/account/refresh", {
        method: "POST",
        credentials: "include",
      });

      if (!response.ok) {
        const error: ErrorResponse = await response.json();
        throw new Error(error.message);
      }
    } catch (error) {
      if (error instanceof Error) {
        console.error(error.message);
      }
    }
  };

  const auth: AuthContextValue = {
    login,
    logout,
    user,
    authenticatedRequest,
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
