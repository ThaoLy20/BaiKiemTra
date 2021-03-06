using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoffeeConsole
{
    class NhapHangController
    {
        private StreamReader sr;
        private StreamWriter sw;
        private string fileName = "nhaphang.txt";
        private string fileNameDetail = "chitietnhaphang.txt";
        private HangHoaController hhController;

        public NhapHangController()
        {
            hhController = new HangHoaController();    
        }

        public void HienDanhSach() {
            //Hiện danh sách các hóa đơn
            sr = new StreamReader(fileName);
            
            string s;
            while ((s = sr.ReadLine()) != null) {
                String[] tmp = s.Split('|');
                Console.WriteLine(tmp[0] + "\t" + tmp[1]);
            }

            sr.Close();   
        }

        public void HienChiTiet() {
            Console.Write("Nhap ma hoa don can xem chi tiet: ");
            string maHD = Console.ReadLine();

            sr = new StreamReader(fileNameDetail);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHD) 
                    Console.WriteLine(tmp[0] + "\t" + hhController.LayTenHang(tmp[1]) + "\t" + tmp[2]);
            }

            sr.Close();   
        }

        public void Them() {
            sw = new StreamWriter(fileName, true);
            Console.Write("Nhap ma hoa don: ");
            string maHD = Console.ReadLine();
            Console.Write("Nhap ten nguoi nhap: ");
            string tenNguoiNhap = Console.ReadLine();

            sw.WriteLine(maHD + "|" + tenNguoiNhap);
            sw.Close();

            Console.WriteLine("Nhap cac hang hoa trong chi tiet hoa don nhap: ");
            sw = new StreamWriter(fileNameDetail, true);
            while (true) {
                Console.Write("Nhap ma hang hoa: ");
                string maHH = Console.ReadLine();
                Console.Write("Nhap so luong: ");
                string soLuong = Console.ReadLine();

                sw.WriteLine(maHD + "|" + maHH + "|" + soLuong);

                Console.Write("Ban co muon nhap tiep khong (c/k): ");
                string s = Console.ReadLine();
                if (s.ToUpper() != "C")
                    break;
            }
            sw.Close();
        }

        public void Xoa() {
            Console.Write("Nhap ma hoa don can xoa: ");
            string maHD = Console.ReadLine();

            String data = "";

            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHD)
                    continue;
                else
                    data += tmp[0] + "|" + tmp[1] + "\n";
            }

            sr.Close();

            sw = new StreamWriter(fileName);
            sw.Write(data);
            sw.Close();

            data = "";

            sr = new StreamReader(fileNameDetail);

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHD)
                    continue;
                else
                    data += tmp[0] + "|" + tmp[1] + "|" + tmp[2] + "\n";
            }

            sr.Close();

            sw = new StreamWriter(fileNameDetail);
            sw.Write(data);
            sw.Close();
        }

        public void Menu() {
            Console.WriteLine("Quan ly hoa don nhap");
            Console.WriteLine("1. Hien danh sach cac hoa don nhap");
            Console.WriteLine("2. Xem chi tiet hoa don nhap");
            Console.WriteLine("3. Them hoa don nhap");
            Console.WriteLine("4. Xoa hoa don nhap");
            Console.WriteLine("5. Quay lai");
            Console.Write("Chon: ");
            string s = Console.ReadLine();

            if (s == "1")
                HienDanhSach();
            else if (s == "2")
                HienChiTiet();
            else if (s == "3")
                Them();
            else if (s == "4")
                Xoa();
            else if (s == "5")
                return;

            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
