USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_layloginname]    Script Date: 11/17/2021 06:30:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_layloginname] @tenlogin VARCHAR(50)	--tenlogin là truyền mã nhân viên
AS
BEGIN
	DECLARE @SID VARBINARY(85)
	SELECT @SID = sid FROM sys.sysusers WHERE name = @tenlogin
	IF (@SID IS NULL)
		RAISERROR('K TIM THAY SID',16,1)
	ELSE
	BEGIN
		DECLARE @LGNAME VARCHAR(50)
		SELECT @LGNAME = loginname FROM sys.syslogins WHERE sid = @SID
		IF(@LGNAME IS NULL)
			RAISERROR('K TIM THAY LGNAME',16,1)
		ELSE
			select @LGNAME
	END
END

GO

