-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UserInfoProcedure
	-- Add the parameters for the stored procedure here
	@Filter varchar(50),
	@UserName varchar(50) = null,
	@NewUserName varchar(50) = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	If @Filter = 'Create'
	BEGIN
		Insert into UserInfo (UserName) values (@UserName);
	END
	ELSE
	If @Filter = 'Read'
	BEGIN
		SELECT * FROM UserInfo;
	END
	ELSE
	IF @Filter = 'Update'
	BEGIN
		UPDATE UserInfo SET UserName = @NewUserName WHERE UserName = @UserName;
	END
	ELSE
	IF @Filter = 'Delete'
	BEGIN
		DELETE FROM UserInfo WHERE UserName = @UserName;
	END
END
GO
