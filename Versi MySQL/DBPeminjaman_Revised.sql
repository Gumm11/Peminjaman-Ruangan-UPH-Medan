DROP DATABASE IF EXISTS DBPeminjaman;
CREATE DATABASE DBPeminjaman;
USE DBPeminjaman;

CREATE TABLE `User` (
  `User_Email` VARCHAR(50) NOT NULL,
  `User_Name` VARCHAR(50) NOT NULL,
  `User_Password` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`User_Email`)
);

CREATE TABLE `Staff` (
  `Staff_Email` VARCHAR(50) NOT NULL,
  `Staff_Name` VARCHAR(50) NOT NULL,
  `Staff_Password` VARCHAR(255) NOT NULL,
  `Staff_PhoneNumber` INT(20) NOT NULL,
  `Staff_Job` VARCHAR(50) NOT NULL,
  PRIMARY KEY(`Staff_Email`)
);

CREATE TABLE `Ruangan` (
  `Ruangan_Name` VARCHAR(10) NOT NULL, 
  `Ruangan_Location` VARCHAR(50) NOT NULL,
  `Ruangan_Capacity` SMALLINT NOT NULL,
  PRIMARY KEY(`Ruangan_Name`)
);

CREATE TABLE `Form` (
  `FormID` INT NOT NULL AUTO_INCREMENT,
  `Ruangan_Name` VARCHAR(10) NOT NULL,
  `User_Email` VARCHAR(50) NOT NULL,
  `Form_Date` DATE NOT NULL,
  `Form_Description` VARCHAR(255) NOT NULL,
  `User_Associate` VARCHAR(50) NOT NULL,
  `Room_Approval` TINYINT(1) NOT NULL DEFAULT 0,
  `Rejection_Reason` VARCHAR(255) DEFAULT NULL,
  `Form_Status` VARCHAR(10) NOT NULL DEFAULT 'active',
  PRIMARY KEY(`FormID`),
  CONSTRAINT `fk_Ruangan_Name` FOREIGN KEY (`Ruangan_Name`) REFERENCES `Ruangan`(`Ruangan_Name`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_User_Email` FOREIGN KEY (`User_Email`) REFERENCES `User`(`User_Email`) ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE `Form_Time` (
  `FormID` INT NOT NULL AUTO_INCREMENT,
  `TimeStart` TIME,
  `TimeEnd` TIME,
  PRIMARY KEY(`FormID`),
  CONSTRAINT `fk_FormID` FOREIGN KEY (`FormID`) REFERENCES `Form`(`FormID`) ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE `Equipment` (
  `EquipmentID` INT NOT NULL AUTO_INCREMENT,
  `Equipment_Name` VARCHAR(50) NOT NULL,
  `Equipment_Quantity` INT NOT NULL,
  `Equipment_Location` VARCHAR(50) NOT NULL,
  PRIMARY KEY(`EquipmentID`)
);

CREATE TABLE `Form_Equipment` (
  `FormID` INT NOT NULL AUTO_INCREMENT,
  `EquipmentID` INT NOT NULL AUTO_INCREMENT,
  `Equipment_Quantity` INT NOT NULL,
  PRIMARY KEY (`FormID`, `EquipmentID`),
  CONSTRAINT `fk_FormID` FOREIGN KEY (`FormID`) REFERENCES `Form`(`FormID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_EquipmentID` FOREIGN KEY (`EquipmentID`) REFERENCES `Equipment`(`EquipmentID`) ON DELETE RESTRICT ON UPDATE RESTRICT
  -- Jika suatu equipment dihapus, asosiasi form dengan equipment jangan dihapus dulu agar bisa notif user. 
);