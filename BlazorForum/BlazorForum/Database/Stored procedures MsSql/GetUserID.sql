USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetUserID]    Script Date: 5/10/2025 9:49:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetUserID] @Name VARCHAR(20), @IP VARCHAR(16)
AS
BEGIN
	SELECT U.ID
	FROM Users U
	WHERE TRIM(LOWER(U.Name)) = TRIM(LOWER(@Name)) 
    AND TRIM(U.IP) = TRIM(@IP);
END