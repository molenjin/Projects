USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCommentReactions]    Script Date: 5/10/2025 9:57:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateCommentReactions] @CommentID INT
AS
BEGIN
	DECLARE @Reactions VARCHAR(40);
	/*   
    SET @Reactions = 
    (
		SELECT 
			GROUP_CONCAT(T.Type, T.Count, ';' SEPARATOR '')
		FROM
		(	
			SELECT 
				R.Type AS Type, 
				Count(R.Type) AS Count,
                CASE R.Type 
					WHEN 'L' THEN 6
                    WHEN 'H' THEN 5
                    WHEN 'F' THEN 4
                    WHEN 'W' THEN 3
                    WHEN 'S' THEN 2
                    WHEN 'A' THEN 1
                    ELSE 0
				END AS TypeOrder
			FROM Reaction R
			WHERE R.CommentID = CommentID
			GROUP BY R.Type, TypeOrder
			ORDER BY COUNT(R.Type) DESC, SUM(TypeOrder) DESC
		) T
    );
    
	UPDATE Comments
	SET Reactions = Reactions, ModifiedOn = NOW()
	WHERE ID = CommentID
    */
END