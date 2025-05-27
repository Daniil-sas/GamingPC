import React, { useState } from "react";
import { useAuth } from "../../context/AuthContext";
import styles from "./AuthModal.module.css"

const AuthModal: React.FC = () => {
    const { setShowAuthModal, login } = useAuth();
    const [isLogin, setIsLogin] = useState<boolean>(true);
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();

        login({ email });
    }

    return (
        <div className={styles.modalOverlay}>
            <div className={styles.modal}>
                <button className={styles.closeButton} onClick={() => setShowAuthModal(false)}>
                    &times;
                </button>
            </div>

            <div className={styles.tabs}>
                <button
                    className={`${styles.tab} ${isLogin ? styles.active : ''}`}
                    onClick={() => setIsLogin(true)}
                >
                    Вход
                </button>
                <button
                    className={`${styles.tab} ${!isLogin ? styles.active : ''}`}
                    onClick={() => setIsLogin(false)}
                >
                    Регистрация
                </button>
            </div>

            <form onSubmit={handleSubmit} className={styles.form}>
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <input
                    type="password"
                    placeholder="Пароль"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
                {!isLogin && (
                    <input
                        type="password"
                        placeholder="Повторите пароль"
                        required
                    />
                )}
                <button type="submit" className={styles.submitButton}>
                    {isLogin ? 'Войти' : 'Зарегистрироваться'}
                </button>
            </form>
        </div>
    );
};

export default AuthModal;