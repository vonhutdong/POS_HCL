using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace WindowsFormsApp1
{
    public partial class From1 : Form
    {
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        public From1()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frm_TrangChu fm = new frm_TrangChu();
            fm.ShowDialog();
        }
    }
}
