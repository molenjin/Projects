CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `GetCommentList`(TopicID INT, ShowAll INT)
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
	FROM Comment C
	LEFT JOIN User U ON U.ID = UserID
	WHERE (C.ID = TopicID OR C.TopicID = TopicID)
	AND (C.Hidden = 0 OR ShowAll = 1)
	ORDER BY C.CreatedOn;
END