USE `goodtime`;
DROP procedure IF EXISTS `GetAllBars`;

DELIMITER $$
USE `goodtime`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllBars`()
BEGIN
	select bar.id,
		name,
        phone,
        address.latitude as lat,
        address.longitude as lon,
        '3,5' as cheaper_pint,
        concat_ws(' ', address.num, address.street, address.post_code, address.city) as adress
    from bar
    inner join address on bar.address_id = address.id;
END$$

DELIMITER ;