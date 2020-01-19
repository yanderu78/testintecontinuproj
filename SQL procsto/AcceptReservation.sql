CREATE PROCEDURE `AcceptReservation` (IN res_ID INT)
BEGIN
	UPDATE event SET status = 1
    where res_ID = id;
END
