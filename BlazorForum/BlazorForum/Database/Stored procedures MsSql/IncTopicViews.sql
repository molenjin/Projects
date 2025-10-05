CREATE DEFINER=`accnaust_ACCN`@`101.189.80.166` PROCEDURE `IncTopicViews`(TopicID INT)
BEGIN
	UPDATE Comment
	SET Views = COALESCE(Views, 0) + 1
	WHERE (ID = TopicID OR TopicID = TopicID)
	AND Hidden = 0;
END