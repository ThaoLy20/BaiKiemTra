using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu() {
            Console.WriteLine("Quan ly cua hang coffee");
            Console.WriteLine("Hieu Nguyen Productions");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("1. Quan ly danh muc");
            Console.WriteLine("2. Quan ly hang hoa");
            Console.WriteLine("3. Nhap hang hoa");
            Console.WriteLine("4. Ban hang");
            Console.WriteLine("5. Thong ke");
            Console.WriteLine("6. Thoat");

            Console.Write("Chon: ");
            string s = Console.ReadLine();

            Console.Clear();
            if (s == "1")
            {
                DanhMucController obj = new DanhMucController();
                obj.Menu();
            }
            else if (s == "2")
            {
                HangHoaController obj = new HangHoaController();
                obj.Menu();
            }
            else if (s == "3")
            {
                NhapHangController obj = new NhapHangController();
                obj.Menu();
            }
            else if (s == "4")
            {
                BanHangController obj = new BanHangController();
                obj.Menu();
            }
            else if (s == "5")
            {
                ThongKeController obj = new ThongKeController();
                obj.Menu();
            }
            else if (s == "6")
                return;


            Console.Clear();
            Menu();
        }
    }
}
