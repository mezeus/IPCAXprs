-- MySQL dump 10.13  Distrib 5.1.73, for Win32 (ia32)
--
-- Host: localhost    Database: sunspeed
-- ------------------------------------------------------
-- Server version	5.1.73-community

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
-- Table structure for table `accountfieldsettings`
--

DROP TABLE IF EXISTS `accountfieldsettings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accountfieldsettings` (
  `ID` int(10) NOT NULL,
  `UserId` tinyint(1) NOT NULL,
  `Acc_DbName` tinyint(1) NOT NULL,
  `ACC_NAME` tinyint(1) NOT NULL,
  `ACC_SHORTNAME` tinyint(1) NOT NULL,
  `ACC_PRINTNAME` tinyint(1) NOT NULL,
  `ACC_LedgerType` tinyint(1) NOT NULL,
  `ACC_MultiCurr` tinyint(1) NOT NULL,
  `ACC_Group` tinyint(1) NOT NULL,
  `ACC_OpBal` tinyint(1) NOT NULL,
  `ACC_PrevYearBal` tinyint(1) NOT NULL,
  `ACC_DrCrOpenBal` tinyint(1) NOT NULL,
  `ACC_DrCrPrevBal` tinyint(1) NOT NULL,
  `ACC_MaintainBitwise` tinyint(1) NOT NULL,
  `ACC_ActivateInterestCal` tinyint(1) NOT NULL,
  `ACC_CreditDays` tinyint(1) NOT NULL,
  `ACC_CreditLimit` tinyint(1) NOT NULL,
  `ACC_TypeofDealer` tinyint(1) NOT NULL,
  `ACC_TypeofBuissness` tinyint(1) NOT NULL,
  `ACC_Transport` tinyint(1) NOT NULL,
  `ACC_Station` tinyint(1) NOT NULL,
  `ACC_SpecifyDefaultSaleType` tinyint(1) NOT NULL,
  `ACC_DefaultSaleType` tinyint(1) NOT NULL,
  `ACC_FreezeSaleType` tinyint(1) NOT NULL,
  `ACC_SpecifyDefaultPurType` tinyint(1) NOT NULL,
  `ACC_DefaultPurcType` tinyint(1) NOT NULL,
  `ACC_LockSalesType` tinyint(1) NOT NULL,
  `ACC_LockPurcType` tinyint(1) NOT NULL,
  `ACC_address1` tinyint(1) NOT NULL,
  `ACC_address2` tinyint(1) NOT NULL,
  `ACC_Address3` tinyint(1) NOT NULL,
  `ACC_Address4` tinyint(1) NOT NULL,
  `ACC_State` tinyint(1) NOT NULL,
  `ACC_TelephoneNumber` tinyint(1) NOT NULL,
  `ACC_Fax` tinyint(1) NOT NULL,
  `ACC_MobileNumber` tinyint(1) NOT NULL,
  `ACC_email` tinyint(1) NOT NULL,
  `ACC_Website` tinyint(1) NOT NULL,
  `ACC_enablemailquery` tinyint(1) NOT NULL,
  `ACC_enableSMSquery` tinyint(1) NOT NULL,
  `ACC_contactperson` tinyint(1) NOT NULL,
  `ACC_ITPanNumber` tinyint(1) NOT NULL,
  `ACC_LSTNumber` tinyint(1) NOT NULL,
  `ACC_CSTNumber` tinyint(1) NOT NULL,
  `ACC_TIN` tinyint(1) NOT NULL,
  `ACC_ServiceTax` tinyint(1) NOT NULL,
  `ACC_LBTNumber` tinyint(1) NOT NULL,
  `ACC_BankAccountNumber` tinyint(1) NOT NULL,
  `ACC_IECode` tinyint(1) NOT NULL,
  `ACC_Ward` tinyint(1) NOT NULL,
  `ACC_CreatedBy` tinyint(1) NOT NULL,
  `ACC_CreatedDate` tinyint(1) NOT NULL,
  `ACC_ModifiedBy` tinyint(1) NOT NULL,
  `ACC_ModifiedDate` tinyint(1) NOT NULL,
  `ACC_DEFAULT_CHEQUE_FORMAT` tinyint(1) NOT NULL,
  `ENABLE_CHEQUE_PRINTING` tinyint(1) NOT NULL,
  `ACC_Cheque_PrintName` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ACC_IECode` (`ACC_IECode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accountfieldsettings`
--

LOCK TABLES `accountfieldsettings` WRITE;
/*!40000 ALTER TABLE `accountfieldsettings` DISABLE KEYS */;
/*!40000 ALTER TABLE `accountfieldsettings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accountgroups`
--

DROP TABLE IF EXISTS `accountgroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accountgroups` (
  `AG_ID` int(10) NOT NULL,
  `GroupName` varchar(255) DEFAULT NULL,
  `AliasName` varchar(255) DEFAULT NULL,
  `Primary` varchar(255) DEFAULT NULL,
  `UnderGroup` varchar(255) DEFAULT NULL,
  `CanDelete` tinyint(1) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`AG_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accountgroups`
--

LOCK TABLES `accountgroups` WRITE;
/*!40000 ALTER TABLE `accountgroups` DISABLE KEYS */;
/*!40000 ALTER TABLE `accountgroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accountmaster`
--

DROP TABLE IF EXISTS `accountmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accountmaster` (
  `Ac_ID` int(10) NOT NULL AUTO_INCREMENT,
  `ACC_NAME` varchar(255) DEFAULT NULL,
  `ACC_SHORTNAME` varchar(255) DEFAULT NULL,
  `ACC_PRINTNAME` varchar(255) DEFAULT NULL,
  `ACC_LedgerType` varchar(255) DEFAULT NULL,
  `ACC_MultiCurr` tinyint(1) DEFAULT NULL,
  `ACC_Group` varchar(255) DEFAULT NULL,
  `ACC_OpBal` int(10) DEFAULT NULL,
  `ACC_PrevYearBal` int(255) DEFAULT NULL,
  `ACC_DrCrOpenBal` char(2) CHARACTER SET latin1 DEFAULT NULL,
  `ACC_DrCrPrevBal` char(2) CHARACTER SET latin1 DEFAULT NULL,
  `ACC_MaintainBitwise` tinyint(1) DEFAULT NULL,
  `ACC_ActivateInterestCal` tinyint(1) DEFAULT NULL,
  `ACC_CreditDays_ForSale` int(11) DEFAULT NULL,
  `ACC_CreditDays_ForPurch` int(11) DEFAULT NULL,
  `ACC_CreditDays` int(255) DEFAULT NULL,
  `ACC_CreditLimit` int(255) DEFAULT NULL,
  `ACC_TypeofDealer` varchar(255) DEFAULT NULL,
  `ACC_TypeofBuissness` varchar(255) DEFAULT NULL,
  `ACC_Transport` varchar(255) DEFAULT NULL,
  `ACC_Station` varchar(255) DEFAULT NULL,
  `ACC_SpecifyDefaultSaleType` tinyint(1) DEFAULT NULL,
  `ACC_DefaultSaleType` varchar(255) DEFAULT NULL,
  `ACC_FreezeSaleType` tinyint(1) DEFAULT NULL,
  `ACC_SpecifyDefaultPurType` tinyint(1) DEFAULT NULL,
  `ACC_DefaultPurcType` varchar(255) DEFAULT NULL,
  `ACC_LockSalesType` tinyint(1) DEFAULT NULL,
  `ACC_LockPurcType` tinyint(1) DEFAULT NULL,
  `ACC_address1` varchar(255) DEFAULT NULL,
  `ACC_address2` varchar(255) DEFAULT NULL,
  `ACC_Address3` varchar(255) DEFAULT NULL,
  `ACC_Address4` varchar(255) DEFAULT NULL,
  `ACC_State` varchar(255) DEFAULT NULL,
  `ACC_TelephoneNumber` varchar(255) DEFAULT NULL,
  `ACC_Fax` varchar(255) DEFAULT NULL,
  `ACC_MobileNumber` varchar(255) DEFAULT NULL,
  `ACC_email` varchar(255) DEFAULT NULL,
  `ACC_Website` varchar(255) DEFAULT NULL,
  `ACC_enablemailquery` tinyint(1) NOT NULL,
  `ACC_enableSMSquery` tinyint(1) NOT NULL,
  `ACC_contactperson` varchar(255) DEFAULT NULL,
  `ACC_ITPanNumber` varchar(255) DEFAULT NULL,
  `ACC_LSTNumber` varchar(255) DEFAULT NULL,
  `ACC_CSTNumber` varchar(255) DEFAULT NULL,
  `ACC_TIN` varchar(255) DEFAULT NULL,
  `ACC_ServiceTax` varchar(255) DEFAULT NULL,
  `ACC_LBTNumber` varchar(255) DEFAULT NULL,
  `ACC_BankAccountNumber` varchar(255) DEFAULT NULL,
  `ACC_IECode` varchar(255) DEFAULT NULL,
  `ACC_Ward` varchar(255) DEFAULT NULL,
  `ACC_DEFAULT_CHEQUE_FORMAT` varchar(255) DEFAULT NULL,
  `ENABLE_CHEQUE_PRINTING` tinyint(1) DEFAULT NULL,
  `ACC_Cheque_PrintName` varchar(255) DEFAULT NULL,
  `ACC_CreatedBy` varchar(255) DEFAULT NULL,
  `ACC_CreatedDate` datetime DEFAULT NULL,
  `ACC_ModifiedBy` varchar(255) DEFAULT NULL,
  `ACC_ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Ac_ID`),
  KEY `ACC_IECode` (`ACC_IECode`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accountmaster`
--

LOCK TABLES `accountmaster` WRITE;
/*!40000 ALTER TABLE `accountmaster` DISABLE KEYS */;
INSERT INTO `accountmaster` VALUES (1,'testing','testing','testing','General Ledger',1,'Sunday Debitors',0,0,'D','D',0,0,0,0,NULL,NULL,NULL,NULL,'','',0,'C/C-Form',0,0,'C/Stocf Trf',0,0,'','','','','Telangana','','','','',NULL,0,0,'','','','','','',NULL,NULL,'',NULL,NULL,NULL,NULL,'admin',NULL,NULL,NULL),(2,'testing 123','testing 123','testing 123','General Ledger',1,'Sunday Debitors',0,0,'D','D',0,0,0,0,NULL,NULL,NULL,NULL,'','',0,'C/C-Form',0,0,'C/Stocf Trf',0,0,'','','','','Telangana','','','','',NULL,0,0,'','','','','','',NULL,NULL,'',NULL,NULL,NULL,NULL,'admin',NULL,NULL,NULL),(3,'testing4444','testing4444','testing4444','General Ledger',1,'Sunday Debitors',0,0,'D','D',0,0,0,0,NULL,NULL,NULL,NULL,'test','dsdf',0,'C/C-Form',0,0,'C/Stocf Trf',0,0,'','','','','Telangana','','','','',NULL,0,0,'','','','','','',NULL,NULL,'',NULL,NULL,NULL,NULL,'admin',NULL,NULL,NULL),(4,'test123','test123','test123','General Ledger',1,'Sunday Debitors',0,0,'D','D',0,0,0,0,NULL,NULL,NULL,NULL,'tee','station',0,'C/C-Form',0,0,'C/Stocf Trf',0,0,'','','','','Telangana','','','','',NULL,0,0,'','','','','','',NULL,NULL,'',NULL,NULL,NULL,NULL,'admin',NULL,NULL,NULL);
/*!40000 ALTER TABLE `accountmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authormaster`
--

DROP TABLE IF EXISTS `authormaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `authormaster` (
  `Author_Id` int(10) NOT NULL,
  `Author_Name` varchar(255) DEFAULT NULL,
  `Author_Alias` varchar(255) DEFAULT NULL,
  `Author_PName` varchar(255) DEFAULT NULL,
  `Author_Connect` tinyint(1) NOT NULL,
  `Author_Address` varchar(255) DEFAULT NULL,
  `Author_Street` varchar(255) DEFAULT NULL,
  `Author_PinCode` varchar(255) DEFAULT NULL,
  `Author_City` varchar(255) DEFAULT NULL,
  `Author_State` varchar(255) DEFAULT NULL,
  `Author_Country` varchar(255) DEFAULT NULL,
  `Author_Mobile` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Author_Id`),
  UNIQUE KEY `Author_Id` (`Author_Id`),
  KEY `Author_PinCode` (`Author_PinCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authormaster`
--

LOCK TABLES `authormaster` WRITE;
/*!40000 ALTER TABLE `authormaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `authormaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `backuprestore`
--

DROP TABLE IF EXISTS `backuprestore`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `backuprestore` (
  `ID` int(10) NOT NULL,
  `NB_Restore` tinyint(1) NOT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `FTP_Restore` tinyint(1) NOT NULL,
  `Server_Name` varchar(255) DEFAULT NULL,
  `Port_No` varchar(255) DEFAULT NULL,
  `User_Name` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `BK_Folder` varchar(255) DEFAULT NULL,
  `Creaded_By` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `backuprestore`
--

LOCK TABLES `backuprestore` WRITE;
/*!40000 ALTER TABLE `backuprestore` DISABLE KEYS */;
/*!40000 ALTER TABLE `backuprestore` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `billsofmaterial`
--

DROP TABLE IF EXISTS `billsofmaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `billsofmaterial` (
  `Bom_Id` int(10) NOT NULL AUTO_INCREMENT,
  `BomName` varchar(255) NOT NULL,
  `Itemtoproduce` varchar(255) DEFAULT NULL,
  `Quantity` int(10) DEFAULT NULL,
  `ItemUnit` varchar(255) DEFAULT NULL,
  `Expenses` int(10) DEFAULT NULL,
  `SpecifyMCGenerated` tinyint(1) DEFAULT NULL,
  `SpecifyDefaultMCforItemConsumed` tinyint(1) DEFAULT NULL,
  `AppMc` varchar(255) DEFAULT NULL,
  `SNo` int(10) DEFAULT NULL,
  `ItemName` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` int(10) DEFAULT NULL,
  `TotalofConsumedqtyUnit` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Bom_Id`,`BomName`),
  KEY `id` (`Bom_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billsofmaterial`
--

LOCK TABLES `billsofmaterial` WRITE;
/*!40000 ALTER TABLE `billsofmaterial` DISABLE KEYS */;
/*!40000 ALTER TABLE `billsofmaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `billsundrymaster`
--

DROP TABLE IF EXISTS `billsundrymaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `billsundrymaster` (
  `BS_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Alias` varchar(255) DEFAULT NULL,
  `PrintName` varchar(255) DEFAULT NULL,
  `BillSundryType` varchar(255) DEFAULT NULL,
  `BillSundryNature` varchar(255) DEFAULT NULL,
  `AffectstheCostofGoodsinSale` tinyint(1) NOT NULL,
  `DefaultValue` int(10) DEFAULT NULL,
  `AffectstheCostofGoodsinPurchase` tinyint(1) NOT NULL,
  `AffectstheCostofGoodsinMaterialIssue` tinyint(1) NOT NULL,
  `AffectstheCostofGoodsinMaterialReceipt` tinyint(1) NOT NULL,
  `AffectstheCostofGoodsinStockTransfer` tinyint(1) NOT NULL,
  `AffectsAccounting` tinyint(1) NOT NULL,
  `AdjustInSaleAmount` tinyint(1) NOT NULL,
  `AccountHeadtoPost` varchar(255) DEFAULT NULL,
  `AdjustInPartyAmount` tinyint(1) NOT NULL,
  `PostOverandAbove` varchar(255) DEFAULT NULL,
  `AdjustInPurchaseAmount` tinyint(1) NOT NULL,
  `typeMaterialIssue` tinyint(1) NOT NULL,
  `typeMaterialReceipt` tinyint(1) DEFAULT NULL,
  `StockTransfer` tinyint(1) DEFAULT NULL,
  `AffectAccounting` varchar(255) DEFAULT NULL,
  `OtherSide` varchar(255) DEFAULT NULL,
  `AdjustinMC` varchar(255) DEFAULT NULL,
  `typeAbsoluteAmunt` varchar(255) DEFAULT NULL,
  `typePercentage` varchar(255) DEFAULT NULL,
  `typePerMainQty` varchar(255) DEFAULT NULL,
  `Percentoff` varchar(255) DEFAULT NULL,
  `typeNetBillAmount` varchar(255) DEFAULT NULL,
  `SelectiveCalculation` tinyint(1) DEFAULT NULL,
  `tyeItemsBasicAmt` varchar(255) DEFAULT NULL,
  `typeTotalMRPofItems` varchar(255) DEFAULT NULL,
  `typeTaxableAmount` varchar(255) DEFAULT NULL,
  `typePreviousBillSundryAmount` varchar(255) DEFAULT NULL,
  `typeOtherBillsundry` varchar(255) DEFAULT NULL,
  `RBSAmt` tinyint(1) DEFAULT NULL,
  `BSAmt` varchar(255) DEFAULT NULL,
  `BSAppOn` varchar(255) DEFAULT NULL,
  `TextBox` varchar(255) DEFAULT NULL,
  `NoOfBillSundrys` varchar(255) DEFAULT NULL,
  `ConsolidateBillSundriesAmount` tinyint(1) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `subtotalheading` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`BS_Id`),
  KEY `id` (`BS_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billsundrymaster`
--

LOCK TABLES `billsundrymaster` WRITE;
/*!40000 ALTER TABLE `billsundrymaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `billsundrymaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `citymaster`
--

DROP TABLE IF EXISTS `citymaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `citymaster` (
  `ID` int(10) NOT NULL,
  `State_ID` int(10) NOT NULL,
  `City_ID` int(10) NOT NULL,
  `City_Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`State_ID`,`City_ID`),
  KEY `City_ID` (`City_ID`),
  KEY `State_ID` (`State_ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `citymaster`
--

LOCK TABLES `citymaster` WRITE;
/*!40000 ALTER TABLE `citymaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `citymaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `company` (
  `CompanyID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `PrintName` varchar(255) DEFAULT NULL,
  `ShortName` varchar(255) DEFAULT NULL,
  `Country` varchar(255) DEFAULT NULL,
  `State` varchar(255) DEFAULT NULL,
  `FYBegining` datetime DEFAULT NULL,
  `BooksCommencing` datetime DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `CIN` varchar(255) DEFAULT NULL,
  `PAN` varchar(255) DEFAULT NULL,
  `Ward` varchar(255) DEFAULT NULL,
  `TelePhone` varchar(255) DEFAULT NULL,
  `Fax` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `CurrencySymbol` varchar(255) DEFAULT NULL,
  `CurrencyString` varchar(255) DEFAULT NULL,
  `CurrencySubString` varchar(255) DEFAULT NULL,
  `CurrencyFont` varchar(255) DEFAULT NULL,
  `CurrencyCharacter` varchar(255) DEFAULT NULL,
  `VAT` varchar(255) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `EnableTaxSchg` tinyint(1) NOT NULL,
  `TIN` varchar(255) DEFAULT NULL,
  `CSTNo` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CompanyID`),
  KEY `CompanyID` (`CompanyID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `companypath`
--

DROP TABLE IF EXISTS `companypath`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `companypath` (
  `companyId` bigint(20) NOT NULL AUTO_INCREMENT,
  `companyName` longtext,
  `companyPath` longtext,
  `isDefault` tinyint(1) DEFAULT NULL,
  `extraDate` datetime DEFAULT NULL,
  `extra1` longtext,
  `extra2` longtext,
  PRIMARY KEY (`companyId`),
  KEY `IX_tbl_CompanyPath` (`isDefault`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `companypath`
--

LOCK TABLES `companypath` WRITE;
/*!40000 ALTER TABLE `companypath` DISABLE KEYS */;
/*!40000 ALTER TABLE `companypath` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conta_voucher_account`
--

DROP TABLE IF EXISTS `conta_voucher_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conta_voucher_account` (
  `AC_Id` int(10) NOT NULL,
  `Contra_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`Contra_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conta_voucher_account`
--

LOCK TABLES `conta_voucher_account` WRITE;
/*!40000 ALTER TABLE `conta_voucher_account` DISABLE KEYS */;
/*!40000 ALTER TABLE `conta_voucher_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactgroup`
--

DROP TABLE IF EXISTS `contactgroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contactgroup` (
  `Cg_Id` int(20) NOT NULL AUTO_INCREMENT,
  `Group` varchar(20) DEFAULT NULL,
  `Alias` varchar(20) DEFAULT NULL,
  `Primarygroup` tinyint(1) DEFAULT NULL,
  `Undergroup` varchar(20) DEFAULT NULL,
  `Natureofgroup` varchar(20) DEFAULT NULL,
  `Affectgrossprofit` tinyint(1) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `ModifiedBy` varchar(20) DEFAULT NULL,
  `ModifiedDate` date DEFAULT NULL,
  PRIMARY KEY (`Cg_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactgroup`
--

LOCK TABLES `contactgroup` WRITE;
/*!40000 ALTER TABLE `contactgroup` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactgroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactmaster`
--

DROP TABLE IF EXISTS `contactmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contactmaster` (
  `cm_id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) DEFAULT NULL,
  `Alias` varchar(20) DEFAULT NULL,
  `PrintName` varchar(20) DEFAULT NULL,
  `Connectwithledger` tinyint(1) DEFAULT NULL,
  `Organisation` varchar(20) DEFAULT NULL,
  `MobileNo` varchar(11) DEFAULT NULL,
  `Email` varchar(20) DEFAULT NULL,
  `TypeofTrade` varchar(20) DEFAULT NULL,
  `Group` varchar(20) DEFAULT NULL,
  `Area` varchar(20) DEFAULT NULL,
  `Department` varchar(20) DEFAULT NULL,
  `SpecifyDateofBirth` tinyint(4) DEFAULT NULL,
  `Specifydateofanniversary` tinyint(4) DEFAULT NULL,
  `Address` varchar(20) DEFAULT NULL,
  `Address1` varchar(20) DEFAULT NULL,
  `Address2` varchar(20) DEFAULT NULL,
  `Address3` varchar(20) DEFAULT NULL,
  `Phoneno` varchar(11) DEFAULT NULL,
  `FaxNo` varchar(11) DEFAULT NULL,
  `CreatedBy` varchar(20) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(20) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`cm_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactmaster`
--

LOCK TABLES `contactmaster` WRITE;
/*!40000 ALTER TABLE `contactmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contra_voucher`
--

DROP TABLE IF EXISTS `contra_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contra_voucher` (
  `Contra_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `CV_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `PDC_Date` datetime DEFAULT NULL,
  `LongNarration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Contra_Id`),
  KEY `CV_Id` (`Contra_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contra_voucher`
--

LOCK TABLES `contra_voucher` WRITE;
/*!40000 ALTER TABLE `contra_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `contra_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contra_voucher_accounts`
--

DROP TABLE IF EXISTS `contra_voucher_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contra_voucher_accounts` (
  `AC_Id` int(10) NOT NULL,
  `Contra_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`Contra_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contra_voucher_accounts`
--

LOCK TABLES `contra_voucher_accounts` WRITE;
/*!40000 ALTER TABLE `contra_voucher_accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `contra_voucher_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `copy of accounts`
--

DROP TABLE IF EXISTS `copy of accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `copy of accounts` (
  `ID` int(10) NOT NULL,
  `AccountId` int(10) DEFAULT NULL,
  `AccountName` varchar(255) DEFAULT NULL,
  `GroupName` varchar(255) DEFAULT NULL,
  `AliasName` varchar(255) DEFAULT NULL,
  `Primary` varchar(255) DEFAULT NULL,
  `UnderGroup` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Account Id` (`AccountId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `copy of accounts`
--

LOCK TABLES `copy of accounts` WRITE;
/*!40000 ALTER TABLE `copy of accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `copy of accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `costcentregroupmaster`
--

DROP TABLE IF EXISTS `costcentregroupmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `costcentregroupmaster` (
  `CCG_ID` int(10) NOT NULL AUTO_INCREMENT,
  `GroupName` varchar(255) DEFAULT NULL,
  `Alias` varchar(255) DEFAULT NULL,
  `PrimaryGroup` tinyint(1) NOT NULL,
  `underGroup` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CCG_ID`),
  KEY `CCG_ID` (`CCG_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `costcentregroupmaster`
--

LOCK TABLES `costcentregroupmaster` WRITE;
/*!40000 ALTER TABLE `costcentregroupmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `costcentregroupmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `costcentremaster`
--

DROP TABLE IF EXISTS `costcentremaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `costcentremaster` (
  `CCM_ID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Alias` varchar(255) DEFAULT NULL,
  `Group` varchar(255) DEFAULT NULL,
  `opBal` int(10) DEFAULT NULL,
  `DrCr` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CCM_ID`),
  KEY `CC_ID` (`CCM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `costcentremaster`
--

LOCK TABLES `costcentremaster` WRITE;
/*!40000 ALTER TABLE `costcentremaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `costcentremaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit_note_details`
--

DROP TABLE IF EXISTS `credit_note_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `credit_note_details` (
  `AC_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Credit_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`Credit_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit_note_details`
--

LOCK TABLES `credit_note_details` WRITE;
/*!40000 ALTER TABLE `credit_note_details` DISABLE KEYS */;
INSERT INTO `credit_note_details` VALUES (2,4,'D','2',150000,0,NULL,'Admin',NULL,'Admin','2017-01-05 12:02:59'),(3,4,'C','2',0,500,NULL,'Admin',NULL,'Admin','2017-01-05 12:02:59'),(4,4,'D','3',1200,0,NULL,'Admin','2017-01-05 12:00:33','Admin','2017-01-05 12:02:59'),(5,4,'C','4',0,1200,NULL,'Admin','2017-01-05 12:00:33','Admin','2017-01-05 12:02:59'),(6,4,'D','1',1100,0,NULL,'Admin','2017-01-05 12:03:19',NULL,NULL);
/*!40000 ALTER TABLE `credit_note_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit_note_master`
--

DROP TABLE IF EXISTS `credit_note_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `credit_note_master` (
  `Credit_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Series` varchar(255) DEFAULT NULL,
  `CN_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `PDC_Date` datetime DEFAULT NULL,
  `LongNarration` varchar(255) DEFAULT NULL,
  `TotalCreditAmt` int(10) DEFAULT NULL,
  `TotalDebitAmt` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Credit_Id`),
  KEY `CV_Id` (`Credit_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit_note_master`
--

LOCK TABLES `credit_note_master` WRITE;
/*!40000 ALTER TABLE `credit_note_master` DISABLE KEYS */;
INSERT INTO `credit_note_master` VALUES (4,'Main','2017-01-05 00:00:00',11,NULL,NULL,NULL,1700,152300,'Admin',NULL,'Admin','2017-01-05 12:02:58');
/*!40000 ALTER TABLE `credit_note_master` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currencyconversion`
--

DROP TABLE IF EXISTS `currencyconversion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `currencyconversion` (
  `CCId` int(11) NOT NULL AUTO_INCREMENT,
  `Date` varchar(235) DEFAULT NULL,
  PRIMARY KEY (`CCId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currencyconversion`
--

LOCK TABLES `currencyconversion` WRITE;
/*!40000 ALTER TABLE `currencyconversion` DISABLE KEYS */;
/*!40000 ALTER TABLE `currencyconversion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currencymaster`
--

DROP TABLE IF EXISTS `currencymaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `currencymaster` (
  `CM_ID` int(10) NOT NULL AUTO_INCREMENT,
  `Symbol` varchar(255) DEFAULT NULL,
  `CString` varchar(255) DEFAULT NULL,
  `SubString` varchar(255) DEFAULT NULL,
  `ConversionMode` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currencymaster`
--

LOCK TABLES `currencymaster` WRITE;
/*!40000 ALTER TABLE `currencymaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `currencymaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `datadirectory`
--

DROP TABLE IF EXISTS `datadirectory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `datadirectory` (
  `ID` int(10) NOT NULL,
  `DD_Munl` tinyint(1) NOT NULL,
  `DD_Path` varchar(255) DEFAULT NULL,
  `Data_PathFile` tinyint(1) NOT NULL,
  `DP_File` varchar(255) DEFAULT NULL,
  `Companies` varchar(255) DEFAULT NULL,
  `DPF` varchar(255) DEFAULT NULL,
  `Password` tinyint(1) NOT NULL,
  `Information` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `datadirectory`
--

LOCK TABLES `datadirectory` WRITE;
/*!40000 ALTER TABLE `datadirectory` DISABLE KEYS */;
/*!40000 ALTER TABLE `datadirectory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `debit_note_details`
--

DROP TABLE IF EXISTS `debit_note_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debit_note_details` (
  `AC_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Debit_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`Debit_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debit_note_details`
--

LOCK TABLES `debit_note_details` WRITE;
/*!40000 ALTER TABLE `debit_note_details` DISABLE KEYS */;
INSERT INTO `debit_note_details` VALUES (17,21,'D','1',500,0,NULL,'Admin',NULL,'Admin','2017-01-05 10:58:03'),(18,21,'C','1',0,500,NULL,'Admin',NULL,'Admin','2017-01-05 10:58:03'),(19,21,'D','2',1000,0,NULL,'Admin','2017-01-04 23:59:50','Admin','2017-01-05 10:58:03'),(20,21,'C','2',0,1000,NULL,'Admin','2017-01-04 23:59:57','Admin','2017-01-05 10:58:03'),(21,21,'D','2',500,0,NULL,'Admin','2017-01-05 10:45:18','Admin','2017-01-05 10:58:03'),(22,21,'C','1',0,500,NULL,'Admin','2017-01-05 10:45:18','Admin','2017-01-05 10:58:03'),(23,21,'D','4',150,0,NULL,'Admin','2017-01-05 10:58:03',NULL,NULL),(24,21,'C','6',0,150,NULL,'Admin','2017-01-05 10:58:03',NULL,NULL);
/*!40000 ALTER TABLE `debit_note_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `debit_note_master`
--

DROP TABLE IF EXISTS `debit_note_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debit_note_master` (
  `Debit_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Series` varchar(255) DEFAULT NULL,
  `DN_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `PDC_Date` datetime DEFAULT NULL,
  `LongNarration` varchar(255) DEFAULT NULL,
  `TotalCreditAmount` decimal(18,5) DEFAULT NULL,
  `TotalDebitAmount` decimal(18,5) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `TotalAmount` int(20) DEFAULT NULL,
  PRIMARY KEY (`Debit_Id`),
  KEY `CV_Id` (`Debit_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debit_note_master`
--

LOCK TABLES `debit_note_master` WRITE;
/*!40000 ALTER TABLE `debit_note_master` DISABLE KEYS */;
INSERT INTO `debit_note_master` VALUES (21,'Main','2017-01-04 00:00:00',1,NULL,NULL,NULL,'2150.00000','2150.00000','Admin',NULL,'Admin','2017-01-05 10:58:02',NULL);
/*!40000 ALTER TABLE `debit_note_master` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `discountstructure`
--

DROP TABLE IF EXISTS `discountstructure`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `discountstructure` (
  `DS_Id` int(10) NOT NULL,
  `StructureName` varchar(255) DEFAULT NULL,
  `SimpleDiscount` tinyint(1) NOT NULL,
  `CD_withSameNature` tinyint(1) NOT NULL,
  `CD_DifferentNature` tinyint(1) NOT NULL,
  `NoOfDiscounts` int(10) DEFAULT NULL,
  `SpecifyCaptionForDiscount` varchar(255) DEFAULT NULL,
  `AbsoluteAmount` tinyint(1) NOT NULL,
  `PerMainQty` tinyint(1) NOT NULL,
  `Percentage` tinyint(1) NOT NULL,
  `PerAltQty` tinyint(1) NOT NULL,
  `ItemPrice` tinyint(1) NOT NULL,
  `ItemMRP` tinyint(1) NOT NULL,
  `ItemAmount` tinyint(1) NOT NULL,
  `ItemListPrice` tinyint(1) NOT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`DS_Id`),
  KEY `id` (`DS_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `discountstructure`
--

LOCK TABLES `discountstructure` WRITE;
/*!40000 ALTER TABLE `discountstructure` DISABLE KEYS */;
/*!40000 ALTER TABLE `discountstructure` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ds_accountposting`
--

DROP TABLE IF EXISTS `ds_accountposting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ds_accountposting` (
  `AccPost_Id` int(10) NOT NULL,
  `DS_Id` int(10) DEFAULT NULL,
  `AccountPosting` tinyint(1) NOT NULL,
  `AccountHeadPost` varchar(255) DEFAULT NULL,
  `AffectsGoods` tinyint(1) NOT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AccPost_Id`),
  KEY `AccPost_Id` (`AccPost_Id`),
  KEY `DS_Id` (`DS_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ds_accountposting`
--

LOCK TABLES `ds_accountposting` WRITE;
/*!40000 ALTER TABLE `ds_accountposting` DISABLE KEYS */;
/*!40000 ALTER TABLE `ds_accountposting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `executivegroup`
--

DROP TABLE IF EXISTS `executivegroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `executivegroup` (
  `Eg_Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) DEFAULT NULL,
  `Alias` varchar(20) DEFAULT NULL,
  `PrintName` varchar(20) DEFAULT NULL,
  `HandlesCallType` varchar(20) DEFAULT NULL,
  `Area` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Address1` varchar(255) DEFAULT NULL,
  `Address2` varchar(255) DEFAULT NULL,
  `Address3` varchar(220) DEFAULT NULL,
  `Telephone` int(11) DEFAULT NULL,
  `MobileNo` int(11) DEFAULT NULL,
  `E-Mail` varchar(200) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Eg_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `executivegroup`
--

LOCK TABLES `executivegroup` WRITE;
/*!40000 ALTER TABLE `executivegroup` DISABLE KEYS */;
/*!40000 ALTER TABLE `executivegroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issued_amount_voucher`
--

DROP TABLE IF EXISTS `issued_amount_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issued_amount_voucher` (
  `SNo` int(10) NOT NULL,
  `Issued_Id` int(10) DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Dated` varchar(255) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `PurchaseBillNo` int(10) DEFAULT NULL,
  `PurchaseDate` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SNo`),
  KEY `Recevied_Id` (`Issued_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issued_amount_voucher`
--

LOCK TABLES `issued_amount_voucher` WRITE;
/*!40000 ALTER TABLE `issued_amount_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `issued_amount_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issued_voucher`
--

DROP TABLE IF EXISTS `issued_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issued_voucher` (
  `Issued_Id` int(10) NOT NULL,
  `Issued_Date` datetime DEFAULT NULL,
  `From` varchar(255) DEFAULT NULL,
  `Rcvd Authourity` varchar(255) DEFAULT NULL,
  `FromNo` int(10) DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Issued_Id`),
  KEY `Recevied_Id` (`Issued_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issued_voucher`
--

LOCK TABLES `issued_voucher` WRITE;
/*!40000 ALTER TABLE `issued_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `issued_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item_master`
--

DROP TABLE IF EXISTS `item_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item_master` (
  `ITM_ID` int(10) NOT NULL AUTO_INCREMENT,
  `ITEM_Name` varchar(255) DEFAULT NULL,
  `ITEM_ALIAS` varchar(255) DEFAULT NULL,
  `ITEM_GROUP` varchar(255) DEFAULT NULL,
  `ITEM_PRINTNAME` varchar(255) DEFAULT NULL,
  `ITEM_UNIT` varchar(255) DEFAULT NULL,
  `ITEM_OPSTOCKQTY` int(10) DEFAULT NULL,
  `ITEM_OPSTOCKVALUE` int(10) DEFAULT NULL,
  `ITEM_SALEPRICE` int(10) DEFAULT NULL,
  `ITEM_PURCHASEPRICE` int(10) DEFAULT NULL,
  `ITEM_MRP` int(10) DEFAULT NULL,
  `ITEM_MINSALEPRICE` int(10) DEFAULT NULL,
  `ITEM_SELFVALUEPRICE` int(10) DEFAULT NULL,
  `ITEM_SALEDISCOUNT` int(10) DEFAULT NULL,
  `ITEM_PURCHASEDISCOUNT` int(10) DEFAULT NULL,
  `ITEM_SALECOMPDISCOUNT` int(10) DEFAULT NULL,
  `ITEM_PURCHCOMPDISCOUNT` int(10) DEFAULT NULL,
  `ITEM_SPECIFYSALEDISCSTRUCT` tinyint(1) NOT NULL,
  `ITEM_SPECIFYPURDISCSTRUCT` tinyint(1) NOT NULL,
  `ITEM_SALEMARKUP` varchar(255) DEFAULT NULL,
  `ITEM_PURMARKUP` varchar(255) DEFAULT NULL,
  `ITEM_SALECOMPMARKUP` varchar(255) DEFAULT NULL,
  `ITEM_PURCOMPMARKUP` varchar(255) DEFAULT NULL,
  `ITEM_SPECIFYSALEMARKUPSTRUCT` tinyint(1) NOT NULL,
  `ITEM_SPECIFYPURMARKUPSTRUCT` tinyint(1) NOT NULL,
  `ITEM_TAXCATEGORY` varchar(255) DEFAULT NULL,
  `ITEM_TAXTYPE` varchar(255) DEFAULT NULL,
  `ITEM_SERVICETAXRATE` int(10) DEFAULT NULL,
  `ITEM_LOCALTAX` int(10) DEFAULT NULL,
  `ITEM_CENTRALTAX` int(10) DEFAULT NULL,
  `ITEM_TAXONMRP` tinyint(1) NOT NULL,
  `ITEM_HSNCODE` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION1` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION2` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION3` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION4` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION5` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION6` varchar(255) DEFAULT NULL,
  `ITEM_SETCRITICALLEVEL` tinyint(1) NOT NULL,
  `ITEM_MAINTAINRG23D` tinyint(1) NOT NULL,
  `ITEM_TARIFHEADING` varchar(255) DEFAULT NULL,
  `ITEM_SERIALWISEDETAILS` tinyint(1) NOT NULL,
  `ITEM_MRPWISEDETAILS` tinyint(1) NOT NULL,
  `ITEM_PARAMETERIZEDDETAILS` tinyint(1) NOT NULL,
  `ITEM_BATCHWISEDETAILS` tinyint(1) NOT NULL,
  `ITEM_EXPDATEREQUIRED` tinyint(1) NOT NULL,
  `ITEM_EXPIRYDAYS` int(10) DEFAULT NULL,
  `ITEM_SALESACCOUNT` varchar(255) DEFAULT NULL,
  `ITEM_PURCACCOUNT` varchar(255) DEFAULT NULL,
  `ITEM_SPECIFYDEFAULTMC` tinyint(1) NOT NULL,
  `ITEM_FREEZEMCFORITEM` tinyint(1) NOT NULL,
  `ITEM_TOTALNUMBEROFAUTHORS` varchar(255) DEFAULT NULL,
  `ITEM_MAINTAINSTOCKBAL` tinyint(1) NOT NULL,
  `ITEM_PICKITEMSIZEFROMDESC` tinyint(1) NOT NULL,
  `ITEM_SPECIFYDEFAULTVENDOR` tinyint(1) NOT NULL,
  `CREATEDBY` varchar(255) DEFAULT NULL,
  `CREATEDDATE` datetime DEFAULT NULL,
  `MODIFIEDBY` varchar(255) DEFAULT NULL,
  `MODIFIEDDATE` datetime DEFAULT NULL,
  PRIMARY KEY (`ITM_ID`),
  KEY `HSNCODE` (`ITEM_HSNCODE`),
  KEY `ID` (`ITM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item_master`
--

LOCK TABLES `item_master` WRITE;
/*!40000 ALTER TABLE `item_master` DISABLE KEYS */;
/*!40000 ALTER TABLE `item_master` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itembarcodes`
--

DROP TABLE IF EXISTS `itembarcodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itembarcodes` (
  `SL_ID` int(100) NOT NULL AUTO_INCREMENT,
  `ITM_ID` int(100) DEFAULT NULL,
  `ITEM_BARCODE` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itembarcodes`
--

LOCK TABLES `itembarcodes` WRITE;
/*!40000 ALTER TABLE `itembarcodes` DISABLE KEYS */;
/*!40000 ALTER TABLE `itembarcodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itembatchwisedetails`
--

DROP TABLE IF EXISTS `itembatchwisedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itembatchwisedetails` (
  `SL_NO` int(100) NOT NULL AUTO_INCREMENT,
  `ITM_ID` int(100) DEFAULT NULL,
  `ITEM_BATCHNO` int(100) DEFAULT NULL,
  `ITEM_QTY` float DEFAULT NULL,
  `ITEM_MFGDATE` datetime DEFAULT NULL,
  `ITEM_EXPDATE` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SL_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itembatchwisedetails`
--

LOCK TABLES `itembatchwisedetails` WRITE;
/*!40000 ALTER TABLE `itembatchwisedetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itembatchwisedetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemdefinecriticallevel`
--

DROP TABLE IF EXISTS `itemdefinecriticallevel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemdefinecriticallevel` (
  `DC_ID` int(100) NOT NULL AUTO_INCREMENT,
  `ITM_ID` int(100) DEFAULT NULL,
  `ITEM_MINIMUMLVLQTY` float DEFAULT NULL,
  `ITEM_RECORDLVLQTY` float DEFAULT NULL,
  `ITEM_MAXIMUMLVLQTY` float DEFAULT NULL,
  `ITEM_MINIMUMLVLDAYS` float DEFAULT NULL,
  `ITEM_RECORDLVLDAYS` float DEFAULT NULL,
  `ITEM_MAXIMUMLVLDAYS` float DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`DC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemdefinecriticallevel`
--

LOCK TABLES `itemdefinecriticallevel` WRITE;
/*!40000 ALTER TABLE `itemdefinecriticallevel` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemdefinecriticallevel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemgroupmaster`
--

DROP TABLE IF EXISTS `itemgroupmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemgroupmaster` (
  `IGM_Id` int(10) NOT NULL AUTO_INCREMENT,
  `ItemGroup` varchar(255) DEFAULT NULL,
  `Alias` varchar(255) DEFAULT NULL,
  `PrimaryGroup` tinyint(1) NOT NULL,
  `UnderGroup` varchar(255) DEFAULT NULL,
  `StockAccount` varchar(255) DEFAULT NULL,
  `SalesAccount` varchar(255) DEFAULT NULL,
  `PurchaseAccount` varchar(255) DEFAULT NULL,
  `DefaultConfig` tinyint(1) DEFAULT NULL,
  `SeparateConfig` int(1) DEFAULT NULL,
  `Parameters` int(20) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`IGM_Id`),
  UNIQUE KEY `id` (`IGM_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemgroupmaster`
--

LOCK TABLES `itemgroupmaster` WRITE;
/*!40000 ALTER TABLE `itemgroupmaster` DISABLE KEYS */;
INSERT INTO `itemgroupmaster` VALUES (7,'narayana','narayana',1,NULL,NULL,NULL,NULL,0,1,0,'Admin',NULL,NULL,NULL);
/*!40000 ALTER TABLE `itemgroupmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemmaster`
--

DROP TABLE IF EXISTS `itemmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemmaster` (
  `ITM_ID` int(100) NOT NULL AUTO_INCREMENT,
  `ITEM_Name` varchar(255) DEFAULT NULL,
  `ITEM_PRINTName` varchar(255) DEFAULT NULL,
  `ITEM_ALIAS` varchar(255) DEFAULT NULL,
  `ITEM_GROUP` varchar(255) DEFAULT NULL,
  `ITEM_COMPANY` varchar(255) DEFAULT NULL,
  `ITEM_MAINUNIT` varchar(255) DEFAULT NULL,
  `ITEM_ALTUNIT` varchar(255) DEFAULT NULL,
  `ITEM_CONALTUNIT` float DEFAULT NULL,
  `ITEM_OPSTOCK` float DEFAULT NULL,
  `ITEM_UNIT` varchar(255) DEFAULT NULL,
  `ITEM_RATE` float DEFAULT NULL,
  `ITEM_PER` varchar(255) DEFAULT NULL,
  `ITEM_VALUE` float DEFAULT NULL,
  `ITEM_SALEPRICETOAPPLY` varchar(255) DEFAULT NULL,
  `ITEM_PURCPRICETOAPPLY` varchar(255) DEFAULT NULL,
  `ITEM_SALEPRICEMAIN` float DEFAULT NULL,
  `ITEM_SALESPRICEALT` float DEFAULT NULL,
  `ITEM_PURCHASEPRICEMAIN` float DEFAULT NULL,
  `ITEM_PURCPRICEALT` float DEFAULT NULL,
  `ITEM_MRPMAIN` float DEFAULT NULL,
  `ITEM_MRPALT` float DEFAULT NULL,
  `ITEM_MINSALEPRICEMAIN` float DEFAULT NULL,
  `ITEM_MINSALEPRICEALT` float DEFAULT NULL,
  `ITEM_SELFVALUEPRICE` float DEFAULT NULL,
  `ITEM_SALEDISCOUNT` float DEFAULT NULL,
  `ITEM_PURCHASEDISCOUNT` float DEFAULT NULL,
  `ITEM_SALECOMPDISCOUNT` float DEFAULT NULL,
  `ITEM_PURCHCOMPDISCOUNT` float DEFAULT NULL,
  `ITEM_SPECIFYSALEDISCSTRUCT` tinyint(1) DEFAULT NULL,
  `ITEM_SPECIFYPURDISCSTRUCT` tinyint(1) DEFAULT NULL,
  `ITEM_STOCKVALMETHOD` varchar(255) DEFAULT NULL,
  `ITEM_SALEMARKUP` varchar(20) DEFAULT NULL,
  `ITEM_TAXCATEGORY` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION1` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION2` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION3` varchar(255) DEFAULT NULL,
  `ITEM_DESCRIPTION4` varchar(225) DEFAULT NULL,
  `ITEM_SETCRITICALLEVEL` tinyint(1) DEFAULT NULL,
  `ITEM_MAINTAINRG23D` tinyint(1) DEFAULT NULL,
  `ITEM_TARIFHEADING` varchar(255) DEFAULT NULL,
  `ITEM_SERIALWISEDETAILS` tinyint(1) DEFAULT NULL,
  `ITEM_PARAMETERIZEDDETAILS` tinyint(1) DEFAULT NULL,
  `ITEM_MRPWISEDETAILS` tinyint(1) DEFAULT NULL,
  `ITEM_BATCHWISEDETAILS` tinyint(1) DEFAULT NULL,
  `ITEM_EXPDATEREQUIRED` tinyint(1) DEFAULT NULL,
  `ITEM_EXPIRYDAYS` int(100) DEFAULT NULL,
  `ITEM_SALESACCOUNT` varchar(255) DEFAULT NULL,
  `ITEM_PURCACCOUNT` varchar(255) DEFAULT NULL,
  `ITEM_MAINTAINSTOCKBAL` tinyint(1) DEFAULT NULL,
  `ITEM_SPECIFYDEFAULTMC` tinyint(1) DEFAULT NULL,
  `ITEM_FREEZEMCFORITEM` tinyint(1) DEFAULT NULL,
  `ITEM_TOTALNUMBEROFAUTHORS` int(100) DEFAULT NULL,
  `ITEM_PICKITEMSIZEFROMDESC` tinyint(1) DEFAULT NULL,
  `ITEM_SPECIFYDEFAULTVENDOR` tinyint(1) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `ITEM_CONMAINUNIT` float DEFAULT NULL,
  `ITEM_PURMARKUP` varchar(20) DEFAULT NULL,
  `ITEM_SALECOMPMARKUP` varchar(20) DEFAULT NULL,
  `ITEM_PURCCOMPMARKUP` varchar(20) DEFAULT NULL,
  `ITEM_SPECIFYSALEMARKUPSTRUCT` tinyint(1) DEFAULT NULL,
  `ITEM_SPECIFYPURCMARKUPSTRUCT` tinyint(1) DEFAULT NULL,
  `ITEM_DISCOUNTINFO` tinyint(1) DEFAULT NULL,
  `ITEM_MARKUPINFO` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ITM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemmaster`
--

LOCK TABLES `itemmaster` WRITE;
/*!40000 ALTER TABLE `itemmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemmrpwisedetails`
--

DROP TABLE IF EXISTS `itemmrpwisedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemmrpwisedetails` (
  `SL_ID` int(100) NOT NULL AUTO_INCREMENT,
  `ITM_ID` int(100) DEFAULT NULL,
  `ITEM_MRP` float DEFAULT NULL,
  `ITEM_SALESPRICE` float DEFAULT NULL,
  `ITEM_QUANTITY` float DEFAULT NULL,
  `ITEM_AMOUNT` float DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemmrpwisedetails`
--

LOCK TABLES `itemmrpwisedetails` WRITE;
/*!40000 ALTER TABLE `itemmrpwisedetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemmrpwisedetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemparameterizeddetails`
--

DROP TABLE IF EXISTS `itemparameterizeddetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemparameterizeddetails` (
  `SL_NO` int(100) NOT NULL AUTO_INCREMENT,
  `ITM_ID` int(100) DEFAULT NULL,
  `ITEM_NAME` varchar(255) DEFAULT NULL,
  `ITEM_QTY` float DEFAULT NULL,
  `CreatedBy` varchar(20) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SL_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemparameterizeddetails`
--

LOCK TABLES `itemparameterizeddetails` WRITE;
/*!40000 ALTER TABLE `itemparameterizeddetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemparameterizeddetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemserialnodetails`
--

DROP TABLE IF EXISTS `itemserialnodetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemserialnodetails` (
  `SL_NO` int(100) NOT NULL AUTO_INCREMENT,
  `ITM_ID` int(100) DEFAULT NULL,
  `ITEM_MANUALNO` tinyint(1) DEFAULT NULL,
  `ITEM_AUTONO` tinyint(1) DEFAULT NULL,
  `ITEM_STARTINGAUTONO` int(100) DEFAULT NULL,
  `ITEM_NUMBERINGFREQ` varchar(255) DEFAULT NULL,
  `ITEM_STRUCTUENAME` varchar(255) DEFAULT NULL,
  `ITEM_REGENARATEAUTONO` int(100) DEFAULT NULL,
  `ITEM_SALESWARRANTY` tinyint(1) DEFAULT NULL,
  `ITEM_PURCHASEWARRANTY` tinyint(1) DEFAULT NULL,
  `ITEM_INSTALLWARRANTY` tinyint(1) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`SL_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemserialnodetails`
--

LOCK TABLES `itemserialnodetails` WRITE;
/*!40000 ALTER TABLE `itemserialnodetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemserialnodetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `journal_voucher`
--

DROP TABLE IF EXISTS `journal_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `journal_voucher` (
  `JV_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `JV_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `PDC_Date` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`JV_Id`),
  KEY `CV_Id` (`JV_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `journal_voucher`
--

LOCK TABLES `journal_voucher` WRITE;
/*!40000 ALTER TABLE `journal_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `journal_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `journal_voucher_accounts`
--

DROP TABLE IF EXISTS `journal_voucher_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `journal_voucher_accounts` (
  `AC_Id` int(10) NOT NULL,
  `JV_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`JV_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `journal_voucher_accounts`
--

LOCK TABLES `journal_voucher_accounts` WRITE;
/*!40000 ALTER TABLE `journal_voucher_accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `journal_voucher_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `masterseriesgroup`
--

DROP TABLE IF EXISTS `masterseriesgroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `masterseriesgroup` (
  `masid` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`masid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `masterseriesgroup`
--

LOCK TABLES `masterseriesgroup` WRITE;
/*!40000 ALTER TABLE `masterseriesgroup` DISABLE KEYS */;
/*!40000 ALTER TABLE `masterseriesgroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materialcentregroupmaster`
--

DROP TABLE IF EXISTS `materialcentregroupmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materialcentregroupmaster` (
  `MCG_ID` int(10) NOT NULL AUTO_INCREMENT,
  `Group` varchar(255) DEFAULT NULL,
  `Alias` varchar(255) DEFAULT NULL,
  `PrimaryGroup` tinyint(1) NOT NULL,
  `UnderGroup` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MCG_ID`),
  KEY `id` (`MCG_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materialcentregroupmaster`
--

LOCK TABLES `materialcentregroupmaster` WRITE;
/*!40000 ALTER TABLE `materialcentregroupmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `materialcentregroupmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materialcentremaster`
--

DROP TABLE IF EXISTS `materialcentremaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materialcentremaster` (
  `MC_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Alias` varchar(255) DEFAULT NULL,
  `PrintName` varchar(255) DEFAULT NULL,
  `Group` varchar(255) DEFAULT NULL,
  `StockAccount` varchar(255) DEFAULT NULL,
  `EnableStockinBal` tinyint(1) DEFAULT NULL,
  `SalesAccount` varchar(255) DEFAULT NULL,
  `PurchaseAccount` varchar(255) DEFAULT NULL,
  `EnableAccinTransfer` tinyint(1) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Address1` varchar(255) DEFAULT NULL,
  `Street` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `State` varchar(255) DEFAULT NULL,
  `Country` varchar(255) DEFAULT NULL,
  `PinCode` varchar(255) DEFAULT NULL,
  `Mobile` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `Address2` varchar(255) DEFAULT NULL,
  `Address3` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`MC_Id`),
  KEY `PinCode` (`PinCode`),
  KEY `Id` (`MC_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materialcentremaster`
--

LOCK TABLES `materialcentremaster` WRITE;
/*!40000 ALTER TABLE `materialcentremaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `materialcentremaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_voucher`
--

DROP TABLE IF EXISTS `payment_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_voucher` (
  `Payment_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `Pay_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `PDC_Date` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Payment_Id`),
  KEY `CV_Id` (`Payment_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_voucher`
--

LOCK TABLES `payment_voucher` WRITE;
/*!40000 ALTER TABLE `payment_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_voucher_accounts`
--

DROP TABLE IF EXISTS `payment_voucher_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_voucher_accounts` (
  `AC_Id` int(10) NOT NULL,
  `Payment_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`Payment_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_voucher_accounts`
--

LOCK TABLES `payment_voucher_accounts` WRITE;
/*!40000 ALTER TABLE `payment_voucher_accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment_voucher_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physical_stock_items`
--

DROP TABLE IF EXISTS `physical_stock_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physical_stock_items` (
  `Item_Id` int(10) NOT NULL,
  `Physical_Id` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Physical Stock` int(10) DEFAULT NULL,
  `Book Stock` int(10) DEFAULT NULL,
  `Difference` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Item_Id`),
  KEY `Item_Id` (`Item_Id`),
  KEY `Physical_Id` (`Physical_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physical_stock_items`
--

LOCK TABLES `physical_stock_items` WRITE;
/*!40000 ALTER TABLE `physical_stock_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `physical_stock_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physical_stock_voucher`
--

DROP TABLE IF EXISTS `physical_stock_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physical_stock_voucher` (
  `Physical_Id` int(10) NOT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Physical_Date` datetime DEFAULT NULL,
  `MatCenter` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `Journal Series` int(10) DEFAULT NULL,
  `Journal Voucher` tinyint(1) NOT NULL,
  `Input Sub` tinyint(1) NOT NULL,
  `Scann Barcode` tinyint(1) NOT NULL,
  `Update Journal Narration` tinyint(1) NOT NULL,
  `Items` tinyint(1) NOT NULL,
  `BCN` tinyint(1) NOT NULL,
  `SerialNo` tinyint(1) NOT NULL,
  `Batch` tinyint(1) NOT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Physical_Id`),
  KEY `Stock_Id` (`Physical_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physical_stock_voucher`
--

LOCK TABLES `physical_stock_voucher` WRITE;
/*!40000 ALTER TABLE `physical_stock_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `physical_stock_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recevied_amount_voucher`
--

DROP TABLE IF EXISTS `recevied_amount_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recevied_amount_voucher` (
  `SNo` int(10) NOT NULL,
  `Recevied_Id` int(10) DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Dated` varchar(255) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SNo`),
  KEY `Recevied_Id` (`Recevied_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recevied_amount_voucher`
--

LOCK TABLES `recevied_amount_voucher` WRITE;
/*!40000 ALTER TABLE `recevied_amount_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `recevied_amount_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recevied_voucher`
--

DROP TABLE IF EXISTS `recevied_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recevied_voucher` (
  `Recevied_Id` int(10) NOT NULL,
  `Recevied_Date` datetime DEFAULT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `Issuing Office` varchar(255) DEFAULT NULL,
  `FromNo` int(10) DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `DateOfIssue` datetime DEFAULT NULL,
  `StateOfIssue` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Recevied_Id`),
  KEY `Recevied_Id` (`Recevied_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recevied_voucher`
--

LOCK TABLES `recevied_voucher` WRITE;
/*!40000 ALTER TABLE `recevied_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `recevied_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reciept_voucher`
--

DROP TABLE IF EXISTS `reciept_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reciept_voucher` (
  `Reciept_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `Reciept_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `PDC_Date` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Reciept_Id`),
  KEY `CV_Id` (`Reciept_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reciept_voucher`
--

LOCK TABLES `reciept_voucher` WRITE;
/*!40000 ALTER TABLE `reciept_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `reciept_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reciept_voucher_accounts`
--

DROP TABLE IF EXISTS `reciept_voucher_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reciept_voucher_accounts` (
  `AC_Id` int(10) NOT NULL,
  `Reciept_Id` int(10) DEFAULT NULL,
  `DC` varchar(255) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `Debit` int(10) DEFAULT NULL,
  `Credit` int(10) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AC_Id`),
  KEY `Contra_Id` (`Reciept_Id`),
  KEY `AC_Id` (`AC_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reciept_voucher_accounts`
--

LOCK TABLES `reciept_voucher_accounts` WRITE;
/*!40000 ALTER TABLE `reciept_voucher_accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `reciept_voucher_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salesmanmaster`
--

DROP TABLE IF EXISTS `salesmanmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salesmanmaster` (
  `SalesMan_Id` int(10) NOT NULL,
  `SM_Name` varchar(255) DEFAULT NULL,
  `SM_Alias` varchar(255) DEFAULT NULL,
  `SM_PrintName` varchar(255) DEFAULT NULL,
  `EnableDefCommision` tinyint(1) NOT NULL,
  `Commision_Mode` varchar(255) DEFAULT NULL,
  `DefCommision` int(10) DEFAULT NULL,
  `FreezeCommision` tinyint(1) NOT NULL,
  `Sales_DebitMode` varchar(255) DEFAULT NULL,
  `Sales_AccDebited` varchar(255) DEFAULT NULL,
  `Sales_ACCredited` varchar(255) DEFAULT NULL,
  `Purchase_DebitMode` varchar(255) DEFAULT NULL,
  `Purchase_AccDebited` varchar(255) DEFAULT NULL,
  `Purchase_AccCredited` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Street` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `State` varchar(255) DEFAULT NULL,
  `PinCode` varchar(255) DEFAULT NULL,
  `Country` varchar(255) DEFAULT NULL,
  `Mobile` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SalesMan_Id`),
  KEY `SalesMan_Id` (`SalesMan_Id`),
  KEY `PinCode` (`PinCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salesmanmaster`
--

LOCK TABLES `salesmanmaster` WRITE;
/*!40000 ALTER TABLE `salesmanmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `salesmanmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saletype`
--

DROP TABLE IF EXISTS `saletype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `saletype` (
  `SalesType` varchar(255) DEFAULT NULL,
  `typeSpecifyHereSingleAccount` varchar(255) DEFAULT NULL,
  `typeDifferentTaxRate` tinyint(1) DEFAULT NULL,
  `typeSpecifyINVoucher` tinyint(1) DEFAULT NULL,
  `typeTaxable` tinyint(1) DEFAULT NULL,
  `tyypeMultiTax` tinyint(1) DEFAULT NULL,
  `typeAgainstSTFrom` tinyint(1) DEFAULT NULL,
  `typeTaxpaid` tinyint(1) DEFAULT NULL,
  `typeExempt` tinyint(1) DEFAULT NULL,
  `typeTaxFree` tinyint(1) DEFAULT NULL,
  `typeLUMSumDealer` tinyint(1) DEFAULT NULL,
  `typeUnRegDealer` tinyint(1) DEFAULT NULL,
  `TaxInvoice` tinyint(1) DEFAULT NULL,
  `VatReturnCategory` varchar(255) DEFAULT NULL,
  `VatSaleTaxReport` tinyint(1) DEFAULT NULL,
  `CalculateTaxonItemMRP` tinyint(1) DEFAULT NULL,
  `TaxInclusiveItemPrice` tinyint(1) DEFAULT NULL,
  `CalculateTaxonpercentofAmount` int(10) DEFAULT NULL,
  `AdjustTaxinSaleAccount` tinyint(1) DEFAULT NULL,
  `TaxAccount` varchar(255) DEFAULT NULL,
  `TypeLocal` tinyint(1) DEFAULT NULL,
  `TypeCentral` tinyint(1) DEFAULT NULL,
  `TypeStockTransfer` tinyint(1) DEFAULT NULL,
  `TypeOther` tinyint(1) DEFAULT NULL,
  `ExportNormal` tinyint(1) DEFAULT NULL,
  `SaleinTransit` tinyint(1) DEFAULT NULL,
  `ExportHighsea` tinyint(1) DEFAULT NULL,
  `IssueSTFrom` tinyint(1) DEFAULT NULL,
  `FromIssuable` varchar(255) DEFAULT NULL,
  `ReceiveSTForm` tinyint(1) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saletype`
--

LOCK TABLES `saletype` WRITE;
/*!40000 ALTER TABLE `saletype` DISABLE KEYS */;
/*!40000 ALTER TABLE `saletype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statemaster`
--

DROP TABLE IF EXISTS `statemaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `statemaster` (
  `ID` int(10) NOT NULL,
  `State_ID` varchar(255) NOT NULL,
  `State_Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`State_ID`),
  KEY `StateID` (`State_ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statemaster`
--

LOCK TABLES `statemaster` WRITE;
/*!40000 ALTER TABLE `statemaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `statemaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stdnarrationmaster`
--

DROP TABLE IF EXISTS `stdnarrationmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stdnarrationmaster` (
  `SN_Id` int(10) NOT NULL,
  `Vouchertype` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SN_Id`),
  KEY `Id` (`SN_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stdnarrationmaster`
--

LOCK TABLES `stdnarrationmaster` WRITE;
/*!40000 ALTER TABLE `stdnarrationmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `stdnarrationmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stformmaster`
--

DROP TABLE IF EXISTS `stformmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stformmaster` (
  `STF_Id` int(10) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `PrintName` varchar(255) DEFAULT NULL,
  `STRegType` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`STF_Id`),
  KEY `Id` (`STF_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stformmaster`
--

LOCK TABLES `stformmaster` WRITE;
/*!40000 ALTER TABLE `stformmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `stformmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_transfer_bs`
--

DROP TABLE IF EXISTS `stock_transfer_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_transfer_bs` (
  `BSId` int(10) NOT NULL,
  `Stock_Id` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransPVId` (`Stock_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_transfer_bs`
--

LOCK TABLES `stock_transfer_bs` WRITE;
/*!40000 ALTER TABLE `stock_transfer_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock_transfer_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_transfer_items`
--

DROP TABLE IF EXISTS `stock_transfer_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_transfer_items` (
  `ItemId` int(10) NOT NULL,
  `Stock_Id` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransPVId` (`Stock_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_transfer_items`
--

LOCK TABLES `stock_transfer_items` WRITE;
/*!40000 ALTER TABLE `stock_transfer_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock_transfer_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_transfer_voucher`
--

DROP TABLE IF EXISTS `stock_transfer_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock_transfer_voucher` (
  `Stock_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `ST_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `FromDate` datetime DEFAULT NULL,
  `ToDate` datetime DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `TotalBSAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Stock_Id`),
  KEY `Pro_Id` (`Stock_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_transfer_voucher`
--

LOCK TABLES `stock_transfer_voucher` WRITE;
/*!40000 ALTER TABLE `stock_transfer_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock_transfer_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `taxcategory`
--

DROP TABLE IF EXISTS `taxcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `taxcategory` (
  `TaxCat_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `TaxCat_Type` varchar(255) DEFAULT NULL,
  `Service_Tax` int(100) DEFAULT NULL,
  `Local_Tax` decimal(18,0) DEFAULT NULL,
  `Central_Tax` decimal(18,0) DEFAULT NULL,
  `TaxonMRP` tinyint(1) DEFAULT NULL,
  `CalculatedTaxon` decimal(18,0) DEFAULT NULL,
  `TaxonMRPMode` varchar(255) DEFAULT NULL,
  `Taxation_Type` varchar(255) DEFAULT NULL,
  `HSNCode` varchar(255) DEFAULT NULL,
  `Tax_Desc` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `STReg.Type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`TaxCat_Id`),
  KEY `HSNCode` (`HSNCode`),
  KEY `id` (`TaxCat_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taxcategory`
--

LOCK TABLES `taxcategory` WRITE;
/*!40000 ALTER TABLE `taxcategory` DISABLE KEYS */;
INSERT INTO `taxcategory` VALUES (1,'tax5%','Goods',0,'55','20',1,'50','Inclusive','Exempt','56789','zakir testing on tax category',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `taxcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `taxrate`
--

DROP TABLE IF EXISTS `taxrate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `taxrate` (
  `TaxRate_Id` int(100) NOT NULL AUTO_INCREMENT,
  `TaxCat_Id` int(100) DEFAULT NULL,
  `wef` datetime DEFAULT NULL,
  `Tax_Local` int(100) DEFAULT NULL,
  `Tax_Schg` int(100) DEFAULT NULL,
  `Tax_Type` varchar(255) DEFAULT NULL,
  `Tax_Central` int(100) DEFAULT NULL,
  `Schg_Central` int(100) DEFAULT NULL,
  `Entry_Tax` int(100) DEFAULT NULL,
  `Service_Tax` int(100) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`TaxRate_Id`),
  KEY `TaxCat_Id` (`TaxCat_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taxrate`
--

LOCK TABLES `taxrate` WRITE;
/*!40000 ALTER TABLE `taxrate` DISABLE KEYS */;
INSERT INTO `taxrate` VALUES (1,1,'2017-01-11 00:00:00',3,4,'5',6,7,8,9,NULL,NULL,NULL,NULL),(2,1,'2017-01-09 00:00:00',7,3,'6',88,55,4,44,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `taxrate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbdscategory`
--

DROP TABLE IF EXISTS `tbdscategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbdscategory` (
  `Tds_Id` varchar(20) DEFAULT NULL,
  `TdsCategoryName` varchar(20) DEFAULT NULL,
  `SelectCode` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbdscategory`
--

LOCK TABLES `tbdscategory` WRITE;
/*!40000 ALTER TABLE `tbdscategory` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbdscategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tdsmodel`
--

DROP TABLE IF EXISTS `tdsmodel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tdsmodel` (
  `td_id` int(11) NOT NULL AUTO_INCREMENT,
  `TdsCategoryName` varchar(20) DEFAULT NULL,
  `SelectCode` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`td_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tdsmodel`
--

LOCK TABLES `tdsmodel` WRITE;
/*!40000 ALTER TABLE `tdsmodel` DISABLE KEYS */;
/*!40000 ALTER TABLE `tdsmodel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_matissued`
--

DROP TABLE IF EXISTS `trans_matissued`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_matissued` (
  `MatIssued_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `Issued_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCentre` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MatIssued_Id`),
  KEY `SR_Id` (`MatIssued_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_matissued`
--

LOCK TABLES `trans_matissued` WRITE;
/*!40000 ALTER TABLE `trans_matissued` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_matissued` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_matissued_bs`
--

DROP TABLE IF EXISTS `trans_matissued_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_matissued_bs` (
  `BSId` int(10) NOT NULL,
  `MatIssued_Id` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransSalesId` (`MatIssued_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_matissued_bs`
--

LOCK TABLES `trans_matissued_bs` WRITE;
/*!40000 ALTER TABLE `trans_matissued_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_matissued_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_matissued_items`
--

DROP TABLE IF EXISTS `trans_matissued_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_matissued_items` (
  `ItemId` int(10) NOT NULL,
  `MatIssued_Id` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransSalesId` (`MatIssued_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_matissued_items`
--

LOCK TABLES `trans_matissued_items` WRITE;
/*!40000 ALTER TABLE `trans_matissued_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_matissued_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_matrcvd_bs`
--

DROP TABLE IF EXISTS `trans_matrcvd_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_matrcvd_bs` (
  `BSId` int(10) NOT NULL,
  `MatRcvd_Id` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransSalesId` (`MatRcvd_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_matrcvd_bs`
--

LOCK TABLES `trans_matrcvd_bs` WRITE;
/*!40000 ALTER TABLE `trans_matrcvd_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_matrcvd_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_matrcvd_items`
--

DROP TABLE IF EXISTS `trans_matrcvd_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_matrcvd_items` (
  `ItemId` int(10) NOT NULL,
  `MatRcvd_Id` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransSalesId` (`MatRcvd_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_matrcvd_items`
--

LOCK TABLES `trans_matrcvd_items` WRITE;
/*!40000 ALTER TABLE `trans_matrcvd_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_matrcvd_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_matrcvd_voucher`
--

DROP TABLE IF EXISTS `trans_matrcvd_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_matrcvd_voucher` (
  `MatRcvd_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `Rcvd_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `Type` varchar(255) DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCentre` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MatRcvd_Id`),
  KEY `SR_Id` (`MatRcvd_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_matrcvd_voucher`
--

LOCK TABLES `trans_matrcvd_voucher` WRITE;
/*!40000 ALTER TABLE `trans_matrcvd_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_matrcvd_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_pr_bs`
--

DROP TABLE IF EXISTS `trans_pr_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_pr_bs` (
  `BSId` int(10) NOT NULL,
  `TransPRId` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransPRId` (`TransPRId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_pr_bs`
--

LOCK TABLES `trans_pr_bs` WRITE;
/*!40000 ALTER TABLE `trans_pr_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_pr_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_pr_items`
--

DROP TABLE IF EXISTS `trans_pr_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_pr_items` (
  `ItemID` int(10) NOT NULL,
  `TransPRId` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemID`),
  KEY `TransPRId` (`TransPRId`),
  KEY `TransSRId` (`Item`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_pr_items`
--

LOCK TABLES `trans_pr_items` WRITE;
/*!40000 ALTER TABLE `trans_pr_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_pr_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_production_bs`
--

DROP TABLE IF EXISTS `trans_production_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_production_bs` (
  `BSId` int(10) NOT NULL,
  `Production_Id` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransPVId` (`Production_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_production_bs`
--

LOCK TABLES `trans_production_bs` WRITE;
/*!40000 ALTER TABLE `trans_production_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_production_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_production_items`
--

DROP TABLE IF EXISTS `trans_production_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_production_items` (
  `ItemId` int(10) NOT NULL,
  `Production_Id` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransPVId` (`Production_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_production_items`
--

LOCK TABLES `trans_production_items` WRITE;
/*!40000 ALTER TABLE `trans_production_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_production_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_production_voucher`
--

DROP TABLE IF EXISTS `trans_production_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_production_voucher` (
  `Production_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `Production_Type` varchar(255) DEFAULT NULL,
  `Production_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `BillNo` int(10) DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCenter` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Production_Id`),
  KEY `Pro_Id` (`Production_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_production_voucher`
--

LOCK TABLES `trans_production_voucher` WRITE;
/*!40000 ALTER TABLE `trans_production_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_production_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_purchase_voucher`
--

DROP TABLE IF EXISTS `trans_purchase_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_purchase_voucher` (
  `TransPVId` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `PV_Type` varchar(255) DEFAULT NULL,
  `PV_Date` datetime DEFAULT NULL,
  `VoucherNo` varchar(255) DEFAULT NULL,
  `BillNo` varchar(255) DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCenter` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`TransPVId`),
  KEY `PV_Id` (`TransPVId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_purchase_voucher`
--

LOCK TABLES `trans_purchase_voucher` WRITE;
/*!40000 ALTER TABLE `trans_purchase_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_purchase_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_purchasereturn`
--

DROP TABLE IF EXISTS `trans_purchasereturn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_purchasereturn` (
  `TransPRId` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `PurchaseType` varchar(255) DEFAULT NULL,
  `PR_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `BillNo` int(10) DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCenter` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`TransPRId`),
  KEY `PR_Id` (`TransPRId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_purchasereturn`
--

LOCK TABLES `trans_purchasereturn` WRITE;
/*!40000 ALTER TABLE `trans_purchasereturn` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_purchasereturn` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_pv_bs`
--

DROP TABLE IF EXISTS `trans_pv_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_pv_bs` (
  `BSId` int(10) NOT NULL,
  `TransPVId` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransSalesId` (`TransPVId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_pv_bs`
--

LOCK TABLES `trans_pv_bs` WRITE;
/*!40000 ALTER TABLE `trans_pv_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_pv_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_pv_items`
--

DROP TABLE IF EXISTS `trans_pv_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_pv_items` (
  `ItemId` int(10) NOT NULL,
  `TransPVId` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransSalesId` (`TransPVId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_pv_items`
--

LOCK TABLES `trans_pv_items` WRITE;
/*!40000 ALTER TABLE `trans_pv_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_pv_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_sales`
--

DROP TABLE IF EXISTS `trans_sales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_sales` (
  `Trans_Sales_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Series` varchar(255) DEFAULT NULL,
  `SaleDate` datetime DEFAULT NULL,
  `VoucherNumber` int(10) DEFAULT NULL,
  `BillNumber` int(10) DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `SalesType` varchar(255) DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCentre` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` decimal(18,0) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Trans_Sales_Id`),
  KEY `TransSalesId` (`Trans_Sales_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_sales`
--

LOCK TABLES `trans_sales` WRITE;
/*!40000 ALTER TABLE `trans_sales` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_sales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_sales_bs`
--

DROP TABLE IF EXISTS `trans_sales_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_sales_bs` (
  `BSId` int(10) NOT NULL AUTO_INCREMENT,
  `Trans_Sales_Id` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransSalesId` (`Trans_Sales_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_sales_bs`
--

LOCK TABLES `trans_sales_bs` WRITE;
/*!40000 ALTER TABLE `trans_sales_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_sales_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_sales_item`
--

DROP TABLE IF EXISTS `trans_sales_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_sales_item` (
  `ItemId` int(10) NOT NULL,
  `Trans_Sales_Id` int(10) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransSalesId` (`Trans_Sales_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_sales_item`
--

LOCK TABLES `trans_sales_item` WRITE;
/*!40000 ALTER TABLE `trans_sales_item` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_sales_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_salesreturn`
--

DROP TABLE IF EXISTS `trans_salesreturn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_salesreturn` (
  `TransSRId` int(10) NOT NULL,
  `SalesType` varchar(255) DEFAULT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `SR_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `BillNo` varchar(255) DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `Party` varchar(255) DEFAULT NULL,
  `MatCentre` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`TransSRId`),
  KEY `SR_Id` (`TransSRId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_salesreturn`
--

LOCK TABLES `trans_salesreturn` WRITE;
/*!40000 ALTER TABLE `trans_salesreturn` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_salesreturn` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_salesreturn_bs`
--

DROP TABLE IF EXISTS `trans_salesreturn_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_salesreturn_bs` (
  `BSId` int(10) NOT NULL,
  `TransSRId` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransSalesId` (`TransSRId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_salesreturn_bs`
--

LOCK TABLES `trans_salesreturn_bs` WRITE;
/*!40000 ALTER TABLE `trans_salesreturn_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_salesreturn_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_salesreturn_item`
--

DROP TABLE IF EXISTS `trans_salesreturn_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_salesreturn_item` (
  `ItemId` int(10) NOT NULL,
  `TransSRId` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransSalesId` (`TransSRId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_salesreturn_item`
--

LOCK TABLES `trans_salesreturn_item` WRITE;
/*!40000 ALTER TABLE `trans_salesreturn_item` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_salesreturn_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_unassemble_bs`
--

DROP TABLE IF EXISTS `trans_unassemble_bs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_unassemble_bs` (
  `BSId` int(10) NOT NULL,
  `Unassemble_Id` int(10) DEFAULT NULL,
  `BillSundry` varchar(255) DEFAULT NULL,
  `Percentage` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BSId`),
  KEY `BSId` (`BSId`),
  KEY `TransSalesId` (`Unassemble_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_unassemble_bs`
--

LOCK TABLES `trans_unassemble_bs` WRITE;
/*!40000 ALTER TABLE `trans_unassemble_bs` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_unassemble_bs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_unassemble_items`
--

DROP TABLE IF EXISTS `trans_unassemble_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_unassemble_items` (
  `ItemId` int(10) NOT NULL,
  `Unassemble_Id` int(10) DEFAULT NULL,
  `Item` varchar(255) DEFAULT NULL,
  `Batch` varchar(255) DEFAULT NULL,
  `Qty` int(10) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Price` int(10) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `ItemId` (`ItemId`),
  KEY `TransSalesId` (`Unassemble_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_unassemble_items`
--

LOCK TABLES `trans_unassemble_items` WRITE;
/*!40000 ALTER TABLE `trans_unassemble_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_unassemble_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trans_unassemble_voucher`
--

DROP TABLE IF EXISTS `trans_unassemble_voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trans_unassemble_voucher` (
  `Unassemble_Id` int(10) NOT NULL,
  `Series` varchar(255) DEFAULT NULL,
  `UA_Date` datetime DEFAULT NULL,
  `VoucherNo` int(10) DEFAULT NULL,
  `BOM_Name` varchar(255) DEFAULT NULL,
  `MatCenter1` varchar(255) DEFAULT NULL,
  `MatCenter2` varchar(255) DEFAULT NULL,
  `Narration` varchar(255) DEFAULT NULL,
  `TotalQty` int(10) DEFAULT NULL,
  `TotalAmount` int(10) DEFAULT NULL,
  `BSTotalAmount` int(10) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Unassemble_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trans_unassemble_voucher`
--

LOCK TABLES `trans_unassemble_voucher` WRITE;
/*!40000 ALTER TABLE `trans_unassemble_voucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `trans_unassemble_voucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unitconversion`
--

DROP TABLE IF EXISTS `unitconversion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unitconversion` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `MainUnit` varchar(255) DEFAULT NULL,
  `SubUnit` varchar(255) DEFAULT NULL,
  `ConFactor` int(10) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unitconversion`
--

LOCK TABLES `unitconversion` WRITE;
/*!40000 ALTER TABLE `unitconversion` DISABLE KEYS */;
/*!40000 ALTER TABLE `unitconversion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unitmaster`
--

DROP TABLE IF EXISTS `unitmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unitmaster` (
  `UM_Id` int(10) NOT NULL AUTO_INCREMENT,
  `UnitName` varchar(255) DEFAULT NULL,
  `PrintName` varchar(255) DEFAULT NULL,
  `ExciseReturn` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`UM_Id`),
  KEY `Id` (`UM_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unitmaster`
--

LOCK TABLES `unitmaster` WRITE;
/*!40000 ALTER TABLE `unitmaster` DISABLE KEYS */;
INSERT INTO `unitmaster` VALUES (1,'gms','gms','Gms','Admin',NULL,NULL,NULL);
/*!40000 ALTER TABLE `unitmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `userId` bigint(20) NOT NULL AUTO_INCREMENT,
  `userName` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `active` tinyint(1) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `narration` longtext,
  `extraDate` datetime DEFAULT NULL,
  `extra1` varchar(50) DEFAULT NULL,
  `extra2` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userId`),
  KEY `roleId` (`roleId`),
  KEY `grp01` (`roleId`,`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vat_inputtax`
--

DROP TABLE IF EXISTS `vat_inputtax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vat_inputtax` (
  `SNo` int(10) NOT NULL,
  `Month` varchar(255) DEFAULT NULL,
  `Tax_Inc/Dec` varchar(255) DEFAULT NULL,
  `Pure_Amount` int(10) DEFAULT NULL,
  `Tax` int(10) DEFAULT NULL,
  `Schg` int(10) DEFAULT NULL,
  `Inc_Amount` int(10) DEFAULT NULL,
  `Inc_Schg` int(10) DEFAULT NULL,
  `Dec_Amount` int(10) DEFAULT NULL,
  `Dec_Schg` int(10) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vat_inputtax`
--

LOCK TABLES `vat_inputtax` WRITE;
/*!40000 ALTER TABLE `vat_inputtax` DISABLE KEYS */;
/*!40000 ALTER TABLE `vat_inputtax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vat_outputtax`
--

DROP TABLE IF EXISTS `vat_outputtax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vat_outputtax` (
  `SNo` int(10) NOT NULL,
  `Month` varchar(255) DEFAULT NULL,
  `Tax_Inc/Dec` varchar(255) DEFAULT NULL,
  `Nature` varchar(255) DEFAULT NULL,
  `Sale_Amount` int(10) DEFAULT NULL,
  `Tax` int(10) DEFAULT NULL,
  `Schg` int(10) DEFAULT NULL,
  `Inc_Amount` int(10) DEFAULT NULL,
  `Inc_Schg` int(10) DEFAULT NULL,
  `Dec_Amount` int(10) DEFAULT NULL,
  `Dec_Schg` int(10) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vat_outputtax`
--

LOCK TABLES `vat_outputtax` WRITE;
/*!40000 ALTER TABLE `vat_outputtax` DISABLE KEYS */;
/*!40000 ALTER TABLE `vat_outputtax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'sunspeed'
--
/*!50003 DROP PROCEDURE IF EXISTS `spCheckLogin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckLogin`(S_userName varchar(250) ,S_password varchar(250))
BEGIN
SELECT * from user where userName=S_userName AND active=1;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCompanyCheckExistence` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spCompanyCheckExistence`(companyName VARCHAR(250),
companyId NUMERIC)
BEGIN
IF(SELECT COUNT(companyId)FROM company where Name=companyName AND companyId!=companyId)>0 THEN
SELECT 1;
ELSE
SELECT 0;
END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spcompanypathAdd` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spcompanypathAdd`(companyName VARCHAR(250),
companyPath varchar(250),
isDefault bit,
extra1 varchar(250),
extra12 varchar(250))
BEGIN
INSERT INTO companypath(companyname,companypath,isdefault,extra1,extra2) VALUES
(companyname,companypath,isdefault,extra1,extra2);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCreateCompany` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spCreateCompany`(Name varchar(250) ,
PrintName varchar(250) ,
ShortName varchar(250) ,
Country varchar(250) ,
State varchar(250) ,
FYBegining datetime ,
Bookscommencing datetime ,
Address varchar(250) ,
CIN varchar(250) ,
PAN varchar(250) ,
Ward varchar(250),
Telephone varchar(250) ,
Fax varchar(250) ,
Email varchar(250) ,
CurrencySymbol varchar(250) ,
CurrencyString varchar(250) ,
CurrencySubString varchar(250) ,
CurrencyFont varchar(250) ,
CurrencyCharacter varchar(250) ,
VAT varchar(250),
Type varchar(250),
EnableTaxSchg bit ,
TIN varchar(250),
CSTNo varchar(250) ,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO company
(
Name,
PrintName,
ShortName,
Country,
State,
FYBegining,
Bookscommencing,
Address,
CIN,
PAN,
Ward,
Telephone,
Fax,
Email,
CurrencySymbol,
CurrencyString,
CurrencySubString,
CurrencyFont,
CurrencyCharacter,
VAT,
Type,
EnableTaxSchg,
TIN,
CSTNo,
CreatedBy,
CreatedDate
)
VALUES
(
Name,
PrintName,
ShortName,
Country,
State,
FYBegining,
Bookscommencing,
Address,
CIN,
PAN,
Ward,
Telephone,
Fax,
Email,
CurrencySymbol,
CurrencyString,
CurrencySubString,
CurrencyFont,
CurrencyCharacter,
VAT,
Type,
EnableTaxSchg,
TIN,
CSTNo,
CreatedBy,
CURRENT_DATE());
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertBillSundryMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertBillSundryMaster`(
Trans_Sales_Id INT,
BillSundry varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_sales_bs`
(
Trans_Sales_Id,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
Trans_Sales_Id,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertContraDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertContraDetails`(
ContraId INT,
DC varchar(250),
Account varchar(250),
DebitAmount decimal(18,5),
CreditAmount decimal(18,5),
Narration varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `Contra_voucher_details`
(
Contra_Id,
DC,
Account,
Debit,
Credit,
Narration,
CreatedBy)
VALUES
(
ContraId,
DC,
Account,
DebitAmount,
CreditAmount,
Narration,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertContraMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertContraMaster`(
VoucherNumber INT,
Series varchar(250),
CVDate date,
LongNarration varchar(5000),
TotalCreditAmount int(10),
TotalDebitAmount int(10),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `contra_vouchermaster`
(
VoucherNo,
Series,
CV_Date,
LongNarration,
TotalCreditAmt,
TotalDebitAmt,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
CVDate,
LongNarration,
TotalCreditAmount,
TotalDebitAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCreditDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertCreditDetails`(
CreditId INT,
DC varchar(250),
Account varchar(250),
DebitAmount decimal(18,5),
CreditAmount decimal(18,5),
Narration varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `credit_note_Details`
(
Credit_Id,
DC,
Account,
Debit,
Credit,
Narration,
CreatedBy)
VALUES
(
CreditId,
DC,
Account,
DebitAmount,
CreditAmount,
Narration,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCreditNoteMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertCreditNoteMaster`(
VoucherNumber INT,
Series varchar(250),
CNDate date,
CNType varchar(250),
PDCDate date,
LongNarration varchar(5000),
TotalCreditAmount int(10),
TotalDebitAmount int(10),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `credit_note_master`
(
VoucherNo,
Series,
CN_Date,
Type,
PDC_Date,
LongNarration,
TotalCreditAmt,
TotalDebitAmt,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
CNDate,
CNType,
PDCDate,
LongNarration,
TotalCreditAmount,
TotalDebitAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertDebitDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertDebitDetails`(
DebitId INT,
DC varchar(250),
Account varchar(250),
DebitAmount decimal(18,5),
CreditAmount decimal(18,5),
Narration varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `debit_note_Details`
(
Debit_Id,
DC,
Account,
Debit,
Credit,
Narration,
CreatedBy)
VALUES
(
DebitId,
DC,
Account,
DebitAmount,
CreditAmount,
Narration,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertDebitNoteMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertDebitNoteMaster`(
VoucherNumber INT,
Series varchar(250),
DNDate date,
DNType varchar(250),
TotalCreditAmount decimal(18,5),
TotalDebitAmount decimal(18,5),
LongNarration varchar(5000),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `Debit_note_master`
(
VoucherNo,
Series,
DN_Date,
Type,
TotalCreditAmount,
TotalDebitAmount,
LongNarration,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
DNDate,
DNType,
TotalCreditAmount,
TotalDebitAmount,
LongNarration,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFormIssuedDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertFormIssuedDetails`(
IssuedId INT,
VoucherNumber int,
Dated varchar(250),
Amount INT,
PurchaseBillNo int,
PurchaseDate int,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `formissued_details`
(
Issued_Id,
VoucherNo,
Dated,
TotalAmount,
PurchaseBillNo,
PurchaseDate,
CreatedBy)
VALUES
(
IssuedId,
VoucherNumber,
Dated,
Amount,
PurchaseBillNo,
PurchaseDate,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFormIssuedMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertFormIssuedMaster`(
Form varchar(250),
Date date,
FormNo int,
Authority date,
Party varchar(250),
Narration varchar(5000),
TotalAmount int,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `formissued_master`
(
Issued_Date,
Form,
RcvdAuthourity,
FormNo,
Party,
Narration,
TotalAmount,
CreatedBy)
VALUES
(
Date,
Form,
Authority,
FormNo,
Party,
Narration,
TotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFormRcvdDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertFormRcvdDetails`(
RcvdId INT,
Voucherno int,
Dated varchar(250),
Amount INT,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `formrecevied_details`
(
Recevied_Id,
VoucherNo,
Dated,
Amount,
CreatedBy)
VALUES
(
RcvdId,
Voucherno,
Dated,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFormRcvdMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertFormRcvdMaster`(
Date date,
Form varchar(250),
Series varchar(250),
Issuingoffice varchar(250),
Formnumber int,
DateofIssue date,
Stateofissue varchar(250),
Party varchar(250),
Narration varchar(5000),
TotalAmount int,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `formrecevied_master`
(
Recevied_Date,
Form,
Series,
IssuingOffice,
FormNo,
Party,
DateOfIssue,
StateOfIssue,
Narration,
TotalAmount,
CreatedBy)
VALUES
(
Date,
Form,
Series,
Issuingoffice,
Formnumber,
Party,
DateofIssue,
Stateofissue,
Narration,
TotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemBarcodes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemBarcodes`(
Item_Id INT,
Item_Barcode varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `ItemBarcodes`
(
ITM_ID,
ITEM_BARCODE,
CreatedBy)
VALUES
(
Item_Id,
Item_Barcode,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemBatchWiseDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemBatchWiseDetails`(
Item_Id INT,
ITEM_BATCHNO int,
ITEM_QTY decimal(18,5),
ITEM_MFGDATE datetime,
ITEM_EXPDATE datetime,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `Itembatchwisedetails`
(
ITM_ID,
ITEM_BATCHNO,
ITEM_QTY,
ITEM_MFGDATE,
ITEM_EXPDATE,
CreatedBy)
VALUES
(
Item_Id,
ITEM_BATCHNO,
ITEM_QTY,
ITEM_MFGDATE,
ITEM_EXPDATE,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemCriticalLvlDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemCriticalLvlDetails`(
Item_Id INT,
ITEM_MINIMUMLVLQTY decimal(18,5),
ITEM_RECORDLVLQTY decimal(18,5),
ITEM_MAXIMUMLVLQTY decimal(18,5),
ITEM_MINIMUMLVLDAYS decimal(18,5),
ITEM_RECORDLVLDAYS decimal(18,5),
ITEM_MAXIMUMLVLDAYS decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `Itemdefinecriticallevel`
(
ITM_ID,
ITEM_MINIMUMLVLQTY,
ITEM_RECORDLVLQTY,
ITEM_MAXIMUMLVLQTY,
ITEM_MINIMUMLVLDAYS,
ITEM_RECORDLVLDAYS,
ITEM_MAXIMUMLVLDAYS,
CreatedBy)
VALUES
(
Item_Id,
ITEM_MINIMUMLVLQTY,
ITEM_RECORDLVLQTY,
ITEM_MAXIMUMLVLQTY,
ITEM_MINIMUMLVLDAYS,
ITEM_RECORDLVLDAYS,
ITEM_MAXIMUMLVLDAYS,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemMaster`(
ITEM_Name varchar(255),
ITEM_PrintName varchar(255),
ITEM_ALIAS varchar(255),
ITEM_GROUP varchar(255),
ITEM_COMPANY varchar(255),
ITEM_MAINUNIT varchar(255),
ALT_UNIT varchar(255),
ITEM_CONAlt decimal(18,5),
ITEM_CONMain decimal(18,5),
ITEM_OPSTOCKVALUE decimal(18,5),
ITEM_UNIT varchar(255),
ITEM_RATE decimal(18,5),
ITEM_PER varchar(255),
ITEM_VALUE decimal(18,5),
ITEM_APPLYSALEPRICE varchar(255),
ITEM_APPLYPURCPRICE varchar(255),
ITEM_SALEPRICE decimal(18,5),
ITEM_ALTSALEPRICE decimal(18,5),
ITEM_PURCEPRICE decimal(18,5),
ITEM_ALTPURCEPRICE decimal(18,5),
ITEM_MRP decimal(18,5),
ITEM_ALTMRP decimal(18,5),
ITEM_MINSALEPRICE decimal(18,5),
ITEM_ALTMINSALEPRICE decimal(18,5),
ITEM_SELFVALUEPRICE decimal(18,5),
ITEM_DISSCOUNTINFO tinyint(1),
ITEM_MARKUPINFO tinyint(1),
ITEM_SALEDISCOUNT decimal(18,5),
ITEM_PURCHASEDISCOUNT decimal(18,5),
ITEM_SALEDISCOUNTCOMP decimal(18,5),
ITEM_PURCHASEDISCOUNTCOMP decimal(18,5),
ITEM_SpecifySaleDiscStructure tinyint(1),
ITEM_SpecifyPurDiscStructure tinyint(1),
ITEM_SaleMarkup varchar(255),
ITEM_PurMarkup varchar(255),
ITEM_SaleCompMarkup varchar(255),
ITEM_PurCompMarkup varchar(255),
ITEM_SpecifySaleMarkupStruct varchar(255),
ITEM_SpecifyPurMarkupStruct varchar(255),
ITEM_StockValMethod varchar(255),
ITEM_TAXCATEGORY varchar(255),
ITEM_DESCRIPTION1 varchar(255),
ITEM_DESCRIPTION2 varchar(255),
ITEM_DESCRIPTION3 varchar(255),
ITEM_DESCRIPTION4 varchar(255),
ITEM_SETCRITICALLEVEL tinyint(1),
ITEM_MAINTAINRG23D tinyint(1),
ITEM_TARIFHEADING varchar(255),
ITEM_SERIALWISEDETAILS tinyint(1),
ITEM_PARAMETERIZEDDETAILS tinyint(1),
ITEM_MRPWISEDETAILS tinyint(1),
ITEM_BATCHWISEDETAILS tinyint(1),
ITEM_EXPDATEREQUIRED tinyint(1),
ITEM_EXPIRYDAYS INT(100),
ITEM_SALESACCOUNT varchar(255),
ITEM_PURCACCOUNT varchar(255),
ITEM_MAINTAINSTOCKBAL varchar(255),
ITEM_SPECIFYDEFAULTMC varchar(255),
ITEM_FREEZEMCFORITEM tinyint(1),
ITEM_TOTALNUMBEROFAUTHORS INT(100),
ITEM_PICKITEMSIZEFROMDESC tinyint(1),
ITEM_SPECIFYDEFAULTVENDOR tinyint(1),
CreatedBy varchar(255)
)
BEGIN
INSERT INTO `itemmaster`
(
  ITEM_Name,
  ITEM_PRINTName,
  ITEM_ALIAS,
  ITEM_GROUP,
  ITEM_COMPANY,
  ITEM_MAINUNIT,
  ITEM_ALTUNIT,
  ITEM_CONALTUNIT,
  ITEM_CONMAINUNIT,
  ITEM_OPSTOCK,
  ITEM_UNIT,
  ITEM_RATE,
  ITEM_PER,
  ITEM_VALUE,
  ITEM_SALEPRICETOAPPLY,
  ITEM_PURCPRICETOAPPLY,
  ITEM_SALEPRICEMAIN,
  ITEM_SALESPRICEALT,
  ITEM_PURCHASEPRICEMAIN,
  ITEM_PURCPRICEALT  ,
  ITEM_MRPMAIN  ,
  ITEM_MRPALT  ,
  ITEM_MINSALEPRICEMAIN  ,
  ITEM_MINSALEPRICEALT  ,
  ITEM_SELFVALUEPRICE  ,
  ITEM_DISCOUNTINFO  ,
  ITEM_MARKUPINFO ,
  ITEM_SALEDISCOUNT  ,
  ITEM_PURCHASEDISCOUNT  ,
  ITEM_SALECOMPDISCOUNT  ,
  ITEM_PURCHCOMPDISCOUNT  ,
  ITEM_SPECIFYSALEDISCSTRUCT  ,
  ITEM_SPECIFYPURDISCSTRUCT  ,
  ITEM_SALEMARKUP,
  ITEM_PURMARKUP ,
  ITEM_SALECOMPMARKUP ,
  ITEM_PURCCOMPMARKUP,
  ITEM_SPECIFYSALEMARKUPSTRUCT  ,
  ITEM_SPECIFYPURCMARKUPSTRUCT  ,
  ITEM_STOCKVALMETHOD  ,
  ITEM_TAXCATEGORY  ,
  ITEM_DESCRIPTION1  ,
  ITEM_DESCRIPTION2  ,
  ITEM_DESCRIPTION3  ,
  ITEM_DESCRIPTION4,
  ITEM_SETCRITICALLEVEL  ,
  ITEM_MAINTAINRG23D  ,
  ITEM_TARIFHEADING  ,
  ITEM_SERIALWISEDETAILS  ,
  ITEM_PARAMETERIZEDDETAILS  ,
  ITEM_MRPWISEDETAILS  ,
  ITEM_BATCHWISEDETAILS  ,
  ITEM_EXPDATEREQUIRED  ,
  ITEM_EXPIRYDAYS,
  ITEM_SALESACCOUNT  ,
  ITEM_PURCACCOUNT  ,
  ITEM_MAINTAINSTOCKBAL  ,
  ITEM_SPECIFYDEFAULTMC  ,
  ITEM_FREEZEMCFORITEM  ,
  ITEM_TOTALNUMBEROFAUTHORS,
  ITEM_PICKITEMSIZEFROMDESC  ,
  ITEM_SPECIFYDEFAULTVENDOR  ,
  CreatedBy 
 )
VALUES
(
ITEM_Name,
ITEM_PrintName,
ITEM_ALIAS,
ITEM_GROUP,
ITEM_COMPANY,
ITEM_MAINUNIT,
ALT_UNIT,
ITEM_CONAlt,
ITEM_CONMain,
ITEM_OPSTOCKVALUE,
ITEM_UNIT,
ITEM_RATE,
ITEM_PER,
ITEM_VALUE,
ITEM_APPLYSALEPRICE,
ITEM_APPLYPURCPRICE,
ITEM_SALEPRICE,
ITEM_ALTSALEPRICE,
ITEM_PURCEPRICE,
ITEM_ALTPURCEPRICE,
ITEM_MRP,
ITEM_ALTMRP,
ITEM_MINSALEPRICE,
ITEM_ALTMINSALEPRICE,
ITEM_SELFVALUEPRICE,
ITEM_DISSCOUNTINFO,
ITEM_MARKUPINFO,
ITEM_SALEDISCOUNT,
ITEM_PURCHASEDISCOUNT,
ITEM_SALEDISCOUNTCOMP,
ITEM_PURCHASEDISCOUNTCOMP,
ITEM_SpecifySaleDiscStructure,
ITEM_SpecifyPurDiscStructure,
ITEM_SaleMarkup,
ITEM_PurMarkup,
ITEM_SaleCompMarkup,
ITEM_PurCompMarkup,
ITEM_SpecifySaleMarkupStruct,
ITEM_SpecifyPurMarkupStruct,
ITEM_StockValMethod,
ITEM_TAXCATEGORY,
ITEM_DESCRIPTION1,
ITEM_DESCRIPTION2,
ITEM_DESCRIPTION3,
ITEM_DESCRIPTION4,
ITEM_SETCRITICALLEVEL,
ITEM_MAINTAINRG23D,
ITEM_TARIFHEADING,
ITEM_SERIALWISEDETAILS,
ITEM_PARAMETERIZEDDETAILS,
ITEM_MRPWISEDETAILS,
ITEM_BATCHWISEDETAILS,
ITEM_EXPDATEREQUIRED,
ITEM_EXPIRYDAYS,
ITEM_SALESACCOUNT,
ITEM_PURCACCOUNT,
ITEM_MAINTAINSTOCKBAL,
ITEM_SPECIFYDEFAULTMC,
ITEM_FREEZEMCFORITEM,
ITEM_TOTALNUMBEROFAUTHORS,
ITEM_PICKITEMSIZEFROMDESC,
ITEM_SPECIFYDEFAULTVENDOR,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemMRPWiseDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemMRPWiseDetails`(
Item_Id INT,
ITEM_MRP decimal(18,5),
ITEM_SALESPRICE decimal(18,5),
ITEM_QUANTITY decimal(18,5),
ITEM_AMOUNT decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `Itemmrpwisedetails`
(
ITM_ID,
ITEM_MRP,
ITEM_SALESPRICE,
ITEM_QUANTITY,
ITEM_AMOUNT,
CreatedBy)
VALUES
(
Item_Id,
ITEM_MRP,
ITEM_SALESPRICE,
ITEM_QUANTITY,
ITEM_AMOUNT,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemParameterized` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemParameterized`(
Item_Id INT,
ITEM_NAME varchar(250),
ITEM_QTY int,
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `ItemParameterizeddetails`
(
ITM_ID,
ITEM_NAME,
ITEM_QTY,
CreatedBy)
VALUES
(
Item_Id,
ITEM_NAME,
ITEM_QTY,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemSerialNoDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemSerialNoDetails`(
Item_Id INT,
Item_ManulaNo tinyint(1),
Item_AutoNo tinyint(1),
Item_StartingAuto int(100),
Item_NumberingFreq varchar(255),
Item_Structure varchar(255),
Item_RegenerateAuto int(100),
Item_PurchaseWarranty tinyint(1),
Item_SaleWarranty tinyint(1),
Item_InstallWaranty tinyint(1),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `itemserialnodetails`
(
ITM_ID,
ITEM_MANUALNO,
ITEM_AUTONO,
ITEM_STARTINGAUTONO,
ITEM_NUMBERINGFREQ,
ITEM_STRUCTUENAME,
ITEM_REGENARATEAUTONO,
ITEM_SALESWARRANTY,
ITEM_PURCHASEWARRANTY,
ITEM_INSTALLWARRANTY,
CreatedBy)
VALUES
(
Item_Id,
Item_ManulaNo,
Item_AutoNo,
Item_StartingAuto,
Item_NumberingFreq,
Item_Structure,
Item_RegenerateAuto,
Item_PurchaseWarranty,
Item_SaleWarranty,
Item_InstallWaranty,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertJournalDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertJournalDetails`(
JournalId INT,
DC varchar(250),
Account varchar(250),
DebitAmount decimal(18,5),
CreditAmount decimal(18,5),
Narration varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `journal_voucher_Details`
(
JV_Id,
DC,
Account,
Debit,
Credit,
Narration,
CreatedBy)
VALUES
(
JournalId,
DC,
Account,
DebitAmount,
CreditAmount,
Narration,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertJournalMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertJournalMaster`(
VoucherNumber INT,
Series varchar(250),
JVDate date,
Type varchar(250),
PDCDate date,
LongNarration varchar(5000),
TotalCreditAmount int(10),
TotalDebitAmount int(10),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `journal_voucher_master`
(
VoucherNo,
Series,
JV_Date,
Type,
PDC_Date,
LongNarration,
TotalCreditAmt,
TotalDebitAmt,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
JVDate,
Type,
PDCDate,
LongNarration,
TotalCreditAmount,
TotalDebitAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMatIssuedBS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertMatIssuedBS`(
MatId INT,
BillSundry varchar(250),
Narration varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `MatIssued_bs`
(
MatIssued_Id,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
MatId,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMatIssuedItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertMatIssuedItem`(
MatId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `matissued_items`
(
MatIssued_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
MatId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMatIssuedMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertMatIssuedMaster`(
VoucherNumber INT,
Series varchar(250),
MatDate date,
MatType varchar(250),
MatParty varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `matissued_master`
(
VoucherNo,
Series,
Issued_Date,
Type,
Party,
MatCentre,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
MatDate,
MatType,
MatParty,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMatRcvddMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertMatRcvddMaster`(
VoucherNumber INT,
Series varchar(250),
MatRcvdDate date,
MatRcvdType varchar(250),
MatRcvdParty varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `matrecevied_master`
(
VoucherNo,
Series,
Rcvd_Date,
Type,
Party,
MatCentre,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
MatRcvdDate,
MatRcvdType,
MatRcvdParty,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMatReceviedBS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertMatReceviedBS`(
MatRcvdId INT,
BillSundry varchar(250),
Narration varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `matrecevied_bs`
(
MatRcvd_Id,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
MatRcvdId,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMatReceviedItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertMatReceviedItem`(
MatRcvdId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `matrecevied_items`
(
MatRcvd_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
MatRcvdId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPaymentDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPaymentDetails`(
PaymentId INT,
DC varchar(250),
Account varchar(250),
DebitAmount decimal(18,5),
CreditAmount decimal(18,5),
Narration varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `payment_voucher_Details`
(
Payment_Id,
DC,
Account,
Debit,
Credit,
Narration,
CreatedBy)
VALUES
(
PaymentId,
DC,
Account,
DebitAmount,
CreditAmount,
Narration,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPaymentMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPaymentMaster`(
VoucherNumber INT,
Series varchar(250),
PayDate date,
Type varchar(250),
PDCDate date,
LongNarration varchar(5000),
TotalCreditAmount int(10),
TotalDebitAmount int(10),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `payment_voucher_master`
(
VoucherNo,
Series,
Pay_Date,
Type,
PDC_Date,
LongNarration,
TotalCreditAmt,
TotalDebitAmt,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
PayDate,
Type,
PDCDate,
LongNarration,
TotalCreditAmount,
TotalDebitAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPRBillSundry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPRBillSundry`(
TransPRId INT,
BillSundry varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_pr_bs`
(
TransPRId,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
TransPRId,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPRItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPRItem`(
TransPRId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_pr_items`
(
TransPRId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
TransPRId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertProductionItemconsumed` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertProductionItemconsumed`(
ProductionId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `production_itemconsumed`
(
Production_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
ProductionId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertProductionItemgenerated` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertProductionItemgenerated`(
ProductionId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `production_itemgenerate`
(
Production_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
ProductionId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertProductionMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertProductionMaster`(
VoucherNumber INT,
Series varchar(250),
ProductionDate date,
BOMName varchar(250),
MatCentreIG varchar(250),
MatCentreIC varchar(250),
Narration varchar(5000),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `production_master`
(
VoucherNo,
Series,
Production_Date,
BOMName,
MatCenterIG,
MatCenterIC,
Narration,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
ProductionDate,
BOMName,
MatCentreIG,
MatCentreIC,
Narration,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseIndentBS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseIndentBS`(
PIId INT,
BillSundry varchar(250),
Narration varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `purchaseindent_bs`
(
PI_Id,
BillSundry,
Narration,
Percentage,
Amount,
CreatedBy)
VALUES
(
Trans_Sales_Id,
BillSundry,
Narration,
Percentage,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseIndentItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseIndentItem`(
PIId INT,
Item varchar(250),
Qty INT,
Unit varchar(250),
TotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_sales_item`
(
PI_Id,
Item,
Qty,
Unit,
TotalAmount,
CreatedBy)
VALUES
(
PIId,
Item,
Qty,
Unit,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseIndentMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseIndentMaster`(
VoucherNumber INT,
Series varchar(250),
Date date,
MatCentre varchar(250),
Executive varchar(250),
Narration varchar(5000),
ItemTotalQty int,

CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_sales`
(
VoucherNumber,
Series,
Date,
MatCentre,
Executive,
Narration,
TotalQty,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
Date,
MatCentre,
Executive,
Narration,
ItemTotalQty,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseOrder`(
VoucherNumber INT,
Series varchar(250),
PurcDate date,
PurcType varchar(250),
Party varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_Purchaseorder`
(
VoucherNumber,
Series,
PurcDate,
PurcType,
Party,
MatCentre,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
PurcDate,
PurcType,
Party,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseQuotationBS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseQuotationBS`(
PQId INT,
BillSundry varchar(250),
Narration varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `purchasequotation_bs`
(
PQ_Id,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
PQId,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseQuotationItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseQuotationItem`(
PQId INT,
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `purchasequotation_item`
(
PQ_Id,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
PQId,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseQuotationMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseQuotationMaster`(
VoucherNumber INT,
Series varchar(250),
PurcDate date,
PurcType varchar(250),
Party varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `purchasequotation_master`
(
VoucherNo,
Series,
PurcType,
PQDate,
Party,
MatCenter,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
PurcType,
PurcDate,
Party,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseReturn` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseReturn`(
VoucherNumber INT,
Series varchar(250),
PRDate date,
PRType varchar(250),
Party varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_purchasereturn`
(
VoucherNo,
Series,
PurchaseType,
PR_Date,
Party,
MatCenter,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
PurchaseType,
PRDate,
Party,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurchaseVoucher` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurchaseVoucher`(
VoucherNumber INT,
Series varchar(250),
PurcDate date,
PurcType varchar(250),
Party varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_purchase_voucher`
(
VoucherNo,
Series,
PV_Type,
PV_Date,
Party,
MatCenter,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
PurcType,
PurcDate,
Party,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurcItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurcItem`(
TransPVId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_pv_items`
(
TransPVId,
Item,
Batch,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
TransPVId,
Item,
Batch,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPurcOrderItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPurcOrderItem`(
Trans_Purcord_Id INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_Purcorder_item`
(
Trans_Purcord_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
Trans_Purcord_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPVBillSundry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertPVBillSundry`(
TransPVId INT,
BillSundry varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_pv_bs`
(
TransPVId,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
TransPVId,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRecieptDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertRecieptDetails`(
RecieptId INT,
DC varchar(250),
Account varchar(250),
DebitAmount decimal(18,5),
CreditAmount decimal(18,5),
Narration varchar(250),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `reciept_voucher_Details`
(
Recipt_Id,
DC,
Account,
Debit,
Credit,
Narration,
CreatedBy)
VALUES
(
RecieptId,
DC,
Account,
DebitAmount,
CreditAmount,
Narration,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRecieptMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertRecieptMaster`(
VoucherNumber INT,
Series varchar(250),
RecieptDate date,
Type varchar(250),
PDCDate date,
LongNarration varchar(250),
TotalCreditAmount int(10),
TotalDebitAmount int(10),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `reciept_voucher_master`
(
VoucherNo,
Series,
Reciept_Date,
Type,
PDC_Date,
LongNarration,
TotalCreditAmt,
TotalDebitAmt,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
RecieptDate,
Type,
PDCDate,
LongNarration,
TotalCreditAmount,
TotalDebitAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSalesItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertSalesItem`(
Trans_Sales_Id INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_sales_item`
(
Trans_Sales_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
Trans_Sales_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSalesQuotationBS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertSalesQuotationBS`(
SQId INT,
BillSundry varchar(250),
Narration varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `salesquotation_bs`
(
SQ_Id,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
SQId,
BillSundry,
Narration,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSalesQuotationItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertSalesQuotationItem`(
SQId INT,
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `salesquotation_item`
(
SQ_Id,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
SQ_Id,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSalesQuotationMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertSalesQuotationMaster`(
VoucherNumber INT,
Series varchar(250),
SQDate date,
SalesType varchar(250),
Party varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalQty int,
ItemTotalAmount decimal(18,5),
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `salesquotation_master`
(
VoucherNumber,
Series,
SQDate,
SalesType,
Party,
MatCentre,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
SQDate,
SalesType,
Party,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSalesVoucher` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertSalesVoucher`(
VoucherNumber INT,
Series varchar(250),
SaleDate date,
SalesType varchar(250),
Party varchar(250),
MatCentre varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_sales`
(
VoucherNumber,
Series,
SaleDate,
SalesType,
Party,
MatCentre,
Narration,
TotalQty,
TotalAmount,
BSTotalAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
SaleDate,
SalesType,
Party,
MatCentre,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStockBillSundry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertStockBillSundry`(
StockId INT,
BillSundry varchar(250),
Narration varchar(250),
Percentage INT,
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `stocktransfer_bs`
(
Stock_Id,
BillSundry,
Narration,
Percentage,
TotalAmount,
CreatedBy)
VALUES
(
StockId,
BillSundry,
Narration,
Percentage,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStockJournalItemconsumed` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertStockJournalItemconsumed`(
StockId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `stockjournal_itemconsumed`
(
Sjournal_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
StockId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStockJournalItemgenerated` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertStockJournalItemgenerated`(
StockId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `stockjournal_itemgenerate`
(
Sjournal_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
StockId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStockjournalMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertStockjournalMaster`(
VoucherNumber INT,
Series varchar(250),
Date date,
MatCentreIG varchar(250),
MatCentreIC varchar(250),
Narration varchar(5000),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `stockjournal_master`
(
VoucherNo,
Series,
Date,
MatCenterIG,
MatCenterIC,
Narration,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
Date,
MatCentreIG,
MatCentreIC,
Narration,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStockTransferItem` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertStockTransferItem`(
StockId INT,
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `stocktransfer_items`
(
Stock_Id,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
StockId,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStockTransMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertStockTransMaster`(
VoucherNumber INT,
Series varchar(250),
Date date,
StockFrom varchar(250),
StockTo varchar(250),
Narration varchar(5000),
ItemTotalAmount decimal(18,5),
ItemTotalQty int,
BSTotalAmount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `stocktransfer_master`
(
VoucherNo,
Series,
ST_Date,
StockFrom,
StockTo,
Narration,
TotalQty,
TotalAmount,
TotalBSAmount,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
Date,
StockFrom,
StockTo,
Narration,
ItemTotalQty,
ItemTotalAmount,
BSTotalAmount,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUnassembleItemconsumed` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertUnassembleItemconsumed`(
UnassembleId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `unassemble_itemconsumed`
(
Unassemble_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
UnassembleId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUnassembleItemgenerated` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertUnassembleItemgenerated`(
UnassembleId INT,
Batch varchar(250),
Item varchar(250),
Qty INT,
Unit varchar(250),
Price decimal(18,5),
Amount decimal(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `unassemble_itemgenerate`
(
Unassemble_Id,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy)
VALUES
(
UnassembleId,
Batch,
Item,
Qty,
Unit,
Price,
Amount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUnassembleMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spInsertUnassembleMaster`(
VoucherNumber INT,
Series varchar(250),
Date date,
BOMName varchar(250),
MatCentreIG varchar(250),
MatCentreIC varchar(250),
Narration varchar(5000),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `unassemble_master`
(
VoucherNo,
Series,
UA_Date,
BOM_Name,
MatCenterIG,
MatCenterIC,
Narration,
CreatedBy)
VALUES
(
VoucherNumber,
Series,
Date,
BOMName,
MatCentreIG,
MatCentreIC,
Narration,
CreatedBy);
SELECT LAST_INSERT_ID();
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spPurOrdertBillSundry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`zakir`@`%`*/ /*!50003 PROCEDURE `spPurOrdertBillSundry`(
Trans_Purcord_Id INT,
BillSundry varchar(250),
Percentage INT,
Amount DECIMAL(18,5),
TotalAmount DECIMAL(18,5),
CreatedBy varchar(250)
)
BEGIN
INSERT INTO `trans_Purcorder_bs`
(
Trans_Purcord_Id,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy)
VALUES
(
Trans_Purcord_Id,
BillSundry,
Percentage,
Amount,
TotalAmount,
CreatedBy);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUserAdd` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUserAdd`(
S_userName varchar(50) ,
S_password varchar(50) ,
S_active bit ,
S_roleId numeric,
S_narration varchar(5000),
S_extra1 varchar(50) ,
S_extra2 varchar(50)
)
BEGIN
INSERT INTO User
(userName,
password,
active,
roleId,
narration,
extraDate,
extra1,
extra2)
VALUES
(S_userName,
S_password,
S_active,
S_roleId,
S_narration,
Current_Date(),
S_extra1,
S_extra2);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UserAdd` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = latin1 */ ;
/*!50003 SET character_set_results = latin1 */ ;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `UserAdd`(
S_userName varchar(50) ,
S_password varchar(50) ,
S_active bit ,
S_roleId numeric,
S_narration varchar(5000),
S_extra1 varchar(50) ,
S_extra2 varchar(50)
)
BEGIN
INSERT INTO tbl_User
(userName,
password,
active,
roleId,
narration,
extraDate,
extra1,
extra2)
VALUES
(S_userName,
S_password,
S_active,
S_roleId,
S_narration,
Current_Date(),
S_extra1,
S_extra2);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-25 23:52:54
