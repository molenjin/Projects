CREATE DEFINER=`accnaust_ACCN`@`101.185.215.189` PROCEDURE `GetCommentList`(TopicID INT, ShowAll INT)
BEGIN
	SELECT
		  C.ID           AS ID
		, C.TopicID      AS TopicID
		, C.Title        AS Title
		, C.Text         AS Text
		, C.UserID       AS UserID
		, U.Name         AS UserName
		, U.CountryCode  AS UserCountryCode
		, U.IP           AS UserIP
		, U.Active       AS UserActive
		, U.Moderator    AS UserModerator
		, C.Hidden       AS Hidden
		, C.Closed       AS Closed
		, C.Views        AS Views
		, C.CreatedOn    AS CreatedOn
		, C.ModifiedOn   AS ModifiedOn
	FROM Comment C
	LEFT JOIN ser U ON U.ID = UserID
	WHERE ((C.ID = @TopicID) OR (C.TopicID = @TopicID))
	AND ((C.Hidden = 0) OR (@ShowAll = 1))
	ORDER BY CreatedOn;
END