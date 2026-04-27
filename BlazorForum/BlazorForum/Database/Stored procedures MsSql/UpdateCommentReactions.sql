USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCommentReactions]    Script Date: 18/04/2026 2:05:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateCommentReactions] @CommentID INT
AS
BEGIN
	DECLARE @Reactions VARCHAR(40);
	   
    SET @Reactions = 
    (
		SELECT STRING_AGG(T.Type + CAST(T.Count AS VARCHAR), ';') FROM
		(
			SELECT TOP 100	
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
			FROM [dbo].[Reactions] R
			WHERE R.CommentID = @CommentID
			GROUP BY R.Type
			ORDER BY Count(R.Type) DESC, TypeOrder DESC
		) T
    );
    
	UPDATE Comments
	SET Reactions = @Reactions, ModifiedOn = GetDate()
	WHERE ID = @CommentID;
END