CREATE DEFINER=`accnaust_ACCN`@`2001:8003:9489:4400:a0f6:2b53:7752:c55b` PROCEDURE `UpdateComment`(CommentID INT, Title VARCHAR(60), Text TEXT)
proc_exit: BEGIN
	IF (SELECT COUNT(C.ID) FROM Comment C WHERE C.ID = CommentID) = 0 THEN
		LEAVE proc_exit;
	END IF;	
    
	UPDATE Comment
	SET Title = Title, Text = Text, ModifiedOn = NOW()
	WHERE ID = CommentID
	LIMIT 1;
END