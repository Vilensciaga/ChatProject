CREATE TRIGGER OnUserInsertTrigger
	ON Users
	AFTER INSERT
	AS
	BEGIN
		INSERT INTO TriggerTest(email, ActionDate)
		SELECT email, GETDATE()
    FROM inserted;
	END
