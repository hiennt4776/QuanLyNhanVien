using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFQuanLyNhanVien.Controller;

namespace WFQuanLyNhanVien
{
    public partial class Form1 : Form
    {
        private PhongBanADO phongBanADO = new PhongBanADO();

        private NhanVienADO nhanVienADO = new NhanVienADO();
        Boolean isEdit = false;
        OpenFileDialog open = new OpenFileDialog();
        string CorrectFilename = "";
        bool changeImageEdit = false;


        string[] GioiTinh = { "Nữ" ,"Nam"};
        string[] TinhThanh = { "Hà Nội", "Đà Nẵng", "Huế", "TP Hồ Chí Minh" };
        string[] DanToc = { "Kinh", "Tày", "Nùng", "Thái", "Khác" };
        string[] TonGiao = { "Không", "Phật", "Thiên Chúa", "Khác" };
        string[] QuocTich = { "Việt Nam", "Lào", "Campuchia", "Thái Lan", "Khác" };

        void Clear()
        {
            txtMaNhanVien.Text = "";
            txtMaCC.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            cmbGioiTinh.SelectedIndex = 1;
            dtmNgaySinh.Value = DateTime.Now;         
            txtNoiSinh.Text = "";
            txtQueQuan.Text = "";
            txtDiaChiThuongTru.Text = "";
            cmbTinhThanh.SelectedIndex = 0;
            txtDiaChiTamTru.Text = "";
            txtDienThoai.Text = "";
            txtDTDD.Text = "";
            cmbDanToc.SelectedIndex = 0;
            cmbTonGiao.SelectedIndex = 0;
            cmbQuocTich.SelectedIndex = 0;
            txtCMND.Text = "";
            dtmCapNgay.Value = DateTime.Now;
            txtNoiCap.Text = "";
            chkConThuongBinh.Checked = false;
            chkConMeVN.Checked = false;
            chkBanThanBoDoi.Checked = false;
            chkDangVien.Checked = false;
            dtmVaoDoan.Value = DateTime.Now;
            chkDangLamViec.Checked = false;
            dtmNgayVaoDang.Value = DateTime.Now;
            dtmNgayChinhThuc.Value = DateTime.Now;
            cmbPhongBan.SelectedIndex = 0;
            CorrectFilename = "";
            picImage.Image = null;

        }

        void LoadGioiTinh()
        {
            cmbGioiTinh.Items.AddRange(GioiTinh);
            cmbGioiTinh.SelectedIndex = 1;
        }
        void LoadDanToc()
        {
            cmbDanToc.Items.AddRange(DanToc);
            cmbDanToc.SelectedIndex = 0;
        }
        void LoadTonGiao()
        {
            cmbTonGiao.Items.AddRange(TonGiao);
            cmbTonGiao.SelectedIndex = 0;
        }
        void LoadQuocTich()
        {
            cmbQuocTich.Items.AddRange(QuocTich);
            cmbQuocTich.SelectedIndex = 0;
        }
        void LoadTinhThanh()
        {
           cmbTinhThanh.Items.AddRange(TinhThanh);
            cmbTinhThanh.SelectedIndex = 0;
        }
        void LoadPhongBanDangLamViec()
        {
            tvPhongBan.Nodes.Clear();
            List<PhongBan> lstPhongBan = new List<PhongBan>();           
            DataTable phongBanDataTable = phongBanADO.selectAllPhongBan();
      
            TreeNode phongBanNode = new TreeNode();
            foreach (DataRow item in phongBanDataTable.Rows)
            {
                phongBanNode = tvPhongBan.Nodes.Add(item["Id"].ToString(), item["TenPhongBan"].ToString(),1);
                LoadNhanVienDangLamViecTreeView(Convert.ToInt32(item["Id"].ToString()), phongBanNode);
                PhongBan phongBan = new PhongBan();
                phongBan.Id = item.Field<int>("Id");
                phongBan.TenPhongBan = item.Field<string>("TenPhongBan");
                lstPhongBan.Add(phongBan);
            }
            cmbPhongBan.DataSource = lstPhongBan;
            cmbPhongBan.DisplayMember = "TenPhongBan";
            cmbPhongBan.ValueMember = "Id";
        }

