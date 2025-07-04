CREATE DEFINER=`accnaust_ACCN`@`101.189.80.166` PROCEDURE `SaveSettingValue`(SearchKey VARCHAR(20), Value VARCHAR(100))
BEGIN
	UPDATE Settings S
	SET 
		  S.Value = Value
		, S.ModifiedOn = NOW()
	WHERE S.Key = SearchKey;
END