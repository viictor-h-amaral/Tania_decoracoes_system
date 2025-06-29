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
-- Table structure for table `assoc_decoracoes_flores`
--

DROP TABLE IF EXISTS `assoc_decoracoes_flores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assoc_decoracoes_flores` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Decoracao` int NOT NULL,
  `Flor` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Decoracao_idx` (`Decoracao`),
  KEY `fk_Flor_idx` (`Flor`),
  CONSTRAINT `fk_Decoracao2` FOREIGN KEY (`Decoracao`) REFERENCES `dec_decoracoes` (`Id`),
  CONSTRAINT `fk_Flor` FOREIGN KEY (`Flor`) REFERENCES `it_flores` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `assoc_decoracoes_itens`
--

DROP TABLE IF EXISTS `assoc_decoracoes_itens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assoc_decoracoes_itens` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Decoracao` int NOT NULL,
  `Item` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Decoracao_idx` (`Decoracao`),
  KEY `fk_Item_idx` (`Item`),
  CONSTRAINT `fk_Decoracao` FOREIGN KEY (`Decoracao`) REFERENCES `dec_decoracoes` (`Id`),
  CONSTRAINT `fk_Item` FOREIGN KEY (`Item`) REFERENCES `it_itens` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cl_clientes`
--

DROP TABLE IF EXISTS `cl_clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cl_clientes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DataCadastro` date NOT NULL,
  `Nome` varchar(80) NOT NULL,
  `Apelido` varchar(120) DEFAULT NULL,
  `DataNascimento` date DEFAULT NULL,
  `Genero` int DEFAULT NULL,
  `Endereco` int NOT NULL,
  `TelefoneCelular` char(11) NOT NULL,
  `Cpf` char(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Genero` (`Genero`),
  KEY `Endereco` (`Endereco`),
  CONSTRAINT `cl_clientes_ibfk_1` FOREIGN KEY (`Genero`) REFERENCES `ta_generos` (`Id`),
  CONSTRAINT `cl_clientes_ibfk_2` FOREIGN KEY (`Endereco`) REFERENCES `end_enderecosclientes` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cl_dependentesclientes`
--

DROP TABLE IF EXISTS `cl_dependentesclientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cl_dependentesclientes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(60) NOT NULL,
  `DataAniversario` date NOT NULL,
  `Responsavel` int NOT NULL,
  `Genero` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Responsavel` (`Responsavel`),
  KEY `Genero` (`Genero`),
  CONSTRAINT `cl_dependentesclientes_ibfk_1` FOREIGN KEY (`Responsavel`) REFERENCES `cl_clientes` (`Id`),
  CONSTRAINT `cl_dependentesclientes_ibfk_2` FOREIGN KEY (`Genero`) REFERENCES `ta_generos` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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

--
-- Table structure for table `dec_temasaniversarios`
--

DROP TABLE IF EXISTS `dec_temasaniversarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dec_temasaniversarios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Tema` varchar(200) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dec_tiposeventos`
--

DROP TABLE IF EXISTS `dec_tiposeventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dec_tiposeventos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoEvento` varchar(120) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_bairros`
--

DROP TABLE IF EXISTS `end_bairros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_bairros` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Municipio` int NOT NULL,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Municipio` (`Municipio`),
  CONSTRAINT `end_bairros_ibfk_1` FOREIGN KEY (`Municipio`) REFERENCES `end_municipios` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=148 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_ceps`
--

DROP TABLE IF EXISTS `end_ceps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_ceps` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Cep` varchar(8) NOT NULL,
  `Logradouro` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Cep_UNIQUE` (`Cep`),
  KEY `fk_logradouro_idx` (`Logradouro`),
  CONSTRAINT `fk_logradouro` FOREIGN KEY (`Logradouro`) REFERENCES `end_logradouros` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8192 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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

--
-- Table structure for table `end_enderecoseventos`
--

