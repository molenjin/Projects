USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[IsBannedIP]    Script Date: 5/10/2025 9:50:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[IsBannedIP] @IP VARCHAR(16)
AS
BEGIN
	SELECT COUNT(B.IP) AS NumOfIPs
	FROM BannedIP B
	WHERE @IP LIKE CONCAT(B.IP, '.%');
END