using System;
using System.Collections.Generic;
using System.Text;

namespace TugasLab9.Employee
{
    public abstract class Karyawan
    {
        public string NIK { get; set; }
        public string Nama { get; set; }

        public abstract double Gaji();
    }
}