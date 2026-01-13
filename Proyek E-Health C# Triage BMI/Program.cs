using System;

namespace EHealthTriageSystem
{
    class Program
    {
        // Global Variables (simulasi database)
        // Menentukan batas maksimal pasien (fixed size untuk array)
        // Di set 100 agar memori tidak terlalu besar
        static int maxCapacity = 100;

        // Variabel counter untuk melacak berapa jumlah pasien yang sudah tersimpan saat ini
        static int currentCount = 0;

        // [ARRAY ONE DIMENSIONAL]
        // Array 1 Dimensi ini digunakan untuk menyimpan data string (Nama Pasien).
        // Indeks array ini berkorelasi dengan indeks array data kesehatan.
        static string[] namaPasien = new string[maxCapacity];

        // [ARRAY MULTI DIMENSIONAL]
        // Array 2 Dimensi bertipe double untuk menyimpan data angka/metrik.
        // Format: [Baris, Kolom]
        // - Baris: Mewakili ID Pasien (0 s/d 99)
        // - Kolom 0: Menyimpan berat badan (kg)
        // - Kolom 1: Menyimpan tinggi badan (meter)
        // - Kolom 2: Menyimpan hasil kalkulasi BMI
        static double[,] dataKesehatan = new double[maxCapacity, 3];

        static void Main(string[] args)
        {
            Console.Title = "E-Health Triage System v1.1";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM TRIAGE E-HEALTH ===");
                Console.WriteLine("1. Input Data Pasien");
                Console.WriteLine("2. Lihat Laporan & Analisis");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        InputData();
                        break;
                    case "2":
                        // Memanggil Procedure untuk menampilkan output
                        TampilkanLaporan();
                        break;
                    case "3":
                        return; // Keluar dari program
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // [PROCEDURE]
        // Definisi Procedure: Sebuah method dengan tipe 'void' yang menjalankan serangkaian aksi 
        // tanpa mengembalikan nilai (return value) ke pemanggilnya.
        // Tugas: Menangani proses input data dari keyboard user.
        static void InputData()
        {
            Console.Clear();
            Console.WriteLine("--- Input Data Pasien ---");

            Console.Write("Masukkan jumlah pasien yang ingin didata: ");

            // Validasi input angka jumlah pasien
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                for (int i = 0; i < n; i++)
                {
                    // Cek apakah array sudah penuh
                    if (currentCount >= maxCapacity)
                    {
                        Console.WriteLine("Memori Penuh! Tidak bisa menambah data lagi.");
                        break;
                    }

                    Console.WriteLine($"\nData Pasien ke-{currentCount + 1}");

                    // Input Nama -> Masuk ke Array 1 Dimensi
                    Console.Write("Nama Lengkap: ");
                    namaPasien[currentCount] = Console.ReadLine();

                    // Input Data Fisik -> Masuk ke Array Multi Dimensi (variable lokal)
                    Console.Write("Berat Badan (kg): ");
                    double berat = double.Parse(Console.ReadLine());

                    Console.Write("Tinggi Badan (cm) (contoh: 170): ");
                    double tinggiCm = double.Parse(Console.ReadLine());

                    // Konversi cm ke meter agar sesuai rumus BMI standar
                    double tinggiMeter = tinggiCm / 100.0;

                    // Simpan ke Array Multi Dimensi
                    dataKesehatan[currentCount, 0] = berat;       // Kolom 0
                    dataKesehatan[currentCount, 1] = tinggiMeter; // Kolom 1

                    // [PENGGUNAAN FUNCTION]
                    // Memanggil function HitungBMI, lalu hasilnya langsung disimpan ke Kolom 2
                    dataKesehatan[currentCount, 2] = HitungBMI(berat, tinggiMeter);

                    // Increment jumlah data
                    currentCount++;
                }
                Console.WriteLine("\nData berhasil disimpan! Tekan ENTER untuk kembali ke menu...");
            }
            else
            {
                Console.WriteLine("Input angka salah.");
            }
            Console.ReadKey();
        }

        // [FUNCTION]
        // Definisi Function: Sebuah method yang memiliki tipe data (disini 'double') 
        // dan WAJIB mengembalikan nilai menggunakan kata kunci 'return'.
        // Tugas: Menerima input berat & tinggi dan mengembalikan hasil hitungan BMI.
        static double HitungBMI(double berat, double tinggi)
        {
            // Validasi untuk menghindari pembagian dengan nol 
            if (tinggi <= 0) return 0;

            // Rumus BMI = Berat / (Tinggi * Tinggi)
            // Hasil dibulatkan 2 angka dibelakang koma
            return Math.Round(berat / (tinggi * tinggi), 2);
        }

