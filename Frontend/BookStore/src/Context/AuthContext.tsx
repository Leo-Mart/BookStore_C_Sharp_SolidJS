import {
  createContext,
  useContext,
  ParentComponent,
  createSignal,
} from 'solid-js';

interface AuthContextValue {
  token: string;
  login: (email: string, password: string) => void;
}

const AuthContext = createContext<AuthContextValue>();

export const AuthProvider: ParentComponent = (props) => {
  const [token, setToken] = createSignal<string>('');

  const login = async (email: string, password: string) => {
    const response = await fetch('/api/authentication/authenticate', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    });

    const result = await response.json();
    setToken(result.token);
  };

  const auth: AuthContextValue = {
    token: token(),
    login,
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