        void LoadPhongDaNghiViec()
        {
            tvPhongBan.Nodes.Clear();
            List<PhongBan> lstPhongBan = new List<PhongBan>();
            DataTable phongBanDataTable = phongBanADO.selectAllPhongBan();
            TreeNode phongBanNode = new TreeNode();
            foreach (DataRow item in phongBanDataTable.Rows)
            {
                phongBanNode = tvPhongBan.Nodes.Add(item["Id"].ToString(), item["TenPhongBan"].ToString(), 1);
                LoadNhanVienDaNghiTreeView(Convert.ToInt32(item["Id"].ToString()), phongBanNode);
                PhongBan phongBan = new PhongBan();
                phongBan.Id = item.Field<int>("Id");
                phongBan.TenPhongBan = item.Field<string>("TenPhongBan");
                lstPhongBan.Add(phongBan);
            }
            cmbPhongBan.DataSource = lstPhongBan;
            cmbPhongBan.DisplayMember = "TenPhongBan";
            cmbPhongBan.ValueMember = "Id";
        }

        int indexPhongBan(int ID)
        {
            int index = -1;
            List<PhongBan> lstPhongBan = new List<PhongBan>();
            DataTable phongBanDataTable = phongBanADO.selectAllPhongBan();
            foreach (DataRow item in phongBanDataTable.Rows)
            {
                PhongBan phongBan = new PhongBan();
                phongBan.Id = item.Field<int>("Id");
                phongBan.TenPhongBan = item.Field<string>("TenPhongBan");
                lstPhongBan.Add(phongBan);
            }
            for (int i = 0; i < lstPhongBan.Count; i++)
            {
                if (lstPhongBan[i].Id == ID) index = i;
            }
            return index;
        }


        void LoadNhanVienDangLamViecTreeView(int phongBanId, TreeNode phongBanNode)
        {
        
            DataTable nhanvienPhongBanDataTable = nhanVienADO.selectNhanVientheoDangLamViecTheoPhongBan(phongBanId);
            TreeNode nhanVienNode = new TreeNode();
            try
            {
                foreach (DataRow item in nhanvienPhongBanDataTable.Rows)
                {
                    string tenHoTen = item["TenNV"].ToString() + ", " + item["HoNV"].ToString() + " " + item["TenNV"].ToString();
                    nhanVienNode = phongBanNode.Nodes.Add(item["Id"].ToString(), tenHoTen,2);          
                }
            }
            catch (Exception ex)
            {

            }
        }

