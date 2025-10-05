USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[DeleteComment]    Script Date: 5/10/2025 9:48:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteComment] @CommentID INT
AS
BEGIN
	DELETE FROM Comments
	WHERE ID = @CommentID
END;