﻿--create database PTTKHTTT_QLKS
--go
--use PTTKHTTT_QLKS
--go

drop table PDT_DICHVU;
drop table DICHVU;
drop table HOADON;
drop table CHITIETPHIEUDATPHONG;
drop table PHIEUDATPHONG;
drop table PHONG;
drop table NHANVIEN;
drop table TAIKHOAN;
drop table KHACHHANG;
CREATE TABLE KHACHHANG
(
	MAKH INT, 
	HOTEN NVARCHAR(50), 
	SDT CHAR(11), 
	DIACHI NVARCHAR(60), 
	FAXID INT, 
	EMAIL VARCHAR(50),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKH)
)

CREATE TABLE TAIKHOAN
(
	USERNAME VARCHAR(30),
	PASS VARCHAR(30) NOT NULL,
	LOAI TINYINT NOT NULL,
	CONSTRAINT PK_TAIKHOAN PRIMARY KEY(USERNAME)
)
CREATE TABLE NHANVIEN
(
	MANV INT, 
	HOTEN NVARCHAR(50), 
	SDT CHAR(11), 
	DIACHI NVARCHAR(60), 
	EMAIL VARCHAR(50),
	USERNAME VARCHAR(30),
	CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV),
	FOREIGN KEY(USERNAME) REFERENCES TAIKHOAN(USERNAME)
)
CREATE TABLE PHONG
(
	MAPHONG INT, 
	LOAIPHONG NVARCHAR(8), -- Đơn / Đôi
	HANG NVARCHAR(8), -- Thường / Cao cấp
	GIA INT,
	TINHTRANG NVARCHAR(15), -- Trống / Chưa dọn / Đang dùng
	CONSTRAINT PK_PHONG PRIMARY KEY(MAPHONG)
)
CREATE TABLE PHIEUDATPHONG
(
	MAPDP INT, 
	NGAYLAP DATE,
	NGAYNHANPHONG DATE,
	NGAYTRAPHONG DATE,
	MAKH INT,
	MANV INT,
	CONSTRAINT PK_PDP PRIMARY KEY(MAPDP),
	FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
)
CREATE TABLE CHITIETPHIEUDATPHONG
(
	MAPDP INT, 
	MAPHONG INT,
	CONSTRAINT PK_CTPDP PRIMARY KEY(MAPDP, MAPHONG),
	FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG)
)

CREATE TABLE HOADON
(
	MAHD INT, 
	NGAYLAP DATE,
	MAPDP INT, 
	TONGTIEN INT,
	TINHTRANGTT NVARCHAR(16), --Đã thanh toán / Đã cọc
	MANV INT, 
	CONSTRAINT PK_HOADON PRIMARY KEY(MAHD),
	FOREIGN KEY(MAPDP) REFERENCES PHIEUDATPHONG(MAPDP),
	FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)
CREATE TABLE DICHVU
(
	MADV INT, 
	TENDV VARCHAR(30),
	GIA INT,
	MOTA NVARCHAR(100),
	DIADIEM NVARCHAR(30),
	CONSTRAINT PK_DV PRIMARY KEY(MADV)
)
CREATE TABLE PDT_DICHVU
(
	MADV INT, 
	MAPDP INT, 
	SOLUONG INT, 
	THOIGIAN DATETIME,
	CONSTRAINT PK_PDT_DV PRIMARY KEY(MADV, MAPDP),
	FOREIGN KEY(MADV) REFERENCES DICHVU(MADV),
	FOREIGN KEY(MAPDP) REFERENCES PHIEUDATPHONG(MAPDP)
)


-- create table Doitac
-- (
-- 	MaDoiTac CHAR(8), 
-- 	TenDoiTac nvarchar(50), 
-- 	SDT int
-- 	Constraint PK_Doitac Primary key(MaDoiTac)
-- )	

-- create table TOUR_Doitac
-- (
-- 	MaTOURDT CHAR(8), 
-- 	TenTOUR nvarchar(50), 
-- 	DIADIEM NVARCHAR(50),
-- 	GIA int,
-- 	MOTACT NVARCHAR(100),
-- 	MaDoiTac CHAR(8)
-- 	Constraint PK_TOURDT Primary key(MaTOURDT),
-- 	FOREIGN KEY(MADOITAC) REFERENCES DOITAC(MADOITAC)
-- )

