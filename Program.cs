using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TugasLab9.Employee;

namespace TugasLab9
{
	class Program
	{
		static void Main()
		{
			List<Karyawan> karyawan = new List<Karyawan>();

            Pilih(karyawan);
        }

        static void Pilih(List<Karyawan> karyawan)
        {
            bool status = true;

            while(status == true)
            {
                Console.Clear();
                Console.WriteLine("Menu Utama : ");
                Console.WriteLine("[1]. Tambah Data\n[2]. Hapus Data \n[3]. Tampilkan Data \n[4]. Keluar\n");
                Console.Write("Masukkan Pilihan Anda[1-4]: ");
                int pil = int.Parse(Console.ReadLine());

                switch (pil)
                {
                    case 1:
                    {
                            TambahData(karyawan);
                            BackToMainMenu();
                            break;
                    }

                    case 2:
                    {
                            HapusData(karyawan);
                            BackToMainMenu();
                            break;
                    }

                    case 3:
                    {
                            TampilData(karyawan);
                            BackToMainMenu();
                            break;

                    }

                    case 4:
                    {
                            Console.WriteLine("Good Bye.");
                            Thread.Sleep(500);
                            status = false;
                            break;
                    }

                    default:
                    {
                            Console.WriteLine("Pilihan tidak ada, silahkan masukkan pilihan yang Ada.\nPress Any Button");
                            Console.ReadKey();
                            Pilih(karyawan);
                            break;
                    }
                }
            }
        }

        static void TambahData(List<Karyawan> karyawan)
        {
            Console.Clear();
            Console.WriteLine("=========== Menu Menambah Karyawan ===========");
            Console.WriteLine("\nPilih Tipe Karyawan: ");
            Console.WriteLine("[1] Karyawan Tetap \n[2] Karyawan Harian \n[3] Sales");

            Console.Write("Masukkan Pilihan Anda [1-3]: ");
            int pil = int.Parse(Console.ReadLine());

            switch (pil)
            {
                    case 1:
                    {
                        KaryawanTetap karyawanTetap = new KaryawanTetap();

                        Console.WriteLine("\nTambah Karyawan Tetap");

                        Console.Write("Masukkan NIK \t\t\t: ");
                        karyawanTetap.NIK = Console.ReadLine();

                        Console.Write("Masukkan Nama \t\t\t: ");
                        karyawanTetap.Nama = Console.ReadLine();

                        Console.Write("Masukkan Gaji Bulanan \t\t: ");
                        karyawanTetap.GajiBulanan = Convert.ToDouble(Console.ReadLine());

                        karyawan.Add(karyawanTetap);
                        break;
                    }

                    case 2:
                    {
                        KaryawanHarian karyawanHarian = new KaryawanHarian();

                        Console.WriteLine("Tambah Karyawan Harian");

                        Console.Write("Masukkan NIK \t\t\t: ");
                        karyawanHarian.NIK = Console.ReadLine();

                        Console.Write("Masukkan Nama \t\t\t: ");
                        karyawanHarian.Nama = Console.ReadLine();

                        Console.Write("Masukkan Upah per Jam \t\t: ");
                        karyawanHarian.UpahPerJam = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Masukkan Jam Kerja \t\t: ");
                        karyawanHarian.JumlahJamKerja = Convert.ToDouble(Console.ReadLine());

                        karyawan.Add(karyawanHarian);
                        break;
                    }

                    case 3:
                    {
                        Sales sales = new Sales();

                        Console.WriteLine("Tambah sales");

                        Console.Write("Masukkan NIK \t\t\t: ");
                        sales.NIK = Console.ReadLine();

                        Console.Write("Masukkan Nama \t\t\t: ");
                        sales.Nama = Console.ReadLine();

                        Console.Write("Masukkan Jumlah Penjualan \t: ");
                        sales.JumlahPenjualan = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Masukkan Komisi \t\t: ");
                        sales.Komisi = Convert.ToDouble(Console.ReadLine());

                        karyawan.Add(sales);
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Pilihan tidak ada, silahkan masukkan lagi.\nPress Any Button");
                        Console.ReadKey();
                        TambahData(karyawan);
                        break;
                    }
            }
        }

        static void HapusData(List<Karyawan> karyawan)
        {
            bool Ditemukan = true;

            TampilData(karyawan);
            Console.Write("\nMasukkan NIK Karyawan Yang Ingin Di Hapus: ");
            string nik = Console.ReadLine();

            for (int i = 0; i < karyawan.Count; i++)
            {
                if (karyawan[i].NIK == nik)
                {
                    karyawan.Remove(karyawan[i]);
                    Ditemukan = true;
                    break;
                }
                else
                {
                    Ditemukan = false;
                }
            }

            switch (Ditemukan)
            {
                case true:
                    Console.WriteLine("\nData dengan NIK = \"{0}\" berhasil dihapus", nik);
                    break;
                case false:
                    Console.WriteLine("\nData dengan NIK = \"{0}\" Tidak Ditemukan", nik);
                    break;
            }
        }

        static void TampilData(List<Karyawan> karyawan)
        {
            Console.Clear();

            Console.WriteLine("=========== DATA KARYAWAN ===========");
            Console.WriteLine("=====================================================================================");
            Console.WriteLine(String.Format("| {0,-3} | {1,-15} | {2,-30} | {3,-24} |", "NO", "NIK", "NAMA", "GAJI"));
            Console.WriteLine("=====================================================================================");
            for (int i = 0; i < karyawan.Count; i++)
            {
                Console.WriteLine(String.Format("| {0,-3} | {1,-15} | {2,-30} | {3,-3} {4,-20} |", i + 1, karyawan[i].NIK, karyawan[i].Nama, "Rp." , karyawan[i].Gaji()));
            }
        }

        static void BackToMainMenu()
        {
            Console.WriteLine("\nPress Any Key To Back To The Main Menu.");
            Console.ReadKey();
        }
    }
}