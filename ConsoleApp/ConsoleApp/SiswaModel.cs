using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class SiswaModel
    {
        private string _NIM;
        private string _NAMA;
        private string _KELAS;
        public string NIM
        {
            get
            {
                return _NIM;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Nim Tidak Boleh Kosong ");

                }
                _NIM = Value;
            }
        }
    }
}
