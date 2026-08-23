import { Accessor } from "solid-js";

export interface AuthContextValue {
  token: Accessor<string>;
  refreshToken: Accessor<string>;
  isAuthenticated: Accessor<boolean>;
  isTokenExpired: (token: string) => boolean;
  refreshJWT: () => void;
  login: (email: string, password: string) => Promise<LoginResponse>;
  logout: () => void;
}

export interface LoginResponse {
  email: string;
  accessToken: string;
  refreshToken: string;
  refreshTokenExpiry: Date;
}

export type LoginForm = {
  email: string;
  password: string;
};

export type RefreshTokenPayload = {
  refreshToken: string;
};

export type ConfirmEmailPayload = {
  email: string;
  token: string;
};

export type ForgottenPasswordPayload = {
  email: string;
};

export type ResetPasswordPayload = {
  email: string;
  token: string;
  newPassword: string;
};

export type RegisterForm = {
  email: string;
  password: string;
  confirmPassword: string;
  firstName: string;
  lastName: string;
};
