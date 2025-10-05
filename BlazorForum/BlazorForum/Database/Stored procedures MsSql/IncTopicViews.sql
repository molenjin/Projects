USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[IncTopicViews]    Script Date: 5/10/2025 9:50:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[IncTopicViews] @TopicID INT
AS
BEGIN
	UPDATE Comments
	SET Views = COALESCE(Views, 0) + 1
	WHERE (ID = @TopicID OR TopicID = @TopicID)
	AND Hidden = 0;
END