DROP TABLE IF EXISTS `end_enderecoseventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_enderecoseventos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Estado` int NOT NULL,
  `Municipio` int NOT NULL,
  `Bairro` int NOT NULL,
  `Logradouro` int NOT NULL,
  `TipoEndereco` int NOT NULL,
  `NumeroEndereco` int NOT NULL,
  `Apelido` varchar(100) NOT NULL,
  `Observacoes` text,
  `AndarApartamento` int DEFAULT NULL,
  `NumeroApartamento` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Estado` (`Estado`),
  KEY `Municipio` (`Municipio`),
  KEY `Bairro` (`Bairro`),
  KEY `TipoEndereco` (`TipoEndereco`),
  KEY `end_enderecoseventos_ibfk_4_idx` (`Logradouro`),
  CONSTRAINT `end_enderecoseventos_ibfk_1` FOREIGN KEY (`Estado`) REFERENCES `end_estados` (`Id`),
  CONSTRAINT `end_enderecoseventos_ibfk_2` FOREIGN KEY (`Municipio`) REFERENCES `end_municipios` (`Id`),
  CONSTRAINT `end_enderecoseventos_ibfk_3` FOREIGN KEY (`Bairro`) REFERENCES `end_bairros` (`Id`),
  CONSTRAINT `end_enderecoseventos_ibfk_4` FOREIGN KEY (`Logradouro`) REFERENCES `end_logradouros` (`Id`),
  CONSTRAINT `end_enderecoseventos_ibfk_5` FOREIGN KEY (`TipoEndereco`) REFERENCES `end_tiposenderecoseventos` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_estados`
--

DROP TABLE IF EXISTS `end_estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_estados` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `Sigla` varchar(2) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Tabela referente aos estados do Brasil';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_logradouros`
--

DROP TABLE IF EXISTS `end_logradouros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_logradouros` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Bairro` int NOT NULL DEFAULT '0',
  `Nome` varchar(120) NOT NULL,
  `Tipo` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_tipo_logradouro_idx` (`Tipo`),
  CONSTRAINT `fk_tipo_logradouro` FOREIGN KEY (`Tipo`) REFERENCES `end_tiposlogradouros` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6646 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_municipios`
--

DROP TABLE IF EXISTS `end_municipios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_municipios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Estado` int NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `Codigo_IBGE` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Codigo_IBGE_UNIQUE` (`Codigo_IBGE`),
  KEY `Estado` (`Estado`),
  CONSTRAINT `end_municipios_ibfk_1` FOREIGN KEY (`Estado`) REFERENCES `end_estados` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=142 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_tiposenderecosclientes`
--

DROP TABLE IF EXISTS `end_tiposenderecosclientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_tiposenderecosclientes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoEndereco` varchar(35) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_tiposenderecoseventos`
--

DROP TABLE IF EXISTS `end_tiposenderecoseventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_tiposenderecoseventos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoEndereco` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `end_tiposlogradouros`
--

DROP TABLE IF EXISTS `end_tiposlogradouros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `end_tiposlogradouros` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(40) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `it_flores`
--

DROP TABLE IF EXISTS `it_flores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `it_flores` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `PrecoTemporada` decimal(10,0) DEFAULT NULL,
  `PrecoPadrao` decimal(10,0) NOT NULL,
  `Imagem` varchar(200) DEFAULT NULL,
  `Cor` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `fk_cor` FOREIGN KEY (`Id`) REFERENCES `ta_cores` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `it_itens`
--

DROP TABLE IF EXISTS `it_itens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `it_itens` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Apelido` varchar(120) DEFAULT NULL,
  `TipoItem` int NOT NULL,
  `QuantidadeEstoque` int NOT NULL DEFAULT '1',
  `Preco` decimal(10,0) DEFAULT NULL,
  `Cor` int DEFAULT NULL,
  `Tamanho` int DEFAULT NULL,
  `Altura` float DEFAULT NULL,
  `Comprimento` float DEFAULT NULL,
  `Largura` float DEFAULT NULL,
  `Imagem` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `TipoItem` (`TipoItem`),
  KEY `Cor` (`Cor`),
  KEY `Tamanho` (`Tamanho`),
  CONSTRAINT `it_itens_ibfk_1` FOREIGN KEY (`TipoItem`) REFERENCES `it_tipositens` (`Id`),
  CONSTRAINT `it_itens_ibfk_2` FOREIGN KEY (`Cor`) REFERENCES `ta_cores` (`Id`),
  CONSTRAINT `it_itens_ibfk_3` FOREIGN KEY (`Tamanho`) REFERENCES `ta_tamanhos` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `it_tipositens`
--

