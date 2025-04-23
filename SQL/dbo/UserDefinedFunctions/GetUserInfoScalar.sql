CREATE FUNCTION GetUserInfoScalar
(
	@LastName Varchar(50),
	@FirstName  Varchar(50),
	@email VarChar(50)
)
RETURNS NVarchar(150)
AS
BEGIN
	RETURN Concat( @LastName , ' ' , @FirstName , ' ' , @email);
END;


