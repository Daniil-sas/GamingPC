import { useAuth } from './context/AuthContext';
import Header from './components/Header/Header';
import AuthModal from './components/AuthModal/AuthModal';

function App() {
  const { showAuthModal } = useAuth();

  return (
    <div className="App">
      <Header />
      {showAuthModal && <AuthModal />}
      {/* Остальной контент страницы */}
    </div>
  );
}

export default App;