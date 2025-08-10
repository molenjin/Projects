CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `UpdateCommentReactions`(CommentID INT)
BEGIN
	DECLARE Reactions VARCHAR(40);
   
    SET Reactions = 
    (
		SELECT 
			GROUP_CONCAT(T.Type, T.Count, ';' SEPARATOR '')
		FROM
		(	
			SELECT 
				R.Type AS Type, 
				Count(R.Type) AS Count
			FROM Reaction R
			WHERE R.CommentID = CommentID
			GROUP BY R.Type
			ORDER BY COUNT(R.Type) DESC
		) T
    );
    
	UPDATE Comment
	SET Reactions = Reactions, ModifiedOn = NOW()
	WHERE ID = CommentID
	LIMIT 1;
    
END