using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoffeeConsole
{
    class HangHoaController
    {
        private StreamReader sr;
        private StreamWriter sw;
        private string fileName = "hanghoa.txt";
        private DanhMucController danhMucController;

        public HangHoaController()
        {
            danhMucController = new DanhMucController();    
        }

        public void HienDanhSach() {
            //Hiện danh sách các danh mục
            sr = new StreamReader(fileName);
            
            string s;
            while ((s = sr.ReadLine()) != null) {
                String[] tmp = s.Split('|');
                Console.WriteLine(tmp[0] + "\t" + tmp[1] + "\t" + tmp[2] + "\t" + danhMucController.LayTenDanhMuc(tmp[3]));
            }

            sr.Close();
            
        }

        public void Them() {
            sw = new StreamWriter(fileName, true);
            Console.Write("Nhap ma hang hoa: ");
            string maHH = Console.ReadLine();
            Console.Write("Nhap ten hang hoa: ");
            string tenHH = Console.ReadLine();
            Console.Write("Nhap gia ban: ");
            string giaBan = Console.ReadLine();
            danhMucController.HienDanhSach();
            Console.Write("Nhap ma danh muc: ");
            string danhMuc = Console.ReadLine();

            sw.WriteLine(maHH + "|" + tenHH + "|" + giaBan + "|" + danhMuc);
            sw.Close();
        }

        public void Sua() {
            Console.Write("Nhap ma hang hoa can sua: ");
            string maHH = Console.ReadLine();
            Console.Write("Nhap ten hang hoa: ");
            string tenHH = Console.ReadLine();
            Console.Write("Nhap gia ban: ");
            string giaBan = Console.ReadLine();
            danhMucController.HienDanhSach();
            Console.Write("Nhap ma danh muc: ");
            string danhMuc = Console.ReadLine();

            String data = "";

            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHH)
                    data += maHH + "|" + tenHH + "|" + giaBan + "|" + danhMuc + "\n";
                else
                    data += tmp[0] + "|" + tmp[1] + "|" + tmp[2] + "|" + tmp[3] + "\n";
            }

            sr.Close();

            sw = new StreamWriter(fileName);
            sw.Write(data);
            sw.Close();
        }

        public void Xoa() {
            Console.Write("Nhap ma hang hoa can xoa: ");
            string maHH = Console.ReadLine();

            String data = "";

            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHH)
                    continue;
                else
                    data += tmp[0] + "|" + tmp[1] + "|" + tmp[2] + "|" + tmp[3] + "\n";
            }

            sr.Close();

            sw = new StreamWriter(fileName);
            sw.Write(data);
            sw.Close();
        }

        public void Menu() {
            Console.WriteLine("Quan ly hang hoa");
            Console.WriteLine("1. Hien danh sach cac hang hoa");
            Console.WriteLine("2. Them hang hoa");
            Console.WriteLine("3. Sua hang hoa");
            Console.WriteLine("4. Xoa hang hoa");
            Console.WriteLine("5. Quay lai");
            Console.Write("Chon: ");
            string s = Console.ReadLine();

            if (s == "1")
                HienDanhSach();
            else if (s == "2")
                Them();
            else if (s == "3")
                Sua();
            else if (s == "4")
                Xoa();
            else if (s == "5")
                return;

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public string LayTenHang(string maHH) {
            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHH)
                    return tmp[1];
            }

            sr.Close();
            return "";
        }

        public string LayGia(string maHH) {
            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maHH)
                    return tmp[2];
            }

            sr.Close();
            return "";
        }
    }
}
