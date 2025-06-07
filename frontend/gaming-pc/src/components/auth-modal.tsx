import type React from "react";
import { useState } from "react";
import { User } from "../types/auth";

interface AuthModalProps {
  isOpen: boolean;
  onClose: () => void;
  onLogin: (user: User) => void;
}

const AuthModal: React.FC<AuthModalProps> = ({ isOpen, onClose, onLogin }) => {
  const [isLoginMode, setIsLoginMode] = useState(true);
  const [formData, setFormData] = useState({
    login: "",
    username: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [isErrorVisible, setErrorVisible] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (isLoginMode) {
      const user: User = {
        id: "1",
        login: formData.login || "danya",
        password: formData.password || "das",
        username: formData.username || "user123",
        email: formData.email || "user@example.com",
      };

      if (formData.password !== "ddd") {
        setErrorVisible(true);
        setErrorMessage("Неверный логин или пароль")
        return;
      }

      setErrorVisible(false);

      onLogin(user);
    } else {
      if (formData.password !== formData.confirmPassword) {
        setErrorVisible(true);
        setErrorMessage("Введёные пароли не совподают")
        return;
      }

      const user: User = {
        id: "1",
        login: formData.login,
        password: formData.password,
        username: formData.username,
        email: formData.email,
      };

      if (user.email === "ddd@mail.ru") {
        setErrorVisible(true);
        setErrorMessage("Пользователь с такой почтой уже существует");
        return;
      }

      onLogin(user);
    }

    setFormData({
      login: "",
      username: "",
      email: "",
      password: "",
      confirmPassword: "",
    });
  };

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
      <div className="bg-white rounded-lg p-8 w-full max-w-md mx-4">
        <div className="flex justify-between items-center mb-6">
          <h2 className="text-2xl font-bold text-gray-900">
            {isLoginMode ? "Вход" : "Регистрация"}
          </h2>
          <button
            onClick={onClose}
            className="text-gray-500 hover:text-gray-700 text-2xl"
          >
            ×
          </button>
        </div>

        <form onSubmit={handleSubmit} className="space-y-4">
          {isErrorVisible && (
            <div>
              <p className="text-red-500">{errorMessage}</p>
            </div>
          )}

          {!isLoginMode && (
            <div>
              <label
                htmlFor="username"
                className="block text-sm font-medium text-gray-700 mb-1"
              >
                Логин
              </label>
              <input
                type="text"
                id="username"
                name="username"
                value={formData.username}
                onChange={handleInputChange}
                className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                required
              />
            </div>
          )}

          <div>
            <label
              htmlFor="email"
              className="block text-sm font-medium text-gray-700 mb-1"
            >
              Почта
            </label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
              className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
              required
            />
          </div>

          <div>
            <label
              htmlFor="password"
              className="block text-sm font-medium text-gray-700 mb-1"
            >
              Пароль
            </label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleInputChange}
              className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
              required
            />
          </div>

          {!isLoginMode && (
            <div>
              <label
                htmlFor="confirmPassword"
                className="block text-sm font-medium text-gray-700 mb-1"
              >
                Подтверждение пароля
              </label>
              <input
                type="password"
                id="confirmPassword"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleInputChange}
                className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                required
              />
            </div>
          )}

          <button
            type="submit"
            className="w-full bg-amber-600 hover:bg-amber-700 text-white py-2 px-4 rounded-lg font-semibold transition-colors"
          >
            {isLoginMode ? "Вход" : "Регистрация"}
          </button>
        </form>

        <div className="mt-6 text-center">
          <p className="text-sm text-gray-600">
            {isLoginMode
              ? "Нет аккаунта? "
              : "Уже есть аккаунт? "}
            <button
              onClick={() => {setIsLoginMode(!isLoginMode); setErrorVisible(false);}}
              className="text-amber-600 hover:text-amber-700 font-semibold"
            >
              {isLoginMode ? "Зарегистрироваться" : "Войти"}
            </button>
          </p>
        </div>
      </div>
    </div>
  );
};

export default AuthModal;
