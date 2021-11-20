USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_bangkectvt]    Script Date: 11/20/2021 04:35:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_bangkectvt]
@MODE NCHAR,
@LOAI NCHAR,
@BEGIN NCHAR(10),
@END NCHAR(10)
AS
BEGIN
  IF @MODE = 'C'
    IF @LOAI = 'N'
    SELECT SUBSTRING(CONVERT(VARCHAR, PN.NGAY, 103),4,7) AS [THOIGIAN], VT.TENVT, SUM(CT.SOLUONG) AS 'SOLUONG', SUM(CT.SOLUONG * CT.DONGIA) AS 'TRIGIA'
    FROM 
    (
      SELECT MAPN, NGAY
      FROM dbo.PhieuNhap
      WHERE NGAY BETWEEN @BEGIN and  @END
    ) PN
    INNER JOIN dbo.CTPN CT ON CT.MAPN = PN.MAPN
    INNER JOIN dbo.Vattu VT ON VT.MAVT = CT.MAVT
    GROUP BY SUBSTRING(CONVERT(VARCHAR, PN.NGAY, 103),4,7), VT.TENVT -- 103	 dd/mm/yyyy
	ORDER BY SUBSTRING(CONVERT(VARCHAR, PN.NGAY, 103),4,7)
    ELSE
    IF @LOAI = 'X'
      SELECT SUBSTRING(CONVERT(VARCHAR, PX.NGAY, 103),4,7) AS [THOIGIAN], VT.TENVT, SUM(CT.SOLUONG) AS 'SOLUONG', SUM(CT.SOLUONG * CT.DONGIA) AS 'TRIGIA'
      FROM 
      (
      SELECT MAPX, NGAY
      FROM dbo.PhieuXuat
      WHERE NGAY BETWEEN @BEGIN and  @END
      ) PX
      INNER JOIN dbo.CTPX CT ON CT.MAPX = PX.MAPX
      INNER JOIN dbo.Vattu VT ON VT.MAVT = CT.MAVT
      GROUP BY SUBSTRING(CONVERT(VARCHAR, PX.NGAY, 103),4,7), VT.TENVT
	  ORDER BY SUBSTRING(CONVERT(VARCHAR, PX.NGAY, 103),4,7)
  IF @MODE = 'F'	--quyền công ty
    IF @LOAI = 'N'
    SELECT SUBSTRING(CONVERT(VARCHAR, PN.NGAY, 103),4,7) AS [THOIGIAN], VT.TENVT, SUM(CT.SOLUONG) AS 'SOLUONG', SUM(CT.SOLUONG * CT.DONGIA) AS 'TRIGIA'
    FROM 
    (
      SELECT MAPN, NGAY
      FROM LINK0.QLVT_DATHANG.dbo.PhieuNhap
      WHERE NGAY BETWEEN @BEGIN and  @END
    ) PN
    INNER JOIN LINK0.QLVT_DATHANG.dbo.CTPN CT ON CT.MAPN = PN.MAPN
    INNER JOIN dbo.Vattu VT ON VT.MAVT = CT.MAVT
    GROUP BY SUBSTRING(CONVERT(VARCHAR, PN.NGAY, 103),4,7), VT.TENVT
	ORDER BY SUBSTRING(CONVERT(VARCHAR, PN.NGAY, 103),4,7)
    ELSE
    IF @LOAI = 'X'
      SELECT SUBSTRING(CONVERT(VARCHAR, PX.NGAY, 103),4,7) AS [THOIGIAN], VT.TENVT, SUM(CT.SOLUONG) AS 'SOLUONG', SUM(CT.SOLUONG * CT.DONGIA) AS 'TRIGIA'
      FROM 
      (
      SELECT MAPX, NGAY
      FROM LINK0.QLVT_DATHANG.dbo.PhieuXuat
      WHERE NGAY BETWEEN @BEGIN and  @END
      ) PX
      INNER JOIN LINK0.QLVT_DATHANG.dbo.CTPX CT ON CT.MAPX = PX.MAPX
      INNER JOIN dbo.Vattu VT ON VT.MAVT = CT.MAVT
      GROUP BY  SUBSTRING(CONVERT(VARCHAR, PX.NGAY, 103),4,7), VT.TENVT
	  ORDER BY SUBSTRING(CONVERT(VARCHAR, PX.NGAY, 103),4,7)
END

GO

