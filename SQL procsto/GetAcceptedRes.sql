CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAcceptedRes`(IN bar_ID INT)
BEGIN
	select event.id,
    event.name,
    user.phone,
    user.email,
    event.nb_persons,
    event.date
    from event
    inner join user on user.id = event.created_by
    where event.bar_id = bar_ID AND event.status = 1;		
END