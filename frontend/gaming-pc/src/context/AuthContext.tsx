import React, { createContext, useContext, useState, useEffect, ReactNode } from "react";
import { AuthService } from "../api/authService";
import { LoginRequest, RegisterRequest } from "../types/api";
import { User } from "../types/auth";

interface AuthContextType {
  user: User | null;
  isAuthenticated: boolean;
  isLoading: boolean;
  error: string | null;
  login: (email: string, password: string) => Promise<void>;
  register: (name: string, login: string, email: string, password: string) => Promise<void>;
  logout: () => void;
  fetchUserProfile: () => Promise<void>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth должен использоваться внутри AuthProvider");
  }
  return context;
};

export const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const checkAuth = async () => {
      try {
        const token = localStorage.getItem("authToken");
        if (token) {
          await fetchUserProfile();
        }
      } catch (error) {
        console.error("Ошибка проверки аутентификации", error);
        logout();
      } finally {
        setIsLoading(false);
      }
    };

    checkAuth();
  }, []);

  const login = async (email: string, password: string) => {
    setIsLoading(true);
    setError(null);
    
    try {
      const loginData: LoginRequest = { email, password };
      const response = await AuthService.login(loginData);
      
      localStorage.setItem("authToken", response.token);
      setUser(response.user);
      setIsAuthenticated(true);
    } catch (error: any) {
      console.error("Ошибка входа", error);
      setError(error.response?.data?.message || "Неверные учетные данные");
      throw error;
    } finally {
      setIsLoading(false);
    }
  };

  const register = async (name: string, login: string, email: string, password: string) => {
    setIsLoading(true);
    setError(null);
    
    try {
      const registerData: RegisterRequest = { name, login, email, password };
      const response = await AuthService.register(registerData);
      
      localStorage.setItem("authToken", response.token);
      setUser(response.user);
      setIsAuthenticated(true);
    } catch (error: any) {
      console.error("Ошибка регистрации", error);
      setError(error.response?.data?.message || "Ошибка создания аккаунта");
      throw error;
    } finally {
      setIsLoading(false);
    }
  };

  const logout = () => {
    localStorage.removeItem("authToken");
    setUser(null);
    setIsAuthenticated(false);
    setError(null);
  };

  const fetchUserProfile = async () => {
    setIsLoading(true);
    try {
      const profile = await AuthService.getProfile();
      setUser(profile);
      setIsAuthenticated(true);
    } catch (error) {
      console.error("Ошибка загрузки профиля", error);
      logout();
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <AuthContext.Provider value={{ 
      user, 
      isAuthenticated,
      isLoading,
      error,
      login, 
      register, 
      logout,
      fetchUserProfile
    }}>
      {children}
    </AuthContext.Provider>
  );
};