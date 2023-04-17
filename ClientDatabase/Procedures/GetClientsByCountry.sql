CREATE PROCEDURE [dbo].[GetClientsByCountry]
	@CountryName varchar(25)
AS
	SELECT 
	[Id],
	[Name],
	[LastName],
	[Age],
	[Phone],
	[Direction],
	[Country]
	FROM [dbo].Client where Country = @CountryName
RETURN 0
