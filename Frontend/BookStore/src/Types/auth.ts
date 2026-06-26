import { Accessor } from "solid-js";

export interface AuthContextValue {
  token: Accessor<string | null>;
  isAuthenticated: () => boolean
  login: (email: string, password: string) => Promise<LoginResponse>;
  logout: () => void
}

export interface LoginResponse {
  email: string
  token: string
}

export type LoginForm = {
  email: string;
  password: string;
};

export type RegisterForm = {
  email: string;
  password: string;
  confirmPassword: string;
};