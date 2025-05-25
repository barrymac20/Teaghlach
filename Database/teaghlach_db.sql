-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: teaghlachdb
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20250514141804_InitialCreate','9.0.3'),('20250516204022_AddEventCategorySubCategory','9.0.3'),('20250516205431_UpdateSeedData','9.0.3'),('20250519105043_UpdateEventCategory','9.0.3'),('20250519111119_FixCategoryConflict','9.0.3'),('20250521132506_AddFamilyRoleAndSeedDate','9.0.3'),('20250522141132_AddReward','9.0.3'),('20250522141810_AddMeal','9.0.3'),('20250522142105_AddList','9.0.3'),('20250523173212_AddChoreTypeToChore','9.0.3'),('20250524144820_UpdateChoreModel','9.0.3'),('20250524161046_AddIdentifyModel','9.0.5'),('20250524162656_AddLoginFieldsToFamilyMember','9.0.5'),('20250524165601_MakeUsernamePasswordOptional','9.0.5'),('20250524165941_AddSettingsModel','9.0.5');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chores`
--

DROP TABLE IF EXISTS `chores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chores` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DueDate` datetime(6) NOT NULL,
  `IsCompleted` tinyint(1) NOT NULL,
  `AssignedToId` int NOT NULL DEFAULT '0',
  `CreatedAt` datetime(6) NOT NULL,
  `Type` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Chores_AssignedToId` (`AssignedToId`),
  CONSTRAINT `FK_Chores_FamilyMembers_AssignedToId` FOREIGN KEY (`AssignedToId`) REFERENCES `familymembers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chores`
--

