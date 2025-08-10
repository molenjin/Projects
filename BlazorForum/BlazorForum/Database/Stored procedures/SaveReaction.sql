CREATE DEFINER=`accnaust_ACCN`@`101.185.177.147` PROCEDURE `SaveReaction`(Type CHAR, CommentID INT, IP VARCHAR(16))
BEGIN
	DECLARE ReactionType CHAR;
    
	IF (SELECT COUNT(Type) FROM Reaction R WHERE R.CommentID = CommentID AND R.IP = IP) = 0 THEN
		INSERT INTO Reaction
		VALUES
		(
			  Type
			, CommentID
			, IP
			, NOW()
			, NULL
		);    
    ELSE
		IF (SELECT R.Type FROM Reaction R WHERE R.CommentID = CommentID AND R.IP = IP LIMIT 1) = Type THEN
			DELETE FROM Reaction
			WHERE CommentID = CommentID
			LIMIT 1;
		ELSE
			UPDATE Reaction
			SET Type = Type, ModifiedOn = NOW()
			WHERE CommentID = CommentID
			LIMIT 1;
		END IF;

	END IF;
END