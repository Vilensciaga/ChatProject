CREATE FUNCTION dbo.GetFullName (@Id INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        FirstName + ' ' + LastName  AS FullName
    FROM 
        Users
    WHERE 
        Id = @Id
);


--SELECT FullName FROM dbo.GetFullName(3);
