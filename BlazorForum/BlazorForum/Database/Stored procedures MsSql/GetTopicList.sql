USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetTopicList]    Script Date: 5/10/2025 9:49:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetTopicList] @ShowAll INT, @PageLimit INT, @PageOffset INT
AS
BEGIN
	SELECT
		  T.ID
		, T.TopicID
		, T.Title
		, U.Name
		, U.CountryCode
		, U.Active
		, U.Moderator
		, T.Hidden
		, (SELECT COUNT(C.ID) FROM Comments C WHERE C.TopicID = T.ID AND C.Hidden = 0) AS NumOfComments
		, (SELECT MAX(C.CreatedOn) FROM Comments C WHERE (C.TopicID = T.ID OR C.ID = T.ID)) AS LastCommentOn
	FROM Comments T
	LEFT JOIN Users U ON U.ID = T.UserID
	WHERE T.TopicID IS NULL
	AND (T.Hidden = 0 OR @ShowAll = 1)
	ORDER BY LastCommentOn DESC
	OFFSET @PageOffset ROWS
	FETCH NEXT @PageLimit ROWS ONLY;
END