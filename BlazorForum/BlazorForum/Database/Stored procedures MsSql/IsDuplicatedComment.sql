USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[IsDuplicatedComment]    Script Date: 5/10/2025 9:56:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[IsDuplicatedComment] @Text TEXT
AS
BEGIN
	SELECT COUNT(C.ID) AS NumOfComments
	FROM Comments C
	WHERE TRIM(LOWER(C.Text)) = TRIM(LOWER(@Text))
	AND DATEDIFF(DAY, C.CreatedOn, GetDate()) < 3;
END