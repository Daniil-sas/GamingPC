import { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from "./components/header";
import Footer from "./components/footer";
import AuthModal from "./components/auth-modal";
import HomePage from "./pages/home-page";
import BookingPage from "./pages/booking-page";
import ContactPage from "./pages/contact-page";
import FaqPage from "./pages/faq-page";
import "./index.css";
import { useAuth } from "./context/AuthContext";
import { User } from "./types/auth";

function App() {
  const [isAuthModalOpen, setIsAuthModalOpen] = useState(false);
  const { user, login, logout } = useAuth();

  const handleLogin = (userData: User) => {
    login(userData);
    setIsAuthModalOpen(false);
  };

  const handleLogout = () => {
    logout();
  };

  return (
    <Router>
      <div className="min-h-screen bg-white flex flex-col">
        <Header
          user={user}
          onLoginClick={() => setIsAuthModalOpen(true)}
          onLogout={handleLogout}
        />

        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/booking" element={<BookingPage />} />
          <Route path="/contact" element={<ContactPage />} />
          <Route path="/faq" element={<FaqPage />} />
        </Routes>

        <Footer />

        <AuthModal
          isOpen={isAuthModalOpen}
          onClose={() => setIsAuthModalOpen(false)}
          onLogin={handleLogin}
        />
      </div>
    </Router>
  );
}

export default App;
