CREATE DATABASE MNCoffee;
drop database MNCoffee;

USE MNCoffee;

CREATE TABLE Staffs(
	staff_id int auto_increment primary key,
    staff_name nvarchar(50),
    user_name nvarchar(50),
    user_pass nvarchar(50),
    staff_phone nvarchar(20),
    role int not null default 1
);


CREATE TABLE Customers(
	customer_id int auto_increment primary key,
    customer_name nvarchar(50),
    customer_phone int
);

CREATE TABLE CoffeeTables(
	coffeeTable_no int primary key,
    coffeeTable_desception nvarchar(50)
);

CREATE TABLE Items(
	item_id int auto_increment primary key,
    item_name nvarchar(50),
    item_price double,
    item_size nvarchar(10),
    item_description nvarchar(500)
);

CREATE TABLE Categories(
	category_id int primary key,
    category_name nvarchar(50)
);

CREATE TABLE ItemsDetails(
	item_id int,
    category_id int,
    constraint fk_ItemsDetails_Items foreign key (item_id) references Items(item_id),
    constraint fk_ItemsDetails_Categories foreign key (category_id) references Categories(category_id),
    constraint pk_ItemsDetails primary key (item_id, category_id)
);

CREATE TABLE Invoices(
	invoice_no int auto_increment primary key,
    invoice_date datetime default now() not null,
    invoice_status nvarchar(20),
    customer_id int,
    staff_id int,
    coffeeTable_no int
);
drop table InvoiceDetails;
CREATE TABLE InvoiceDetails(
	invoice_no int ,
    item_id int ,
    amount int,
    price double,
    coffeeTable_no int,
    quantity int,
    constraint fk_InvoiceDetails_Items foreign key (item_id) references Items(item_id),
    constraint fk_InvoiceDetails_Invoices foreign key (invoice_no) references Invoices(invoice_no),
    constraint fk_InvoiceDetails_CoffeeTables foreign key (coffeeTable_no) references CoffeeTables(coffeeTable_no),
    constraint pk_InvoiceDetails primary key (item_id, invoice_no, coffeeTable_no)
);

delimiter $$
create trigger tg_before_insert before insert
	on Items for each row
    begin
		if new.item_id < 0 then
            signal sqlstate '45001' set message_text = 'tg_before_insert: id must > 0';
        end if;
    end $$
delimiter ;

delimiter $$
create procedure sp_createCustomer(IN customerName nvarchar(50), IN customerPhone int, OUT customerId int)
begin
	insert into Customers(customer_name, customer_phone) values (customerName, customerPhone); 
    select max(customer_id) into customerId from Customers;
end $$
delimiter ;

call sp_createCustomer('no name','21', @cusId);
select @cusId;

INSERT INTO Items(item_name,item_price,item_size,item_description) VALUES 
( 'ca phe sua da', '100000', 'M', 'ca phe sua them da' ),
( 'ca phe sua', '20000', 'L', 'ca phe da' ),
( 'nuoc ep cam', '9000', 'M', 'cam nguyen chat' );
select * from Items;

INSERT INTO CoffeeTables(coffeeTable_no,coffeeTable_description) VALUES 
( '1', 'ban 2 nguoi' ),
( '2', 'ban 3 nguoi' ),
( '3', 'ban 4 nguoi' );
select * from CoffeeTables;

INSERT INTO Customers(customer_name,customer_phone) VALUE
('Pham Quan', '01234567'),
('Nguyen Hoang', '6454884');
select * from Customers;

INSERT INTO Categories VALUE ('1', 'ca phe');
INSERT INTO Categories VALUE ('2', 'nuoc ep');
select * from Categories;

CREATE USER IF NOT EXISTS 'hongquan'@'localhost' identified by 'hongquan22';
grant all on MNCoffee.* to 'hongquan'@'localhost';
insert into Staffs(staff_name, user_name, user_pass, role) values
								-- Hongquan202
				('HongQuan', 'hongquan1', 'a67ced6fde6e7d773d810ae87a33b35e', 1);
                
Select * from Staffs;

select * from Items where item_name like '%n%';
select * from Items;

select item_id, item_name, item_price, item_size, ifnull(item_description, '') as item_description from Items where item_id = 1;

select item_id, item_name, item_price, item_size, ifnull(item_description, '') as item_description from Items where item_name Like '%e%'
