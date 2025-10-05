USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetCommentList]    Script Date: 5/10/2025 9:48:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetCommentList] @TopicID INT, @ShowAll INT
AS
BEGIN
	SELECT
		  C.ID
		, C.TopicID
		, C.Title
		, C.Text
		, C.UserID
		, U.Name
		, U.CountryCode
		, U.IP
		, U.Active
		, U.Moderator
		, C.Hidden
		, C.Closed
		, C.Views
		, C.Reactions
        , C.CreatedOn
        , C.ModifiedOn
	FROM Comments C
	LEFT JOIN Users U ON U.ID = UserID
	WHERE (C.ID = @TopicID OR C.TopicID = @TopicID)
	AND (C.Hidden = 0 OR @ShowAll = 1)
	ORDER BY C.CreatedOn;
END;