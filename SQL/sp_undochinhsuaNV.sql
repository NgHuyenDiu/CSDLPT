USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undochinhsuaNV]    Script Date: 11/21/2021 09:08:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undochinhsuaNV]
@MANV int , @HO nvarchar(40), @TEN nvarchar(10), @DIACHI nvarchar(100), @NGAYSINH nvarchar(50),@LUONG float , @MACN nchar(10), @TrangThaiXoa int
AS
BEGIN
	Update NhanVien Set HO=@HO ,TEN=@TEN ,DIACHI= @DIACHI ,NGAYSINH=@NGAYSINH ,LUONG=@LUONG,MACN=@MACN ,TrangThaiXoa=@TrangThaiXoa where MANV= @MANV
END

GO

