using System;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
   
            if (string.IsNullOrWhiteSpace(txtMSNV.Text))
            {
                MessageBox.Show("MSNV không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên nhân viên không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtLuong.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var luong))
            {
         
                if (!decimal.TryParse(txtLuong.Text, out luong))
                {
                    MessageBox.Show("Lương không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            LuongCB = luong;
            MSNV = txtMSNV.Text.Trim();
            Ten = txtTen.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        public string MSNV
        {
            get => txtMSNV.Text;
            set => txtMSNV.Text = value;
        }

        public string Ten
        {
            get => txtTen.Text;
            set => txtTen.Text = value;
        }

        public decimal LuongCB
        {
            get
            {
                if (decimal.TryParse(txtLuong.Text, out var v)) return v;
                return 0;
            }
            set => txtLuong.Text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
