using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFQuanLyNhanVien.Controller;

namespace WFQuanLyNhanVien
{
    class NhanVienADO
    {
        //private string ConnectionString = @"Data Source=DESKTOP-H8M37V7\SQLEXPRESS;Initial Catalog=WFQuanLyNhanVien;User ID=sa;Password=123";
        private string ConnectionString = ConnectDBString.connectionString();
        private SqlConnection conn;
        public DataSet selectAllNhanVien()
        { 
            conn = new SqlConnection(ConnectionString);
            string queryString = "select nv.Id, nv.MaCC, nv.HoNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.NoiSinh," +
                "nv.QueQuan, nv.DiaChiThuongTru, nv.TinhThanh, nv.DiaChiTamTru, nv.DienThoai, nv.DTDD, nv.DanToc, nv.TonGiao" +
                 "nv.QuocTich, nv.CMND, nv.CapNgay, nv.NoiCap, nv.ConThuongBinhLietSi, nv.ConMeVNAnhHung, nv.BanThanLaBoDoi" +
                 "nv.DangVien, nv.VaoDoan, nv.DangLamViec, nv.NgayVaoDang, nv.NgayChinhThuc, nv.HinhNhanVien, pb.TenPhongBan" +
                " from NhanVien as nv inner join PhongBan as pb on nv.PhongBanId = pb.Id";
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataTable selectNhanVientheoPhongBan(int IdPhongBan)
        {
            conn = new SqlConnection(ConnectionString);
            string queryString = "SELECT * FROM NhanVien Where PhongBanId = @IdPhongBan";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@IdPhongBan", IdPhongBan);
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.Open();
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            //binding dataset
            dataAdapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable selectNhanVientheoDangLamViecTheoPhongBan(int IdPhongBan)
        {
            conn = new SqlConnection(ConnectionString);
            string queryString = "select * from NhanVien where ((DangLamViec = 1) and (PhongBanId = @IdPhongBan))";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@IdPhongBan", IdPhongBan);
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.Open();
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            //binding dataset
            dataAdapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable selectNhanVientheoDaNghiTheoPhongBan(int IdPhongBan)
        {
            conn = new SqlConnection(ConnectionString);
            string queryString = "select * from NhanVien where ((DangLamViec = 0) and (PhongBanId = @IdPhongBan))";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@IdPhongBan", IdPhongBan);
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.Open();
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            //binding dataset
            dataAdapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataRow getIDNhanVientheoId(int IdNhanVien)
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            string queryString = "SELECT * FROM NhanVien Where (Id = @IdNhanVien)";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Parameters.AddWithValue("@IdNhanVien", IdNhanVien);
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataRow dr = null;
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            conn.Close();
            return dr;
        }

        public void insertNhanVien(NhanVien nhanVien)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            conn = new SqlConnection(ConnectionString);
            string queryString = " INSERT INTO NhanVien(MaCC, HoNV, TenNV, GioiTinh, NgaySinh," +
                " NoiSinh, QueQuan, DiaChiThuongTru, TinhThanh, DiaChiTamTru, DienThoai, DTDD," +
                " DanToc, TonGiao, QuocTich, CMND, CapNgay, NoiCap, ConThuongBinhLietSi, ConMeVNAnhHung, " +
                "BanThanLaBoDoi, DangVien, VaoDoan, DangLamViec, NgayVaoDang, NgayChinhThuc, HinhNhanVien," +
                " PhongBanId)VALUES(@MaCC, @HoNV, @TenNV, @GioiTinh, @NgaySinh," +
                "@NoiSinh, @QueQuan, @DiaChiThuongTru, @TinhThanh, @DiaChiTamTru, @DienThoai, @DTDD," +
                "@DanToc, @TonGiao, @QuocTich, @CMND, @CapNgay, @NoiCap, @ConThuongBinhLietSi, @ConMeVNAnhHung," +
                "@BanThanLaBoDoi, @DangVien, @VaoDoan, @DangLamViec, @NgayVaoDang, @NgayChinhThuc, @HinhNhanVien, " +
                "@PhongBanId);";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MaCC", nhanVien.MaCC); ;
            command.Parameters.AddWithValue("@HoNV", nhanVien.HoNV);
            command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
            command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh); ;
            command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
            command.Parameters.AddWithValue("@NoiSinh", nhanVien.NoiSinh);
            command.Parameters.AddWithValue("@QueQuan", nhanVien.QueQuan); ;
            command.Parameters.AddWithValue("@DiaChiThuongTru", nhanVien.DiaChiThuongTru);
            command.Parameters.AddWithValue("@TinhThanh", nhanVien.TinhThanh);
            command.Parameters.AddWithValue("@DiaChiTamTru", nhanVien.DiaChiTamTru); ;
            command.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
            command.Parameters.AddWithValue("@DTDD", nhanVien.DTDD);
            command.Parameters.AddWithValue("@DanToc", nhanVien.DanToc); ;
            command.Parameters.AddWithValue("@TonGiao", nhanVien.TonGiao);
            command.Parameters.AddWithValue("@QuocTich", nhanVien.QuocTich);
            command.Parameters.AddWithValue("@CMND", nhanVien.CMND); ;
            command.Parameters.AddWithValue("@CapNgay", nhanVien.CapNgay);
            command.Parameters.AddWithValue("@NoiCap", nhanVien.NoiCap);
            command.Parameters.AddWithValue("@ConThuongBinhLietSi", nhanVien.ConThuongBinhLietSi); ;
            command.Parameters.AddWithValue("@ConMeVNAnhHung", nhanVien.ConMeVNAnhHung);
            command.Parameters.AddWithValue("@BanThanLaBoDoi", nhanVien.BanThanBoDoi);
            command.Parameters.AddWithValue("@DangVien", nhanVien.DangVien); ;
            command.Parameters.AddWithValue("@VaoDoan", nhanVien.VaoDoan);
            command.Parameters.AddWithValue("@DangLamViec", nhanVien.DangLamViec);
            command.Parameters.AddWithValue("@NgayVaoDang", nhanVien.NgayVaoDang); ;
            command.Parameters.AddWithValue("@NgayChinhThuc", nhanVien.NgayChinhThuc);
            command.Parameters.AddWithValue("@HinhNhanVien", nhanVien.HinhNhanVien);
            command.Parameters.AddWithValue("@PhongBanId", nhanVien.PhongBanId); 
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();
            var rowsAffected = command.ExecuteNonQuery();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void updateNhanVien(NhanVien nhanVien)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            conn = new SqlConnection(ConnectionString);
            string queryString = "update NhanVien set MaCC = @MaCC, HoNV = @HoNV, TenNV = @TenNV," +
                                 "GioiTinh = @GioiTinh, NgaySinh  = @NgaySinh, NoiSinh = @NoiSinh, QueQuan = @QueQuan, DiaChiThuongTru = @DiaChiThuongTru," +
                                 "TinhThanh = @TinhThanh, DiaChiTamTru = @DiaChiTamTru, DienThoai = @DienThoai, DTDD = @DTDD, DanToc = @DanToc, " +
                                  "TonGiao = @TonGiao, QuocTich = @QuocTich, CMND = @CMND, CapNgay = @CapNgay, NoiCap = @NoiCap, ConThuongBinhLietSi = @ConThuongBinhLietSi, " +
                                  "ConMeVNAnhHung = @ConMeVNAnhHung, BanThanLaBoDoi = @BanThanLaBoDoi, DangVien = @DangVien, VaoDoan = @VaoDoan,  DangLamViec = @DangLamViec, " +
                                   "NgayVaoDang = @NgayVaoDang, NgayChinhThuc = @NgayChinhThuc, PhongBanId = @PhongBanId, HinhNhanVien = @HinhNhanVien " +
                                  "WHERE Id = @Id";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MaCC", nhanVien.MaCC); 
            command.Parameters.AddWithValue("@HoNV", nhanVien.HoNV);
            command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
            command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
            command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
            command.Parameters.AddWithValue("@NoiSinh", nhanVien.NoiSinh);
            command.Parameters.AddWithValue("@QueQuan", nhanVien.QueQuan); 
            command.Parameters.AddWithValue("@DiaChiThuongTru", nhanVien.DiaChiThuongTru);
            command.Parameters.AddWithValue("@TinhThanh", nhanVien.TinhThanh);
            command.Parameters.AddWithValue("@DiaChiTamTru", nhanVien.DiaChiTamTru); ;
            command.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
            command.Parameters.AddWithValue("@DTDD", nhanVien.DTDD);
            command.Parameters.AddWithValue("@DanToc", nhanVien.DanToc); ;
            command.Parameters.AddWithValue("@TonGiao", nhanVien.TonGiao);
            command.Parameters.AddWithValue("@QuocTich", nhanVien.QuocTich);
            command.Parameters.AddWithValue("@CMND", nhanVien.CMND);
            command.Parameters.AddWithValue("@CapNgay", nhanVien.CapNgay);
            command.Parameters.AddWithValue("@NoiCap", nhanVien.NoiCap);
            command.Parameters.AddWithValue("@ConThuongBinhLietSi", nhanVien.ConThuongBinhLietSi);
            command.Parameters.AddWithValue("@ConMeVNAnhHung", nhanVien.ConMeVNAnhHung);
            command.Parameters.AddWithValue("@BanThanLaBoDoi", nhanVien.BanThanBoDoi);
            command.Parameters.AddWithValue("@DangVien", nhanVien.DangVien); ;
            command.Parameters.AddWithValue("@VaoDoan", nhanVien.VaoDoan);
            command.Parameters.AddWithValue("@DangLamViec", nhanVien.DangLamViec);
            command.Parameters.AddWithValue("@NgayVaoDang", nhanVien.NgayVaoDang); ;
            command.Parameters.AddWithValue("@NgayChinhThuc", nhanVien.NgayChinhThuc);
            command.Parameters.AddWithValue("@HinhNhanVien", nhanVien.HinhNhanVien);
            command.Parameters.AddWithValue("@PhongBanId", nhanVien.PhongBanId);
            command.Parameters.AddWithValue("@Id", nhanVien.Id);

            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();
            var rowsAffected = command.ExecuteNonQuery();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void deleteNhanVien(int Id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            conn = new SqlConnection(ConnectionString);
            string queryString = "delete NhanVien where Id = @Id";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conn.Open();
            var rowsAffected = command.ExecuteNonQuery();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public int tinhSoLuongNhanVien()
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            string queryString = "SELECT COUNT(*) FROM NhanVien WHERE DangLamViec = 1";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Connection = conn;
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;
            SqlDataReader dataReader = command.ExecuteReader();
            int count = 0;

            if (dataReader.Read() == true)
            {
                count = int.Parse(dataReader[0].ToString());
            }
            
            conn.Close();
            return count;
        }



    }
}
