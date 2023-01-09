using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFQuanLyNhanVien
{
    class NhanVien
    {
        int id;
		string maCC;
		string hoNV;
		string tenNV;
		bool gioiTinh;
		DateTime ngaySinh;
		string noiSinh;
		string queQuan;
		string diaChiThuongTru;
		string tinhThanh;
		string diaChiTamTru;
		string dienThoai;
		string dTDD;
		string danToc;
		string tonGiao;
		string quocTich;
		string cMND;
		DateTime capNgay;
		string noiCap;
        bool conThuongBinhLietSi;
        bool conMeVNAnhHung;
        bool banThanBoDoi;
        bool dangVien;
		DateTime vaoDoan;
        bool dangLamViec;
		DateTime ngayVaoDang;
		DateTime ngayChinhThuc;
		string hinhNhanVien;
		int phongBanId;

        public int Id { get => id; set => id = value; }
        public string MaCC { get => maCC; set => maCC = value; }
        public string HoNV { get => hoNV; set => hoNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string NoiSinh { get => noiSinh; set => noiSinh = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string DiaChiThuongTru { get => diaChiThuongTru; set => diaChiThuongTru = value; }
        public string TinhThanh { get => tinhThanh; set => tinhThanh = value; }
        public string DiaChiTamTru { get => diaChiTamTru; set => diaChiTamTru = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string DTDD { get => dTDD; set => dTDD = value; }
        public string DanToc { get => danToc; set => danToc = value; }
        public string TonGiao { get => tonGiao; set => tonGiao = value; }
      
        public string CMND { get => cMND; set => cMND = value; }
        public DateTime CapNgay { get => capNgay; set => capNgay = value; }
        public string NoiCap { get => noiCap; set => noiCap = value; }
        public bool ConThuongBinhLietSi { get => conThuongBinhLietSi; set => conThuongBinhLietSi = value; }
        public bool ConMeVNAnhHung { get => conMeVNAnhHung; set => conMeVNAnhHung = value; }
        public bool DangVien { get => dangVien; set => dangVien = value; }
        public DateTime VaoDoan { get => vaoDoan; set => vaoDoan = value; }
        public bool DangLamViec { get => dangLamViec; set => dangLamViec = value; }
        public DateTime NgayVaoDang { get => ngayVaoDang; set => ngayVaoDang = value; }
        public DateTime NgayChinhThuc { get => ngayChinhThuc; set => ngayChinhThuc = value; }
        public string HinhNhanVien { get => hinhNhanVien; set => hinhNhanVien = value; }
        public int PhongBanId { get => phongBanId; set => phongBanId = value; }
        public string QuocTich { get => quocTich; set => quocTich = value; }
        public bool BanThanBoDoi { get => banThanBoDoi; set => banThanBoDoi = value; }
    }
}
