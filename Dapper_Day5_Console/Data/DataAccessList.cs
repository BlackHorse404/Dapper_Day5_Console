using System;
using System.Collections.Generic;
using Dapper_Day5_Console.Models;
using Dapper_Day5_Console.Utilities;
using Dapper_Day5_Console.Data.InterFace;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Dapper_Day5_Console.Data
{
    public class DataAccessList : ISinhVienDAL
    {
        //thuộc tính 
        #region attribute
        public string serverName { get; set; }
        public string dataBaseName { get; set;}

        private List<SinhVien> _lSinhVien = new List<SinhVien>();
        private List<MonHoc> _lMonHoc = new List<MonHoc>();
        private List<BangDiem> _lBangDiem = new List<BangDiem>();
        #endregion

        //constructor
        #region Constructor
        public DataAccessList()
        {
            ConnectDataBaseSinhVien();
        }
        #endregion

        //hàm kết nối tới Database
        #region Kết nối database + truy xuất dữ liệu
        //input Server Name + DB Name
        private void InputDBServer()
        {
            //nhập vào Server Name, Database Name để lấy thông tin kết nối
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[!] Để trống ServerName nếu muốn lấy tên Server mặc định tự nhận theo máy !");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[>] "); Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nhập vào Server Name: ");
            serverName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[>] "); Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nhập vào Database Name (DatabaseSinhVien): ");
            dataBaseName = Console.ReadLine();
            Console.ResetColor();
            //thông báo đang kết nối
            ExceptionNotice.WarningConnectingDB();
        }
        //Hàm kết nối sqlDataBase
        public void ConnectDataBaseSinhVien()
        {
            InputDBServer();

            string connectionString = @"Data Source=" + serverName + ";Initial Catalog=" + dataBaseName + ";Integrated Security=True";
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    _lSinhVien = db.Query<SinhVien>("SELECT * FROM SINHVIEN").ToList<SinhVien>();
                    _lBangDiem = db.Query<BangDiem>("SELECT * FROM BangDiem").ToList<BangDiem>();
                    _lMonHoc = db.Query<MonHoc>("SELECT * FROM MONHOC").ToList<MonHoc>();
                }
                ExceptionNotice.SuccessConnectDatabase(); 
                Thread.Sleep(2000);
                Console.Clear();
            }
            catch
            {
                Console.WriteLine(ExceptionNotice.ExceptionConnectDatabase().Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
            
        }
        //update core when change
        public void updateScoreLive(string maSinhVien, string maMH, double diemTPnew, double diemQTnew)
        {
            string connectionString = @"Data Source=" + serverName + ";Initial Catalog=" + dataBaseName + ";Integrated Security=True";
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute("UPDATE BangDiem SET DiemThanhPhan = " + diemTPnew + ", DiemQuaTrinh = " + diemQTnew + " WHERE MaMonHoc = '" + maMH + "' AND MaSinhVien = '" + maSinhVien+"'");
                }
            }
            catch
            {
                ExceptionNotice.ExceptionErrorUpdate();
                Console.ReadKey();
                return;
            }
        }
        #endregion

        //method select get All
        #region Method Select Object
        //method select all sinh vien
        public List<SinhVien> GetAllSinhVien() => _lSinhVien;
        //method select all Mon Hoc
        public List<MonHoc> GetAllMonHoc() => _lMonHoc;
        //method select all Bang Diem
        public List<BangDiem> GetAllBangDiem() => _lBangDiem;
        //method select all in one
        public void GetAllInOne(ref List<SinhVien> lsv, ref List<MonHoc> lmh, ref List<BangDiem> lbd)
        {
            lsv = _lSinhVien;
            lmh = _lMonHoc;
            lbd = _lBangDiem;
        }

        #endregion
    }
}
