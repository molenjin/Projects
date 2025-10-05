USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[UnhideComment]    Script Date: 5/10/2025 9:57:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UnhideComment] @CommentID INT
AS
BEGIN
	IF (SELECT COUNT(C.ID) FROM Comments C WHERE C.ID = @CommentID) = 0
		RETURN;
    
	IF (SELECT Hidden FROM Comments C WHERE C.ID = @CommentID) = 0
		RETURN;

	UPDATE Comments
    SET Hidden = 0, ModifiedOn = GetDate()
	WHERE ID = @CommentID
END