USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[IsDuplicatedTitle]    Script Date: 5/10/2025 9:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[IsDuplicatedTitle] @Title VARCHAR(60)
AS
BEGIN
	IF @Title IS NULL
		SELECT 0;
	ELSE
	BEGIN
		SELECT COUNT(C.ID) AS NumOfComments    
		FROM Comments C
		WHERE TRIM(LOWER(C.Title)) = TRIM(LOWER(@Title));
    END;
END