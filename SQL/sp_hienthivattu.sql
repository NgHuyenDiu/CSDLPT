USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_hienthivattu]    Script Date: 12/13/2021 03:33:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_hienthivattu]
AS
	SET NOCOUNT ON;
SELECT MAVT, TENVT, SOLUONGTON FROM Vattu
GO