        void LoadNhanVienDaNghiTreeView(int phongBanId, TreeNode phongBanNode)
        {

            DataTable nhanvienPhongBanDataTable = nhanVienADO.selectNhanVientheoDaNghiTheoPhongBan(phongBanId);
            TreeNode nhanVienNode = new TreeNode();
            try
            {
                foreach (DataRow item in nhanvienPhongBanDataTable.Rows)
                {
                    string tenHoTen = item["TenNV"].ToString() + ", " + item["HoNV"].ToString() + " " + item["TenNV"].ToString();
                    nhanVienNode = phongBanNode.Nodes.Add(item["Id"].ToString(), tenHoTen, 2);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Form1()
        {
            InitializeComponent();

           

            LoadPhongBanDangLamViec();
            LoadGioiTinh();
            LoadDanToc();
            LoadTonGiao();
            LoadQuocTich();
            LoadTinhThanh();
            chkDangLamViec.Enabled = true;
            lblTongNhanSu.Text = "Tổng số nhân sự " + nhanVienADO.tinhSoLuongNhanVien().ToString();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            dtmNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtmNgaySinh.Format = DateTimePickerFormat.Custom;
            dtmCapNgay.CustomFormat = "dd/MM/yyyy";
            dtmCapNgay.Format = DateTimePickerFormat.Custom;
            dtmNgayChinhThuc.CustomFormat = "dd/MM/yyyy";
            dtmNgayChinhThuc.Format = DateTimePickerFormat.Custom;
            dtmNgayVaoDang.CustomFormat = "dd/MM/yyyy";
            dtmNgayVaoDang.Format = DateTimePickerFormat.Custom;
            dtmVaoDoan.CustomFormat = "dd/MM/yyyy";
            dtmVaoDoan.Format = DateTimePickerFormat.Custom;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel4.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHo.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show("Bạn phải nhập họ tên");
            }
            else
            {

                NhanVien nhanVien = new NhanVien();
                nhanVien.MaCC = txtMaCC.Text.ToString();
                nhanVien.HoNV = txtHo.Text.ToString();
                nhanVien.TenNV = txtTen.Text.ToString();
                if (cmbGioiTinh.SelectedIndex == 1) nhanVien.GioiTinh = true;
                else nhanVien.GioiTinh = false;
                nhanVien.NgaySinh = dtmNgaySinh.Value;
                nhanVien.NoiSinh = txtNoiSinh.Text.ToString();
                nhanVien.QueQuan = txtQueQuan.Text.ToString();
                nhanVien.DiaChiThuongTru = txtDiaChiThuongTru.Text.ToString();
                nhanVien.TinhThanh = cmbTinhThanh.SelectedItem.ToString();
                nhanVien.DiaChiTamTru = txtDiaChiTamTru.Text.ToString();
                nhanVien.DienThoai = txtDienThoai.Text.ToString();
                nhanVien.DTDD = txtDTDD.Text.ToString();
                nhanVien.DanToc = cmbDanToc.SelectedItem.ToString();
                nhanVien.TonGiao = cmbTonGiao.SelectedItem.ToString();
                nhanVien.QuocTich = cmbQuocTich.SelectedItem.ToString(); ;
                nhanVien.CMND = txtCMND.Text.ToString();
                nhanVien.CapNgay = dtmCapNgay.Value;
                nhanVien.NoiCap = txtNoiCap.Text.ToString();
                nhanVien.ConThuongBinhLietSi = chkConThuongBinh.Checked;
                nhanVien.ConMeVNAnhHung = chkConMeVN.Checked;
                nhanVien.BanThanBoDoi = chkBanThanBoDoi.Checked; ;
                nhanVien.DangVien = chkDangVien.Checked;
                nhanVien.VaoDoan = dtmVaoDoan.Value;
                nhanVien.DangLamViec = chkDangLamViec.Checked;
                nhanVien.NgayVaoDang = dtmNgayVaoDang.Value;
                nhanVien.NgayChinhThuc = dtmNgayChinhThuc.Value;
                nhanVien.PhongBanId = int.Parse(cmbPhongBan.SelectedValue.ToString());
                nhanVien.HinhNhanVien = CorrectFilename;
                try
                {
                    if (isEdit)
                    {
                        nhanVien.Id = int.Parse(txtMaNhanVien.Text.ToString());
                        if (changeImageEdit)
                        {
                            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                            CorrectFilename = System.IO.Path.GetFileName(open.FileName);
                            if (!System.IO.Directory.Exists(paths + "\\Images\\"))
                            {
                                Directory.CreateDirectory(paths + "\\Images\\");
                            }
                            System.IO.File.Copy(open.FileName, paths + "\\Images\\" + CorrectFilename);
                        }
                        nhanVien.HinhNhanVien = CorrectFilename;
                        nhanVienADO.updateNhanVien(nhanVien);
                    }
                    else
                    {
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        CorrectFilename = System.IO.Path.GetFileName(open.FileName);
                        if (!System.IO.Directory.Exists(paths + "\\Images\\"))
                        {
                            Directory.CreateDirectory(paths + "\\Images\\");
                        }

                        System.IO.File.Copy(open.FileName, paths + "\\Images\\" + CorrectFilename);
                        nhanVien.HinhNhanVien = CorrectFilename;

                        nhanVienADO.insertNhanVien(nhanVien);
                    }

                    panel1.Enabled = false;
                    panel4.Enabled = false;
                    btnSave.Enabled = false;
                    isEdit = false;
                    tvPhongBan.Nodes.Clear();
                    LoadPhongBanDangLamViec();
                    Clear();
                }




                catch (Exception ex)
                {
                    if(CorrectFilename == "") {
                        MessageBox.Show("Bạn phải nhập ảnh", "Warning");
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString(), "Warning");
                    }
                    
                }

            }
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            Clear();
        }

        private void btnImageUpload_Click(object sender, EventArgs e)
        {

            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files (*.jpg)|*.jpg|All Files(*.*)|*.*";
            open.FilterIndex = 1;
         

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    picImage.Image = Image.FromFile(open.FileName);

                    if (isEdit) {
                        changeImageEdit = true;
                    }
                }
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            CorrectFilename = "";
     
            picImage.Image = null;
            changeImageEdit = true;
        }

