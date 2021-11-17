USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_timvattu]    Script Date: 11/17/2021 07:42:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_timvattu]
@MAVT nchar(4)
AS
BEGIN
	IF EXISTS (SELECT MAVT FROM dbo.Vattu WHERE MAVT = @mavt)
		RETURN 1;
	ELSE
		RAISERROR(N'Vật tư bạn tìm không tồn tại',16,1)
END
GO

