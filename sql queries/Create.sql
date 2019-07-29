go

create table Special (
	SpecialID int primary key identity(1, 1),
	SpecialTitle nvarchar(100) not null,
	SpecialDescription text not null
);

create table StaffRole (
	RoleID int primary key identity(1, 1),
	RoleName nvarchar(50) not null
);

create table Staff (
	StaffID int primary key identity(1, 1),
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(75) not null,
	StaffRoleID int not null,
	constraint fk_Staff_StaffRoleID foreign key (StaffRoleID) 
		references StaffRole(RoleID)
);

create table Contact (
	ContactID int primary key identity(1, 1),
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(75) not null,
	PhoneNumber nvarchar(15) not null,
	StreetAddress1 nvarchar(100) not null,
	StreetAddress2 nvarchar(100),
	City nvarchar(50) not null,
	[State] nvarchar(50) not null,
	ZipCode int not null,
);

create table PurchaseType (
	PurchaseTypeID int primary key identity(1, 1),
	[Type] nvarchar(50) not null
);

create table Customer (
	CustomerID int primary key identity(1, 1),
	ContactID int not null,
	PurchasePrice decimal(15, 2) not null,
	PurchaseTypeID int not null,
	constraint fk_Customer_PurchaseType foreign key (PurchaseTypeID)
		references PurchaseType(PurchaseTypeID)
);

create table Make (
	MakeID int primary key identity(1, 1),
	MakeName nvarchar(50) not null
);

create table Model (
	ModelID int primary key identity(1, 1),
	ModelName nvarchar(100) not null,
	MakeID int not null,
	constraint fk_Model_MakeID foreign key (MakeID)
		references Make(MakeID)
);

create table Vehicle (
	VehicleID int primary key identity(1, 1),
	StaffID int not null,
	BodyStyle nvarchar(75) not null,
	[Year] int not null,
	Transmission nvarchar(50) not null,
	Color nvarchar(50) not null,
	Interior nvarchar(50) not null,
	Mileage int not null,
	VIN nvarchar(100) not null,
	MSRP decimal(15, 2) not null,
	SalePrice decimal (15, 2) not null,
	[Description] text not null,
	PicturePath nvarchar(150) not null,
	Featured bit not null,
	constraint fk_Vehicle_StaffID foreign key (StaffID)
		references Staff(StaffID)
);

create table MakeModelVehicle (
	VehicleID int not null,
	ModelID int not null,
	MakeID int not null,
	primary key (VehicleID, ModelID, MakeID),
	constraint fk_MakeModelVehicle_VehicleID foreign key (VehicleID)
		references Vehicle(VehicleID),
	constraint fk_MakeModelVehicle_ModelID foreign key (ModelID)
		references Model(ModelID),
	constraint fk_MakeModelVehicle_MakeID foreign key (MakeID)
		references Make(MakeID)
);