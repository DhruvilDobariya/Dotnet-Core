CREATE DATABASE  IF NOT EXISTS `bookshopdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bookshopdb`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bookshopdb
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `bosd01`
--

DROP TABLE IF EXISTS `bosd01`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bosd01` (
  `D01F01` int NOT NULL AUTO_INCREMENT COMMENT 'AuthorId',
  `D01F02` varchar(45) NOT NULL COMMENT 'AuthorName',
  `D01F03` int NOT NULL COMMENT 'UserId',
  PRIMARY KEY (`D01F01`),
  UNIQUE KEY `AuthorName_UNIQUE` (`D01F02`),
  KEY `fk_bosd01_bosd061_idx` (`D01F03`),
  CONSTRAINT `fk_bosd01_bosd061` FOREIGN KEY (`D01F03`) REFERENCES `bosd04` (`D04F01`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Author';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bosd01`
--

LOCK TABLES `bosd01` WRITE;
/*!40000 ALTER TABLE `bosd01` DISABLE KEYS */;
INSERT INTO `bosd01` VALUES (1,'Huntley Fyall',1),(2,'Marcelle Guyon',1),(3,'Leontine Gillinghams',1),(4,'Carine Grundell',1),(5,'Chad Airdrie',1),(6,'Sallie Lonsdale',1),(7,'Adrea Duggon',1),(8,'Tim Gynni',1),(9,'Hill Bickerdike',1),(11,'Curcio McGroarty',1),(12,'Aymer Belleny',1),(13,'Ingrim McGucken',1),(14,'Amity Raymont',1),(15,'Ardith De Paoli',1),(16,'Sylas Swatland',1),(17,'Celinka Sennett',1),(18,'Erik Giacobazzi',1),(19,'Cherilynn Bester',1),(20,'Giffer Gowenlock',1);
/*!40000 ALTER TABLE `bosd01` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bosd02`
--

DROP TABLE IF EXISTS `bosd02`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bosd02` (
  `D02F01` int NOT NULL AUTO_INCREMENT COMMENT 'CustomerId',
  `D02F02` varchar(250) NOT NULL COMMENT 'Name',
  `D02F03` varchar(50) DEFAULT NULL COMMENT 'ContactNo',
  `D02F04` varchar(250) DEFAULT NULL COMMENT 'Email',
  `D02F05` varchar(500) DEFAULT NULL COMMENT 'Address',
  `D02F06` int NOT NULL COMMENT 'UserId',
  PRIMARY KEY (`D02F01`),
  KEY `fk_bosd02_bosd061_idx` (`D02F06`),
  CONSTRAINT `fk_bosd02_bosd061` FOREIGN KEY (`D02F06`) REFERENCES `bosd04` (`D04F01`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='customer';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bosd02`
--

LOCK TABLES `bosd02` WRITE;
/*!40000 ALTER TABLE `bosd02` DISABLE KEYS */;
INSERT INTO `bosd02` VALUES (1,'Rollie Wainman','274-862-6977','rwainman0@theguardian.com','55984 Tennyson Point',3),(2,'Carver Vaulkhard','499-785-3893','cvaulkhard1@rambler.ru','1845 Westport Road',1),(3,'Jobey Bennell','878-678-3264','jbennell2@cornell.edu','86683 Clemons Place',4),(4,'Trever Blandamore','882-923-0523','tblandamore3@dyndns.org','59 Fieldstone Parkway',2),(5,'Connie Pepper','745-728-0322','cpepper4@csmonitor.com','66 Bluejay Crossing',4),(6,'Brittne Woolaston','420-195-9365','bwoolaston5@wordpress.com','46506 Shasta Lane',4),(7,'Rosalynd Dench','851-964-0122','rdench6@weather.com','035 Golf Lane',1),(8,'Sibilla Brockton','955-764-8532','sbrockton7@newsvine.com','95395 Arrowood Parkway',4),(9,'Ezri Coneau','184-447-0871','econeau8@elpais.com','4 Raven Street',4),(10,'Ripley Caslake','225-905-5454','rcaslake9@samsung.com','571 Lien Way',1),(11,'Arni Spellecy','972-570-5426','aspellecya@examiner.com','0 Loeprich Plaza',4),(12,'Guillemette Seddon','617-925-8765','gseddonb@360.cn','6 Delaware Court',1),(13,'Easter Selwyne','505-820-9475','eselwynec@w3.org','5 Division Crossing',3),(14,'Madeleine Moralis','261-309-3292','mmoralisd@wikipedia.org','22 Coolidge Alley',1),(15,'Sandy Blazynski','246-888-0690','sblazynskie@globo.com','223 Dixon Avenue',4),(16,'Broddie Dubbin','700-618-8607','bdubbinf@wsj.com','4 Morning Center',4),(17,'Martainn Jakubowicz','125-818-8809','mjakubowiczg@dedecms.com','8 Knutson Crossing',1),(18,'Tova Fredi','674-390-1504','tfredih@whitehouse.gov','33 Tony Plaza',4),(19,'Gates Donson','854-918-4060','gdonsoni@netlog.com','2048 Dwight Point',2),(20,'Mathilda Slafford','236-382-1533','mslaffordj@ow.ly','719 Gale Center',1);
/*!40000 ALTER TABLE `bosd02` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bosd03`
--

DROP TABLE IF EXISTS `bosd03`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bosd03` (
  `D03F01` int NOT NULL AUTO_INCREMENT COMMENT 'BookId',
  `D03F02` varchar(250) NOT NULL COMMENT 'Title',
  `D03F03` decimal(6,2) DEFAULT NULL COMMENT 'Price',
  `D03F04` int DEFAULT NULL COMMENT 'Quantity',
  `D03F05` text COMMENT 'Description',
  `D03F06` int NOT NULL COMMENT 'AuthorId',
  `D03F07` int NOT NULL COMMENT 'UserId',
  PRIMARY KEY (`D03F01`),
  KEY `FK_Book_Author_idx` (`D03F06`),
  KEY `FK_Book_User_idx` (`D03F07`),
  CONSTRAINT `FK_Book_Author` FOREIGN KEY (`D03F06`) REFERENCES `bosd01` (`D01F01`),
  CONSTRAINT `FK_Book_User` FOREIGN KEY (`D03F07`) REFERENCES `bosd04` (`D04F01`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Book';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bosd03`
--

LOCK TABLES `bosd03` WRITE;
/*!40000 ALTER TABLE `bosd03` DISABLE KEYS */;
INSERT INTO `bosd03` VALUES (1,'Her Master\'s Voice',9269.01,7,'Sed ante. Vivamus tortor. Duis mattis egestas metus.\n\nAenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.',3,1),(2,'Order of Myths, The',5085.14,15,'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\n\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.',13,1),(3,'Tomie: Unlimited',3817.53,1,'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.\n\nNullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.\n\nIn quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.\n\nMaecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.',15,1),(4,'Play House, The',4210.40,2,'Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.\n\nMorbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.\n\nFusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.',14,1),(5,'Tuskegee Airmen, The',8983.82,13,'Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.\n\nDuis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.',13,1),(6,'17 Girls (17 filles)',2213.46,18,'Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.\n\nIn congue. Etiam justo. Etiam pretium iaculis justo.\n\nIn hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.',20,1),(7,'Mating Season, The',1192.59,3,'Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.',16,1),(8,'Rob the Mob',1854.06,8,'Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.',20,1),(9,'Stranger on the Third Floor',8633.94,2,'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.\n\nQuisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.\n\nVestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.\n\nIn congue. Etiam justo. Etiam pretium iaculis justo.',3,1),(10,'Looking for Palladin',7034.21,13,'Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.\n\nNullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.',3,1),(11,'Death of Mr. Lazarescu, The (Moartea domnului Lazarescu)',200.79,5,'Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.\n\nNam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.\n\nCurabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.',11,1),(12,'Henry IV, Part II (Second Part of King Henry the Fourth, including his death and the coronation of King Henry the Fifth, The)',1514.10,20,'Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.',20,1),(13,'I Want Candy',6334.90,3,'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.',13,1),(14,'Solstice',2238.76,9,'Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.\n\nCurabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.',1,1),(15,'Joan of Arc',8117.50,18,'Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.\n\nPraesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.\n\nCras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.',3,1),(16,'Little Soldier (Lille soldat)',3717.69,1,'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\n\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.\n\nPhasellus in felis. Donec semper sapien a libero. Nam dui.',14,1),(17,'Night in Old Mexico, A',9363.36,17,'Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.\n\nIn quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.',20,1),(18,'Pallbearer, The',2487.11,19,'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.\n\nVestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.',8,1),(19,'Grapes of Death, The (Raisins de la mort, Les)',3483.58,12,'In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.',20,1),(20,'Passion of Love (Passione d\'amore)',5381.03,6,'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.',15,1),(21,'fsfsfd',0.00,0,'',1,1),(22,'fsddf',0.00,0,'',1,1),(23,'dsds',0.00,0,'',2,1),(24,'sasa',0.00,0,'',4,1),(26,'saas',0.00,0,'',1,1),(27,'sasas',0.00,0,'',1,1);
/*!40000 ALTER TABLE `bosd03` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bosd04`
--

DROP TABLE IF EXISTS `bosd04`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bosd04` (
  `D04F01` int NOT NULL AUTO_INCREMENT COMMENT 'UserId',
  `D04F02` varchar(50) NOT NULL COMMENT 'Name',
  `D04F03` varchar(50) NOT NULL COMMENT 'Email',
  `D04F04` varchar(50) NOT NULL COMMENT 'Password',
  PRIMARY KEY (`D04F01`),
  UNIQUE KEY `Email_UNIQUE` (`D04F03`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='User';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bosd04`
--

LOCK TABLES `bosd04` WRITE;
/*!40000 ALTER TABLE `bosd04` DISABLE KEYS */;
INSERT INTO `bosd04` VALUES (1,'adminnew','admin@gmail.com','Admin@123'),(2,'Stirling Beckmann','sbeckmann0@accuweather.com','iy0zlS'),(3,'Audra Duffin','aduffin1@un.org','HWMlSG3AM'),(4,'Vinni Djordjevic','vdjordjevic2@nsw.gov.au','PBasES2bK'),(5,'Winnie Linck','wlinck3@epa.gov','m3DLUAFIPea'),(6,'Rea Goligher','rgoligher4@virginia.edu','x4i4DJq'),(7,'Port Poltone','ppoltone5@princeton.edu','jgoEB8YuoZ'),(8,'Corbin Lamdin','clamdin6@tuttocitta.it','4DAEvZhcCMxW'),(9,'Gage Pooly','gpooly7@topsy.com','l7hG4Rxj9FBm'),(10,'Brittany Rudland','brudland8@youku.com','vXB2gp4HCy'),(11,'Jessey Goffe','jgoffe9@scribd.com','tte3PN2IeL'),(12,'Vitia Brindley','vbrindleya@opera.com','MKqJu9Dit'),(13,'Gracia Gomme','ggommeb@xrea.com','iUaBAQIRlFz'),(14,'Tudor Lujan','tlujanc@zdnet.com','hpuzaiNqA0'),(15,'William Bernaldez','wbernaldezd@tuttocitta.it','nuFzIeMQ2sL9'),(16,'Meryl McLeod','mmcleode@nyu.edu','JaQXH3Px7tc'),(17,'Andres Dutchburn','adutchburnf@csmonitor.com','FXA88HVHC2'),(18,'Zebedee Gladyer','zgladyerg@1und1.de','8Ph40Gk'),(20,'Tallia Pardi','tpardii@delicious.com','cXGFgUG3R'),(21,'Creighton Oda','codaj@ifeng.com','EhaUMlPjvVw'),(22,'string','user@example.com','string');
/*!40000 ALTER TABLE `bosd04` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-22 10:59:29
