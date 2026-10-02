using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;

namespace BaiTap
{
    public partial class Form1 : Form
    {
        private BindingList<Employee> employees = new BindingList<Employee>();

        public Form1()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MSNV", HeaderText = "MSNV", Width = 120 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ten", HeaderText = "Tên NV", Width = 280 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LuongCB", HeaderText = "Lương CB", Width = 140 });

            employees.Add(new Employee { MSNV = "NV001", Ten = "Nguyễn Thị Thu Hiền", LuongCB = 8500000 });

            dataGridView1.DataSource = employees;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            using var f = new FormNhanVien();
            if (f.ShowDialog() == DialogResult.OK)
            {
                employees.Add(new Employee { MSNV = f.MSNV, Ten = f.Ten, LuongCB = f.LuongCB });
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var emp = dataGridView1.CurrentRow.DataBoundItem as Employee;
            if (emp == null) return;
            using var f = new FormNhanVien();
            f.MSNV = emp.MSNV;
            f.Ten = emp.Ten;
            f.LuongCB = emp.LuongCB;
      
            if (f.ShowDialog() == DialogResult.OK)
            {
                emp.Ten = f.Ten;
                emp.LuongCB = f.LuongCB;
                dataGridView1.Refresh();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var emp = dataGridView1.CurrentRow.DataBoundItem as Employee;
            if (emp == null) return;
            var r = MessageBox.Show($"Xóa nhân viên {emp.MSNV}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                employees.Remove(emp);
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        public class Employee
        {
            public string MSNV { get; set; } = string.Empty;
            public string Ten { get; set; } = string.Empty;
            public decimal LuongCB { get; set; }
        }
     }
}
