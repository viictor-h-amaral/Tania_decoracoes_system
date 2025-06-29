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
-- Table structure for table `dec_decoracoes`
--

DROP TABLE IF EXISTS `dec_decoracoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dec_decoracoes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DataCadastro` date NOT NULL,
  `Cliente` int NOT NULL,
  `Comemorando` int DEFAULT NULL,
  `EnderecoEvento` int DEFAULT NULL,
  `TipoEvento` int NOT NULL,
  `TemaAniversario` int DEFAULT NULL,
  `CarroUtilizado` int NOT NULL,
  `DistanciaDeCasa` float DEFAULT NULL,
  `ValorSugerido` decimal(6,3) DEFAULT NULL,
  `ValorCobrado` decimal(6,3) NOT NULL,
  `Lucro` decimal(6,3) DEFAULT NULL,
  `DataEvento` datetime DEFAULT NULL,
  `DataHoraMontagem` datetime DEFAULT NULL,
  `PegueEMonte` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Comemorando` (`Comemorando`),
  KEY `EnderecoEvento` (`EnderecoEvento`),
  KEY `TipoEvento` (`TipoEvento`),
  KEY `TemaAniversario` (`TemaAniversario`),
  KEY `Cliente` (`Cliente`),
  CONSTRAINT `dec_decoracoes_ibfk_1` FOREIGN KEY (`Cliente`) REFERENCES `cl_clientes` (`Id`),
  CONSTRAINT `dec_decoracoes_ibfk_2` FOREIGN KEY (`Comemorando`) REFERENCES `cl_dependentesclientes` (`Id`),
  CONSTRAINT `dec_decoracoes_ibfk_3` FOREIGN KEY (`EnderecoEvento`) REFERENCES `end_enderecoseventos` (`Id`),
  CONSTRAINT `dec_decoracoes_ibfk_4` FOREIGN KEY (`TipoEvento`) REFERENCES `dec_tiposeventos` (`Id`),
  CONSTRAINT `dec_decoracoes_ibfk_5` FOREIGN KEY (`TemaAniversario`) REFERENCES `dec_temasaniversarios` (`Id`),
  CONSTRAINT `dec_decoracoes_ibfk_6` FOREIGN KEY (`Cliente`) REFERENCES `ta_carros` (`Id`)
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
