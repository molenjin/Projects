CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `HideComment`(CommentID INT)
proc_exit: BEGIN
	IF (SELECT Hidden FROM Comment WHERE ID = CommentID) = 1 THEN
		LEAVE proc_exit;
	END IF;			

	UPDATE Comment
    SET Hidden = 1, ModifiedOn = NOW()
	WHERE ID = CommentID
	LIMIT 1;
END