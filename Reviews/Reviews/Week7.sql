-- Online Food Delivery System


-- customers, restaurants, menu_items, orders, order_items, delivery_agents, payments
create table customers(
customer_id SERIAL primary key,
name varchar(100) not null,
email varchar(150) unique not null, 
phone varchar(15) not null);

create table restaurants(
restaurant_id serial primary key,
restaurant_name varchar(100) not null,
address varchar(100), 
phone varchar(10));

create table menu_items(
item_id serial primary key,
restaurant_id int not null,
item_name varchar(100) not null,
price decimal not null check(price>0),
available boolean not null default true,

constraint fk_menu_restaurant foreign key(restaurant_id) references restaurants(restaurant_id));

create table orders(
order_id serial primary key, 
customer_id int not null, 
restaurant_id int not null,
delivery_agent_id int,
order_date timestamp default current_timestamp,
status varchar(10) not null default 'pending',
delivery_charge decimal default 0 check (delivery_charge >= 0),

constraint fk_order_customer foreign key (customer_id) references customers(customer_id),
constraint fk_order_restaurant foreign key (restaurant_id) references restaurants(restaurant_id),
constraint fk_order_agent foreign key (delivery_agent_id) references delivery_agents(delivery_agent_id),
constraint check_order_status check (status in ('pending','preparing','out_for_delivery','delivered','cancelled')));

ALTER table orders alter column status type varchar(20);

create table order_items(
order_item_id serial primary key,
order_id int not null, 
item_id int not null, 
quantity int not null check(quantity > 0),
unit_price decimal not null check (unit_price>0),
constraint fk_order_item_order foreign key (order_id) references orders(order_id) on delete cascade,
constraint fk_order_item_menu foreign key (item_id) references menu_items(item_id)
);

create table delivery_agents(
delivery_agent_id serial primary key,
name varchar(100) not null,
phone varchar(15) unique,
status varchar(20) default 'available' check (status in ('available','busy','offline')));

create table payments (
payment_id serial primary key,
order_id int unique not null,
amount decimal not null check(amount>=0),
payment_method varchar(10) not null check (payment_method in ('UPI','CARD','CASH')),
payment_status varchar(10) not null check (payment_status in ('pending','success','failed')),
payment_date timestamp default current_timestamp,

constraint fk_payment_order foreign key(order_id) references orders(order_id));


-- inserting sample data to show results of requirements
INSERT INTO customers (name, email, phone) VALUES
('Rahul Sharma', 'rahul@gmail.com', '9876543210'),
('Aman Verma', 'aman@gmail.com', '9876543211'),
('Priya Singh', 'priya@gmail.com', '9876543212'),
('Rohit Kumar', 'rohit@gmail.com', '9876543213'),
('Neha Gupta', 'neha@gmail.com', '9876543214');


INSERT INTO restaurants (restaurant_name, address, phone) VALUES
('Pizza Palace', 'Sector 17, Chandigarh', '9811111111'),
('Burger House', 'Sector 22, Chandigarh', '9822222222'),
('Food Junction', 'Sector 34, Chandigarh', '9833333333'),
('Spice Garden', 'Sector 15, Chandigarh', '9844444444'),
('South Express', 'Sector 10, Chandigarh', '9855555555');

INSERT INTO menu_items (restaurant_id, item_name, price, available) VALUES
(1, 'Margherita Pizza', 250.00, TRUE),
(1, 'Farmhouse Pizza', 350.00, TRUE),
(2, 'Veg Burger', 150.00, TRUE),
(3, 'Paneer Thali', 220.00, FALSE),
(4, 'Paneer Tikka', 280.00, TRUE);


INSERT INTO delivery_agents (name, phone, status) VALUES
('Raj Kumar', '9900000001', 'available'),
('Amit Singh', '9900000002', 'busy'),
('Vikas Sharma', '9900000003', 'available'),
('Karan Mehta', '9900000004', 'busy'),
('Arjun Verma', '9900000005', 'available');

select * from delivery_agents;

INSERT INTO orders (customer_id, restaurant_id, delivery_agent_id, 
order_date, status, delivery_charge) VALUES
(1, 1, 2, '2026-09-25 12:30:00', 'delivered', 40.00),
(2, 1, 3, '2026-09-25 13:00:00', 'delivered', 30.00),
(3, 2, 4, '2026-09-26 19:00:00', 'out_for_delivery', 35.00),
(4, 3, NULL, '2026-09-27 14:00:00', 'pending', 25.00),
(5, 4, 5, '2026-09-27 20:00:00', 'cancelled', 30.00);

select * from orders;


