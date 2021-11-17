USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_kiemtratontaiuser]    Script Date: 11/17/2021 06:30:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_kiemtratontaiuser]
@user NVARCHAR(50)
AS
BEGIN
SELECT NAME FROM SYS.sysusers WHERE NAME= @user
END

GO

