USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[GetNextCommentID]    Script Date: 5/10/2025 9:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetNextCommentID]
AS
BEGIN
	SELECT COALESCE(MAX(C.ID), 1000) + 1 AS NextCommentID
	FROM Comments C;
END