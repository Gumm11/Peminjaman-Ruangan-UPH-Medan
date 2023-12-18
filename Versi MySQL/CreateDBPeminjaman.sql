DROP DATABASE IF EXISTS DbPeminjaman;
CREATE DATABASE DbPeminjaman;
USE DbPeminjaman;

CREATE TABLE `User` (
	UserID INT AUTO_INCREMENT PRIMARY KEY,
	User_Email VARCHAR(255) NOT NULL,
    User_Name VARCHAR(255) NOT NULL, 
    User_Password VARCHAR(255) NOT NULL,
    User_Role VARCHAR(255) NOT NULL,
	CONSTRAINT `Unique_User_Email` UNIQUE (User_Email)
);

CREATE TABLE Room (
	RoomID INT AUTO_INCREMENT PRIMARY KEY,
    Room_Name VARCHAR(255) NOT NULL,
    Room_Location VARCHAR(255) NOT NULL,
    Room_Capacity INT NOT NULL,
    Room_Type VARCHAR(255) NOT NULL,
	CONSTRAINT `Room_Capacity_Not_Negative` CHECK (Room_Capacity >= 0)
);

CREATE TABLE Equipment (
    EquipmentID INT AUTO_INCREMENT PRIMARY KEY,
    Equipment_Name VARCHAR(255) NOT NULL,
    Equipment_Quantity INT NOT NULL,
    Equipment_Location VARCHAR(255) NOT NULL,
	CONSTRAINT `Equipment_Quantity_Not_Negative` CHECK (Equipment_Quantity >= 0)
);

CREATE TABLE Form (
    FormID INT AUTO_INCREMENT PRIMARY KEY,
	UserID INT NOT NULL,
    RoomID INT NOT NULL,
    Form_Date DATE NOT NULL,
    Form_Description VARCHAR(255) NOT NULL,
    User_Associate VARCHAR(255) NOT NULL,
    Room_Approval INT NOT NULL DEFAULT 0,
    Rejection_Reason VARCHAR(255) NULL,
    Form_Status VARCHAR(255) NOT NULL DEFAULT 'active',
	CONSTRAINT `UserID_fk` FOREIGN KEY (UserID) REFERENCES `User`(UserID) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT `RoomID_fk` FOREIGN KEY (RoomID) REFERENCES Room(RoomID) ON DELETE RESTRICT ON UPDATE CASCADE
);


CREATE TABLE Form_Time (
    FormID INT NOT NULL,
    TimeStart TIME NOT NULL, 
    TimeEnd TIME NOT NULL,
    PRIMARY KEY (FormID, TimeStart, TimeEnd),
	CONSTRAINT `FormID_Form_Time_fk` FOREIGN KEY (FormID) REFERENCES Form(FormID) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT `Check_TimeEnd_GreaterThan_TimeStart` CHECK (TimeEnd > TimeStart)
);

CREATE TABLE Form_Equipment (
    FormID INT NOT NULL,
    EquipmentID INT NOT NULL,
    Equipment_Quantity INT NOT NULL,
    PRIMARY KEY (FormID, EquipmentID),
	CONSTRAINT `FormID_Form_Equipment_fk` FOREIGN KEY (FormID) REFERENCES Form(FormID) ON DELETE CASCADE ON UPDATE CASCADE, 
	CONSTRAINT `EquipmentID_fk` FOREIGN KEY (EquipmentID) REFERENCES Equipment(EquipmentID) ON DELETE RESTRICT ON UPDATE CASCADE
);