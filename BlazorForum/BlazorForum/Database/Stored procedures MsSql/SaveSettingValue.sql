USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[SaveSettingValue]    Script Date: 5/10/2025 9:56:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaveSettingValue] @SearchKey VARCHAR(20), @Value VARCHAR(100)
AS
BEGIN
	UPDATE Settings
	SET 
		Value = @Value,
		ModifiedOn = GetDate()
	WHERE KeyName = @SearchKey;
END