DROP TABLE IF EXISTS `it_tipositens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `it_tipositens` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoItem` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pg_decoracoescustos`
--

DROP TABLE IF EXISTS `pg_decoracoescustos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pg_decoracoescustos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Decoracao` int NOT NULL,
  `CustoCalculado` decimal(6,3) DEFAULT NULL,
  `CustoFlores` decimal(6,3) DEFAULT NULL,
  `CustoBaloes` decimal(6,3) DEFAULT NULL,
  `CustoMoveis` decimal(6,3) DEFAULT NULL,
  `CustosExtras` decimal(6,3) DEFAULT NULL,
  `CustoCombustivel` decimal(6,3) NOT NULL,
  `CustoTotal` decimal(6,3) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Decoracao` (`Decoracao`),
  CONSTRAINT `pg_decoracoescustos_ibfk_1` FOREIGN KEY (`Decoracao`) REFERENCES `dec_decoracoes` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pg_decoracoespagamentos`
--

DROP TABLE IF EXISTS `pg_decoracoespagamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pg_decoracoespagamentos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Decoracao` int NOT NULL,
  `FormaPagamentoEntrada` int NOT NULL,
  `ValorEntrada` decimal(6,3) NOT NULL,
  `DataPagamentoEntrada` date DEFAULT NULL,
  `FormaPagamentoRestante` int NOT NULL,
  `ValorRestante` decimal(6,3) NOT NULL,
  `DataPagamentoRestante` date DEFAULT NULL,
  `ValorParcelaRestante` decimal(6,3) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Decoracao` (`Decoracao`),
  KEY `FormaPagamentoEntrada` (`FormaPagamentoEntrada`),
  KEY `FormaPagamentoRestante` (`FormaPagamentoRestante`),
  CONSTRAINT `pg_decoracoespagamentos_ibfk_1` FOREIGN KEY (`Decoracao`) REFERENCES `dec_decoracoes` (`Id`),
  CONSTRAINT `pg_decoracoespagamentos_ibfk_2` FOREIGN KEY (`FormaPagamentoEntrada`) REFERENCES `pg_formaspagamento` (`Id`),
  CONSTRAINT `pg_decoracoespagamentos_ibfk_3` FOREIGN KEY (`FormaPagamentoRestante`) REFERENCES `pg_formaspagamento` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pg_formaspagamento`
--

DROP TABLE IF EXISTS `pg_formaspagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pg_formaspagamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FormaPagamento` varchar(25) NOT NULL,
  `Parcelado` tinyint(1) NOT NULL DEFAULT '0',
  `NumeroParcelas` int DEFAULT NULL,
  `TaxaParcelamento` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `TaxaParcelamento` (`TaxaParcelamento`),
  CONSTRAINT `pg_formaspagamento_ibfk_1` FOREIGN KEY (`TaxaParcelamento`) REFERENCES `pg_taxasparcelamento` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pg_taxasparcelamento`
--

DROP TABLE IF EXISTS `pg_taxasparcelamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pg_taxasparcelamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Juros` decimal(3,3) NOT NULL,
  `Meses` int NOT NULL,
  `JurosCompostos` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ta_carros`
--

DROP TABLE IF EXISTS `ta_carros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ta_carros` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Apelido` varchar(40) NOT NULL,
  `LitrosPorKm` float NOT NULL,
  `TipoCombustivel` int NOT NULL,
  `EstaAtivo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `TipoCombustivel` (`TipoCombustivel`),
  CONSTRAINT `ta_carros_ibfk_1` FOREIGN KEY (`TipoCombustivel`) REFERENCES `ta_tiposcombustiveis` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ta_cores`
--

DROP TABLE IF EXISTS `ta_cores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ta_cores` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `CodigoHex` char(7) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ta_custoscombustiveis`
--

DROP TABLE IF EXISTS `ta_custoscombustiveis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ta_custoscombustiveis` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Combustivel` int NOT NULL,
  `ReaisPorLitro` decimal(10,0) NOT NULL DEFAULT '0',
  `DataInicial` date NOT NULL,
  `DataFinal` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_tipocombustivel_idx` (`Combustivel`),
  CONSTRAINT `fk_tipocombustivel` FOREIGN KEY (`Combustivel`) REFERENCES `ta_tiposcombustiveis` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ta_generos`
--

DROP TABLE IF EXISTS `ta_generos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ta_generos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Sexo` varchar(20) NOT NULL,
  `LetraSexo` char(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ta_tamanhos`
--

DROP TABLE IF EXISTS `ta_tamanhos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ta_tamanhos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Tamanho` varchar(25) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ta_tiposcombustiveis`
--

DROP TABLE IF EXISTS `ta_tiposcombustiveis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ta_tiposcombustiveis` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoCombustivel` varchar(40) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'taniadecoracoes'
--

--
-- Dumping routines for database 'taniadecoracoes'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-29  9:12:06
