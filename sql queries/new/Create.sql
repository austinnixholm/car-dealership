use [master];
GO

if exists (select * from sys.databases where name = N'Dealership')
begin
	exec msdb.dbo.sp_delete_database_backuphistory @database_name = N'Dealership';
	alter DATABASE Dealership SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	drop DATABASE Dealership;
end

create database Dealership

use Dealership
GO

create table StaffRole (
	StaffRoleID int primary key identity(1, 1),
	RoleName nvarchar(50) not null,
);

create table StaffMember (
	StaffID int primary key identity(1, 1),
	[Name] nvarchar(100) not null,
	Email nvarchar(100) not null,
	[Password] nvarchar(100) not null,
	StaffRoleID int not null,
	constraint fk_StaffMember_StaffRoleID foreign key (StaffRoleID)
		references StaffRole(StaffRoleID)
);

create table Make (
	MakeID int primary key identity(1, 1),
	MakeName nvarchar(50) not null,
	DateAdded datetime not null,
	StaffID int not null,
	constraint fk_Make_StaffID foreign key (StaffID)
		references StaffMember(StaffID)
);

create table BodyStyle (
	BodyStyleID int primary key identity(1, 1),
	Style nvarchar(50) not null
);

create table Model (
	ModelID int primary key identity(1, 1),
	ModelName nvarchar(50) not null,
	MakeID int not null,
	BodyStyleID int not null,
	StaffID int not null,
	DateAdded datetime not null,
	constraint fk_Model_MakeID foreign key (MakeID)
		references Make(MakeID),
	constraint fk_Model_BodyStyleID foreign key (BodyStyleID)
		references BodyStyle(BodyStyleID),
	constraint fk_Model_StaffID foreign key (StaffID)
		references StaffMember(StaffID)
);

create table Color (
	ColorID int primary key identity(1, 1),
	ColorName nvarchar(50)
);

create table Interior (
	InteriorID int primary key identity(1, 1),
	InteriorName nvarchar(50) not null
);

create table Transmission (
	TransmissionID int primary key identity(1, 1),
	TransmissionName nvarchar(50) not null
);

create table [State] (
	StateAbbreviation nvarchar(10) primary key,
	StateName nvarchar(50) not null
);

create table VehicleSale (
	VehicleSaleID int primary key identity(1, 1),
	StaffID int not null,
	DateSold datetime not null,
	AmountSoldFor decimal(10, 2) not null,
	constraint vk_VehicleSale_StaffID foreign key (StaffID)
		references StaffMember(StaffID)
);

create table PurchaseType(
	PurchaseTypeID int primary key identity(1, 1),
	PurchaseTypeName nvarchar(50)
);

create table Special (
	SpecialID int primary key identity(1, 1),
	SpecialTitle nvarchar(100) not null,
	SpecialDescription text not null
);

create table Contact (
	ContactID int primary key identity(1, 1),
	[Name] nvarchar(100) not null,
	Email nvarchar(100) not null,
	PhoneNumber nvarchar(50) not null,
	[Message] text not null
);

create table Purchase (
	PurchaseID int primary key identity(1, 1),
	[Name] nvarchar(100) not null,
	PhoneNumber nvarchar(50) not null,
	Email nvarchar(100) not null,
	Street1 nvarchar(100) not null,
	Street2 nvarchar(100),
	City nvarchar(100) not null,
	[State] nvarchar(100) not null,
	ZipCode int not null,
	PurchasePrice decimal(10, 2) not null,
	PurchaseType nvarchar(50) not null,
	PurchaseDate datetime not null
);

create table Vehicle (
	VehicleID int primary key identity(1, 1),
	StaffID int not null,
	MakeID int not null,
	ModelID int not null,
	InteriorID int not null,
	BodyStyle nvarchar(50) not null,
	[Year] int not null,
	Transmission nvarchar(50) not null,
	Color nvarchar(50) not null,
	Mileage int not null,
	VIN nvarchar(100) not null,
	MSRP decimal (10, 2) not null,
	SalePrice decimal (10, 2) not null,
	[Description] text not null,
	PicturePath nvarchar(50) not null,
	Category nvarchar(15) not null,
	Featured bit not null,
	Sold bit not null,
	constraint fk_Vehicle_StaffID foreign key (StaffID)
		references StaffMember(StaffID),
	constraint fk_Vehicle_MakeID foreign key (MakeID)
		references Make(MakeID),
	constraint fk_Vehicle_ModelID foreign key (ModelID)
		references Model(ModelID),
	constraint fk_Vehicle_InteriorID foreign key (InteriorID)
		references Interior(InteriorID)
);