CREATE PROCEDURE `InsertMenuItem` (IN in_name varchar(100), IN in_price float, IN bar_ID INT)
BEGIN
	INSERT INTO item(name)
    VALUES (in_name);
    INSERT INTO menu_item(price)
    VALUES (in_price);
    INSERT INTO menu(bar_id)
    VALUES (bar_ID);
END
