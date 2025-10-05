CREATE DEFINER=`accnaust_ACCN`@`101.189.80.166` PROCEDURE `GetSettingValueList`(SearchKey VARCHAR(20))
BEGIN
	SELECT 
		  S.Key
		, S.Value
		, S.CreatedOn
		, S.ModifiedOn
	FROM Settings S
	WHERE S.Key = SearchKey;
END