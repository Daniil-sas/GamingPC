import React from "react";
import { useAuth } from "../../context/AuthContext";
import styles from "./Header.module.css"
import Navigation from "../Navigation/Navigation";
import LogoIcon from "../../assets/icons/LogoIcon";

const Header: React.FC = () => {
    const { user, setShowAuthModal, logout } = useAuth();

    return (
        <header className={styles.header}>
            <div className={styles.container}>
                <nav className={styles.nav}>
                    <div className={styles.logoContainer}>
                        <div className={styles.logo}>
                            <LogoIcon />
                        </div>
                        <div className={styles.text}>
                            ZIENCLUB
                        </div>
                    </div>

                    <div className={styles.navigationWrapper}>
                        <Navigation />
                    </div>

                    {user ? (
                        <div className={styles.profile}>
                            <span className={styles.username}>{user.email}</span>
                            <i className="material-icons">account_circle</i>
                            <button onClick={logout} className={styles.logoutBtn}>
                                Выйти
                            </button>
                        </div>
                    ) : (
                        <button onClick={() => setShowAuthModal(true)} className={styles.authButton}>
                            Войти
                        </button>
                    )}
                </nav>
            </div>
        </header>
    );
};

export default Header;