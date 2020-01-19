CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteMenuItem`(IN item_ID INT)
BEGIN
	DELETE FROM menu_item where item_ID = menu_item.item_id;
    DELETE FROM item where item_ID = item.id;
END