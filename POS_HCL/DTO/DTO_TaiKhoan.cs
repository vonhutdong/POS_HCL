using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {
        private string maNV;
        private string tenNv;
        private string tenDangNhap;
        private string matKhau;
        private int quyen;

        public DTO_TaiKhoan(string maNV, string tenNv, string tenDangNhap, string matKhau, int quyen)
        {
            this.maNV = maNV;
            this.tenNv = tenNv;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.quyen = quyen;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNv { get => tenNv; set => tenNv = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int Quyen { get => quyen; set => quyen = value; }
    }
}
