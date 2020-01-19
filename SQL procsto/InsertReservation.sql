CREATE PROCEDURE `InsertReservation` (IN bar_ID INT, IN in_name varchar(150), IN in_nb INT, IN in_date datetime, IN user_ID INT)
BEGIN
	INSERT INTO event(bar_id, name, nb_persons, date, created_by)
    VALUES (bar_ID, in_name, in_nb, in_date, user_ID);
END
