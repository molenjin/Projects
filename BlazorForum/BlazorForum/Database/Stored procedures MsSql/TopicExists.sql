USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[TopicExists]    Script Date: 5/10/2025 9:57:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[TopicExists] @TopicID INT
AS
BEGIN
	SELECT COUNT(C.ID) AS NumOfTopics
	FROM Comments C
	WHERE C.ID = @TopicID AND C.TopicID IS NULL;
END