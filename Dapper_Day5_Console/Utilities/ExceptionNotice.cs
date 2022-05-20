using System;

namespace Dapper_Day5_Console.Utilities
{
    public class ExceptionNotice
    {
        //vùng màu quy ước lỗi 
        #region ColorInfo
        public static void ColorError()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
        }
        public static void ColorSecessful()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
        }
        public static void ColorWarning()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
        }

        public static void ColorInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        #endregion

        //vùng lỗi
        #region Error
        //lỗi truyền tham số không hợp lệ
        public static Exception ExceptionParameters()
        {
            Exception err = new Exception("[X] Lỗi truyền tham số không hợp lệ !");
            ColorError();
            return err;   
        }
        //lỗi kết nối database
        public static Exception ExceptionConnectDatabase()
        {
            ColorError();
            Exception err = new Exception("[X] Có lỗi xảy ra khi kết nối Database !");
            return err;
        }
        public static Exception ExceptionErrorUpdate()
        {
            ColorError();
            Exception err = new Exception("[X] Có Lỗi xảy ra update không thành công !");
            return err;
        }
        #endregion

        //vùng cảnh báo
        #region Warning
        public static void WarningInput()
        {
            ColorWarning();
            Console.WriteLine("[!] Vui lòng kiểm tra lại thông tin.");
            Console.ResetColor();
        }
        public static void WarningConnectingDB()
        {
            ColorWarning();
            Console.WriteLine("[!] Đang kết nối đến server !");
            Console.ResetColor();
        }
        public static void WarningNotAvailable()
        {
            ExceptionNotice.ColorWarning();
            Console.WriteLine("Không tồn tại. Vui lòng thử lại !");
            Console.ResetColor();
        }
        public static void WarningNotAvailableMonHoc()
        {
            ExceptionNotice.ColorWarning();
            Console.WriteLine("Sinh Viên Không tồn tại hoặc không đăng kí môn học nào !");
            Console.ResetColor();
        }
        #endregion

        //vùng successful
        #region Successful
        //thông báo thành công
        public static void Successful()
        {
            ColorSecessful();
            Console.WriteLine("[#] Thành Công !");
            Console.ResetColor();
        }
        //thông báo kết nối thành công database
        public static void SuccessConnectDatabase()
        {
            ColorSecessful();
            Console.WriteLine("[#] Đã Kết nối Server thành công !"); 
            Console.ResetColor();
        }
        public static void SuccessUpdateScore()
        {
            ColorSecessful();
            Console.WriteLine("[#] Đã cập nhật điểm thành công !");
            Console.ResetColor();
        }
        public static void SuccessExportFileJson()
        {
            ColorSecessful();
            Console.WriteLine("[#] Export File Json Successful !");
            Console.ResetColor();
        }
        #endregion

        //vùng infomation
        #region info
        public static void InfoExit()
        {
            ColorInfo();
            Console.WriteLine("[$] Enter To Exit...");
            Console.ResetColor();
        }
        public static void InfoNotAvailableSV()
        {
            ColorInfo();
            Console.WriteLine("[$] Sinh viên không tồn tại.");
            Console.ResetColor();
        }
        public static void InfoNotRegisterMonHoc()
        {
            ColorInfo();
            Console.WriteLine("[$] Sinh viên không đăng kí môn nào.");
            Console.ResetColor();
        }
        public static void InfoPressToContinue()
        {
            ColorInfo();
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ResetColor();
        }
        #endregion
    }
}
