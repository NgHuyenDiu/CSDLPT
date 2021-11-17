USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_kiemtratontailogin]    Script Date: 11/17/2021 06:29:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_kiemtratontailogin]
@TENLOGIN NVARCHAR(50)
AS
BEGIN
SELECT NAME FROM SYS.SYSLOGINS WHERE NAME= @TENLOGIN
END


GO

