create database WFQuanLyNhanVien
go
use WFQuanLyNhanVien
go

create table PhongBan(
	Id int primary key not null identity(1,1),
	TenPhongBan nvarchar(100),
)
go

create table NhanVien(
	Id int primary key not null identity(1,1),
	MaCC nvarchar(100),
	HoNV nvarchar(100) not null,
	TenNV nvarchar(100) not null,
	GioiTinh bit,
	NgaySinh Date,
	NoiSinh nvarchar(100),
	QueQuan nvarchar(100),
	DiaChiThuongTru nvarchar(100),
	TinhThanh nvarchar(100),
	DiaChiTamTru nvarchar(100),
	DienThoai varchar(50),
	DTDD varchar(50),
	DanToc nvarchar(15),
	TonGiao nvarchar(15),
	QuocTich nvarchar(30),
	CMND nvarchar(20),
	CapNgay Date,
	NoiCap nvarchar(20),
	ConThuongBinhLietSi bit,
	ConMeVNAnhHung bit,
	BanThanLaBoDoi bit,
	DangVien bit,
	VaoDoan Date,
	DangLamViec bit,
	NgayVaoDang	Date,
	NgayChinhThuc Date,
	HinhNhanVien varchar(MAX),
	PhongBanId int not null foreign key references PhongBan(Id),
)
go


insert into PhongBan values (N'Ban Giám Đốc')

insert into PhongBan values (N'Chỉ đạo tuyến và quản lý chất lượng bệnh viện')

insert into PhongBan values (N'Công nghệ thông tin')

insert into PhongBan values (N'Điều Dưỡng')

insert into PhongBan values (N'Kế hoạch tổng hợp')
insert into PhongBan values (N'Tài chính kế toán')

select * from PhongBan where TenPhongBan = N'Chỉ đạo tuyến và quản lý chất lượng bệnh viện'

INSERT INTO NhanVien(MaCC,HoNV,TenNV,GioiTinh,NgaySinh,NoiSinh,QueQuan, DiaChiThuongTru,TinhThanh,DiaChiTamTru,DienThoai,DTDD,DanToc,TonGiao,QuocTich, CMND,CapNgay,NoiCap,ConThuongBinhLietSi,ConMeVNAnhHung,BanThanLaBoDoi,DangVien,VaoDoan,DangLamViec,NgayVaoDang,NgayChinhThuc,HinhNhanVien, PhongBanId)
VALUES ('MACC0001','HoNV01','TenNV01',1,'1991-01-10','Noi Sinh 1','Que Quan 1', 'Dia chi thuong tru 1','Tinh Thanh 1','Dia chi tam tru 1','01111111111','01111111111','Dan toc 1','Ton giao 1','Quoc tich 1','CMND1','2000-02-01','NoiCap',1,1,1,1,'2005-02-04',1,'2010-02-01','2012-02-09','Hinh Nhan Vien', 1);
		
select * from NhanVien where DangLamViec = 1
