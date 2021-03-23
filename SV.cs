using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVQLSV
{
    public class SV
    {
        private string _MSSV;
        private string _HoTen;
        private bool _GioiTinh;
        private DateTime _NgaySinh;
        private string _Phone;
        private string _Address;
        private string _LopHP;
        public string MSSV
        {
            get { return _MSSV; }
            set { _MSSV = value; }
        }
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        public bool GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        public string LopHP
        {
            get { return _LopHP; }
            set { _LopHP = value; }
        }
        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

      

       

        

        


    }

}
