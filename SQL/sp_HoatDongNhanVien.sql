USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien]    Script Date: 11/17/2021 06:29:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_HoatDongNhanVien]
@MANV int,
@FROM DATE, 
@TO DATE
AS
BEGIN
		SET NOCOUNT ON;
			IF 1=0 BEGIN
			SET FMTONLY OFF
		END
	SELECT FORMAT(PN.NGAY,'MM-yyyy') AS THANGNAM, -- đề yêu cầu theo tháng năm
				PN.NGAY,
				PN.MAPN AS MAPHIEU,
				'NHAP' as LOAI,
				TENVT, 
				TENKHO, 
				CTPN.SOLUONG, 
				CTPN.DONGIA into #n -- bảng tạm thời nhập
		FROM (SELECT NGAY, 
					MAPN,
					TENKHO = ( SELECT TENKHO FROM Kho WHERE P.MAKHO = Kho.MAKHO )
				FROM PhieuNhap AS P
				WHERE MANV = @MANV AND NGAY BETWEEN @FROM AND @TO)PN,
				CTPN,
				(SELECT MAVT, TENVT FROM Vattu ) VT
		WHERE PN.MAPN =CTPN.MAPN
		AND VT.MAVT = CTPN.MAVT
		ORDER BY THANGNAM, NGAY
	
		SELECT FORMAT(PX.NGAY,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
				PX.NGAY, PX.MAPX AS MAPHIEU,
				'XUAT' as LOAI,
				TENVT, 
				TENKHO, 
				CTPX.SOLUONG, 
				CTPX.DONGIA into #x-- bảng tạm thời xuất
		FROM (SELECT NGAY, 
					MAPX,
					TENKHO = ( SELECT TENKHO FROM Kho WHERE P.MAKHO = Kho.MAKHO )
				FROM PhieuXuat AS P
				WHERE MANV = @MANV AND NGAY BETWEEN @FROM AND @TO )PX,
				CTPX,
				(SELECT MAVT, TENVT FROM Vattu ) VT
		WHERE PX.MAPX =CTPX.MAPX
		AND VT.MAVT = CTPX.MAVT
		ORDER BY THANGNAM, NGAY
	
	-- gộp 2 bảng lại thành 1 bảng gồm các thuộc tính giống nhau
	select px.THANGNAM,px.NGAY,px.LOAI, px.MAPHIEU , px.TENVT, px.TENKHO, px.SOLUONG,px.DONGIA
	from #x as px
	UNION
	select pn.THANGNAM,pn.NGAY,pn.LOAI,  pn.MAPHIEU , TENVT, TENKHO, pn.SOLUONG,pn.DONGIA
	from #n as pn
END
GO

