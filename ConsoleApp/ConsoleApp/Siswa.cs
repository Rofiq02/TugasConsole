using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace ConsoleApp
{
    class Siswa
    {
        public DataTable GetAll()
        {
            string quey = "SELECT NIM,NAMA,KELAS FROM Siswa";
            MySQL db = new MySQL();
            return db.GetData(query);
        }


    }
}
