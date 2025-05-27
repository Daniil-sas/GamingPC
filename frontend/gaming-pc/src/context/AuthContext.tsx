import { createContext, useState, ReactNode, useContext } from 'react';

type AuthContextType = {
  user: { email: string } | null;
  showAuthModal: boolean;
  setShowAuthModal: (show: boolean) => void;
  login: (userData: { email: string }) => void;
  logout: () => void;
};

export const AuthContext = createContext<AuthContextType | null>(null);

type AuthProviderProps = {
  children: ReactNode;
};

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [user, setUser] = useState<{ email: string } | null>(null);
  const [showAuthModal, setShowAuthModal] = useState(false);

  const login = (userData: { email: string }) => {
    setUser(userData);
    setShowAuthModal(false);
  };

  const logout = () => {
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, showAuthModal, setShowAuthModal, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};