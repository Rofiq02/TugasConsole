using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class OnProgram
    {
        static public void BentukKotak (int kiri, int atas, int kanan, int bawah)
        {
            Console.SetCursorPosition (kiri,atas);
            Console.Write ("┌");

            for (int i = kiri + 1; i <= kanan - 1; i++)
            {
                Console.SetCursorPosition (i, atas);
                Console.Write("─");
            }

            Console.SetCursorPosition (kanan, atas);
            Console.Write("┐");

            for (int i = atas + 1; i <= bawah - 1; i++)
            {
                Console.SetCursorPosition(kanan, i);
                Console.Write("│");
            }

            Console.SetCursorPosition (kanan, bawah);
            Console.Write("┘");

            for (int i = kanan - 1; i >= kiri + 1; i--)
            {
                Console.SetCursorPosition(i, bawah);
                Console.Write("─");
            }

            Console.SetCursorPosition(kiri, bawah);
            Console.Write("└");

            for (int i = bawah - 1; i >= atas + 1; i--)
            {
                Console.SetCursorPosition(kiri, i);
                Console.Write("│");
            }

        }//Tutup


        static public void WarnaTampilan(int kiri, int atas, string teks, ConsoleColor WarnaTeks,
            ConsoleColor WarnaBackground)
        {
            Console.SetCursorPosition(kiri, atas);
            Console.ForegroundColor = WarnaTeks;
            Console.BackgroundColor = WarnaBackground;
            Console.Write(teks);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }



       static public void RataTengah(int kiri, int atas, string teks)
        {
  
            Console.SetCursorPosition(kiri, atas);
            Console.Write(teks);
        }
    }
}