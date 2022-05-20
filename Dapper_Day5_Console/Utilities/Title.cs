using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Day5_Console.Utilities
{
    public class Title
    {
        //xuất title cho thông tin Sinh Viên
        public static void TitleSinhVienSTT()
        {
            string output = string.Format("{0,-5} {1,-12} {2,-23} {3,-10} {4,-12} {5,-14} {6,-20}", "STT", "Mã SV", "Tên SV", "Giới Tính", "Ngày Sinh", "Lớp", "Khoá Học");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }
        //xuất tiêu đề sinh viên không có đánh số thứ tự
        public static void TitleSinhVien()
        {
            string output = string.Format("{0,-12} {1,-22} {2,-12} {3,-12} {4,-14} {5,-20}", "Mã SV", "Tên SV", "Giới Tính", "Ngày Sinh", "Lớp", "Khoá Học");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        //xuất title cho thông tin Sinh Viên - kết quả đậu rớt
        public static void TitleSinhVienDauRot()
        {
            string output = string.Format("{0,-5} {1,-12} {2,-20} {3,-13} {4,-12} {5,-14} {6,-10} {7}", "STT", "Mã SV", "Tên SV", "Giới Tính", "Ngày Sinh", "Lớp", "Khoá Học", "Kết Quả");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }
        //thông tin tiêu đề môn học sơ bộ của môn (bao gồm điểm)
        public static void TitleThongTinMonHocDangKi()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Format("{0,-6} {1,-11} {2,-20} {3,-10} {4,-10} {5,-8} {6,-8} {7,-8}","STT", "Mã Môn", "Tên Môn", "Số tiết", "Loại môn", "Điểm QT", "Điểm TP", "Tổng Điểm"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }

        //thông tin tiêu đề môn học chi tiết (không bao gồm điểm)
        public static void TitleThongTinMonHoc()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Format("{0,-5} {1,-8} {2,-24} {3,-11} {4,-10}", "STT", "Mã Môn", "Tên Môn Học", "Số Tiết", "Loại Môn"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------");
        }

    }
}
