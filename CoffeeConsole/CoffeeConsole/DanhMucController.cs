using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoffeeConsole
{
    class DanhMucController
    {
        private StreamReader sr;
        private StreamWriter sw;
        private string fileName = "danhmuc.txt";

        public DanhMucController() {
            
        }

        public void HienDanhSach() {
            //Hiện danh sách các danh mục
            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null) {
                String[] tmp = s.Split('|');
                Console.WriteLine(tmp[0] + "\t" + tmp[1]);
            }

            sr.Close();
            
        }

        public void Them() {
            sw = new StreamWriter(fileName, true);
            Console.Write("Nhap ma danh muc: ");
            string maDanhMuc = Console.ReadLine();
            Console.Write("Nhap ten danh muc: ");
            string tenDanhMuc = Console.ReadLine();

            sw.WriteLine(maDanhMuc + "|" + tenDanhMuc);
            sw.Close();
        }

        public void Sua() {
            Console.Write("Nhap ma danh muc can sua: ");
            string maDanhMuc = Console.ReadLine();
            Console.Write("Nhap ten danh muc moi: ");
            string tenDanhMuc = Console.ReadLine();

            String data = "";

            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maDanhMuc)
                    data += maDanhMuc + "|" + tenDanhMuc + "\n";
                else
                    data += tmp[0] + "|" + tmp[1] + "\n";
            }

            sr.Close();

            sw = new StreamWriter(fileName);
            sw.Write(data);
            sw.Close();
        }

        public void Xoa() {
            Console.Write("Nhap ma danh muc can xoa: ");
            string maDanhMuc = Console.ReadLine();

            String data = "";

            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maDanhMuc)
                    continue;
                else
                    data += tmp[0] + "|" + tmp[1] + "\n";
            }

            sr.Close();

            sw = new StreamWriter(fileName);
            sw.Write(data);
            sw.Close();
        }

        public void Menu() {
            Console.WriteLine("Quan ly danh muc");
            Console.WriteLine("1. Hien danh sach cac danh muc");
            Console.WriteLine("2. Them danh muc");
            Console.WriteLine("3. Sua danh muc");
            Console.WriteLine("4. Xoa danh muc");
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

        public String LayTenDanhMuc(String maDanhMuc) {
            sr = new StreamReader(fileName);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('|');
                if (tmp[0] == maDanhMuc)
                    return tmp[1];
            }

            sr.Close();

            return "";
        }
    }
}
