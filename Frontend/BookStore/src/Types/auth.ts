import { UserInfoBasic } from "./User/userinfo";

export interface AuthContextValue {
  user: () => UserInfoBasic | null | undefined;
  login: (email: string, password: string) => Promise<void>;
  logout: () => void;
  authenticatedRequest: (
    url: string,
    options: RequestInit,
  ) => Promise<Response>;
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