INSERT INTO order_items (order_id, item_id, quantity, unit_price) VALUES
(9, 1, 2, 250.00),
(10, 1, 3, 350.00),
(11, 2, 4, 250.00),
(12, 3, 3, 150.00),
(13, 4, 5, 280.00);


INSERT INTO payments (order_id, amount, payment_method, payment_status) VALUES
(9, 890.00, 'UPI', 'success'),
(10, 280.00, 'CARD', 'success'),
(11, 485.00, 'UPI', 'success'),
(12, 585.00, 'CASH', 'pending'),
(13, 310.00, 'CARD', 'failed');

-- Joins to generate complete order information.
 
select o.order_id, 
c.name as customer_name,
r.restaurant_name, 
mi.item_name,
oi.quantity,
oi.unit_price,
o.delivery_charge, 
da.name as delivery_agent, 
o.status
from orders o JOIN customers c on o.customer_id=c.customer_id
JOIN restaurants r ON o.restaurant_id = r.restaurant_id
JOIN order_items oi on o.order_id = oi.order_id
JOIN menu_items mi on oi.item_id = mi.item_id
LEFT JOIN delivery_agents da on o.delivery_agent_id = da.delivery_agent_id;

-- CTE to calculate restaurant-wise revenue.

select * from orders;
select * from order_items;
select * from restaurants;

WITH order_totals AS (
select o.order_id, o.restaurant_id,
sum(oi.quantity * oi.unit_price) + o.delivery_charge as order_total
from orders o join order_items oi on o.order_id = oi.order_id
where o.status <> 'cancelled'
group by o.order_id, o.restaurant_id, o.delivery_charge
)
select r.restaurant_name, sum(ot.order_total) as total_revenue
from order_totals ot join restaurants r on ot.restaurant_id = r.restaurant_id 
group by r.restaurant_id, r.restaurant_name
order by total_revenue desc;

-- Subquery to identify customers whose total spending exceeds the average spending.
-- subquery
-- calculate the total spending first then compare it with inner query of avg spending

select c.customer_id,c.name, SUM(oi.quantity * oi.unit_price + 0) as total_spending
from customers c JOIN orders o ON c.customer _id = o.customer_id JOIN order_items oi on o.order_id = oi.order_id
where o.status <> 'cancelled'
group by c.customer_id,c.name
having SUM(oi.quantity * oi.unit_price) > ( 
	select AVG(customer_spending) from (
		select o.customer_id, SUM(oi.quantity * oi.unit_price) AS customer_spending 
			from orders o JOIN order_items oi ON o.order_id = oi.order_id
			WHERE o.status <> 'cancelled' group by o.customer_id
	) spending
);

-- Temporary table for pending deliveries.

create TEMP table pending_deliveries AS
select order_id,customer_id,restaurant_id,delivery_agent_id,order_date,status
from orders where status = 'pending';

select * from pending_deliveries;

-- View for restaurant order summaries.

create view restaurant_order_summary AS 
select r.restaurant_id, r.restaurant_name, count(DISTINCT o.order_id) AS total_orders,
COALESCE(sum(oi.quantity*oi.unit_price),0) AS food_revenue
from restaurants r LEFT JOIN orders o ON r.restaurant_id = o.restaurant_id 
and o.status <> 'cancelled'
LEFT JOIN order_items oi ON o.order_id = oi.order_id
GROUP by r.restaurant_id,r.restaurant_name;

select * from restaurant_order_summary;


-- UDF to calculate order total including delivery charge.

create or replace function calculate_order_total(p_order_id int)
returns decimal
language plpgsql
AS $$
DECLARE
v_food_total decimal;
v_delivery_charge decimal;

BEGIN

--order total
select COALESCE(sum(quantity*unit_price),0)
into v_food_total from order_items where order_id = p_order_id;

-- delivery charge
select COALESCE(delivery_charge,0)
into v_delivery_charge from orders
where order_id = p_order_id;

return v_food_total + v_delivery_charge; --order total + delivery charge
END;
$$;

select calculate_order_total(9);

-- Stored procedure to place an order.

CREATE or REPLACE procedure place_order(p_customer_id int, p_restaurant_id int, p_item_id int, p_quantity int, p_delivery_charge decimal)
language plpgsql
as $$

DECLARE 
v_order_id int;
v_price decimal;
v_available boolean;

BEGIN
select price,available into v_price,v_available 
from menu_items where item_id = p_item_id
and restaurant_id = p_restaurant_id 
FOR UPDATE; -- locks the menu item row while op is being peformed

if not found 
then raise exception 'Menu item does not exist';
end if;

if v_available = false 
then raise exception 'Menu item is currently unavailable';
end if;

insert into orders(customer_id,restaurant_id,status,delivery_charge)
values(p_customer_id,p_restaurant_id,'pending',p_delivery_charge)
returning order_id into v_order_id;

