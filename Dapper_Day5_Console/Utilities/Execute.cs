using System;
using Castle.Windsor;
using Dapper_Day5_Console.BusinessLogic;

namespace Dapper_Day5_Console.Utilities
{
    public class Execute
    {
        #region menu
        //menu chương trình chính
        private static void menuMain()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tChương trình quản lý sinh viên");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 0. Thoát chương trình");
            Console.WriteLine(" 1. Xem danh sách sinh viên");
            Console.WriteLine(" 2. Xem chi tiết thông tin sinh viên");
            Console.WriteLine(" 3. Xem số môn sinh viên đăng ký");
            Console.WriteLine(" 4. Xem điểm môn học của từng sinh viên");
            Console.WriteLine(" 5. Nhập điểm sinh viên");
            Console.WriteLine(" 6. Xem kết quả trượt đổ của Sinh Viên");
            Console.WriteLine(" 7. Xuất các dữ liệu ra file Json tương ứng");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region runProgram
        public static void RunMain(WindsorContainer container)
        {
            var activeSV = container.Resolve<SVBusinessLogic>();
            int pick = 0;
            bool check;
            do
            {
                //hiện menu
                menuMain();
                //thực thi chương trình
                do
                {
                    Console.Write("Nhập vào lựa chọn: ");
                    check = int.TryParse(Console.ReadLine(), out pick); 
                }while (!check);
                switch (pick)
                {
                    case 0:
                        ExceptionNotice.InfoExit();
                        Environment.Exit(0);
                        break;
                    case 1:
                        Title.TitleSinhVienSTT();
                        activeSV.getAllInfoSinhVien();
                        break;
                    case 2:
                        activeSV.getDetailOfSinhVienBy(activeSV.setMaSVDoSomeThing());
                        break;
                    case 3:
                        activeSV.getDetailTotalMonhoc(activeSV.setMaSVDoSomeThing());
                        break;
                    case 4:
                        activeSV.getScoreAllSinhVien();
                        break;
                    case 5:
                        activeSV.setScoreSinhVien(activeSV.setMaSVDoSomeThing());
                        break;
                    case 6:
                        Title.TitleSinhVienDauRot();
                        activeSV.showResultPass();
                        break;
                    case 7:
                        activeSV.ExportFileJson();
                        break;
                    default:
                        ExceptionNotice.ColorWarning();
                        Console.WriteLine($"Lựa chọn {pick} không tồn tại. Vui lòng kiểm tra lại !");
                        break;
                }
                //pause
                ExceptionNotice.InfoPressToContinue();
                Console.ReadKey();
                Console.Clear();
            } while (pick != 0);
        }
        #endregion
    }
}