        private void tvPhongBan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(tvPhongBan.SelectedNode.ImageIndex == 2)
            {
                int IDSelect = Convert.ToInt32(tvPhongBan.SelectedNode.Name.ToString());
                DataRow dr = nhanVienADO.getIDNhanVientheoId(IDSelect);
                if (dr != null)
                {
                    txtMaNhanVien.Text = Convert.ToString(IDSelect);
                    txtHo.Text = dr["HoNV"].ToString();
                    txtTen.Text = dr["TenNV"].ToString();
                    txtMaCC.Text = dr["MaCC"].ToString();
                    if ((bool)dr["GioiTinh"]) cmbGioiTinh.SelectedIndex = 1;
                    else cmbGioiTinh.SelectedIndex = 0;
                    dtmNgaySinh.Value = Convert.ToDateTime(dr["NgaySinh"]);
                    txtNoiSinh.Text = dr["NoiSinh"].ToString();
                    txtQueQuan.Text = dr["QueQuan"].ToString();
                    txtDiaChiThuongTru.Text = dr["DiaChiThuongTru"].ToString();
                    cmbTinhThanh.SelectedItem = dr["TinhThanh"].ToString();
                    txtDiaChiTamTru.Text = dr["DiaChiTamTru"].ToString();
                    txtDienThoai.Text = dr["DienThoai"].ToString();
                    txtDTDD.Text = dr["DTDD"].ToString();
                    cmbDanToc.SelectedItem = dr["DanToc"].ToString();
                    cmbTonGiao.SelectedItem = dr["TonGiao"].ToString();
                    cmbQuocTich.SelectedItem = dr["QuocTich"].ToString();
                    txtCMND.Text = dr["CMND"].ToString();
                    dtmCapNgay.Value = Convert.ToDateTime(dr["CapNgay"]);
                    txtNoiCap.Text = dr["NoiCap"].ToString();
                    chkConThuongBinh.Checked = (bool)dr["ConThuongBinhLietSi"];
                    chkConMeVN.Checked = (bool)dr["ConMeVNAnhHung"];
                    chkBanThanBoDoi.Checked = (bool)dr["BanThanLaBoDoi"];
                    chkDangVien.Checked = (bool)dr["DangVien"];
                    chkDangLamViec.Checked = (bool)dr["DangLamViec"];
                    dtmVaoDoan.Value = Convert.ToDateTime(dr["VaoDoan"]);
                    dtmNgayVaoDang.Value = Convert.ToDateTime(dr["NgayVaoDang"]);
                    dtmNgayChinhThuc.Value = Convert.ToDateTime(dr["NgayChinhThuc"]);
                    cmbPhongBan.SelectedIndex = indexPhongBan((int)dr["PhongBanId"]);
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    picImage.Image = Image.FromFile(paths + "\\Images\\" + dr["HinhNhanVien"].ToString());
                    CorrectFilename = dr["HinhNhanVien"].ToString();
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                Clear();
            }
           

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEdit = true;
            panel1.Enabled = true;
            panel4.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc xóa nhân viên này?";
            string title = "Xác nhận";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

                nhanVienADO.deleteNhanVien(int.Parse(txtMaNhanVien.Text.ToString()));
            }

            tvPhongBan.Nodes.Clear();
            LoadPhongBanDangLamViec();
            Clear();
        }

        private void chkNhanVienNghi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNhanVienNghi.Checked)
            {
                tvPhongBan.Nodes.Clear();
                LoadPhongDaNghiViec();
            }
            else
            {
                tvPhongBan.Nodes.Clear();
                LoadPhongBanDangLamViec();
            }
        }
    }
}