insert into order_items(order_id,item_id,quantity,unit_price)
values(v_order_id,p_item_id,p_quantity,v_price);

end;
$$;

call place_order(4,3,4,1,25);
call place_order(1,1,1,2,40);

-- checking
SELECT item_id, restaurant_id, item_name, price, available
FROM menu_items ORDER BY item_id;

SELECT * FROM orders 
ORDER BY order_id DESC
LIMIT 1;

SELECT * FROM order_items
ORDER BY order_item_id DESC 
LIMIT 1;

-- Trigger to prevent ordering unavailable menu items.

create or replace function check_menu_item_availability()
returns trigger
language plpgsql
as $$

DECLARE v_available boolean;

BEGIN 

select available into v_available from menu_items
where item_id = NEW.item_id; --new is item_id entered during insert values

if v_available = false then
raise exception 'Cannot order unavailable menu item : %', NEW.item_id;
END IF;

return new; --this means The row passed the validation, so allow the INSERT to continue.

END;
$$;

CREATE TRIGGER trg_check_menu_item_availability 
BEFORE INSERT on order_items
for each row
execute function check_menu_item_availability();

insert into order_items(order_id,item_id,quantity,unit_price) values (9,3,2,150);
select * from order_items;

INSERT INTO order_items (order_id, item_id, quantity, unit_price)
VALUES (9, 4, 1, 220);

-- Cursor to generate delivery-agent workload.

create or replace procedure generate_delivery_workload()
language plpgsql
as $$
declare
agent_record RECORD;
workload INT;
BEGIN
for agent_record in
 select delivery_agent_id, name
 from delivery_agents 
loop
	select count(*) into workload from orders
	where delivery_agent_id = agent_record.delivery_agent_id 
	and status in ('pending','preparing','out_for_delivery');
	raise notice 'Agent: %,Workload: %', agent_record.name, workload;
END LOOP;
END;
$$;

CALL generate_delivery_workload();


-- Indexes on restaurant ID, customer ID and order status.

create index idx_orders_restaurant_id ON orders(restaurant_id);
create index idx_orders_customer_id on orders(customer_id);
create index idx_orders_status ON orders(status);

-- Demonstrate transaction and locking while placing an order.

BEGIN;

SELECT *
FROM menu_items
WHERE item_id = 101
FOR UPDATE;

BEGIN;

SELECT *
FROM menu_items
WHERE item_id = 101
FOR UPDATE; -- locks the row during a transaction to ensure consistency


-- Create restaurant/order schemas and apply DCL.

CREATE SCHEMA restaurant_schema;
CREATE SCHEMA order_schema;

CREATE TABLE restaurant_schema.restaurant_settings (
    setting_id SERIAL PRIMARY KEY,
    restaurant_name VARCHAR(100) NOT NULL,
    minimum_order_amount NUMERIC(10,2),
    delivery_available BOOLEAN DEFAULT TRUE
);

INSERT INTO restaurant_schema.restaurant_settings
(restaurant_name, minimum_order_amount, delivery_available)
VALUES
('Pizza Palace', 200, TRUE),
('Burger House', 150, TRUE),
('Food Junction', 250, TRUE),
('Spice Garden', 200, FALSE),
('South Express', 100, TRUE);

select * from restaurant_schema.restaurant_settings;


CREATE TABLE order_schema.order_processing_log (
    log_id SERIAL PRIMARY KEY,
    order_reference INT NOT NULL,
    action VARCHAR(50) NOT NULL,
    action_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO order_schema.order_processing_log
(order_reference, action)
VALUES
(9, 'ORDER_PLACED'),
(10, 'ORDER_CONFIRMED'),
(11, 'OUT_FOR_DELIVERY'),
(12, 'ORDER_PENDING'),
(13, 'ORDER_CANCELLED');

select * from order_schema.order_processing_log;

-- DCL 

CREATE ROLE restaurant_user LOGIN PASSWORD 'restaurant123';

CREATE ROLE order_user LOGIN PASSWORD 'order123';

GRANT USAGE ON SCHEMA restaurant_schema
TO restaurant_user;

GRANT SELECT, INSERT, UPDATE
ON restaurant_schema.restaurant_settings
TO restaurant_user;

GRANT USAGE ON SCHEMA order_schema
TO order_user;

GRANT SELECT, INSERT
ON order_schema.order_processing_log
TO order_user;

REVOKE UPDATE
ON restaurant_schema.restaurant_settings
FROM restaurant_user;

SELECT * FROM information_schema.role_table_grants
WHERE grantee = 'restaurant_user';

SELECT * FROM information_schema.role_table_grants
WHERE grantee = 'order_user';
