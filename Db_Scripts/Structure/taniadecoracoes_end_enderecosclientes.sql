CREATE DATABASE  IF NOT EXISTS `taniadecoracoes` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `taniadecoracoes`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: taniadecoracoes
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `end_enderecosclientes`
--

DROP TABLE IF EXISTS `end_enderecosclientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_enderecosclientes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Estado` int NOT NULL,
  `Municipio` int NOT NULL,
  `Bairro` int NOT NULL,
  `Logradouro` int NOT NULL,
  `TipoEndereco` int NOT NULL,
  `Observacoes` text,
  `NumeroEndereco` int NOT NULL,
  `AndarApartamento` int DEFAULT NULL,
  `NumeroApartamento` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Estado` (`Estado`),
  KEY `Municipio` (`Municipio`),
  KEY `Bairro` (`Bairro`),
  KEY `TipoEndereco` (`TipoEndereco`),
  KEY `end_enderecosclientes_ibfk_4_idx` (`Logradouro`),
  CONSTRAINT `end_enderecosclientes_ibfk_1` FOREIGN KEY (`Estado`) REFERENCES `end_estados` (`Id`),
  CONSTRAINT `end_enderecosclientes_ibfk_2` FOREIGN KEY (`Municipio`) REFERENCES `end_municipios` (`Id`),
  CONSTRAINT `end_enderecosclientes_ibfk_3` FOREIGN KEY (`Bairro`) REFERENCES `end_bairros` (`Id`),
  CONSTRAINT `end_enderecosclientes_ibfk_4` FOREIGN KEY (`Logradouro`) REFERENCES `end_logradouros` (`Id`),
  CONSTRAINT `end_enderecosclientes_ibfk_5` FOREIGN KEY (`TipoEndereco`) REFERENCES `end_tiposenderecosclientes` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-29  9:11:12
