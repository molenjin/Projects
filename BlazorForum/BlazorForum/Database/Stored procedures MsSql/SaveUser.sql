CREATE DEFINER=`accnaust_ACCN`@`101.185.215.189` PROCEDURE `SaveUser`(ID INT, Name VARCHAR(20), CountryCode VARCHAR(2), IP VARCHAR(16), Active INT, Moderator INT)
BEGIN
	INSERT INTO User
	VALUES
	(
		  ID
		, Name
		, CountryCode
		, IP
		, Active
		, Moderator
		, NOW()
		, NULL
	);
END