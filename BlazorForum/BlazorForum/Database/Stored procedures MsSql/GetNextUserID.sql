USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetNextUserID]    Script Date: 5/10/2025 10:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetNextUserID]
AS
BEGIN
	SELECT COALESCE(MAX(ID), 1000) + 1 AS NextUserID
	FROM Users;
END