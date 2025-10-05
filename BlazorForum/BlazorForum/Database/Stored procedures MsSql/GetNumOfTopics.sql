USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetNumOfTopics]    Script Date: 5/10/2025 9:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetNumOfTopics] @ShowAll INT
AS
BEGIN
	SELECT COUNT(ID) AS NumOfTopics
	FROM Comments
	WHERE TopicID IS NULL
	AND (Hidden = 0 OR @ShowAll = 1);
END