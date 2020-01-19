CREATE DEFINER=`root`@`localhost` PROCEDURE `GetMenuItem`(IN bar_ID INT)
BEGIN
	select item.id
    from item
    inner join menu_item on menu_item.item_id = item.id
    inner join menu on menu.id = menu_item.menu_id
    where menu.bar_id = bar_ID;
END