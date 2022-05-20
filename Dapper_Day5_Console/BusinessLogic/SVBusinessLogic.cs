using Dapper_Day5_Console.Data.InterFace;
using Dapper_Day5_Console.Models;
using System;
using System.Collections.Generic;
using Dapper_Day5_Console.Utilities;
using Newtonsoft.Json;
using System.IO;


namespace Dapper_Day5_Console.BusinessLogic
{
    public class SVBusinessLogic
    {
        //attribute
        #region attribute
        public ISinhVienDAL _svDAL;
        private List<SinhVien> lsv;
        private List<BangDiem> lbd;
        private List<MonHoc> lmh;
        #endregion

        //constructor injection svDAL from SinhVienDataAccess
        public SVBusinessLogic(ISinhVienDAL svDAL)
        {
            _svDAL = svDAL;
        }

        //method
        #region MethodSinhVienServices
        //method services
        //nhập mã sinh viên để thực hiện một công việc cần dùng thông qua mã sinh viên
        public string setMaSVDoSomeThing()
        {
            Console.Write("Nhập vào mã Sinh viên cần thực hiện: ");
            return Console.ReadLine();
        }
        //Xuất danh sách Thông Tin Sinh Vien
        public void getAllInfoSinhVien()
        {
            int count = 0;
            _svDAL.GetAllSinhVien().ForEach(sv => { Console.Write(String.Format("{0,-6:00}", count++)); sv.XuatThongTinSinhVien(); });
        }
        //xuất thông tin chi tiết của một sinh viên
        public void getDetailOfSinhVienBy(string maSinhVien)
        {
            int count = 0, k = 0;//đếm số môn
            _svDAL.GetAllInOne(ref lsv, ref lmh, ref lbd);
            //tìm thông tin môn học thông qua mã số sinh viên tương ứng 
            for (; k < lsv.Count; k++)
            {
                if (lsv[k].MaSinhVien == maSinhVien)//tìm ra sinh viên có mã sinh viên trùng khớp
                {
                    //tên sinh viên tra cứu
                    Console.Write("\n\tThông tin chi tiết của Sinh Viên: "); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"{lsv[k].TenSinhVien}\n"); Console.ResetColor();
                    //titile
                    Title.TitleThongTinMonHocDangKi();
                    //tìm và so sánh list bảng điểm ứng với mã sinh viên
                    foreach (BangDiem bd in lbd)
                    {
                        if (bd.MaSinhVien == lsv[k].MaSinhVien)
                        {
                            //duyệt list môn học
                            foreach (MonHoc mh in lmh)
                            {
                                if (mh.MaMonHoc == bd.MaMonHoc)
                                {
                                    mh.XuatThongTinMonHocDiemSo(bd.DiemQuaTrinh, bd.DiemThanhPhan, bd.DiemTongKetMon());
                                    count++;
                                }
                            }
                        }
                    }
                    if (count == 0)
                    {
                        ExceptionNotice.ColorError();
                        Console.WriteLine("\nSinh viên không đăng kí môn học nào !");
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++) Console.Write("_");
                        Console.Write("\nTổng số môn đã đăng kí là: ");
                        Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("{0:00}", count); Console.ResetColor();
                    }
                    break;//ngắt khi đã duyệt và xuất xong thông tin sinh viên
                }
            }
            if(k >= lsv.Count)
                ExceptionNotice.InfoNotAvailableSV();
            

        }
        //lấy thông tin môn học sinh viên đã đăng kí
        public void getDetailTotalMonhoc(string maSinhVien)
        {
            int count = 0, i = 0;
            //lấy dữ liệu 
            _svDAL.GetAllInOne(ref lsv, ref lmh, ref lbd);
            //tim kiem ma sinh vien can xem so luong mon hoc dang ki
            for (;i < lsv.Count; i++)
            {
                if(lsv[i].MaSinhVien == maSinhVien)
                {
                    Console.Write("\nThông tin môn học sinh viên ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("{0}", lsv[i].TenSinhVien); Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" đã đăng kí !\n", lsv[i].TenSinhVien);
                    Title.TitleThongTinMonHoc();
                    foreach(BangDiem bd in lbd)
                    {
                        if(bd.MaSinhVien == lsv[i].MaSinhVien)
                        {
                            foreach(MonHoc mh in lmh)
                            {
                                if (mh.MaMonHoc == bd.MaMonHoc)
                                {
                                    Console.Write(String.Format("{0,-6:00}", ++count));
                                    mh.XuatThongTinMonHoc();
                                }
                            }
                        }
                    }
                    if (count > 0)
                    {
                        for (int k = 0; k < 30; k++) Console.Write("_");
                        Console.Write("\nTổng số môn đã đăng kí là: ");
                        Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(string.Format("{0:00}",
                        count)); Console.ResetColor();
                        return;
                    }
                    else
                    {
                        ExceptionNotice.InfoNotRegisterMonHoc();
                        return;
                    }
                }
            }
            if (i >= lsv.Count)
                ExceptionNotice.WarningNotAvailable();
                
        }
        //xem điểm môn học của từng sinh viên
        public void getScoreAllSinhVien()
        {
            double tong = 0;
            int count = 0;
            //get all data
            _svDAL.GetAllInOne(ref lsv, ref lmh, ref lbd);
            //duyệt list SV và xử lý so sánh lấy ra điểm dựa trên các trường chung
            foreach(SinhVien sv in lsv)
            {
                count = 0;//reset số lượng môn => tính tổng điểm
                tong = 0;//reset biến tạm tổng chứa tổng điểm tổng kết từng môn
                Console.Write("\n\tThông tin điểm số của sinh viên ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sv.TenSinhVien+"\n");
                Console.ResetColor();
                Title.TitleThongTinMonHocDangKi();
                foreach (BangDiem bd in lbd)
                {
                    if(bd.MaSinhVien == sv.MaSinhVien)
                    {
                        foreach(MonHoc mh in lmh)
                        {
                            if(mh.MaMonHoc == bd.MaMonHoc)
                            {
                                Console.Write(String.Format("{0,-7:00}", ++count));//đếm số lượng môn đã đăng kí
                                mh.XuatThongTinMonHocDiemSo(bd.DiemQuaTrinh, bd.DiemThanhPhan, bd.DiemTongKetMon());
                                tong += bd.DiemTongKetMon(); 
                            }
                        }
                    }
                }
                if(count <= 0)
                {
                    ExceptionNotice.InfoNotRegisterMonHoc();
                }
                for (int k = 0; k < 30; k++) Console.Write("_");
                Console.Write("\nTổng điểm học lực là: ");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("{0:0.0}\n", tong / count); Console.ResetColor();
            }

        }
        //nhập điểm sinh viên
        public void setScoreSinhVien(string maSinhVien)
        {
            //get data
            _svDAL.GetAllInOne(ref lsv, ref lmh, ref lbd);
            //variale local
            int pick = 0, count = 0, k=0;
            bool check = false;
            string tempMaMH = string.Empty;
            //list vị trí của các môn học của sinh viên
            List<int> lIndex = new List<int>();
            //xuất ra danh sách môn học ứng với sinh viên đang cần sửa điểm + lấy các chỉ số môn trong bảng điểm để edit
            for(; k < lsv.Count; k++)
            {
                if(lsv[k].MaSinhVien == maSinhVien)
                {
                    check = true;
                    Title.TitleThongTinMonHoc();
                    for (int i = 0; i < lbd.Count; i++) 
                    {
                        if(lbd[i].MaSinhVien == lsv[k].MaSinhVien)
                        {
                            foreach(MonHoc mh in lmh)
                            {
                                if(mh.MaMonHoc == lbd[i].MaMonHoc)
                                {
                                    lIndex.Add(i);
                                    Console.Write(String.Format("{0,-6:00}", ++count)); mh.XuatThongTinMonHoc();
                                }
                            }
                        }
                    }
                    break;
                }
            }
            //chỉnh sửa điểm
            if (check == true && count != 0)
            {
                do
                {   //input số thứ tự môn
                    do
                    {
                        Console.Write("\nNhập số thứ tự môn cần nhập/sửa điểm: ");
                        check = int.TryParse(Console.ReadLine(), out pick);
                        if (pick < 0 || pick > count)
                            check = false;
                    } while (!check);
                    //kiểm tra và xử lý cho phép nhập điểm
                    if (pick - 1 > lIndex.Count || pick - 1 < 0)//trường hợp ngoai lệ
                    {
                        ExceptionNotice.WarningNotAvailable();
                        return;
                    }
                    else //nhập vào điểm cho môn học + update điểm vào database
                    {
                        lbd[lIndex[pick - 1]].setScore();
                        _svDAL.updateScoreLive(maSinhVien, lbd[lIndex[pick - 1]].MaMonHoc, lbd[lIndex[pick - 1]].DiemQuaTrinh, lbd[lIndex[pick - 1]].DiemThanhPhan);
                        
                        ExceptionNotice.SuccessUpdateScore();
                    }
                    do
                    {
                        Console.Write("\n[>] Tiếp tục (1) | Thoát (0): ");
                        check = int.TryParse(Console.ReadLine(), out pick);
                        if (pick < 0)
                            check = false;
                    } while (!check);
                } while (pick != 0);
            }
            else if(k >= lsv.Count && count == 0)
                ExceptionNotice.InfoNotAvailableSV();
            else if(count == 0)
                ExceptionNotice.InfoNotRegisterMonHoc();
        }
        //xem kết quả trượt đậu của sinh viên
        public void showResultPass()
        {
            int count = 0;
            //get data Sinhvien + BangDiem
            lsv = _svDAL.GetAllSinhVien();
            lbd = _svDAL.GetAllBangDiem();
            //process show resulte pass or fall
            for (int i = 0; i < lsv.Count; i++)
            {
                count = 0;
                string ketQua = string.Empty;
                foreach(BangDiem bd in lbd)
                {
                    //dùng phương thức Kiểm tra đậu hay rớt của sinh viên
                    if(lsv[i].MaSinhVien == bd.MaSinhVien)
                    {
                        ketQua = lsv[i].KiemTraSVTruotHayDau(bd.DiemTongKetMon());
                        count++;
                    }
                }
                if (count == 0)//trường hợp sinh viên không đăng kí môn nào cũng sẽ đáng rớt
                    ketQua = "Trượt";
                //show kết quả kiểm tra đậu/rớt
                if (string.Compare(ketQua, "Trượt") == 0)
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(string.Format("{0,-5:00}", i + 1));
                lsv[i].XemThongTinSinhVienDauRot(ketQua);
            }
        }
        //export JSON FILE
        public void ExportFileJson()
        {
            _svDAL.GetAllInOne(ref lsv, ref lmh, ref lbd);
            try
            {
                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(@"..\..\FileJson\ListSinhVien.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, lsv);
                }
                using (StreamWriter file = File.CreateText(@"..\..\FileJson\ListMonHoc.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, lmh);
                }
                using (StreamWriter file = File.CreateText(@"..\..\FileJson\ListBangDiem.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, lbd);
                }
                ExceptionNotice.SuccessExportFileJson();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

    }
}
