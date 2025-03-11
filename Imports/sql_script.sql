CREATE TABLE product_types
(
	product_type_id serial PRIMARY KEY,
	product_type_name varchar(255) NOT NULL UNIQUE, 
	type_coefficient decimal(10,2) NOT NULL CHECK (type_coefficient > 0)
);

CREATE TABLE products
(
	product_id serial PRIMARY KEY,
	product_name varchar(255) NOT NULL,
	articul varchar(255) NOT NULL UNIQUE,
	min_cost decimal NOT NULL CHECK (min_cost > 0),
	product_type_id int NOT NULL REFERENCES product_types(product_type_id)
);

CREATE TABLE partner_types
(
	partner_type_id serial PRIMARY KEY,
	partner_type_name varchar(255) NOT NULL UNIQUE
);

CREATE TABLE partners
(
	partner_id serial PRIMARY KEY,
	partner_name varchar(255) NOT NULL,
	partner_type int NOT NULL REFERENCES partner_types(partner_type_id),
	CEO_name varchar(255) NOT NULL,
	partner_email varchar(50) NOT NULL,
	partner_phone varchar(30) NOT NULL,
	partner_address varchar(255) NOT NULL,
	TIN varchar(20) NOT NULL UNIQUE,
	discount decimal(5, 2),
	rating decimal(2,0) CHECK (rating > 0)
);

CREATE TABLE partner_products
(
	product_id int NOT NULL REFERENCES products(product_id),
	partner_id int NOT NULL REFERENCES partners(partner_id),
	amount int NOT NULL CHECK (amount > 0),
	sell_date date NOT NULL,
	PRIMARY KEY (product_id, partner_id)
);