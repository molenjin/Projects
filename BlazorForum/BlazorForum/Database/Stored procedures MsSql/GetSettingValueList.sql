USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetSettingValueList]    Script Date: 5/10/2025 9:49:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetSettingValueList] @SearchKey VARCHAR(20)
AS
BEGIN
	SELECT 
		  S.KeyName
		, S.Value
		, S.CreatedOn
		, S.ModifiedOn
	FROM Settings S
	WHERE S.KeyName = @SearchKey;
END