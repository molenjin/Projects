USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[SaveComment]    Script Date: 5/10/2025 9:56:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaveComment] @CommentID INT, @TopicID INT, @Title VARCHAR(60), @Text TEXT, @UserID INT, @Hidden INT, @Closed INT
AS
BEGIN
	INSERT INTO Comments
	VALUES
	(
		  @CommentID
		, @TopicID
		, @Title
		, @Text
		, @UserID
		, @Hidden
		, @Closed
		, 1
		, NULL
		, GetDate()
		, NULL
	);
END