        // [FUNCTION]
        // Function ini bertugas menerjemahkan Angka BMI menjadi kategori dalam bentuk string.
        // Input: double (BMI), Output: string (Keterangan)
        static string GetKategoriBMI(double bmi)
        {
            if (bmi <= 18.4)
            {
                return "Berat badan kurang (underweight)";
            }
            else if (bmi <= 23.9)
            {
                return "Berat badan normal";
            }
            else if (bmi <= 27.9)
            {
                return "Berat badan berlebih (overweight)";
            }
            else
            {
                return "Berat badan obesitas";
            }
        }

        // [PROCEDURE]
        // Procedure untuk menampilkan laporan akhir ke layar console.
        static void TampilkanLaporan()
        {
            Console.Clear();
            Console.WriteLine("--- Laporan Analisis BMI (Urutan Nilai Tertinggi) ---");

            if (currentCount == 0)
            {
                Console.WriteLine("Belum ada data. Tekan ENTER untuk kembali!");
                Console.ReadKey();
                return;
            }

            // Lakukan penyortiran data terlebih dahulu sebelum ditampilkan
            UrutkanDataBerdasarkanBMI();

            Console.WriteLine("--------------------------------------------------------------------------------");
            // Header Tabel
            Console.WriteLine("{0,-4} | {1,-15} | {2,-8} | {3,-8} | {4,-8} | {5,-15}",
                "No", "Nama", "Berat", "Tinggi", "BMI", "Kategori");
            Console.WriteLine("--------------------------------------------------------------------------------");

            // Looping untuk mencetak isi array yang sudah terurut
            for (int i = 0; i < currentCount; i++)
            {
                double nilaiBMI = dataKesehatan[i, 2];

                // Memanggil Function GetKategoriBMI untuk mendapatkan status BMI pasien
                string kategori = GetKategoriBMI(nilaiBMI);

                Console.WriteLine("{0,-4} | {1,-15} | {2,-8} | {3,-8} | {4,-8} | {5,-15}",
                    (i + 1),
                    namaPasien[i],           // Ambil dari array 1D
                    dataKesehatan[i, 0],     // Berat (array multi-D)
                    dataKesehatan[i, 1],     // Tinggi (array multi-D)
                    nilaiBMI,                // BMI (array multi-D)
                    kategori                 // Hasil function string
                );
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

            // Menampilkan List Kategori
            Console.WriteLine("\nKategori BMI untuk Dewasa (Referensi):");
            Console.WriteLine("- < 18.5       : Berat badan kurang (underweight).");
            Console.WriteLine("- 18.5 - 24.9  : Berat badan normal.");
            Console.WriteLine("- 25.0 - 29.9  : Berat badan berlebih (overweight).");
            Console.WriteLine("- >= 30.0      : Berat badan obesitas (dibagi lagi menjadi obesitas Tingkat I, II, dan seterusnya tergantung rentang BMI).");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\nTekan ENTER untuk kembali...");
            Console.ReadKey();
        }

        // [LOGIKA PENYORTIRAN (SORTING)]
        // Menggunakan algoritma bubble sort untuk mengurutkan data.
        // Jenis Sort: Descending (dari besar ke kecil) berdasarkan nilai BMI.
        static void UrutkanDataBerdasarkanBMI()
        {
            // Loop luar: Mengulang proses scanning sebanyak jumlah data
            for (int i = 0; i < currentCount - 1; i++)
            {
                // Loop dalam: Membandingkan elemen berdampingan
                for (int j = 0; j < currentCount - i - 1; j++)
                {
                    // LOGIKA KOMPARASI:
                    // Jika BMI elemen sekarang (j) LEBIH KECIL dari BMI elemen berikutnya (j+1),
                    // maka kita tukar posisinya agar yang besar naik ke atas (urutan menurun/descending).
                    if (dataKesehatan[j, 2] < dataKesehatan[j + 1, 2])
                    {
                        // PROSES SWAPPING (TUKAR DATA)

                        // 1. Tukar data di Array Multi Dimensional (angka)
                        // Kita loop 3 kali (k=0 s/d 2) untuk menukar Berat, Tinggi, dan BMI sekaligus
                        for (int k = 0; k < 3; k++)
                        {
                            double tempDouble = dataKesehatan[j, k];
                            dataKesehatan[j, k] = dataKesehatan[j + 1, k];
                            dataKesehatan[j + 1, k] = tempDouble;
                        }

                        // 2. Tukar data di Array One Dimensional (string Nama)
                        // NOTE: Nama juga harus ikut ditukar agar data tetap sinkron dengan pemiliknya
                        string tempNama = namaPasien[j];
                        namaPasien[j] = namaPasien[j + 1];
                        namaPasien[j + 1] = tempNama;
                    }
                }
            }
        }
    }
}