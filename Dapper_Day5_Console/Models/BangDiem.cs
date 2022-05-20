using System;
using Dapper_Day5_Console.Utilities;
namespace Dapper_Day5_Console.Models
{
    public class BangDiem
    {
        //thuộc tính môn học
        #region thuộc tính
        private string _maMonHoc;
        private string _maSinhVien;
        private string _loaiMon;
        private double _diemQuaTrinh;
        private double _diemThanhPhan;
        private double _diemTong;
        private int stt;
        #endregion

        //property
        #region Property
        public double DiemQuaTrinh { get { return _diemQuaTrinh; } set { if (value > 0) _diemQuaTrinh = value; else _diemQuaTrinh = 0; } }
        public double DiemThanhPhan { get { return _diemThanhPhan; } set { if (value > 0) _diemThanhPhan = value; else _diemThanhPhan = 0; } }
        public int Stt { get => stt; set => stt = value; }
        public string MaMonHoc { get => _maMonHoc; set => _maMonHoc = value; }
        public string MaSinhVien { get => _maSinhVien; set => _maSinhVien = value; }
        #endregion

        //constructor Mon Hoc khởi tạo dữ liệu cho các thuộc tính MonHoc
        #region Constructor
        //mặc định
        public BangDiem()
        {
        }
        //truyền tham số khởi tạo đối tượng BangDiem
        public BangDiem(string maMonHoc, string maSinhVien, string loaiMon, float diemQuaTrinh, float diemThanhPhan)
        {

            MaMonHoc = maMonHoc;
            MaSinhVien = maSinhVien;
            _loaiMon = loaiMon;
            if (0 <= diemQuaTrinh && diemQuaTrinh <= 10)
                _diemQuaTrinh = diemQuaTrinh;
            else
                ExceptionNotice.ExceptionParameters();
            if (0 <= diemThanhPhan && diemThanhPhan <= 10)
                _diemThanhPhan = diemThanhPhan;
            else
                ExceptionNotice.ExceptionParameters();
        }
        #endregion

        //phương thức môn học
        #region Phương Thức
        //nhập điểm quá trình và thành phần
        public virtual void setScore()
        {
            bool check;
            do
            {
                Console.Write("Nhập vào điểm quá trình: ");
                check = double.TryParse(Console.ReadLine(), out _diemQuaTrinh);
                if (_diemQuaTrinh < 0)
                    check = false;
            } while (!check);
            do
            {
                Console.Write("Nhập vào điểm thành phần: ");
                check = double.TryParse(Console.ReadLine(), out _diemThanhPhan);
                if (_diemThanhPhan < 0)
                    check = false;
            } while (!check);
        }
        // tính theo tỉ lệ - Thực hành 50% : 50% - Lý thuyết (Thành Phần) 70% - (Quá Trình) 30%
        // lấy ra điểm tổng của 1 môn học
        public virtual double DiemTongKetMon()
        {
            if (string.Compare(_loaiMon, "TH") == 0)
                _diemTong = _diemQuaTrinh * 0.5f + _diemThanhPhan * 0.5f;
            else
                _diemTong = _diemQuaTrinh * 0.3f + _diemThanhPhan * 0.7f;
            return _diemTong;
        }
        #endregion
    }
}
