USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[UpdateComment]    Script Date: 5/10/2025 9:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateComment] @CommentID INT, @Title VARCHAR(60), @Text TEXT
AS
BEGIN
	IF (SELECT COUNT(C.ID) FROM Comments C WHERE C.ID = @CommentID) = 0
		RETURN;
    
	UPDATE Comments
	SET Title = @Title, Text = @Text, ModifiedOn = GetDate()
	WHERE ID = @CommentID
END