create database POS_HCL
go
use POS_HCL
go
set dateformat dmy;
go
-- ============================================
-- 💽 CSDL POS Trà Sữa FULL (SQL Server)
-- ============================================

-- 1. DANH MỤC SẢN PHẨM CHÍNH

CREATE TABLE DanhMuc (
    MaDanhMuc INT PRIMARY KEY IDENTITY,
    TenDanhMuc NVARCHAR(100) not null
);

CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1) PRIMARY KEY,
    TenSP NVARCHAR(100) NOT NULL,
	MaDanhMuc INT not null,
    DonGiaCoBan DECIMAL(18,1) NOT NULL,
	FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
);

-- 2. NHÓM TÙY CHỌN (Size, Đường, Đá, Topping...)
CREATE TABLE OptionLoai (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
);

-- 3. CHI TIẾT CÁC TẬP TÙY CHỌN
CREATE TABLE OptionChiTiet (
    MaOption INT IDENTITY(1,1) PRIMARY KEY,
    MaLoai INT NOT NULL FOREIGN KEY REFERENCES OptionLoai(MaLoai),
    TenOption NVARCHAR(50) NOT NULL,
    GiaThem DECIMAL(18,2) DEFAULT 0
);

-- 4. KHÁCH HÀNG
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100),
	SoThe INT UNIQUE,
    SDT NVARCHAR(15),
    SoTien DECIMAL(18,1) DEFAULT 0
);

-- 5. NHÂN VIÊN
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    TenDangNhap NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(50) NOT NULL,
    Quyen int -- admin, thu ngan
);

-- 6. HÓA ĐƠN
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL,
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaKH INT NULL FOREIGN KEY REFERENCES KhachHang(MaKH)
);

-- 7. CHI TIẾT HÓA ĐƠN
CREATE TABLE ChiTietHoaDon (
    MaCTHD INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP INT NOT NULL FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,1) NOT NULL
);

-- 8. CHI TIẾT TÙY CHỌN THEO MÓN TRONG HÓA ĐƠN
CREATE TABLE ChiTietHoaDon_Option (
    MaCTHD INT NOT NULL FOREIGN KEY REFERENCES ChiTietHoaDon(MaCTHD),
    MaOption INT NOT NULL FOREIGN KEY REFERENCES OptionChiTiet(MaOption),
    CONSTRAINT PK_CTHD_Option PRIMARY KEY (MaCTHD, MaOption)
);
go
-- ✅ GỢI Ý: Sau khi tạo CSDL, bạn insert các OptionLoais như Đường, Đá, Size, Topping và OptionChiTiet tương ứng.

INSERT INTO NhanVien (TenNV, TenDangNhap, MatKhau, Quyen)
VALUES
(N'Nguyễn Văn A', N'nguyenvana', N'123456', 1),  -- admin
(N'Lê Thị B', N'lethib', N'abc123', 2),          -- thu ngân
(N'Trần Văn C', N'tranvanc', N'qwerty', 2),
(N'Phạm Thị D', N'phamthid', N'pass123', 2),
(N'Võ Minh E', N'vominhe', N'mk@2025', 1);       -- admin
