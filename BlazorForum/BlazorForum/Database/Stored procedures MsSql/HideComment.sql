USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[HideComment]    Script Date: 5/10/2025 9:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HideComment] @CommentID INT
AS
BEGIN
	IF (SELECT COUNT(C.ID) FROM Comments C WHERE C.ID = @CommentID) = 0 
		RETURN;
    
	IF (SELECT Hidden FROM Comments C WHERE C.ID = @CommentID) = 1 
		RETURN;

	UPDATE Comments
    SET Hidden = 1, ModifiedOn = GetDate()
	WHERE ID = @CommentID;
END