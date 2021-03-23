using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVQLSV
{
    // BACK-END
    // NGHIEP VU QUAN LY SINH VIEN
    public class QLSV_DT
    {
        // Design Pattern: Singleton -> chỉ cho phép tạo duy nhất 1 đối tượng
        private DataTable _DB;
        private static QLSV_DT _Instance;

        public DataTable DB
        {
            get => _DB;
            set => _DB = value;
        }
        public static QLSV_DT Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSV_DT();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        private QLSV_DT() // Ben ngoai lop ko truy cap duoc
        {
            CreateDB();
        }
        public void CreateDB()
        {
            // Tao Columns cho DB (7 Columns)
            DB = new DataTable();
            DB.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("Họ và Tên", typeof(string)),
                new DataColumn("Giới tính", typeof(bool)),
                new DataColumn("Ngày sinh", typeof(DateTime)),
                new DataColumn("Địa chỉ", typeof(string)),
                new DataColumn("Phone", typeof(string)),
                new DataColumn("Lớp học phần", typeof(string)),
            });
            // Tao Rows cho DB
            DB.Rows.Add(new object[] { "102000001", "Nguyễn Văn An", true, DateTime.Now, "Đà Nẵng", "0978645612", "19TCLC_DT1" });
            DB.Rows.Add(new object[] { "102000002", "Phạm Thế Cụ", true, DateTime.Now, "Quảng Nam", "0978645333", "19TCLC_DT1" });
            DB.Rows.Add(new object[] { "102000003", "Nguyễn Thị Hoa", false, DateTime.Now, "Huế", "0978645444", "19TCLC_DT2" });
        }
        public DataTable GetSV_ByLopHP(string txtLopHP)
        {
            DataTable dt = new DataTable();
            dt = DB.Clone(); // Sao chep all columns DB -> dt
            if (txtLopHP == "All")
            {
                dt = DB;
            }
            else
            {
                foreach (DataRow i in DB.Rows)
                {
                    if (i["Lớp học phần"].ToString() == txtLopHP)
                    {
                        dt.Rows.Add(new object[]
                        {
                            i["MSSV"], i["Họ và Tên"], i["Giới tính"], i["Ngày sinh"], i["Địa chỉ"],
                            i["Phone"], i["Lớp học phần"]
                        });
                    }
                }
            }
            return dt;
        }
        public List<string> GetTenLopHP()
        {
            List<string> data = new List<string>();
            foreach (DataRow i in DB.Rows)
            {
                data.Add(i["Lớp học phần"].ToString());
            }
            return data;
        }
        public DataRow GetSV_ByMSSV(string ms)
        {
            DataRow dr = DB.NewRow();
            try
            {
                foreach (DataRow i in DB.Rows)
                {
                    if (i["MSSV"].ToString() == ms)
                    {
                        dr = i;
                    }
                }
                return dr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Add(params object[] data)
        {
            try
            {
                DB.Rows.Add(new object[]
                {
                    data[0], data[1], data[2], data[3], data[4], data[5], data[6]
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(params object[] data)
        {
            bool check = false;
            try
            {
                // kiểm tra xem có DataRow trùng mssv
                // nếu có thì update, nếu ko thì trả về false
                foreach (DataRow i in DB.Rows)
                {
                    if (i["MSSV"].ToString() == data[0].ToString())
                    {
                        i["Họ và Tên"] = data[1].ToString();
                        i["Giới tính"] = Convert.ToBoolean(data[2].ToString());
                        i["Ngày sinh"] = Convert.ToDateTime(data[3].ToString());
                        i["Địa chỉ"] = data[4].ToString();
                        i["Phone"] = data[5].ToString();
                        i["Lớp học phần"] = data[6].ToString();
                        check = true;
                    }
                }
                return check;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Del(List<string> data)
        {
            try
            {
                foreach (string j in data)
                {
                    foreach (DataRow i in DB.Select())
                    {
                        if (i["MSSV"].ToString() == j)
                        {
                            DB.Rows.Remove(i);
                        }
                    }
                    DB.AcceptChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }

}
