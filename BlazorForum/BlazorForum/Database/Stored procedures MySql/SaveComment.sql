CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `SaveComment`(CommentID INT, TopicID INT, Title VARCHAR(60), Text TEXT, UserID INT, Hidden INT, Closed INT)
BEGIN
	INSERT INTO Comment
	VALUES
	(
		  CommentID
		, TopicID
		, Title
		, Text
		, UserID
		, Hidden
		, Closed
		, 1
		, NULL
		, NOW()
		, NULL
	);
END