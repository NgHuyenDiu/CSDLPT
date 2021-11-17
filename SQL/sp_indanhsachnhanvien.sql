USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_indanhsachnhanvien]    Script Date: 11/17/2021 06:29:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_indanhsachnhanvien]
AS
BEGIN
	SELECT MANV AS 'Mã NV', HO + ' ' + TEN AS 'Họ tên', DIACHI AS 'Địa chỉ', NGAYSINH AS 'Ngày sinh', LUONG AS 'Lương'
	FROM dbo.NhanVien
	ORDER BY TEN, HO
END

GO

