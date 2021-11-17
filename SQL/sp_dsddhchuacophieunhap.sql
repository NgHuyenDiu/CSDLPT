USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_dsddhchuacophieunhap]    Script Date: 11/17/2021 06:28:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_dsddhchuacophieunhap] AS
BEGIN
  SELECT DH.MasoDDH AS 'Mã số DDH', DH.NGAY AS 'Ngày Đặt', DH.NhaCC AS 'Nhà Cung Cấp',
      TENNV AS 'Họ và Tên', VT.TENVT AS 'Tên vật tư', CT.SOLUONG as 'Số lượng', CT.DONGIA as 'Đơn giá'
 
FROM
		(	SELECT MasoDDH,Ngay,NhaCC, MANV 
			FROM dbo.DatHang
			WHERE DatHang.MasoDDH not in (SELECT MasoDDH FROM dbo.PhieuNhap)
		) DH,
		(
			SELECT MANV,TENNV = HO +' ' +Ten FROM dbo.NhanVien
		) NV,
		(
			SELECT MAVT,TENVT FROM dbo.Vattu
		) VT, CTDDH CT
WHERE (NV.MANV = DH.MANV) AND (VT.MAVT =CT.MAVT) AND (CT.MasoDDH = DH.MasoDDH)
END

GO

