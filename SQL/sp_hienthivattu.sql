USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_hienthivattu]    Script Date: 11/21/2021 09:17:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_hienthivattu]
AS
	SET NOCOUNT ON;
select MAVT, TENVT, SOLUONGTON from Vattu

GO

