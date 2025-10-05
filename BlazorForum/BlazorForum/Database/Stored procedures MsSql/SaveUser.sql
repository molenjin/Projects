USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 5/10/2025 9:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaveUser] @ID INT, @Name VARCHAR(20), @CountryCode VARCHAR(2), @IP VARCHAR(16), @Active INT, @Moderator INT
AS
BEGIN
	INSERT INTO Users
	VALUES
	(
		  @ID
		, @Name
		, @CountryCode
		, @IP
		, @Active
		, @Moderator
		, GetDate()
		, NULL
	);
END