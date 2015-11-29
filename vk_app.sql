-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Ноя 29 2015 г., 15:24
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `vk_app`
--

-- --------------------------------------------------------

--
-- Структура таблицы `friends`
--

CREATE TABLE IF NOT EXISTS `friends` (
  `FriendID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `SecondName` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  KEY `FK_friends_userfriends` (`FriendID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `friendsposts`
--

CREATE TABLE IF NOT EXISTS `friendsposts` (
  `FriendID` int(11) NOT NULL,
  `PostID` int(11) NOT NULL,
  `CountLikes` int(11) NOT NULL,
  `Date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Text` text NOT NULL,
  KEY `FK_post_friends` (`FriendID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `links`
--

CREATE TABLE IF NOT EXISTS `links` (
  `link` varchar(50) DEFAULT NULL,
  `param` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `UserID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `SecondName` varchar(50) NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `userfriends`
--

CREATE TABLE IF NOT EXISTS `userfriends` (
  `UserID` int(11) NOT NULL,
  `FriendsID` int(11) NOT NULL,
  KEY `FriendsID` (`FriendsID`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `userposts`
--

CREATE TABLE IF NOT EXISTS `userposts` (
  `userId` int(11) DEFAULT NULL,
  `postId` int(11) DEFAULT NULL,
  `CountLikes` int(11) DEFAULT NULL,
  `Date` timestamp NULL DEFAULT NULL,
  `postText` text,
  KEY `FK_userposts_user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `friends`
--
ALTER TABLE `friends`
  ADD CONSTRAINT `FK_friends_userfriends` FOREIGN KEY (`FriendID`) REFERENCES `userfriends` (`FriendsID`);

--
-- Ограничения внешнего ключа таблицы `friendsposts`
--
ALTER TABLE `friendsposts`
  ADD CONSTRAINT `FK_post_user` FOREIGN KEY (`FriendID`) REFERENCES `userfriends` (`FriendsID`);

--
-- Ограничения внешнего ключа таблицы `userfriends`
--
ALTER TABLE `userfriends`
  ADD CONSTRAINT `FK_userfriends_user` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`);

--
-- Ограничения внешнего ключа таблицы `userposts`
--
ALTER TABLE `userposts`
  ADD CONSTRAINT `FK_userposts_user` FOREIGN KEY (`userId`) REFERENCES `user` (`UserID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
