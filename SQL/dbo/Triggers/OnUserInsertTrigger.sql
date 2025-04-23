CREATE TRIGGER OnUserInsertTrigger
	ON Users
	AFTER INSERT
	AS
	BEGIN
		INSERT INTO TriggerTest(Id, email, ActionDate)
		SELECT Id, Email, GETDATE()
    FROM inserted;
	END
