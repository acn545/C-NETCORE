-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: wall
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `comment` longtext,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `message_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_comments_messages1_idx` (`message_id`),
  KEY `fk_comments_users1_idx` (`user_id`),
  CONSTRAINT `fk_comments_messages1` FOREIGN KEY (`message_id`) REFERENCES `messages` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_comments_users1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
INSERT INTO `comments` VALUES (2,'Nice message','2018-06-11 14:38:36','2018-06-11 14:38:36',1,1),(3,'Sweet message bro!','2018-06-11 14:49:47','2018-06-11 14:49:47',1,2),(4,'Good Test, very useful','2018-06-11 15:04:44','2018-06-11 15:04:44',1,2),(5,'Good Test, very useful','2018-06-11 15:04:55','2018-06-11 15:04:55',2,2),(6,'Thanks!','2018-06-11 15:05:41','2018-06-11 15:05:41',2,1),(7,'Hey John HERRY CARRY HERE!','2018-06-12 10:07:38','2018-06-12 10:07:38',2,3),(8,'','2018-06-13 10:07:29','2018-06-13 10:07:29',1,1),(14,'HELLO NEW USER, WELCOME','2018-06-18 17:24:46','2018-06-18 17:24:46',16,1);
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `messages`
--

DROP TABLE IF EXISTS `messages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `message` longtext,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `user_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_messages_users_idx` (`user_id`),
  CONSTRAINT `fk_messages_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messages`
--

LOCK TABLES `messages` WRITE;
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
INSERT INTO `messages` VALUES (1,'This is the first message','2018-06-11 13:52:00','2018-06-11 13:52:00',1),(2,'Message number 2 test','2018-06-11 14:42:36','2018-06-11 14:42:36',1),(3,'Im john doe a new USer!','2018-06-11 14:49:36','2018-06-11 14:49:36',2),(4,'NEW MESDSAGE HARRY','2018-06-12 10:17:16','2018-06-12 10:17:16',3),(5,'cool mines first ','2018-06-12 10:17:40','2018-06-12 10:17:40',1),(15,'HELLO! I AM NEW USER','2018-06-18 13:24:46','2018-06-18 13:24:46',5),(16,'NOW I AM TYPING INTO A TEXTAREA','2018-06-18 13:26:49','2018-06-18 13:26:49',5);
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Anthony','Noble','anthonycnoble@live.com','AQAAAAEAACcQAAAAEATMQpH7WKIgWLxrr1S7Mo+kKhuBAIPCzO0vY+3rOYZLjBjkHzezgCtlocnezIFc4w==','2018-06-11 11:26:11','2018-06-11 11:26:11'),(2,'John','Doe','Jdoe@gmail.com','AQAAAAEAACcQAAAAENfnAI2wnPSt19P9l147Jyk0kK/yHp5HRwBzGBPrwYDHmf/en/Jnu9cp/3gJCDcRQA==','2018-06-11 14:48:15','2018-06-11 14:48:15'),(3,'Harry','Carry','HC@gmail.com','AQAAAAEAACcQAAAAECt97FJJQCIF1wBy31enufRRMWhMKZevqbOVX4+L/YHA674b/R8TKabUatx5uf2tpA==','2018-06-12 10:07:20','2018-06-12 10:07:20'),(4,'Dana','Noble','DanaNoble@gmail.com','AQAAAAEAACcQAAAAEAUKVCB5VQT5GtVIGPRnxhQW72r7tZtJZRlF/jKoTowMcmFDy/bdFIa4Ir3P/Ph2Ww==','2018-06-15 12:20:22','2018-06-15 12:20:22'),(5,'New','User','NewYOU@gmail.com','AQAAAAEAACcQAAAAEDbOjrx1oQQXUd/BVuSzlqy/6YPKxN9prPvHsayGyu3oPsDgU+w1QH6XpOmvyirRaA==','2018-06-15 16:07:24','2018-06-15 16:07:24');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-18 17:45:21
