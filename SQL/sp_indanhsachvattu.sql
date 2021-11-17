USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_indanhsachvattu]    Script Date: 11/17/2021 06:29:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_indanhsachvattu]
AS
BEGIN
	SELECT MAVT as 'Mã vật tư', TENVT as 'Tên vật tư', DVT as 'Đơn vị tính'
	FROM Vattu
	ORDER BY TENVT ASC
END

GO

