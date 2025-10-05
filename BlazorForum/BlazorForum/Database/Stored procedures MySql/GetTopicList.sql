CREATE DEFINER=`accnaust_ACCN`@`101.185.215.189` PROCEDURE `GetTopicList`(ShowAll INT, PageLimit INT, PageOffset INT)
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
		, (SELECT COUNT(C.ID) FROM Comment C WHERE C.TopicID = T.ID AND C.Hidden = 0) AS NumOfComments
		, (SELECT MAX(C.CreatedOn) FROM Comment C WHERE (C.TopicID = T.ID OR C.ID = T.ID)) AS LastCommentOn
	FROM Comment T
	LEFT JOIN User U ON U.ID = T.UserID
	WHERE T.TopicID IS NULL
	AND (T.Hidden = 0 OR ShowAll = 1)
	ORDER BY LastCommentOn DESC
	LIMIT PageLimit OFFSET PageOffset;
END