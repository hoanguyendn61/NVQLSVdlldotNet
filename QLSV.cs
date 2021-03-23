using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVQLSV
{
    public class QLSV
    {
        private static QLSV _Instance;
        public static QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSV();
                }
                return _Instance;
            }
            private set { _Instance = value; }
        }

        private List<SV> _SVs;

        public List<SV> SVs
        {
            get { return _SVs; }
            private set { _SVs = value; }
        }
        private QLSV()
        {
            SVs = new List<SV>();
            SVs.AddRange(new SV[]
            {
                new SV
                {
                    MSSV = "102000001",
                    HoTen ="Nguyễn Văn An",
                    GioiTinh = true,
                    NgaySinh = DateTime.Now,
                    Address = "Đà Nẵng",
                    Phone = "0978645612",
                    LopHP = "19TCLC_DT1"
               },
                new SV
                {
                    MSSV = "102000002", 
                    HoTen = "Phạm Thế Cụ", 
                    GioiTinh = true, 
                    NgaySinh = DateTime.Now, 
                    Address = "Quảng Nam", 
                    Phone = "0978645333", 
                    LopHP = "19TCLC_DT1"
                },
                new SV
                {
                    MSSV = "102000003", 
                    HoTen = "Nguyễn Thị Hoa", 
                    GioiTinh = false, 
                    NgaySinh = DateTime.Now, 
                    Address = "Huế", 
                    Phone = "0978645444", 
                    LopHP = "19TCLC_DT2"
                }
            });
        }
        public List<SV> GetAllSV()
        {
            return SVs;
        }
    }

}
