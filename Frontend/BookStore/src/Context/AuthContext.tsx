import {
  createContext,
  useContext,
  ParentComponent,
  createSignal,
  Accessor,
  createEffect,
} from 'solid-js';

interface AuthContextValue {
  token: Accessor<string | null>;
  isAuthenticated: () => boolean
  login: (email: string, password: string) => Promise<LoginResponse>;
  logout: () => void
}

interface LoginResponse {
  email: string
  token: string
}

const AuthContext = createContext<AuthContextValue>();

export const AuthProvider: ParentComponent = (props) => {
  const [token, setToken] = createSignal<string | null>('');

  createEffect(() => {
    const t = token()
    if (t) {
      localStorage.setItem("jwt", t) //TODO: probably some other choice for persistence here, but this suffices for now.
    } else {
      localStorage.removeItem("jwt")
    }
  })

  const login = async (email: string, password: string): Promise<LoginResponse> => {
    const response = await fetch('/api/account/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    });

    const result: LoginResponse = await response.json();
    setToken(result.token);
    return result
  };

  const logout = () => {
    setToken(null)
  }

  const auth: AuthContextValue = {
    token,
    login,
    logout,
    isAuthenticated: () => !!token() //TODO: only checks that there actually is a token, so might need a deeper check here
  };

  return (
    <AuthContext.Provider value={auth}>{props.children}</AuthContext.Provider>
  );
};

export const useAuth = (): AuthContextValue => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error('useAuth must be used within a AuthProvider');
  return ctx;
};
