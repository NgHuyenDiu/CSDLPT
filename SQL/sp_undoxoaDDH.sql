USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaDDH]    Script Date: 11/21/2021 09:13:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undoxoaDDH]
 @MasoDDH nchar(8), @NGAY nvarchar(50), @NhaCC nvarchar(100), @MANV int, @MAKHO nchar(4)
AS
BEGIN
	insert into  DatHang(MasoDDH, NGAY, NHACC, MANV, MAKHO) values( @MasoDDH, @NGAY,  @NhaCC, @MANV, @MAKHO  ) 
END

GO

