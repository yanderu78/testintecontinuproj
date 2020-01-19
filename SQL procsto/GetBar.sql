USE `goodtime`;
DROP procedure IF EXISTS `GetBar`;

DELIMITER $$
USE `goodtime`$$
CREATE PROCEDURE `GetBar` (IN bar_ID INT)
BEGIN
	select bar.id,
		name,
        phone,
        address.latitude as lat,
        address.longitude as lon,
        '3,5' as cheaper_pint,
        concat_ws(' ', address.num, address.street, address.post_code, address.city) as adress
    from bar
    inner join address on bar.address_id = address.id
    where bar.id = bar_ID;
END$$

DELIMITER ;