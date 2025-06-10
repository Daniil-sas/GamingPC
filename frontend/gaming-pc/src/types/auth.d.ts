export interface User {
  id: string;
  login: string;
  password: string;
  username?: string;
  email: string;
  avatar?: string;
}

export interface LoginFormData {
  email: string;
  password: string;
}

export interface RegisterFormData extends LoginFormData {
  confirmPassword: string;
}

export interface AuthResponse {
  user: User;
  token: string;
  expiresIn: number;
}

export interface ErrorResponse {
  message: string;
  code: number;
  errors?: Record<string, string[]>;
}

export interface AuthContextType {
  user: User | null;
  showAuthModal: boolean;
  setShowAuthModal: (show: boolean) => void;
  login: (userData: User) => void;
  logout: () => void;
}
