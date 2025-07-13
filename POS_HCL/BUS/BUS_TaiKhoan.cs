using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        // Fields
        private DAL_TaiKhoan dal_tk = new DAL_TaiKhoan();
        private DatabaseAccess dbAccess = new DatabaseAccess();
        // Methods
        public bool CheckTaiKhoan(string taiKhoan, string matKhau)
        {
            return dal_tk.CheckTaiKhoan(taiKhoan, matKhau);
        }
        public int getIdTaiKhoan(string taiKhoan, string matKhau)
        {

            return dal_tk.getIdTaiKhoan(taiKhoan, matKhau);
        }

        public int GetRole(string taiKhoan, string matKhau)
        {
            return dal_tk.GetRole(taiKhoan, matKhau);
        }

        public IQueryable GetListTK()
        {
            return dal_tk.GetListTK();
        }

        public IQueryable GetListTKByQuyen()
        {
            return dal_tk.GetListTKByQuyen();
        }

        public IQueryable GetListAllTKByTenTK()
        {
            return dal_tk.GetListAllTKByTenTK();
        }

        //public IQueryable GetListOneTKByTenTK(int id)
        //{
        //    return dal_tk.GetListOneTKByTenTK(id);
        //}
    }
}
