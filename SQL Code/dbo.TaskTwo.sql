﻿CREATE PROCEDURE [dbo].[TaskTwo]
	@pwd int
AS
	SELECT [dbo].[RecordRegistration].Book_Register_Number, [dbo].[RecordRegistration].Date_Issue, [dbo].[Book].Count_Pages, [dbo].[Book].Section
	FROM [dbo].[RecordRegistration], [dbo].[Book] WHERE 
	([dbo].[RecordRegistration].Reader_Password_Data=@pwd) AND ([dbo].[RecordRegistration].Book_Register_Number=[dbo].[Book].Register_Number);
RETURN 0
