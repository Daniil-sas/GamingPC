import type React from "react";
import Logo from "../assets/icons/LogoIcon";

interface User {
  id: string;
  username: string;
  email: string;
  avatar?: string;
}

interface HeaderProps {
  user: User | null;
  onLoginClick: () => void;
  onLogout: () => void;
}

const Header: React.FC<HeaderProps> = ({ user, onLoginClick, onLogout }) => {
  return (
    <header className="bg-black text-white shadow-lg">
      <div className="container mx-auto px-4 py-4 flex items-center justify-between">
        <a href="/">
          <div className="flex items-center bg-amber-600 space-x-2">
            <div className="w-10 h-10 rounded-lg flex items-center justify-center">
              <Logo />
            </div>
            <span className="text-xl font-bold">ZIENCLUB&nbsp;</span>
          </div>
        </a>

        <nav className="hidden md:flex space-x-8 font-semibold">
          <a href="/" className="hover:text-amber-400 transition-colors">
            Главная
          </a>
          {/* <a href="/events" className="hover:text-amber-400 transition-colors">
            События
          </a> */}
          <a href="/booking" className="hover:text-amber-400 transition-colors">
            Бронь
          </a>
          <a href="/faq" className="hover:text-amber-400 transition-colors">
            FAQ
          </a>
          <a href="/contact" className="hover:text-amber-400 transition-colors">
            Контакты
          </a>
        </nav>

        <div className="flex items-center space-x-4">
          {user ? (
            <div className="flex items-center space-x-3">
              <div className="flex items-center space-x-2">
                <div className="w-8 h-8 bg-amber-600 rounded-full flex items-center justify-center">
                  <span className="text-white text-sm font-semibold">
                    {user.avatar ? (
                      <img
                        src={user.avatar || "/placeholder.svg"}
                        alt={user.username}
                        className="w-8 h-8 rounded-full"
                      />
                    ) : (
                      user.username.charAt(0).toUpperCase()
                    )}
                  </span>
                </div>
                <span className="text-sm font-medium">{user.username}</span>
              </div>
              <button
                onClick={onLogout}
                className="text-sm text-gray-300 hover:text-white transition-colors"
              >
                Logout
              </button>
            </div>
          ) : (
            <button
              onClick={onLoginClick}
              className="bg-amber-600 hover:bg-amber-700 text-white px-6 py-2 rounded-xl font-semibold transition-colors"
            >
              Вход
            </button>
          )}
        </div>

        {/* Mobile menu button */}
        <button className="md:hidden">
          <svg
            className="w-6 h-6"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth={2}
              d="M4 6h16M4 12h16M4 18h16"
            />
          </svg>
        </button>
      </div>
    </header>
  );
};

export default Header;
