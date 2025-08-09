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
			, Active
			, NOW()
			, NULL
		);    
    ELSE
		IF (SELECT R.Type FROM Reaction R WHERE R.CommentID = CommentID AND R.IP = IP LIMIT 1) = Type THEN
			SET ReactionType = '';
		ELSE
			SET ReactionType = Type;
		END IF;            
        
		UPDATE Reaction
		SET Type = ReactionType, ModifiedOn = NOW()
		WHERE CommentID = CommentID
		LIMIT 1;
	END IF;
END