LOCK TABLES `chores` WRITE;
/*!40000 ALTER TABLE `chores` DISABLE KEYS */;
INSERT INTO `chores` VALUES (1,'test','test','2025-05-26 00:00:00.000000',1,2,'2025-05-19 16:34:51.574996',1),(2,'d','d','2025-05-24 00:00:00.000000',0,1,'2025-05-23 00:00:00.000000',1),(3,'f','f','2025-05-24 00:00:00.000000',0,2,'2025-05-23 00:00:00.000000',1),(4,'test',NULL,'2025-05-24 00:00:00.000000',0,1,'2025-05-24 00:00:00.000000',0),(5,'test',NULL,'2025-05-24 00:00:00.000000',0,1,'2025-05-24 00:00:00.000000',0),(6,'test',NULL,'2025-05-24 00:00:00.000000',0,1,'2025-05-24 00:00:00.000000',2),(7,'rrr',NULL,'2025-05-24 00:00:00.000000',0,1,'2025-05-24 00:00:00.000000',0),(8,'',NULL,'2025-05-24 00:00:00.000000',0,1,'2025-05-24 00:00:00.000000',0),(9,'',NULL,'2025-05-24 00:00:00.000000',1,1,'2025-05-24 00:00:00.000000',0);
/*!40000 ALTER TABLE `chores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventcategories`
--

DROP TABLE IF EXISTS `eventcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventcategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventcategories`
--

LOCK TABLES `eventcategories` WRITE;
/*!40000 ALTER TABLE `eventcategories` DISABLE KEYS */;
INSERT INTO `eventcategories` VALUES (1,'School'),(2,'Sports'),(3,'Birthday');
/*!40000 ALTER TABLE `eventcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventsubcategories`
--

DROP TABLE IF EXISTS `eventsubcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventsubcategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EventCategoryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_EventSubCategories_EventCategoryId` (`EventCategoryId`),
  CONSTRAINT `FK_EventSubCategories_EventCategories_EventCategoryId` FOREIGN KEY (`EventCategoryId`) REFERENCES `eventcategories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventsubcategories`
--

LOCK TABLES `eventsubcategories` WRITE;
/*!40000 ALTER TABLE `eventsubcategories` DISABLE KEYS */;
INSERT INTO `eventsubcategories` VALUES (1,'Parent-Teacher Meeting',1),(2,'School Play',1),(3,'Football',2),(4,'Camogie',2),(5,'Child\'s Birthday',3),(6,'Party',3);
/*!40000 ALTER TABLE `eventsubcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `familyevents`
--

DROP TABLE IF EXISTS `familyevents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `familyevents` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Location` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Color` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FamilyMemberId` int NOT NULL DEFAULT '0',
  `Start` datetime(6) NOT NULL,
  `End` datetime(6) DEFAULT NULL,
  `AllDay` tinyint(1) NOT NULL,
  `Text` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EventCategoryId` int NOT NULL DEFAULT '0',
  `EventSubCategoryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FamilyEvents_FamilyMemberId` (`FamilyMemberId`),
  KEY `IX_FamilyEvents_EventCategoryId` (`EventCategoryId`),
  KEY `IX_FamilyEvents_EventSubCategoryId` (`EventSubCategoryId`),
  CONSTRAINT `FK_FamilyEvents_EventCategories_EventCategoryId` FOREIGN KEY (`EventCategoryId`) REFERENCES `eventcategories` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_FamilyEvents_EventSubCategories_EventSubCategoryId` FOREIGN KEY (`EventSubCategoryId`) REFERENCES `eventsubcategories` (`Id`),
  CONSTRAINT `FK_FamilyEvents_FamilyMembers_FamilyMemberId` FOREIGN KEY (`FamilyMemberId`) REFERENCES `familymembers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `familyevents`
--

LOCK TABLES `familyevents` WRITE;
/*!40000 ALTER TABLE `familyevents` DISABLE KEYS */;
INSERT INTO `familyevents` VALUES (1,'test','test','#2196f3',1,'2025-05-16 18:00:00.000000','2025-05-16 22:00:00.000000',0,'test',1,1),(2,'Cavan','Erins Louth Match','#2196f3',1,'2025-05-17 12:00:00.000000','2025-05-17 16:00:00.000000',0,'Erins Louth Match',1,1),(3,'dd','dd','#FFB6C1',1,'2025-05-16 22:30:00.000000','2025-05-16 23:30:00.000000',0,'dd',1,1),(4,'d','d','#FFB6C1',1,'2025-05-16 22:45:00.000000','2025-05-16 23:45:00.000000',0,'s',1,1),(5,'s','s','#FFB6C1',1,'2025-05-16 22:53:00.000000','2025-05-16 23:53:00.000000',0,'s',1,1),(6,'r','r','#ADD8E6',2,'2025-05-17 10:00:00.000000','2025-05-17 11:00:00.000000',0,'r',2,3),(7,'q','q','#FFB6C1',1,'2025-05-16 23:15:00.000000','2025-05-17 00:15:00.000000',0,'q',1,1),(9,'w','w','#90EE90',1,'2025-05-16 20:25:00.000000','2025-05-16 22:30:00.000000',0,'w',3,5),(14,'St. Kevins School','Holly\'s Parent Teacher Meeting','#FFB6C1',1,'2025-05-19 10:00:00.000000','2025-05-19 11:00:00.000000',0,'Holly\'s Parent Teacher Meeting',3,6),(17,'Pirates Den','Craig\'s Birthday Party','#90EE90',1,'2025-05-20 15:00:00.000000','2025-05-20 17:30:00.000000',1,'Craig\'s Birthday Party',3,5),(18,'Darver','U14 Louth training','#ADD8E6',3,'2025-05-24 10:00:00.000000','2025-05-24 11:30:00.000000',0,'U14 Louth training',2,4),(19,'Philipstown','U10 Blitz','#ADD8E6',4,'2025-05-25 11:00:00.000000','2025-05-25 12:30:00.000000',0,'U10 Blitz',2,3),(21,'Kilkerley','U16 Match','#ADD8E6',3,'2025-05-28 19:00:00.000000','2025-05-28 21:00:00.000000',0,'U16 Match',2,3),(22,'Philipstown',NULL,'#ADD8E6',5,'2025-05-22 18:00:00.000000','2025-05-22 19:00:00.000000',0,'U8 Football Training',2,3),(23,'r','r','#FFB6C1',1,'2025-05-25 04:04:00.000000','2025-05-25 05:05:00.000000',0,'r',1,1);
/*!40000 ALTER TABLE `familyevents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `familymembers`
--

DROP TABLE IF EXISTS `familymembers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `familymembers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DateOfBirth` datetime(6) DEFAULT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PhoneNumber` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FamilyRoleId` int NOT NULL DEFAULT '0',
  `FamilySubRoleId` int DEFAULT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `familymembers`
--

LOCK TABLES `familymembers` WRITE;
/*!40000 ALTER TABLE `familymembers` DISABLE KEYS */;
INSERT INTO `familymembers` VALUES (1,'Barry','Dad','1980-09-26 00:00:00.000000','barrymac20@gmail.com','0877836904',1,1,'$2a$12$QtmnkBg4PjeU0ZuCNaNqx.z7VkbL6VWJp.1ncCb6k13nTvAkBP0Z2','barry'),(2,'Gillian','Mam','1984-06-16 00:00:00.000000','gill112rly@hotmail.com','0860562056',1,2,'$2a$12$X0iwoE/hX0jaGbolmTc4feC5fmyUoS7hVf8PtNygIFD4Ve8SSunmO','gillian'),(3,'Erin',NULL,'2011-06-02 00:00:00.000000','n/a','n/a',2,4,'',''),(4,'Sophie',NULL,'2015-07-01 00:00:00.000000','n/a','n/a',2,4,'',''),(5,'Holly',NULL,'2018-01-05 00:00:00.000000','n/a','n/a',2,4,'',''),(6,'Daire',NULL,'2019-10-30 00:00:00.000000','n/a','n/a',2,3,'','');
/*!40000 ALTER TABLE `familymembers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `familyroles`
--

DROP TABLE IF EXISTS `familyroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `familyroles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `familyroles`
--

LOCK TABLES `familyroles` WRITE;
/*!40000 ALTER TABLE `familyroles` DISABLE KEYS */;
INSERT INTO `familyroles` VALUES (1,'Parent'),(2,'Child');
/*!40000 ALTER TABLE `familyroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `familysubroles`
--

DROP TABLE IF EXISTS `familysubroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `familysubroles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FamilyRoleId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FamilySubRoles_FamilyRoleId` (`FamilyRoleId`),
  CONSTRAINT `FK_FamilySubRoles_FamilyRoles_FamilyRoleId` FOREIGN KEY (`FamilyRoleId`) REFERENCES `familyroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `familysubroles`
--

LOCK TABLES `familysubroles` WRITE;
/*!40000 ALTER TABLE `familysubroles` DISABLE KEYS */;
INSERT INTO `familysubroles` VALUES (1,'Father',1),(2,'Mother',1),(3,'Son',2),(4,'Daughter',2);
/*!40000 ALTER TABLE `familysubroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `list`
--

DROP TABLE IF EXISTS `list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `list` (
  `Id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `list`
--

LOCK TABLES `list` WRITE;
/*!40000 ALTER TABLE `list` DISABLE KEYS */;
/*!40000 ALTER TABLE `list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meal`
--

DROP TABLE IF EXISTS `meal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `meal` (
  `Id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meal`
--

LOCK TABLES `meal` WRITE;
/*!40000 ALTER TABLE `meal` DISABLE KEYS */;
/*!40000 ALTER TABLE `meal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reward`
--

DROP TABLE IF EXISTS `reward`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reward` (
  `Id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reward`
--

LOCK TABLES `reward` WRITE;
/*!40000 ALTER TABLE `reward` DISABLE KEYS */;
/*!40000 ALTER TABLE `reward` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-25 15:01:17
