-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Počítač: sql.endora.cz:3310
-- Vytvořeno: Pon 18. led 2021, 04:05
-- Verze serveru: 5.6.45-86.1
-- Verze PHP: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `sluzby`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `objednavky`
--

CREATE TABLE `objednavky` (
  `id` int(10) UNSIGNED NOT NULL,
  `typ_sluzby` varchar(25) NOT NULL,
  `jmeno` varchar(20) NOT NULL,
  `email` varchar(25) NOT NULL,
  `datum` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Vypisuji data pro tabulku `objednavky`
--

INSERT INTO `objednavky` (`id`, `typ_sluzby`, `jmeno`, `email`, `datum`) VALUES
(2, 'Rozvoz jídel', 'Patrik Příhoda', 'prihoda.patrik21@spscv.cz', '2021-02-04'),
(1, 'Ostraha', 'Kotlár', 'kotlarovec42069@seznam.cz', '2021-01-14');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `objednavky`
--
ALTER TABLE `objednavky`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `typ_sluzby` (`typ_sluzby`,`datum`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `objednavky`
--
ALTER TABLE `objednavky`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
