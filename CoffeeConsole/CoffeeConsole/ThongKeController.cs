using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoffeeConsole
{
    class ThongKeController
    {
        private StreamReader sr;
        private string fileName = "banhang.txt";
        private string fileNameDetail = "chitietbanhang.txt";
        private HangHoaController hhController;

        public ThongKeController()
        {
            hhController = new HangHoaController();    
        }

        public void ThongKeTheoNgay() {
            Console.Write("Nhap ngay muon thong ke (dd/MM/yyyy): ");

            string ngay = Console.ReadLine();
            
            sr = new StreamReader(fileName);

            string s;
            int doanhThu = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[2] == ngay)
                {
                    StreamReader sr1 = new StreamReader(fileNameDetail);
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null) {
                        string[] tmp1 = s1.Split('|');
                        if (tmp1[0] == tmp[0])
                        {
                            int gia = int.Parse(hhController.LayGia(tmp1[1]));
                            int soLuong = int.Parse(tmp1[2]);
                            doanhThu += gia * soLuong;
                        }
                    }
                    sr1.Close();
                }
            }
            Console.WriteLine("Doanh thu ban hang: " + doanhThu);
            sr.Close();   
        }

        public void ThongKeTheoThang() {
            Console.Write("Nhap thang thong ke (MM/yyyy): ");

            string thang = Console.ReadLine();

            sr = new StreamReader(fileName);

            string s;
            int doanhThu = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                String[] d = tmp[2].Split('/');

                if ( (d[1] + "/" + d[2]) == thang)
                {
                    StreamReader sr1 = new StreamReader(fileNameDetail);
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('|');
                        if (tmp1[0] == tmp[0])
                        {
                            int gia = int.Parse(hhController.LayGia(tmp1[1]));
                            int soLuong = int.Parse(tmp1[2]);
                            doanhThu += gia * soLuong;
                        }
                    }
                    sr1.Close();
                }
            }
            Console.WriteLine("Doanh thu ban hang: " + doanhThu);
            sr.Close();   
        }

        public void ThongKeTheoNam() {

            Console.Write("Nhap nam can thong ke (yyyy): ");

            string nam = Console.ReadLine();

            sr = new StreamReader(fileName);

            string s;
            int doanhThu = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                String[] d = tmp[2].Split('/');

                if (d[2] == nam)
                {
                    StreamReader sr1 = new StreamReader(fileNameDetail);
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('|');
                        if (tmp1[0] == tmp[0])
                        {
                            int gia = int.Parse(hhController.LayGia(tmp1[1]));
                            int soLuong = int.Parse(tmp1[2]);
                            doanhThu += gia * soLuong;
                        }
                    }
                    sr1.Close();
                }
            }
            Console.WriteLine("Doanh thu ban hang: " + doanhThu);
            sr.Close();   
        }

        public void Menu() {
            Console.WriteLine("Thong ke ban hang");
            Console.WriteLine("1. Thong ke theo ngay");
            Console.WriteLine("2. Thong ke theo thang");
            Console.WriteLine("3. Thong ke theo nam");
            Console.WriteLine("4. Quay lai");
            Console.Write("Chon: ");
            string s = Console.ReadLine();

            if (s == "1")
                ThongKeTheoNgay();
            else if (s == "2")
                ThongKeTheoThang();
            else if (s == "3")
                ThongKeTheoNam();
            else if (s == "4")
                return;

            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
