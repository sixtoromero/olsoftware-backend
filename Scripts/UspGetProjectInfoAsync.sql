CREATE PROCEDURE UspGetProjectInfo
AS
	SELECT c.Names + ' ' + c.Surnames, c.Phone, p.ProjectName, p.StartDate, p.EndDate, p.Price, p.NumberHours, p.Status  FROM [dbo].[Projects] p 
	INNER JOIN [dbo].[Customers] c ON p.CustomerId = c.Id
GO
