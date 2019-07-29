use Dealership
go

create procedure GetAllVehicles
as
select * from Vehicle
go

create procedure AddVehicle(
	@StaffID int,
	@MakeID int,
	@ModelID int,
	@InteriorID int,
	@BodyStyle nvarchar(50),
	@Year int,
	@Transmission nvarchar(50),
	@Color nvarchar(50),
	@Mileage int,
	@VIN nvarchar(100),
	@MSRP decimal(10, 2),
	@SalePrice decimal (10, 2),
	@Description text,
	@PicturePath nvarchar(50),
	@Category nvarchar(15),
	@Featured bit,
	@Sold bit
)
as
insert into Vehicle
	values(@StaffID, @MakeID, @ModelID, @InteriorID, @BodyStyle, @Year, @Transmission, @Color, @Mileage, @VIN, @MSRP, @SalePrice, @Description, @PicturePath, @Category, @Featured, @Sold);
go

create procedure EditVehicle(
	@VehicleID int,
	@MakeID int,
	@ModelID int,
	@InteriorID int,
	@BodyStyle nvarchar(50),
	@Year int,
	@Transmission nvarchar(50),
	@Color nvarchar(50),
	@Mileage int,
	@VIN nvarchar(100),
	@MSRP decimal(10, 2),
	@SalePrice decimal (10, 2),
	@Description text,
	@PicturePath nvarchar(50),
	@Category nvarchar(15),
	@Featured bit,
	@Sold bit
)
as
update Vehicle
set 
	MakeID = @MakeID,
	ModelID = @ModelID,
	InteriorID = @InteriorID,
	BodyStyle = @BodyStyle,
	[Year] = @Year,
	Transmission = @Transmission,
	Color = @Color,
	Mileage = @Mileage,
	VIN = @VIN,
	MSRP = @MSRP,
	SalePrice = @SalePrice,
	[Description] = @Description,
	PicturePath = @PicturePath,
	Category = @Category,
	Featured = @Featured,
	Sold = @Sold
where VehicleID = @VehicleID
go
create procedure DeleteVehicle (
	@VehicleID int
)
as
delete from Vehicle where VehicleID = @VehicleID
go

create procedure GetAllMakes 
as
select * from Make
go

create procedure AddMake(
	@MakeName nvarchar(50),
	@DateAdded datetime,
	@StaffID int
)
as
insert into Make 
	values(@MakeName, @DateAdded, @StaffID);
go

create procedure GetAllModels
as
select * from Model
go

create procedure AddModel(
	@ModelName nvarchar(50),
	@MakeID int,
	@BodyStyleID int,
	@StaffID int,
	@DateAdded datetime
)
as
insert into Model 
	values(@ModelName, @MakeID, @BodyStyleID, @StaffID, @DateAdded);
go

create procedure GetAllUsers
as
select * from StaffMember
go

create procedure AddUser(
	@Name nvarchar(100),
	@Email nvarchar(100),
	@Password nvarchar(100),
	@StaffRoleID int
)
as
insert into StaffMember
	values (@Name, @Email, @Password, @StaffRoleID);
go

create procedure EditUser(
	@StaffID int,
	@Name nvarchar(100),
	@Email nvarchar(100),
	@Password nvarchar(100),
	@StaffRoleID int
)
as
update StaffMember
set
	[Name] = @Name,
	Email = @Email,
	[Password] = @Password,
	StaffRoleID = @StaffRoleID
where StaffID = @StaffID
go

create procedure GetAllStaffRoles
as
select * from StaffRole
go

create procedure GetAllContacts
as
select * from Contact
go

create procedure AddContact(
	@Name nvarchar(100),
	@Email nvarchar(100),
	@PhoneNumber nvarchar(50),
	@Message text
)
as
insert into Contact
	values (@Name, @Email, @PhoneNumber, @Message);
go

create procedure GetAllSpecials
as
select * from Special
go

create procedure AddSpecial(
	@SpecialTitle nvarchar(100),
	@SpecialDescription text
)
as
insert into Special 
	values(@SpecialTitle, @SpecialDescription);
go

create procedure DeleteSpecial(
	@SpecialID int
)
as
delete from Special where SpecialID = @SpecialID
go

create procedure GetAllColors
as
select * from Color
go

create procedure GetAllInteriors
as
select * from Interior 
go

create procedure GetAllTransmissions
as
select * from Transmission
go

create procedure GetAllStates
as
select * from State
go

create procedure GetAllVehicleSales
as
select * from VehicleSale
go

create procedure AddVehicleSale(
	@StaffID int,
	@DateSold datetime,
	@AmountSoldFor decimal(10, 2)
)
as
insert into VehicleSale
	values(@StaffID, @DateSold, @AmountSoldFor);
go

create procedure GetAllPurchases
as
select * from Purchase
go

create procedure AddPurchase(
	@Name nvarchar(100),
	@PhoneNumber nvarchar(100),
	@Email nvarchar(100),
	@Street1 nvarchar(100),
	@Street2 nvarchar(100),
	@City nvarchar(100),
	@State nvarchar(100),
	@ZipCode int,
	@PurchasePrice decimal(10, 2),
	@PurchaseType nvarchar(50),
	@PurchaseDate datetime
)
as
insert into Purchase
	values(@Name, @PhoneNumber, @Email, @Street1, @Street2, @City, @State, @ZipCode, @PurchasePrice, @PurchaseType, @PurchaseDate);
go

create procedure GetAllPurchaseTypes
as
select * from PurchaseType
go

create procedure GetAllBodyStyles
as
select * from BodyStyle
go