using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

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
            OnProgram.BentukKotak(0, 11, 119, 30);

            String judul = " Wearnes Education Center ";
            OnProgram.RataTengah((120 - judul.Length) / 2, 2, judul);
            string subjudul = " IK 1 - 2018 ";
            OnProgram.RataTengah((120 - subjudul.Length) / 2, 3, subjudul);

            
            string[] menu = new string[3];
            menu[0] = " SISWA ";
            menu[1] = " DOSEN ";
            menu[2] = " MATA KULIAH ";

            for (int i = 0; i < 3; i++)
            {
                OnProgram.RataTengah(18 + (i * 38), 8, menu[i]);
            }

            int pilihan = 0;
            OnProgram.WarnaTampilan(18, 8, menu [pilihan], ConsoleColor.Black, ConsoleColor.Blue);

            ConsoleKeyInfo tombol;
            Console.CursorVisible = false;
            do
           {
             tombol = Console.ReadKey (true);

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    OnProgram.WarnaTampilan(18 + (pilihan * 38), 8, menu[pilihan], ConsoleColor.White, ConsoleColor.Black);
                    if (menu[pilihan] == menu[2])
                    {
                        pilihan = 0;
                    }
                    else { pilihan++; };
                    OnProgram.WarnaTampilan(18 + (pilihan * 38), 8, menu[pilihan], ConsoleColor.Black, ConsoleColor.Blue);
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                     OnProgram.WarnaTampilan(18 + (pilihan * 38), 8, menu[pilihan], ConsoleColor.White, ConsoleColor.Black);
                    if (menu[pilihan] == menu[0])
                    {
                        pilihan = 2;
                    }
                    else { pilihan--; };
                    OnProgram.WarnaTampilan(18 + (pilihan * 38), 8, menu[pilihan], ConsoleColor.Black, ConsoleColor.Blue);
                }

           }while(tombol.Key != ConsoleKey.Enter);

            int pilihanSiswa;
            if (pilihan == 0)
            {
                 do
                 {
                    Console.SetCursorPosition ( 1, 12 );
                    
                 Console.WriteLine (" 1. Tambah Data Siswa");
                 Console.SetCursorPosition(1, 13);
                 Console.WriteLine (" 2. Tampil Data Siswa");
                 Console.SetCursorPosition(1, 14);
                 Console.WriteLine (" 3. Edit data siswa");
                 Console.SetCursorPosition(1, 15);
                 Console.WriteLine (" 4. Hapus Data Siswa");
                 Console.WriteLine("");
                 Console.SetCursorPosition(1, 16);
                 Console.Write (" Masukkan Pilihan Anda [1 - 4] :"); 
                 pilihanSiswa = int.Parse (Console.ReadLine());

                 if (pilihanSiswa == 1)
                 {
                     for(int i = 12;i <=17;i++)
                     {
                         OnProgram.RataTengah(1, i, "                                        ");
                     }


                     Console.SetCursorPosition(1, 12);
                     Console.WriteLine("Input Data Siswa");
                     OnProgram.RataTengah(2,13,"NIM    : ");
                     String NIM = Console.ReadLine();
                     OnProgram.RataTengah(2,14,"NAMA   : ");
                     string NAMA = Console.ReadLine();
                     OnProgram.RataTengah(2,15,"KELAS  : ");
                     string KELAS = Console.ReadLine();
                     Console.WriteLine ("");
                     OnProgram.RataTengah(2,16,"Simpan Data ? [Y/N] :");
                     string jawab = Console.ReadLine();

                     if (jawab.ToUpper() == "Y")
                     {
                         string query = " INSERT INTO Siswa (NIM,NAMA,KELAS) VALUES (@NIM, @NAMA, @KELAS)";
                         string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source=Siswa.accdb;";
                         OleDbConnection koneksi = new OleDbConnection (koneksiString);
                         koneksi.Open();
                         OleDbCommand cmd = new OleDbCommand(query, koneksi);
                         cmd.Parameters.AddWithValue("@NIM", NIM);
                         cmd.Parameters.AddWithValue("@NAMA", NAMA);
                         cmd.Parameters.AddWithValue("@KELAS", KELAS);
                         cmd.ExecuteNonQuery();
                         
                     }


                 }
                 else if (pilihanSiswa == 2)
                 {
                     for (int i = 12; i <= 17; i++)
                     {
                         OnProgram.RataTengah(1, i, "                                        ");
                     }

                     OnProgram.RataTengah(1,12," Tampil Data Siswa : ");
                     Console.WriteLine();
                     OnProgram.RataTengah(2,13,"Masukkan Nama Siswa atau kosongi untuk menampilkan semua :");
                     string cari = Console.ReadLine();

                     string koneksistring = "Provider=Microsoft.Ace.OleDB.12.0;Data Source = Siswa.accdb";
                     OleDbConnection koneksi = new OleDbConnection(koneksistring);
                     koneksi.Open();

                     string query;
                     if (cari == " ")
                     {
                         query = "SELECT NIM,NAMA,KELAS, FROM Siswa ";

                     }
                     else
                     {
                         query = "SELECT NIM,NAMA,KELAS FROM Siswa WHERE NAMA LIKE '%" + cari + "%' ";
                     }


                     OleDbCommand cmd = new OleDbCommand(query, koneksi);
                     OleDbDataReader reader = cmd.ExecuteReader();

                     DataTable Dtsiswa = new DataTable();
                     Dtsiswa.Load(reader);

                     Console.WriteLine();

                     if (Dtsiswa.Rows.Count > 0)
                     {

                         OnProgram.RataTengah (2,15, " +-----+----------------------+---------+");
                         OnProgram.RataTengah (2,16, " | NIM |          NAMA        | KELAS   |");
                         OnProgram.RataTengah (2,17, " +-----+----------------------+---------+");
                         foreach (DataRow row in Dtsiswa.Rows)
                         {
                             Console.SetCursorPosition(2, 18);
                             Console.WriteLine(" | {0} |  {1,-18}  |  {2,-5}  |",
                                 row["NIM"], row["NAMA"], row["KELAS"]);

                         }
                         Console.WriteLine("   +-----+----------------------+---------+");
                     }
                     else
                     {
                         OnProgram.RataTengah(2, 16, "Data Tidak Ditemukan ");
                     }

                     Console.ReadKey();
                 

                    }
                 else if (pilihanSiswa == 3)
                 {
                     for (int i = 12; i <= 17; i++)
                     {
                         OnProgram.RataTengah(1, i, "                                        ");
                     }

                     OnProgram.RataTengah(1, 12, "Edit Data Siswa ");
                     Console.WriteLine ();
                     OnProgram.RataTengah(1, 13, "Masukkan NIM yang ingin di Edit  : ");
                     string NIMLama = Console.ReadLine();

                     string query = " SELECT * FROM SISWA WHERE  NIM=@NIM";
                     string koneksistring = "Provider=Microsoft.Ace.OleDB.12.0;Data Source = Siswa.accdb";
                     OleDbConnection koneksi = new OleDbConnection(koneksistring);
                     koneksi.Open();

                     OleDbCommand cmd = new OleDbCommand(query, koneksi);
                     cmd.Parameters.AddWithValue ("@NIM",NIMLama);
                     OleDbDataReader reader = cmd.ExecuteReader();

                     DataTable dtSiswa = new DataTable();
                     dtSiswa.Load(reader);

                     if (dtSiswa.Rows.Count == 1)
                     {
                         //Tampilan Data Lama
                         DataRow Row = dtSiswa.Rows[0];
                         Console.WriteLine("NIM      :  " + Row["NIM"]);
                         Console.WriteLine("NAMA     :  " + Row["NAMA"]);
                         Console.WriteLine("KELAS    :  " + Row["KELAS"]);

                         //input Data Baru
                         Console.WriteLine();
                         Console.Write(" NIM BARU     :");
                         string NIMBaru = Console.ReadLine();
                         Console.Write(" NAMA BARU    :");
                         string NAMABaru = Console.ReadLine();
                         Console.Write(" KELAS BARU   :");
                         string KELAS = Console.ReadLine();

                         Console.Write("Update Data Siswa  [Y/N]  : ");
                         string jawab = Console.ReadLine();
                         if (jawab.ToUpper() == "Y")
                         {
                             query = "UPDATE SISWA SET NIM = @NIMBARU, NAMA=@NAMA,KELAS=@KELAS WHERE NIM = @NIM";
                             cmd = new OleDbCommand(query, koneksi);

                             cmd.Parameters.AddWithValue("@NIMBARU", NIMBaru);
                             cmd.Parameters.AddWithValue("@NAMA", NAMABaru);
                             cmd.Parameters.AddWithValue("@KELAS", KELAS);
                             cmd.Parameters.AddWithValue("@NIM", NIMLama);

                             cmd.ExecuteNonQuery();

                         }

                       }
                       else
                       {
                         //Data Tidak Diketahui
                         Console.WriteLine (" NIM yang anda masukkan salah ");
                         Console.ReadKey();
                       }
                 
                 
                 } 
                     else if (pilihanSiswa == 4)
                     {
                             for (int i = 12; i <= 17; i++)
                        {
                            OnProgram.RataTengah(1, i, "                                        ");
                        }
                         Console.WriteLine (" Hapus Data Siswa ");
                         Console.WriteLine();
                         Console.Write ("Masukkan NIM yang ingin di Hapus  :");
                         string NIM = Console.ReadLine();

                         Console.Write (" Yakin Mau Di Hapus ? [Y/N]  ");
                         string jawab = Console.ReadLine ();
                         if (jawab.ToUpper () == "Y")
                         {
                             string koneksiString = "Provider=Microsoft.Ace.OleDB.12.0;Data Source = Siswa.accdb";
                             OleDbConnection koneksi = new OleDbConnection(koneksiString);
                             koneksi.Open();

                             string query = "DELETE FROM SISWA WHERE NIM = @NIM";
                             OleDbCommand cmd = new OleDbCommand (query, koneksi);
                             cmd.Parameters.AddWithValue ("@NIM", NIM);
                             cmd.ExecuteNonQuery();
                         }



                     }



                 

                 }while (pilihanSiswa != 5);

                 Console.ReadKey();
            }
        }
    }
}

