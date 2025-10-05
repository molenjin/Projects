CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `UnhideComment`(CommentID INT)
proc_exit: BEGIN
	IF (SELECT COUNT(C.ID) FROM Comment C WHERE C.ID = CommentID) = 0 THEN
		LEAVE proc_exit;
	END IF;	
    
	IF (SELECT Hidden FROM Comment C WHERE C.ID = CommentID) = 0 THEN
		LEAVE proc_exit;
	END IF;			

	UPDATE Comment
    SET Hidden = 0, ModifiedOn = NOW()
	WHERE ID = CommentID
	LIMIT 1;
END