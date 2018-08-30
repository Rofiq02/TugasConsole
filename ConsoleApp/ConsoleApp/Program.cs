using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)

        {



            OnProgram.BentukKotak (0, 0, 119, 5);
            OnProgram.BentukKotak (0, 6, 119, 10);
            OnProgram.BentukKotak (1, 7, 118, 9);
            OnProgram.BentukKotak (40, 7, 118, 9);
            OnProgram.BentukKotak(80, 7, 118, 9);
            OnProgram.BentukKotak(0, 11, 119, 43);

            String judul = " Wearnes Education Center ";
            OnProgram.RataTengah((120 - judul.Length) / 2, 2, judul);
            string subjudul = " IK 1 - 2018 ";
            OnProgram.RataTengah((120 - subjudul.Length) / 2, 3, subjudul);

            /*
            string[] menu = new string[3];
            menu[0] = " SISWA ";
            menu[1] = " DOSEN ";
            menu[2] = " MATA KULIAH ";
            

            for (int i = 0; i < 3; i++)
            {
                OnProgram.RataTengah(2, 7 + i, menu[i]);
            }
            */


            Console.ReadKey();
        }
    }
}
