CREATE DEFINER=`accnaust_ACCN`@`101.189.80.166` PROCEDURE `IsDuplicatedTitle`(Title TEXT)
BEGIN
	IF Title IS NULL
    THEN
		SELECT 0;
	ELSE
		SELECT COUNT(C.ID) AS NumOfComments    
		FROM Comment C
		WHERE TRIM(LOWER(C.Title)) = TRIM(LOWER(Title));
    END IF;
END