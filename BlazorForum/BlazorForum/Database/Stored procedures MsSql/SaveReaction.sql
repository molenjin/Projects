USE [accnaust]
GO
/****** Object:  StoredProcedure [dbo].[SaveReaction]    Script Date: 5/10/2025 9:56:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaveReaction] @Type CHAR, @CommentID INT, @IP VARCHAR(16)
AS
BEGIN
	DECLARE @ReactionType CHAR;
    
	IF (SELECT COUNT(@Type) FROM Reactions R WHERE R.CommentID = @CommentID AND R.IP = @IP) = 0 
	BEGIN
		INSERT INTO Reactions
		VALUES
		(
			  @Type
			, @CommentID
			, @IP
			, GetDate()
			, NULL
		)
	END	
    ELSE
	BEGIN
		IF (SELECT R.Type FROM Reactions R WHERE R.CommentID = CommentID AND R.IP = IP) = @Type 
		BEGIN
			DELETE FROM Reactions
			WHERE CommentID = @CommentID
		END
		ELSE
		BEGIN
			UPDATE Reactions
			SET Type = @Type, ModifiedOn = GetDate()
			WHERE CommentID = @CommentID
		END

	END
END