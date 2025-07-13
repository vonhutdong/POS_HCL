using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        private DatabaseAccess da = new DatabaseAccess();

        public bool CheckTaiKhoan(string tenDangNhap, string matKhau)
        {
            var query = from tk in da.Db.NhanViens
                        where tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau
                        select tk;

            if (query.Count() == 1)
            {
                return true;
            }
            return false;
        }

        public int getIdTaiKhoan(string tenDangNhap, string matKhau)
        {
            var query = (from tk in da.Db.NhanViens
                         where tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau
                         select tk).FirstOrDefault();
            return query.MaNV;
        }
        public IQueryable GetListTK()
        {
            IQueryable query = from tk in da.Db.NhanViens
                               select new
                               {
                                   tk.MaNV,
                                   tk.TenNV,
                                   tk.TenDangNhap,
                                   tk.MatKhau,
                                   tk.Quyen
                               };
            return query;
        }

        public IQueryable GetListTKByQuyen()
        {
            IQueryable query = from tk in da.Db.NhanViens
                               group tk by tk.Quyen into q
                               select new
                               {
                                   Quyen = q.Key
                               };
            return query;
        }

        public IQueryable GetListAllTKByTenTK()
        {
            IQueryable query = from tk in da.Db.NhanViens
                               select new
                               {
                                   Id = tk.MaNV,
                                   TenDangNhap = tk.TenDangNhap
                               };
            return query;
        }

        public int GetRole(string tenDangNhap, string matKhau)
        {
            var query = (from tk in da.Db.NhanViens
                         where tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau
                         select new
                         {
                             Quyen = tk.Quyen
                         }).FirstOrDefault();
            return (int)query.Quyen;
        }
    }
}
