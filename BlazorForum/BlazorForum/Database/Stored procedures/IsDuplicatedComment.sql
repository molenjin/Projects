CREATE DEFINER=`accnaust_ACCN`@`101.189.80.166` PROCEDURE `IsDuplicatedComment`(Text TEXT)
BEGIN
	SELECT COUNT(C.ID) AS NumOfComments
	FROM Comment C
	WHERE TRIM(LOWER(C.Text)) = TRIM(LOWER(Text))
	AND NOW() - C.ModifiedOn < 3;
END