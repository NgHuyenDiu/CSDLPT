USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaNVkhongtaikhoan]    Script Date: 11/21/2021 09:13:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undoxoaNVkhongtaikhoan]
@MANV int , @HO nvarchar(40), @TEN nvarchar(10), @DIACHI nvarchar(100), @NGAYSINH nvarchar(50),@LUONG float , @MACN nchar(10), @TrangThaiXoa int
AS
BEGIN
	insert into NhanVien (MANV, HO, TEN, DIACHI, NGAYSINH, LUONG, MACN, TrangThaiXoa) Values(@MANV, @HO ,@TEN ,@DIACHI ,@NGAYSINH ,@LUONG,@MACN ,@TrangThaiXoa)
END

GO

