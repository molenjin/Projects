CREATE DEFINER=`accnaust_ACCN`@`101.185.215.189` PROCEDURE `SaveComment`(ID INT, TopicID INT, Title VARCHAR(60), Text TEXT, UserID INT, Hidden INT, Closed INT)
BEGIN
	INSERT INTO Comment
	VALUES
	(
		  ID
		, TopicID
		, Title
		, Text
		, UserID
		, Hidden
		, Closed
		, 1
		, NOW()
		, NULL
	);
END