-- create table PHIEUDANGKYTOUR
-- (
-- 	MaphieuTOUR CHAR(8), 
-- 	THGIANKHOIHANH DATETIME,
-- 	SONGUOITHGIA INT,
-- 	DICHVUDUADON NVARCHAR(20),--???????
-- 	YEUCAUDACBIET nvarchar(50), 
-- 	TINHTRANGDUYET NVARCHAR(50),
-- 	Constraint PK_PDKTOUR Primary key(MaPHIEUTOUR)
-- )

INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (1, N'Nguyễn Văn An', '0123456789', N'123 Đường Nguyễn Du, Quận 1, Thành phố HCM', 1, 'nguyenvana@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (2, N'Trần Thị Bình', '0987654321', N'456 Đường Lê Lợi, Quận 2, Thành phố HCM', 2, 'tranthib@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (3, N'Lê Văn Cường', '0345678901', N'789 Đường Trần Hưng Đạo, Quận 3, Thành phố HCM', 3, 'levanc@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (4, N'Phạm Thị Dung', '0876543210', N'321 Đường Võ Văn Tần, Quận 4, Thành phố HCM', 4, 'phamthid@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (5, N'Hoàng Văn Eo', '0456789012', N'654 Đường Cách Mạng Tháng 8, Quận 5, Thành phố HCM', 5, 'hoangvane@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (6, N'Vũ Thị Fion', '0567890123', N'987 Đường Nguyễn Thị Minh Khai, Quận 6, Thành phố HCM', 6, 'vuthif@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (7, N'Nguyễn Văn Già', '0234567890', N'123 Đường Nguyễn Văn Linh, Quận 7, Thành phố HCM', 7, 'nguyenvangia@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (8, N'Trần Thị Hoa', '0654321098', N'234 Đường Nguyễn Hữu Thọ, Quận 8, Thành phố HCM', 8, 'tranthihoa@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (9, N'Lê Văn Thành', '0876543219', N'567 Đường Bình Quới, Quận 9, Thành phố HCM', 9, 'levanthanh@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (10, N'Nguyễn Thị Kim', '0345678902', N'678 Đường Lê Văn Việt, Quận 10, Thành phố HCM', 10, 'nguyenthikim@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (11, N'Hoàng Văn Linh', '0456789013', N'789 Đường Trường Chinh, Quận 11, Thành phố HCM', 11, 'hoangvanlinh@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (12, N'Phạm Thị Trinh', '0567890124', N'890 Đường Lý Thường Kiệt, Quận 12, Thành phố HCM', 12, 'phamthitrinh@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (13, N'Lê Văn Tuấn', '0654321098', N'123 Đường Bùi Viện, Quận Bình Thạnh, Thành phố HCM', 13, 'levantuan@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (14, N'Nguyễn Thị Hằng', '0876543219', N'234 Đường Nguyễn Cư Trinh, Quận Gò Vấp, Thành phố HCM', 14, 'nguyenthihang@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (15, N'Trần Văn Long', '0345678902', N'345 Đường Phạm Văn Đồng, Quận Phú Nhuận, Thành phố HCM', 15, 'tranvanlong@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (16, N'Phạm Thị Mỹ', '0456789013', N'456 Đường Nguyễn Thị Định, Quận Tân Bình, Thành phố HCM', 16, 'phamthimy@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (17, N'Hoàng Văn Nam', '0567890124', N'567 Đường Trần Quốc Hoàn, Quận Tân Phú, Thành phố HCM', 17, 'hoangvannam@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (18, N'Lê Thị Loan', '0654321098', N'678 Đường Đặng Văn Ngữ, Quận Bình Tân, Thành phố HCM', 18, 'lethiloan@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (19, N'Nguyễn Văn Đức', '0876543219', N'789 Đường Hòa Bình, Quận Thủ Đức, Thành phố HCM', 19, 'nguyenvanduc@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (20, N'Trần Thị Phượng', '0345678902', N'890 Đường Phan Văn Trị, Quận Cần Giờ, Thành phố HCM', 20, 'tranthiphuong@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (21, N'Lê Văn Quang', '0456789013', N'123 Đường Nguyễn Văn Linh, Quận Hóc Môn, Thành phố HCM', 21, 'levantuan@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (22, N'Phạm Thị Thảo', '0567890124', N'234 Đường Hưng Phước, Quận Nhà Bè, Thành phố HCM', 22, 'phamthithao@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (23, N'Hoàng Văn Tuấn', '0654321098', N'345 Đường Nguyễn Hữu Thọ, Quận 7, Thành phố HCM', 23, 'hoangvantuan@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (24, N'Trần Thị Thủy', '0876543219', N'456 Đường Trường Chinh, Quận 12, Thành phố HCM', 24, 'tranthithuy@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (25, N'Lê Văn Sơn', '0345678902', N'567 Đường Lê Lợi, Quận Tân Bình, Thành phố HCM', 25, 'levanson@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (26, N'Nguyễn Thị Hà', '0456789013', N'678 Đường Cách Mạng Tháng 8, Quận 3, Thành phố HCM', 26, 'nguyenthiha@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (27, N'Trần Văn Minh', '0567890124', N'789 Đường Võ Văn Kiệt, Quận 5, Thành phố HCM', 27, 'tranvanminh@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (28, N'Phạm Thị Nga', '0654321098', N'890 Đường Phạm Ngọc Thạch, Quận 1, Thành phố HCM', 28, 'phamthinga@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (29, N'Hoàng Văn Hùng', '0876543219', N'123 Đường Lê Hồng Phong, Quận 10, Thành phố HCM', 29, 'hoangvanhung@gmail.com');
INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, FAXID, EMAIL)VALUES (30, N'Lê Thị Mai', '0345678902', N'234 Đường Nguyễn Đình Chiểu, Quận 3, Thành phố HCM', 30, 'lethimai@gmail.com');
select count(*) KHACHHANG from KHACHHANG
INSERT INTO TAIKHOAN (username, pass,Loai) VALUES ('letan', '123',2);
INSERT INTO TAIKHOAN VALUES ('admin', '123',1);
INSERT INTO TAIKHOAN VALUES ('levanc', '555555',2);
INSERT INTO TAIKHOAN VALUES ('phamthid', '111111',2);
INSERT INTO TAIKHOAN VALUES ('hoangvane', '999999',2);
INSERT INTO TAIKHOAN VALUES ('ngothif', '444444',2);
INSERT INTO TAIKHOAN VALUES ('trinhvang', '888888',2);
INSERT INTO TAIKHOAN VALUES ('lythih', '222222',2);
INSERT INTO TAIKHOAN VALUES ('huynhvani', '666666',2);
INSERT INTO TAIKHOAN VALUES ('vothik', '333333',2);
select count(*) TAIKHOAN from TAIKHOAN
select * from TAIKHOAN
INSERT INTO NHANVIEN (MANV, HOTEN, SDT, DIACHI, EMAIL, username) VALUES  (1, N'Lễ Thị Tân', '1234567801', N'123 Đường A', 'nguyenvana@example.com', 'letan');
INSERT INTO NHANVIEN VALUES (2, N'Lê Áp Minh', '9876543109', N'456 Đường B', 'tranthib@example.com', 'admin');
INSERT INTO NHANVIEN VALUES (3, N'Lê Văn C', '5555555555', N'789 Đường C', 'levanc@example.com', 'levanc');
INSERT INTO NHANVIEN VALUES (4, N'Phạm Thị D', '1111111111', N'321 Đường D', 'phamthid@example.com', 'phamthid');
INSERT INTO NHANVIEN VALUES (5, N'Hoàng Văn E', '9999999999', N'654 Đường E', 'hoangvane@example.com', 'hoangvane');
INSERT INTO NHANVIEN VALUES (6, N'Ngô Thị F', '4444444444', N'987 Đường F', 'ngothif@example.com', 'ngothif');
INSERT INTO NHANVIEN VALUES (7, N'Trịnh Văn G', '8888888888', N'147 Đường G', 'trinhvang@example.com', 'trinhvang');
INSERT INTO NHANVIEN VALUES (8, N'Lý Thị H', '2222222222', N'258 Đường H', 'lythih@example.com', 'lythih');
INSERT INTO NHANVIEN VALUES (9, N'Huỳnh Văn I', '6666666666', N'369 Đường I', 'huynhvani@example.com', 'huynhvani');
INSERT INTO NHANVIEN VALUES (10, N'Võ Thị K', '3333333333', N'987 Đường K', 'vothik@example.com', 'vothik');
select count(*) NHANVIEN from NHANVIEN

-- Ví dụ chèn 10 dòng dữ liệu vào bảng PHONG
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (1, N'Đơn', N'Thường', 100000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (2, N'Đôi', N'Thường', 150000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (3, N'Đơn', N'Thường', 100000, N'Chưa dọn');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (4, N'Đôi', N'Cao cấp', 200000, N'Đang dùng');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (5, N'Đơn', N'Thường', 100000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (6, N'Đôi', N'Thường', 150000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (7, N'Đơn', N'Thường', 100000, N'Chưa dọn');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (8, N'Đôi', N'Cao cấp', 200000, N'Đang dùng');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (9, N'Đơn', N'Thường', 100000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (10, N'Đôi', N'Thường', 150000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (11, N'Đơn', N'Thường', 100000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (12, N'Đôi', N'Thường', 150000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (13, N'Đơn', N'Thường', 100000, N'Chưa dọn');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (14, N'Đôi', N'Cao cấp', 200000, N'Đang dùng');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (15, N'Đơn', N'Thường', 100000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (16, N'Đôi', N'Thường', 150000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (17, N'Đơn', N'Thường', 100000, N'Chưa dọn');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (18, N'Đôi', N'Cao cấp', 200000, N'Đang dùng');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (19, N'Đơn', N'Thường', 100000, N'Trống');
INSERT INTO PHONG (MAPHONG, LOAIPHONG, HANG, GIA, TINHTRANG)VALUES (20, N'Đôi', N'Thường', 150000, N'Trống');
select count(*) PHONG from PHONG

-- Ví dụ chèn 10 dòng dữ liệu vào bảng PHIEUDATPHONG với mã phòng có giá trị cố định ngẫu nhiên từ 1 đến 20
INSERT INTO PHIEUDATPHONG (MAPDP, NGAYLAP, NGAYNHANPHONG, NGAYTRAPHONG, MAKH, MANV)VALUES (1, '2023-07-01', '2023-07-02', '2023-07-03', 1, 1);
INSERT INTO PHIEUDATPHONG VALUES (2, '2023-07-02', '2023-07-03', '2023-07-04', 2, 2);
INSERT INTO PHIEUDATPHONG VALUES (3, '2023-07-03', '2023-07-04', '2023-07-05', 3, 3);
INSERT INTO PHIEUDATPHONG VALUES (4, '2023-07-04', '2023-07-05', '2023-07-06', 4, 4);
INSERT INTO PHIEUDATPHONG VALUES (5, '2023-07-05', '2023-07-06', '2023-07-07', 5, 5);
INSERT INTO PHIEUDATPHONG VALUES (6, '2023-07-06', '2023-07-07', '2023-07-08', 6, 6);
INSERT INTO PHIEUDATPHONG VALUES (7, '2023-07-07', '2023-07-08', '2023-07-09', 7, 7);
INSERT INTO PHIEUDATPHONG VALUES (8, '2023-07-08', '2023-07-09', '2023-07-10', 8, 8);
INSERT INTO PHIEUDATPHONG VALUES (9, '2023-07-09', '2023-07-10', '2023-07-11', 9, 9);
INSERT INTO PHIEUDATPHONG VALUES (10, '2023-07-10', '2023-07-11', '2023-07-12', 10, 10);
INSERT INTO PHIEUDATPHONG VALUES (11, '2023-07-11', '2023-07-12', '2023-07-13', 11, 1);
INSERT INTO PHIEUDATPHONG VALUES (12, '2023-07-12', '2023-07-13', '2023-07-14', 12, 2);
INSERT INTO PHIEUDATPHONG VALUES (13, '2023-07-13', '2023-07-14', '2023-07-15', 13, 3);
INSERT INTO PHIEUDATPHONG VALUES (14, '2023-07-14', '2023-07-15', '2023-07-16', 14, 4);
INSERT INTO PHIEUDATPHONG VALUES (15, '2023-07-15', '2023-07-16', '2023-07-17', 15, 5);
INSERT INTO PHIEUDATPHONG VALUES (16, '2023-07-16', '2023-07-17', '2023-07-18', 16, 6);
INSERT INTO PHIEUDATPHONG VALUES (17, '2023-07-17', '2023-07-18', '2023-07-19', 17, 7);
INSERT INTO PHIEUDATPHONG VALUES (18, '2023-07-18', '2023-07-19', '2023-07-20', 18, 8);
INSERT INTO PHIEUDATPHONG VALUES (19, '2023-07-19', '2023-07-20', '2023-07-21', 19, 9);
INSERT INTO PHIEUDATPHONG VALUES (20, '2023-07-20', '2023-07-21', '2023-07-22', 20, 10);
INSERT INTO PHIEUDATPHONG VALUES (21, '2023-07-21', '2023-07-22', '2023-07-23', 21, 1);
INSERT INTO PHIEUDATPHONG VALUES (22, '2023-07-22', '2023-07-23', '2023-07-24', 22, 2);
INSERT INTO PHIEUDATPHONG VALUES (23, '2023-07-23', '2023-07-24', '2023-07-25', 23, 3);
INSERT INTO PHIEUDATPHONG VALUES (24, '2023-07-24', '2023-07-25', '2023-07-26', 24, 4);
INSERT INTO PHIEUDATPHONG VALUES (25, '2023-07-25', '2023-07-26', '2023-07-27', 25, 5);
INSERT INTO PHIEUDATPHONG VALUES (26, '2023-07-26', '2023-07-27', '2023-07-28', 26, 6);
INSERT INTO PHIEUDATPHONG VALUES (27, '2023-07-27', '2023-07-28', '2023-07-29', 27, 7);
INSERT INTO PHIEUDATPHONG VALUES (28, '2023-07-28', '2023-07-29', '2023-07-30', 28, 8);
INSERT INTO PHIEUDATPHONG VALUES (29, '2023-07-29', '2023-07-30', '2023-07-31', 29, 9);
INSERT INTO PHIEUDATPHONG VALUES (30, '2023-07-30', '2023-07-31', '2023-08-01', 30, 10);
INSERT INTO PHIEUDATPHONG VALUES (31, '2023-07-31', '2023-08-01', '2023-08-02', 1, 1);
INSERT INTO PHIEUDATPHONG VALUES (32, '2023-08-01', '2023-08-02', '2023-08-03', 2, 2);
INSERT INTO PHIEUDATPHONG VALUES (33, '2023-08-02', '2023-08-03', '2023-08-04', 3, 3);
INSERT INTO PHIEUDATPHONG VALUES (34, '2023-08-03', '2023-08-04', '2023-08-05', 4, 4);
INSERT INTO PHIEUDATPHONG VALUES (35, '2023-08-04', '2023-08-05', '2023-08-06', 5, 5);
INSERT INTO PHIEUDATPHONG VALUES (36, '2023-08-05', '2023-08-06', '2023-08-07', 6, 6);
INSERT INTO PHIEUDATPHONG VALUES (37, '2023-08-06', '2023-08-07', '2023-08-08', 7, 7);
INSERT INTO PHIEUDATPHONG VALUES (38, '2023-08-07', '2023-08-08', '2023-08-09', 8, 8);
INSERT INTO PHIEUDATPHONG VALUES (39, '2023-08-08', '2023-08-09', '2023-08-10', 9, 9);
INSERT INTO PHIEUDATPHONG VALUES (40, '2023-08-09', '2023-08-10', '2023-08-11', 10, 10);
INSERT INTO PHIEUDATPHONG VALUES (41, '2023-08-10', '2023-08-11', '2023-08-12', 11, 1);
INSERT INTO PHIEUDATPHONG VALUES (42, '2023-08-11', '2023-08-12', '2023-08-13', 12, 2);
INSERT INTO PHIEUDATPHONG VALUES (43, '2023-08-12', '2023-08-13', '2023-08-14', 13, 3);
INSERT INTO PHIEUDATPHONG VALUES (44, '2023-08-13', '2023-08-14', '2023-08-15', 14, 4);
INSERT INTO PHIEUDATPHONG VALUES (45, '2023-08-14', '2023-08-15', '2023-08-16', 15, 5);
INSERT INTO PHIEUDATPHONG VALUES (46, '2023-08-15', '2023-08-16', '2023-08-17', 16, 6);
INSERT INTO PHIEUDATPHONG VALUES (47, '2023-08-16', '2023-08-17', '2023-08-18', 17, 7);
INSERT INTO PHIEUDATPHONG VALUES (48, '2023-08-17', '2023-08-18', '2023-08-19', 18, 8);
INSERT INTO PHIEUDATPHONG VALUES (49, '2023-08-18', '2023-08-19', '2023-08-20', 19, 9);
INSERT INTO PHIEUDATPHONG VALUES (50, '2023-08-19', '2023-08-20', '2023-08-21', 20, 10);
select count(*) PHIEUDATPHONG from PHIEUDATPHONG

-- Thêm dữ liệu vào bảng HOADON

INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (1, '2023-07-01', 1, N'Đã thanh toán', 1);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (2, '2023-07-02', 2, N'Chưa thanh toán', 2);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (3, '2023-07-03', 3, N'Chưa thanh toán', 3);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (4, '2023-07-04', 4, N'Đã thanh toán', 4);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (5, '2023-07-05', 5, N'Chưa thanh toán', 5);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (6, '2023-07-06', 6, N'Đã thanh toán', 6);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (7, '2023-07-07', 7, N'Chưa thanh toán', 7);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (8, '2023-07-08', 8, N'Chưa thanh toán', 8);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (9, '2023-07-09', 9, N'Đã thanh toán', 9);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (10, '2023-07-10', 10, N'Chưa thanh toán', 10);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (11, '2023-07-11', 11, N'Đã thanh toán', 1);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (12, '2023-07-12', 12, N'Chưa thanh toán', 2);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (13, '2023-07-13', 13, N'Chưa thanh toán', 3);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (14, '2023-07-14', 14, N'Đã thanh toán', 4);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (15, '2023-07-15', 15, N'Chưa thanh toán', 5);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (16, '2023-07-16', 16, N'Đã thanh toán', 6);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (17, '2023-07-17', 17, N'Chưa thanh toán', 7);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (18, '2023-07-18', 18, N'Chưa thanh toán', 8);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (19, '2023-07-19', 19, N'Đã thanh toán', 9);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (20, '2023-07-20', 20, N'Chưa thanh toán', 10);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (21, '2023-07-21', 21, N'Đã thanh toán', 1);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (22, '2023-07-22', 22, N'Chưa thanh toán', 2);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (23, '2023-07-23', 23, N'Chưa thanh toán', 3);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (24, '2023-07-24', 24, N'Đã thanh toán', 4);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (25, '2023-07-25', 25, N'Chưa thanh toán', 5);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (26, '2023-07-26', 26, N'Đã thanh toán', 6);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (27, '2023-07-27', 27, N'Chưa thanh toán', 7);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (28, '2023-07-28', 28, N'Chưa thanh toán', 8);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (29, '2023-07-29', 29, N'Đã thanh toán', 9);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (30, '2023-07-30', 30, N'Chưa thanh toán', 10);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (31, '2023-07-31', 31, N'Đã thanh toán', 1);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (32, '2023-08-01', 32, N'Chưa thanh toán', 2);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (33, '2023-08-02', 33, N'Chưa thanh toán', 3);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (34, '2023-08-03', 34, N'Đã thanh toán', 4);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (35, '2023-08-04', 35, N'Chưa thanh toán', 5);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (36, '2023-08-05', 36, N'Đã thanh toán', 6);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (37, '2023-08-06', 37, N'Chưa thanh toán', 7);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (38, '2023-08-07', 38, N'Chưa thanh toán', 8);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (39, '2023-08-08', 39, N'Đã thanh toán', 9);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (40, '2023-08-09', 40, N'Chưa thanh toán', 10);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (41, '2023-08-10', 41, N'Đã thanh toán', 1);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (42, '2023-08-11', 42, N'Chưa thanh toán', 2);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (43, '2023-08-12', 43, N'Chưa thanh toán', 3);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (44, '2023-08-13', 44, N'Đã thanh toán', 4);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (45, '2023-08-14', 45, N'Chưa thanh toán', 5);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (46, '2023-08-15', 46, N'Đã thanh toán', 6);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (47, '2023-08-16', 47, N'Chưa thanh toán', 7);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (48, '2023-08-17', 48, N'Chưa thanh toán', 8);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (49, '2023-08-18', 49, N'Đã thanh toán', 9);
INSERT INTO HOADON (MAHD, NGAYLAP, MAPDP, TinhTrangTT, MANV) VALUES (50, '2023-08-19', 50, N'Chưa thanh toán', 10);
select count(*) HOADON from HOADON

--SELECT * FROM PHIEUDATPHONG

INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (1, N'Dịch vụ đưa đón sân bay', 100000, N'Đưa đón khách hàng từ sân bay đến khách sạn', N'Sân bay quốc tế Tân Sơn Nhất');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (2, N'Buffet sáng', 150000, N'Buffet sáng với các món ăn đa dạng và phong phú', N'Restaurant');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (3, N'Dịch vụ giặt ủi', 50000, N'Tiện ích giặt ủi quần áo và vật dụng cá nhân', N'Tầng 2');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (4, N'Dịch vụ phòng', 200000, N'Tiện ích phục vụ trong phòng khách sạn', N'Phòng khách sạn');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (5, N'Dịch vụ spa', 300000, N'Dịch vụ làm đẹp và thư giãn tại spa', N'Tầng 3');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (6, N'Dịch vụ thuê xe', 250000, N'Dịch vụ thuê xe ô tô cho khách hàng', N'Front Desk');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (7, N'Dịch vụ đặt tour', 150000, N'Dịch vụ đặt tour tham quan và du lịch', N'Front Desk');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (8, N'Dịch vụ phòng họp', 500000, N'Dịch vụ cung cấp phòng họp và hội nghị', N'Tầng 4');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (9, N'Dịch vụ nhà hàng', 200000, N'Tiện ích nhà hàng phục vụ bữa trưa và bữa tối', N'Nhà hàng');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (10, N'Dịch vụ quầy bar', 150000, N'Tiện ích quầy bar phục vụ đồ uống và cocktail', N'Quầy Bar');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (11, N'Dịch vụ phòng gym', 100000, N'Tiện ích phòng gym với các trang thiết bị tập luyện', N'Tầng 5');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (12, N'Dịch vụ phòng chơi game', 50000, N'Tiện ích phòng chơi game giải trí', N'Tầng 5');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (13, N'Dịch vụ cho thuê đồ biển', 80000, N'Dịch vụ cho thuê đồ biển và vật dụng tắm nắng', N'Front Desk');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (14, N'Dịch vụ hướng dẫn du lịch', 200000, N'Dịch vụ hướng dẫn du lịch và tham quan', N'Front Desk');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (15, N'Dịch vụ đặt vé sự kiện', 100000, N'Dịch vụ đặt vé tham dự các sự kiện', N'Front Desk');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (16, N'Dịch vụ tiệc cưới', 5000000, N'Tổ chức tiệc cưới tại khách sạn', N'Tầng 6');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (17, N'Dịch vụ truyền hình cáp', 100000, N'Tiện ích truyền hình cáp trong phòng', N'Phòng khách sạn');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (18, N'Dịch vụ Internet', 50000, N'Tiện ích truy cập Internet trong phòng', N'Phòng khách sạn');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (19, N'Dịch vụ đặt vé máy bay', 50000, N'Dịch vụ đặt vé máy bay cho khách hàng', N'Front Desk');
INSERT INTO DICHVU (MADV, TENDV, GIA, MOTA, DIADIEM)
VALUES (20, N'Dịch vụ giữ hành lý', 50000, N'Dịch vụ giữ hành lý cho khách hàng', N'Tầng 1');
select count(*) DICHVU from DICHVU
	
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (1, 1, 2, '2023-06-01 10:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (2, 1, 1, '2023-06-02 15:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (3, 2, 3, '2023-06-03 09:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (4, 3, 1, '2023-06-04 11:20:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (5, 4, 2, '2023-06-05 14:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (6, 5, 1, '2023-06-06 17:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (7, 6, 2, '2023-06-07 09:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (8, 7, 1, '2023-06-08 12:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (9, 8, 3, '2023-06-09 16:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (10, 9, 1, '2023-06-10 10:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (11, 10, 2, '2023-06-11 13:20:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (12, 11, 1, '2023-06-12 11:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (13, 12, 2, '2023-06-13 14:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (14, 13, 1, '2023-06-14 16:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (15, 14, 3, '2023-06-15 09:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (16, 15, 1, '2023-06-16 12:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (17, 16, 2, '2023-06-17 15:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (18, 17, 1, '2023-06-18 10:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (19, 18, 3, '2023-06-19 13:20:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (20, 19, 1, '2023-06-20 16:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (1, 20, 2, '2023-06-21 09:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (2, 21, 1, '2023-06-22 12:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (3, 22, 3, '2023-06-23 15:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (4, 23, 1, '2023-06-24 10:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (5, 24, 2, '2023-06-25 13:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (6, 25, 1, '2023-06-26 16:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (7, 26, 2, '2023-06-27 09:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (8, 27, 1, '2023-06-28 12:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (9, 28, 3, '2023-06-29 15:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (10, 29, 1, '2023-06-30 10:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (11, 30, 2, '2023-07-01 13:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (12, 31, 1, '2023-07-02 16:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (13, 32, 2, '2023-07-03 09:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (14, 33, 1, '2023-07-04 12:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (15, 34, 3, '2023-07-05 15:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (16, 35, 1, '2023-07-06 10:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (17, 36, 2, '2023-07-07 13:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (18, 37, 1, '2023-07-08 16:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (19, 38, 3, '2023-07-09 09:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (20, 39, 1, '2023-07-10 12:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (1, 40, 2, '2023-07-11 15:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (2, 41, 1, '2023-07-12 10:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (3, 42, 3, '2023-07-13 13:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (4, 43, 1, '2023-07-14 16:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (5, 44, 2, '2023-07-15 09:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (6, 45, 1, '2023-07-16 12:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (7, 46, 2, '2023-07-17 15:15:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (8, 47, 1, '2023-07-18 10:45:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (9, 48, 3, '2023-07-19 13:30:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (10, 49, 1, '2023-07-20 16:00:00');
INSERT INTO PDT_DICHVU (MADV, MAPDP, SOLUONG, THOIGIAN)
VALUES (11, 50, 2, '2023-07-21 09:15:00');
select count(*) PDT_DICHVU from PDT_DICHVU


-- create table PHG_PDP
-- (
-- 	MaPHONG CHAR(8), 
-- 	MaPDP CHAR(8)
-- 	Constraint PK_PHG_PDP Primary key(MaPHONG, MaPDP),
-- 	FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG),
-- 	FOREIGN KEY(MaPDP) REFERENCES PHIEUDATPHONG(MaPDP)
-- )
-- create table PHIEUYEUCAU
-- (
-- 	MaPYC CHAR(8), 
-- 	NGLAP DATE,
-- 	NGDEN DATE,
-- 	SODEMLUUTRU INT,--?????
-- 	LOAIPHONG CHAR(8),
-- 	YCDATBIET NVARCHAR(50),
-- 	MAKHACHHANG CHAR(8)
-- 	Constraint PK_PYC Primary key(MaPYC),
-- 	FOREIGN KEY(MaKhachHanG) REFERENCES KHACHHANG(MaKhachHang)
-- )
-- create table PHG_PYC
-- (
-- 	MaPHONG CHAR(8), 
-- 	MaPYC CHAR(8), 
-- 	Constraint PK_PHG_PYC Primary key(MaPHONG, MaPYC),
-- 	FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG),
-- 	FOREIGN KEY(MaPYC) REFERENCES PHIEUYEUCAU(MaPYC)
-- )

-- create table PDT_TOURKD_KH
-- (
-- 	MaTOUR CHAR(8), 
-- 	MaKHACHHANG CHAR(8) 
-- 	Constraint PK_TOURKD_KH Primary key(MaTOUR, MaKHACHHANG),
-- 	FOREIGN KEY(MATOUR) REFERENCES TOURKHACHDEN(MATOUR),
-- 	FOREIGN KEY(MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG)
-- )

-- create table Doitac
-- (
-- 	MaDoiTac CHAR(8), 
-- 	TenDoiTac nvarchar(50), 
-- 	SDT int
-- 	Constraint PK_Doitac Primary key(MaDoiTac)
-- )	

-- create table NHAXE
-- (
-- 	MANHAXE CHAR(5), 
-- 	TENNHAXE nvarchar(50), 
-- 	SDT int
-- 	Constraint PK_NHAXE Primary key(MaNHAXE)
-- )

-- create table TOUR_Doitac
-- (
-- 	MaTOURDT CHAR(8), 
-- 	TenTOUR nvarchar(50), 
-- 	DIADIEM NVARCHAR(50),
-- 	GIA int,
-- 	MOTACT NVARCHAR(100),
-- 	MaDoiTac CHAR(8)
-- 	Constraint PK_TOURDT Primary key(MaTOURDT),
-- 	FOREIGN KEY(MADOITAC) REFERENCES DOITAC(MADOITAC)
-- )

-- create table PHIEUDANGKYTOUR
-- (
-- 	MaphieuTOUR CHAR(8), 
-- 	THGIANKHOIHANH DATETIME,
-- 	SONGUOITHGIA INT,
-- 	DICHVUDUADON NVARCHAR(20),--???????
-- 	YEUCAUDACBIET nvarchar(50), 
-- 	TINHTRANGDUYET NVARCHAR(50),
-- 	Constraint PK_PDKTOUR Primary key(MaPHIEUTOUR)
-- )

-- create table PDKTOUR_TOURDoitac
-- (
-- 	MaTOURDT CHAR(8), 
-- 	MaphieuTOUR CHAR(8), 
-- 	Constraint PK_PDKT_TOURDT Primary key(MaTOURDT, MaphieuTOUR),
-- 	FOREIGN KEY(MaTOURDT) REFERENCES TOUR_Doitac(MaTOURDT),
-- 	FOREIGN KEY(MaphieuTOUR) REFERENCES PHIEUDANGKYTOUR(MaphieuTOUR)
-- )

-- create table PDKTOUR_KH
-- (
-- 	MaKhachHang CHAR(8), 
-- 	MaphieuTOUR CHAR(8), 
-- 	Constraint PK_PDKT_KH Primary key(MaKhachHanG, MaphieuTOUR),
-- 	FOREIGN KEY(MaKhachHanG) REFERENCES KHACHHANG(MaKhachHang),
-- 	FOREIGN KEY(MaphieuTOUR) REFERENCES PHIEUDANGKYTOUR(MaphieuTOUR)
-- )


-- Generate additional 20 rows of sample data for the KHACHHANG table

-- Generate 30 rows of sample data for the KHACHHANG table
--create table TOURKHACHDEN
--(
--	MATOUR int, 
--	TENDOAN nvarchar(30), 
--	MAKH int,
--	Constraint PK_TOURKD Primary key(MATOUR)
--)	