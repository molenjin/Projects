CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `UpdateComment`(CommentID INT, Title VARCHAR(60), Text TEXT)
proc_exit: BEGIN
	IF (SELECT COUNT(C.ID) FROM Comment C WHERE C.ID = CommentID) = 0 THEN
		LEAVE proc_exit;
	END IF;	
    
	UPDATE Comment
	SET Title = Title, Text = Text, ModifiedOn = NOW()
	WHERE ID = CommentID
	LIMIT 1;
END