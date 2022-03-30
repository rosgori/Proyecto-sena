-- MySQL dump 10.13  Distrib 8.0.28, for Linux (x86_64)
--
-- Host: 127.0.0.1    Database: proyecto_innube
-- ------------------------------------------------------
-- Server version	8.0.28-0ubuntu0.20.04.3

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
-- Table structure for table `Ciudad_compañia`
--

DROP TABLE IF EXISTS `Ciudad_compañia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Ciudad_compañia` (
  `id_ciudad` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_ciudad` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_ciudad`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ciudad_compañia`
--

LOCK TABLES `Ciudad_compañia` WRITE;
/*!40000 ALTER TABLE `Ciudad_compañia` DISABLE KEYS */;
INSERT INTO `Ciudad_compañia` VALUES (1,'Bogotá'),(2,'Medellín'),(3,'Cali'),(4,'Barranquilla');
/*!40000 ALTER TABLE `Ciudad_compañia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Cliente`
--

DROP TABLE IF EXISTS `Cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Cliente` (
  `id_cliente` varchar(12) NOT NULL,
  `nombre_cliente` varchar(30) NOT NULL,
  `apellido_cliente` varchar(30) NOT NULL,
  `correo_electronico_cliente` varchar(50) NOT NULL,
  `id_contraseña_cliente` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_cliente`),
  UNIQUE KEY `correo_electronico_cliente` (`correo_electronico_cliente`),
  KEY `id_contraseña_cliente_fk` (`id_contraseña_cliente`),
  CONSTRAINT `id_contraseña_cliente_fk` FOREIGN KEY (`id_contraseña_cliente`) REFERENCES `Contraseña_cliente` (`id_contraseña_cliente`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cliente`
--

LOCK TABLES `Cliente` WRITE;
/*!40000 ALTER TABLE `Cliente` DISABLE KEYS */;
INSERT INTO `Cliente` VALUES ('CC1602751','Mario','Espinoza','mario@gmail.com',4),('CC2622732','Luis','Becerra','luis@gmail.com',6),('CC280580','Ana','Contreras','anitaanita@gmail.com',10),('CC3152747','Daniela','Ortiz','danio@gmail.com',3),('CC6085669','Ana','Díaz','danii@gmail.com',12),('CC647399','Ana','Núñez','ana@gmail.com',2),('CC6526100','Anita','Anita','anitada@gmail.com',11),('CC663343','David','Faradio','dad@gmail.com',1),('CC7298588','Ana','Fernández','anafer@gmail.com',8),('CC7488623','Ana','Montoya','anamonto@gmail.com',9),('CC9257664','Aleja','Andes','aleja@gmail.com',5);
/*!40000 ALTER TABLE `Cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Cliente_compañia`
--

DROP TABLE IF EXISTS `Cliente_compañia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Cliente_compañia` (
  `id_cliente_compañia` varchar(12) NOT NULL,
  `nombre_compañia` varchar(30) NOT NULL,
  `telefono_compañia` varchar(15) NOT NULL,
  `correo_electronico_compañia` varchar(50) NOT NULL,
  `direccion_compañia` varchar(50) NOT NULL,
  `id_contraseña_compañia` int unsigned NOT NULL,
  `nit_compañia` varchar(12) NOT NULL,
  `id_ciudad` int unsigned DEFAULT NULL,
  `id_departamento` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_cliente_compañia`),
  UNIQUE KEY `correo_electronico_compañia` (`correo_electronico_compañia`),
  UNIQUE KEY `nit_compañia` (`nit_compañia`),
  KEY `id_contraseña_compañia_fk` (`id_contraseña_compañia`),
  KEY `id_ciudad_fk` (`id_ciudad`),
  KEY `id_departamento_fk` (`id_departamento`),
  CONSTRAINT `id_ciudad_fk` FOREIGN KEY (`id_ciudad`) REFERENCES `Ciudad_compañia` (`id_ciudad`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_contraseña_compañia_fk` FOREIGN KEY (`id_contraseña_compañia`) REFERENCES `Contraseña_cliente_compañia` (`id_contraseña_compañia`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_departamento_fk` FOREIGN KEY (`id_departamento`) REFERENCES `Departamento_compañia` (`id_departamento`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cliente_compañia`
--

LOCK TABLES `Cliente_compañia` WRITE;
/*!40000 ALTER TABLE `Cliente_compañia` DISABLE KEYS */;
INSERT INTO `Cliente_compañia` VALUES ('CM1198519','Palomillas S.A.','31231','palomillas@gmail.com','Calle 101',6,'214810',1,1),('CM396479','Palomas S.A.S','23450','palomas@gmail.com','Calle 101',4,'45603-2',2,3),('CM9018424','Dados A.A.','345009','dados@gmail.com','Calle 101',5,'50009',1,1),('CM9280900','Juegos S.A','23456','juegosa@gmail.com','Calle 100',2,'3445-3',1,1);
/*!40000 ALTER TABLE `Cliente_compañia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Cliente_general`
--

DROP TABLE IF EXISTS `Cliente_general`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Cliente_general` (
  `id_cliente_general` varchar(12) NOT NULL,
  `personal_natural` tinyint(1) NOT NULL,
  `persona_juridica` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_cliente_general`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cliente_general`
--

LOCK TABLES `Cliente_general` WRITE;
/*!40000 ALTER TABLE `Cliente_general` DISABLE KEYS */;
INSERT INTO `Cliente_general` VALUES ('CC280580',1,0),('CC6085669',1,0),('CC6526100',1,0),('CC7488623',1,0),('CM1198519',0,1),('CM2863643',0,1),('CM396479',0,1),('CM5755671',0,1),('CM8432523',0,1),('CM9018424',0,1),('CM9280900',0,1);
/*!40000 ALTER TABLE `Cliente_general` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Compañia`
--

DROP TABLE IF EXISTS `Compañia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Compañia` (
  `id_compañia` varchar(12) NOT NULL,
  `nombre_compañia` varchar(30) NOT NULL,
  `telefono_compañia` varchar(15) NOT NULL,
  `correo_electronico_compañia` varchar(50) NOT NULL,
  `direccion_compañia` varchar(50) NOT NULL,
  `id_contraseña_compañia` int unsigned NOT NULL,
  `nit_compañia` varchar(12) NOT NULL,
  `id_ciudad` int unsigned DEFAULT NULL,
  `id_departamento` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_compañia`),
  UNIQUE KEY `correo_electronico_compañia` (`correo_electronico_compañia`),
  UNIQUE KEY `nit_compañia` (`nit_compañia`),
  KEY `id_contraseña_compañia_fk2` (`id_contraseña_compañia`),
  KEY `id_ciudad_fk2` (`id_ciudad`),
  KEY `id_departamento_fk2` (`id_departamento`),
  CONSTRAINT `id_ciudad_fk2` FOREIGN KEY (`id_ciudad`) REFERENCES `Ciudad_compañia` (`id_ciudad`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_contraseña_compañia_fk2` FOREIGN KEY (`id_contraseña_compañia`) REFERENCES `Contraseña_compañia` (`id_contraseña_compañia`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_departamento_fk2` FOREIGN KEY (`id_departamento`) REFERENCES `Departamento_compañia` (`id_departamento`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Compañia`
--

LOCK TABLES `Compañia` WRITE;
/*!40000 ALTER TABLE `Compañia` DISABLE KEYS */;
INSERT INTO `Compañia` VALUES ('CM2863643','Ofertitas S.A.','44560','ofertitas@gmail.com','Calle 109',3,'3405-6',1,1),('CM5755671','Dados LTDA','345609','dados@gmail.com','Calle 102',1,'445-65',3,3),('CM8432523','Piezas LTDA','34569','piezas@gmail.com','Calle 97',2,'344-555',2,2);
/*!40000 ALTER TABLE `Compañia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Contraseña_cliente`
--

DROP TABLE IF EXISTS `Contraseña_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Contraseña_cliente` (
  `id_contraseña_cliente` int unsigned NOT NULL AUTO_INCREMENT,
  `salt` varchar(20) NOT NULL,
  `parte_encriptada` varchar(150) NOT NULL,
  PRIMARY KEY (`id_contraseña_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contraseña_cliente`
--

LOCK TABLES `Contraseña_cliente` WRITE;
/*!40000 ALTER TABLE `Contraseña_cliente` DISABLE KEYS */;
INSERT INTO `Contraseña_cliente` VALUES (1,'YWxnb19sYXJnbw==','YWxv'),(2,'QVlFUlE0UDY3Ug==','bWlyYWxh'),(3,'0OA3YRJGGH','wo8qRfuu9ptFq0qYVLajxTnSiCh0xuVgLWf77/F2eic='),(4,'DBYFK10ZG7','2vSd0OciXPjgbN1urhDixzZmkJTmhy3gRX/2zsrOLLM='),(5,'LMA6UGJ6WU','udVt1Zj17DZYCRWSdEbkCAqV0l1saU7bMnkPxlhE9P8='),(6,'POPPBZ1JFU','QUY8aEY4qdsrOExolJTx78mr6Qs1gD4x6Arw8R1N7OY='),(7,'G0YYVGYX7I','v68ylmM0EYN8vtdNzRJJbrV1/RBeyIaJytccaUFhIfE='),(8,'L9YE1N43YR','ZdZukKpSooeuaHRfWsveb7l68PHZH9yTFTZqNVXZzzI='),(9,'6WP3FHSFBJ','QDjNl688l2gW2tJFBkk0j3nSsFvlt241xz8TkiIAaZU='),(10,'W9PY5YOJW5','UNbz/KfVR10SzHZKwddfU8lc/owHVTh8Vg1kmz3zRJ4='),(11,'7HBF7UY3IO','3MSP/0CnTDMcbjoXxNrXVDOB075dILfOUk3Mic8KYOY='),(12,'KM39XBSOYV','W7KU1l+/lr8BVoKqqVlV+dwRh54r1XBJPjrMOvjQduE='),(13,'GDHHW9OK0A','twynkb7g2crqLU6L1e+FDlKWadq4/kBsnVCjLQtE99w='),(14,'XYL8WBS0X7','W0LIvIkFjNpKN8JBNvGmLBndGos5DXgAxw2/5DvGyqY=');
/*!40000 ALTER TABLE `Contraseña_cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Contraseña_cliente_compañia`
--

DROP TABLE IF EXISTS `Contraseña_cliente_compañia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Contraseña_cliente_compañia` (
  `id_contraseña_compañia` int unsigned NOT NULL AUTO_INCREMENT,
  `salt` varchar(20) NOT NULL,
  `parte_encriptada` varchar(150) NOT NULL,
  PRIMARY KEY (`id_contraseña_compañia`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contraseña_cliente_compañia`
--

LOCK TABLES `Contraseña_cliente_compañia` WRITE;
/*!40000 ALTER TABLE `Contraseña_cliente_compañia` DISABLE KEYS */;
INSERT INTO `Contraseña_cliente_compañia` VALUES (1,'13Z4D1SC8R','4SZ/qrvlrPc0T55k3GV6m71sTdyJxq6fqSLrosSAM2I='),(2,'QYE5PWQ7H0','SApeNIUwDQh6kRgsfPJQAGs09rce7iaxMjdesktfsdE='),(3,'C1JUKXJ0LT','nafWMRwD/LQB5/INZW3m/IXVyxCEsgu9Gxpx+D0x7Vo='),(4,'V9LYN7ERUF','6nf+60drLJhfsE3+sxidXsFex7v0BifBKZMpGA1WZP4='),(5,'8LJ25IDFJU','+5jvNtB0fqUhZdpxhN+owbvHK+sWg7zPf1cszrAe5uw='),(6,'HAL77S7RXH','iZh2JagkXL1y95Uc0kA4x+JJQt06iZ79fXj/NNrsfuI=');
/*!40000 ALTER TABLE `Contraseña_cliente_compañia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Contraseña_compañia`
--

DROP TABLE IF EXISTS `Contraseña_compañia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Contraseña_compañia` (
  `id_contraseña_compañia` int unsigned NOT NULL AUTO_INCREMENT,
  `salt` varchar(20) NOT NULL,
  `parte_encriptada` varchar(150) NOT NULL,
  PRIMARY KEY (`id_contraseña_compañia`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contraseña_compañia`
--

LOCK TABLES `Contraseña_compañia` WRITE;
/*!40000 ALTER TABLE `Contraseña_compañia` DISABLE KEYS */;
INSERT INTO `Contraseña_compañia` VALUES (1,'R3NHTQVGTG','t+613SSgpleX5hAt64JgXecjS1MhMr5I3wcvkR5EgsA='),(2,'5I2M7Y7PGX','RTOPcuLugTa4MveBp8mpzucHCVQf/eZ+ll7xSXASsyY='),(3,'UL6NOBWM9B','FLsLbe1e6SD2gnjMFgWnqC4W6s40vV98ghzNOlN8lhE=');
/*!40000 ALTER TABLE `Contraseña_compañia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Cotizacion`
--

DROP TABLE IF EXISTS `Cotizacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Cotizacion` (
  `id_cotizacion` int unsigned NOT NULL AUTO_INCREMENT,
  `precio_total` int unsigned NOT NULL,
  `id_cliente_general` varchar(12) DEFAULT NULL,
  `subtotal` int unsigned NOT NULL,
  PRIMARY KEY (`id_cotizacion`),
  KEY `id_cliente_general_fk` (`id_cliente_general`),
  CONSTRAINT `id_cliente_general_fk` FOREIGN KEY (`id_cliente_general`) REFERENCES `Cliente_general` (`id_cliente_general`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cotizacion`
--

LOCK TABLES `Cotizacion` WRITE;
/*!40000 ALTER TABLE `Cotizacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `Cotizacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Demanda_servicio`
--

DROP TABLE IF EXISTS `Demanda_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Demanda_servicio` (
  `id_cotizacion` int unsigned NOT NULL AUTO_INCREMENT,
  `id_servicio` varchar(12) NOT NULL,
  `fecha_cotizacion` date DEFAULT NULL,
  `cantidad` tinyint DEFAULT NULL,
  PRIMARY KEY (`id_cotizacion`,`id_servicio`),
  KEY `id_servicio_fk` (`id_servicio`),
  CONSTRAINT `id_cotizacion_fk` FOREIGN KEY (`id_cotizacion`) REFERENCES `Cotizacion` (`id_cotizacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_servicio_fk` FOREIGN KEY (`id_servicio`) REFERENCES `Servicio_ofrecido` (`id_servicio`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Demanda_servicio`
--

LOCK TABLES `Demanda_servicio` WRITE;
/*!40000 ALTER TABLE `Demanda_servicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `Demanda_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Departamento_compañia`
--

DROP TABLE IF EXISTS `Departamento_compañia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Departamento_compañia` (
  `id_departamento` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_departamento` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Departamento_compañia`
--

LOCK TABLES `Departamento_compañia` WRITE;
/*!40000 ALTER TABLE `Departamento_compañia` DISABLE KEYS */;
INSERT INTO `Departamento_compañia` VALUES (1,'Bogotá'),(2,'Antioquia'),(3,'Valle del Cauca'),(4,'Atlántico');
/*!40000 ALTER TABLE `Departamento_compañia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Evaluacion`
--

DROP TABLE IF EXISTS `Evaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Evaluacion` (
  `id_evaluacion` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_evaluacion` varchar(30) NOT NULL,
  `descripcion_evaluacion` varchar(1000) NOT NULL,
  PRIMARY KEY (`id_evaluacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Evaluacion`
--

LOCK TABLES `Evaluacion` WRITE;
/*!40000 ALTER TABLE `Evaluacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `Evaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Oferta_servicio`
--

DROP TABLE IF EXISTS `Oferta_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Oferta_servicio` (
  `id_servicio` varchar(12) NOT NULL,
  `id_compañia` varchar(12) NOT NULL,
  PRIMARY KEY (`id_compañia`,`id_servicio`),
  KEY `id_servicio_fk2` (`id_servicio`),
  CONSTRAINT `id_compañia_fk2` FOREIGN KEY (`id_compañia`) REFERENCES `Compañia` (`id_compañia`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_servicio_fk2` FOREIGN KEY (`id_servicio`) REFERENCES `Servicio_ofrecido` (`id_servicio`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Oferta_servicio`
--

LOCK TABLES `Oferta_servicio` WRITE;
/*!40000 ALTER TABLE `Oferta_servicio` DISABLE KEYS */;
INSERT INTO `Oferta_servicio` VALUES ('SO23618060','CM2863643'),('SO34170361','CM2863643'),('SO42005257','CM2863643'),('SO45834545','CM5755671'),('SO98987878','CM8432523');
/*!40000 ALTER TABLE `Oferta_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Parametro`
--

DROP TABLE IF EXISTS `Parametro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Parametro` (
  `id_parametro` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_parametro` varchar(30) NOT NULL,
  `descripcion_parametro` varchar(1000) NOT NULL,
  `id_evaluacion` int unsigned NOT NULL,
  `calificacion_parametro` tinyint NOT NULL,
  PRIMARY KEY (`id_parametro`),
  KEY `id_evaluacion_fk2` (`id_evaluacion`),
  CONSTRAINT `id_evaluacion_fk2` FOREIGN KEY (`id_evaluacion`) REFERENCES `Evaluacion` (`id_evaluacion`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Parametro`
--

LOCK TABLES `Parametro` WRITE;
/*!40000 ALTER TABLE `Parametro` DISABLE KEYS */;
/*!40000 ALTER TABLE `Parametro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Resultado_evaluacion`
--

DROP TABLE IF EXISTS `Resultado_evaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Resultado_evaluacion` (
  `id_compañia` varchar(12) NOT NULL,
  `id_evaluacion` int unsigned NOT NULL AUTO_INCREMENT,
  `aprobado` tinyint(1) NOT NULL,
  `fecha_aprobado` date NOT NULL,
  `calificacion` tinyint NOT NULL,
  PRIMARY KEY (`id_compañia`,`id_evaluacion`),
  KEY `id_evaluacion_fk` (`id_evaluacion`),
  CONSTRAINT `id_compañia_fk4` FOREIGN KEY (`id_compañia`) REFERENCES `Compañia` (`id_compañia`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_evaluacion_fk` FOREIGN KEY (`id_evaluacion`) REFERENCES `Evaluacion` (`id_evaluacion`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Resultado_evaluacion`
--

LOCK TABLES `Resultado_evaluacion` WRITE;
/*!40000 ALTER TABLE `Resultado_evaluacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `Resultado_evaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Servicio_ofrecido`
--

DROP TABLE IF EXISTS `Servicio_ofrecido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Servicio_ofrecido` (
  `id_servicio` varchar(12) NOT NULL,
  `nombre_servicio` varchar(100) NOT NULL,
  `precio_servicio` int unsigned NOT NULL,
  `descripcion` varchar(1000) NOT NULL,
  PRIMARY KEY (`id_servicio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Servicio_ofrecido`
--

LOCK TABLES `Servicio_ofrecido` WRITE;
/*!40000 ALTER TABLE `Servicio_ofrecido` DISABLE KEYS */;
INSERT INTO `Servicio_ofrecido` VALUES ('SO23618060','Servicio 34',120000,'Este es un servicio muy caro'),('SO34170361','Servicio BBB',45000,'Un buen servicio al alcance de todos'),('SO42005257','Servicio 35',80000,'Otro servicio raro'),('SO45834545','Servicio 1',34500,'Es el primer servicios'),('SO95651268','Nopor',100000,'Disfrute infinito'),('SO98987878','Servicio 2',50000,'Es el segundo servicio');
/*!40000 ALTER TABLE `Servicio_ofrecido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-28 23:05:23
