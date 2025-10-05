USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetUserName]    Script Date: 5/10/2025 9:49:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetUserName] @IP VARCHAR(16)
AS
BEGIN
	SELECT U.Name
	FROM Users U
	WHERE TRIM(U.IP) = TRIM(@IP)
    ORDER BY U.CreatedOn DESC
END