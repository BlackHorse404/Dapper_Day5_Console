using System;

namespace Dapper_Day5_Console.Models
{
    public class MonHoc
    {
        //thuộc tính môn học
        #region Thuộc tính
        private string _maMonHoc;
        private string _tenMonHoc;
        private int _soTiet;
        private string _loaiMon;
        #endregion

        //phương thức môn học
        #region Constructor
        //constructor Mon Hoc khởi tạo dữ liệu cho các thuộc tính MonHoc
        public MonHoc()
        {

        }
        public MonHoc(string maMonHoc, string tenMonHoc, string SoTiet, string loaiMon)
        {
            _maMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            this.SoTiet = int.Parse(SoTiet);
            LoaiMon = loaiMon;
        }
        #endregion

        //property
        #region Property
        //lấy ra mã môn 
        public string MaMonHoc { get => _maMonHoc; set => _maMonHoc = value; }
        public string TenMonHoc { get => _tenMonHoc; set => _tenMonHoc = value; }
        public int SoTiet { get => _soTiet; set => _soTiet = value; }
        public string LoaiMon { get => _loaiMon; set => _loaiMon = value; }
        #endregion

        //method Môn Học
        #region Method môn học
        //lấy ra chuỗi rõ ràng loại môn từ chữ viết tắt TH - LT
        public virtual string PhanLoaiMon(string loaiMon)
        {
            switch (loaiMon)
            {
                case "TH":
                    return "Thực Hành";
                default:
                    return "Lý Thuyết";
            }
        }
        //xuất ra màn hình thông tin môn học sơ bộ (không bao gồm điểm)
        public virtual void XuatThongTinMonHoc()
        {
            string output = string.Format("{0,-8} {1,-25} {2,-10} {3,-10}", _maMonHoc, _tenMonHoc, _soTiet.ToString(), PhanLoaiMon(_loaiMon));
            Console.WriteLine(output);
        }
        //xuất ra màn hình thông tin môn học sơ bộ có bao gồm điểm
        public virtual void XuatThongTinMonHocDiemSo(double diemQT, double diemTP, double diemTB)
        {
            Console.WriteLine(string.Format("{0,-8} {1,-25} {2,-8} {3,-12} {4,-8:0.0} {5,-8:0.0} {6,-8:0.0}", _maMonHoc, _tenMonHoc, _soTiet.ToString(), PhanLoaiMon(_loaiMon), diemQT, diemTP, diemTB));
        }
        #endregion
    }
}
