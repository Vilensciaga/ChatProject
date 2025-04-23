CREATE PROCEDURE GetUserByEmail
    @Email NVARCHAR(255)
AS
BEGIN
    SELECT * FROM Users
    WHERE Email = @Email;
END;

EXEC GetUserByEmail @Email = 'mj@gmail.com';