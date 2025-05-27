import React from "react";
import styles from "./Navigation.module.css"

const Navigation: React.FC = () => {
    return (
        <ul className={styles.navList}>
            <li><a href="/">Главная</a></li>
            <li><a href="/booking">Бронь места</a></li>
            <li><a href="/faq">FAQ</a></li>
            <li><a href="/contacts">Контакты</a></li>
            <li><a href="/about">О нас</a></li>
        </ul>
    );
};

export default Navigation;