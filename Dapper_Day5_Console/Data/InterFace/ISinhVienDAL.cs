using System.Collections.Generic;
using Dapper_Day5_Console.Models;

namespace Dapper_Day5_Console.Data.InterFace
{
    public interface ISinhVienDAL
    {
        //connect database
        void ConnectDataBaseSinhVien();
        //get list SinhVien read data from database
        List<SinhVien> GetAllSinhVien();
        //get list MonHoc read data from database
        List<MonHoc> GetAllMonHoc();
        //get list BangDiem read data from database
        List<BangDiem> GetAllBangDiem();
        //get all sinhvien,BangDiem,MonHoc read data from database
        void GetAllInOne(ref List<SinhVien> lsv, ref List<MonHoc> lmh, ref List<BangDiem> lbd);
        //update Core To Database when change
        void updateScoreLive(string maSinhVien, string maMH, double diemTPnew, double diemQTnew);
    }
}
