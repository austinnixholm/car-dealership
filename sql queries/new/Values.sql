use Dealership
go

insert into BodyStyle (Style)
	values('Sedan'), ('SUV'), ('Hatchback'), ('Coupe'), ('Crossover'), ('Convertible'), ('Pickup'), ('Station Wagon)');

insert into Color
	values ('White'), ('Red'), ('Green'), ('Blue'), ('Black'), ('Gray'), ('Silver'), ('Yellow'), ('Orange');

insert into Interior
	values ('Black Fabric'), ('Beige'), ('Brown Leather'), ('Black Leather'), ('Gray Fabric');

insert into Transmission
	values ('Manual'), ('Automatic'), ('Hybrid'), ('Electric');

insert into PurchaseType
	values ('Dealer Finance'), ('Bank Finance'), ('Cash');

insert into StaffRole 
	values ('Sales'), ('Admin'), ('Disabled');

insert into StaffMember
	values ('John Doe', 'sample@sample.com', '123', 1),
	('Admin User', 'admin@email.com', '1234', 2);

insert into Special
	values ('TWO FOR ONE VEHICLE SPECIAL!', 'Get two vehicles for the price of one! Just don''t get held down by all of the insurance fees & taxes.'),
	('DOWN PAYMENT LUXURY SPECIAL!', 'We''ll add luxury interior, dash functions & a brand new sound system to your vehicle! Must put a down payment of at least one half of the total price of vehicle to qualify.'),
	('BUY TWO GET LIFETIME WARRANTY!', 'If you purchase two vehicle within the same day, we will provide lifetime warranty to your favorite vehicle of the two! Does not include collisions that are of the recipients fault.');

insert into [State]
	values('AL', 'Alabama'),
	('AK', 'Alaska'),
	('AZ', 'Arizona'),
	('AR', 'Arkansas'),
	('CA', 'California'),
	('CO', 'Colorado'),
	('CT', 'Connecticut'),
	('DE', 'Delaware'),
	('DC', 'District of Columbia'),
	('FL', 'Florida'),
	('GA', 'Georgia'),
	('HI', 'Hawaii'),
	('ID', 'Idaho'),
	('IL', 'Illinois'),
	('IN', 'Indiana'),
	('IA', 'Iowa'),
	('KS', 'Kansas'),
	('KY', 'Kentucky'),
	('LA', 'Louisiana'),
	('ME', 'Maine'),
	('MD', 'Maryland'),
	('MA', 'Massachusetts'),
	('MI', 'Michigan'),
	('MN', 'Minnesota'),
	('MS', 'Mississippi'),
	('MO', 'Missouri'),
	('MT', 'Montana'),
	('NE', 'Nebraska'),
	('NV', 'Nevada'),
	('NH', 'New Hampshire'),
	('NJ', 'New Jersey'),
	('NM', 'New Mexico'),
	('NY', 'New York'),
	('NC', 'North Carolina'),
	('ND', 'North Dakota'),
	('OH', 'Ohio'),
	('OK', 'Oklahoma'),
	('OR', 'Oregon'),
	('PA', 'Pennsylvania'),
	('PR', 'Puerto Rico'),
	('RI', 'Rhode Island'),
	('SC', 'South Carolina'),
	('SD', 'South Dakota'),
	('TN', 'Tennessee'),
	('TX', 'Texas'),
	('UT', 'Utah'),
	('VT', 'Vermont'),
	('VA', 'Virginia'),
	('WA', 'Washington'),
	('WV', 'West Virginia'),
	('WI', 'Wisconsin'),
	('WY', 'Wyoming');

insert into Make 
	values('Nissan', '2019-07-02', 2),
	('Toyota', '2019-07-02', 2),
	('Chevrolet', '2019-07-02', 2),
	('Hyundai', '2019-07-02', 2),
	('Ford', '2019-07-02', 2),
	('Tesla', '2019-07-02', 2),
	('Dodge', '2019-07-02', 2),
	('Jeep', '2019-07-02', 2),
	('GMC', '2019-07-02', 2),
	('Mercedes Benz', '2019-07-02', 2),
	('BMW', '2019-07-02', 2),
	('Subaru', '2019-07-02', 2);

insert into Model
	values ('Altima', 1, 1, 2, '2019-07-03'),
	('Camry', 2, 1, 2, '2019-07-03'),
	('Corolla', 2, 1, 2, '2019-07-03'),
	('Elantra GT', 4, 3, 2, '2019-07-03'),
	('Sonata', 4, 1, 2, '2019-07-03'),
	('Rogue', 1, 2, 2, '2019-07-03'),
	('Model S', 6, 1, 2, '2019-07-03'),
	('Wrangler', 8, 2, 2, '2019-07-03'),
	('Cherokee', 8, 2, 2, '2019-07-03'),
	('A-Class', 10, 1, 2, '2019-07-03'),
	('C-Class', 10, 1, 2, '2019-07-03'),
	('E-Class', 10, 1, 2, '2019-07-03'),
	('S-Class', 10, 1, 2, '2019-07-03'),
	('WRX', 12, 3, 2, '2019-07-03'),
	('Outback', 12, 3, 2, '2019-07-03'),
	('Forester', 12, 3, 2, '2019-07-03'),
	('Charger', 7, 1, 2, '2019-07-03'),
	('Challenger', 7, 1, 2, '2019-07-03'),
	('Focus', 5, 1, 2, '2019-07-03'),
	('Focus RS', 5, 3, 2, '2019-07-03'),
	('Sierra', 9, 7, 2, '2019-07-03'),
	('Acadia', 9, 2, 2, '2019-07-03'),
	('E9', 11, 4, 2, '2019-07-03'),
	('Malibu', 3, 1, 2, '2019-07-03'),
	('Suburban', 3, 2, 2, '2019-07-03');

insert into Vehicle 
	values (2, 1, 1, 2, 'Sedan', 2005, 'Automatic', 'Green', 570, '34234234234DE121VG', 7500.00, 6000.00, 'A nice green car.', '/Content/images/stockcar.jpg', 'New', 1, 0),
	(2, 4, 5, 2,'Sedan', 2012, 'Manual', 'Red', 13500, '962342K4234DE121VG', 1200.00, 800.00, 'A nice red car.', '/Content/images/stockcar.jpg', 'Used', 1, 0),
	(2, 4, 5, 2, 'Sedan', 2011, 'Automatic', 'Blue', 50320, '962342K4234DE121VG', 1200.00, 800.00, 'A nice red car.', '/Content/images/stockcar.jpg', 'Used', 1, 0);

