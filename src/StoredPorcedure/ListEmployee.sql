IF NOT EXISTS (SELECT 'X' FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.ListEmployee'))   
exec('CREATE PROCEDURE [dbo].[ListEmployee] AS BEGIN SET NOCOUNT ON; END')
GO
ALTER procedure dbo.[ListEmployee] 
@employeeId int = NULL
AS
BEGIN

	DECLARE @temp1 int 
	SET @temp1 = 1
	
	select * from TblEmployee 
	where EmployeeId = IsNull(@employeeId, EmployeeId)
	
END	

--exec dbo.ListEmployee 

