# E-Health Triage System (Tugas 2 Mata Kuliah Pemrograman Lanjut)

Program Console App sederhana menggunakan bahasa C# untuk menghitung dan mengurutkan data BMI pasien. Project ini dibuat untuk memenuhi tugas mata kuliah **Pemrograman Lanjut**.

---

## 🎓 Identitas Tugas

**Mata Kuliah:** Pemrograman Lanjut  
**Kelas:** SI-303  
**Prodi:** PJJ S1 - Sistem Informasi  
**Kampus:** Universitas Siber Asia  
**Dosen:** Bapak Agung Riyadi, S.Kom., M.Kom.

### 👥 Disusun Oleh: Kelompok 20
| NIM | Nama |
| :--- | :--- |
| **240101010025** | MUHAMMAD IRFAN MAULANA |
| **240101010062** | NEZAR HELMI ATHALLAH |

---

## 📝 Tentang Program
Aplikasi ini mensimulasikan pendataan pasien sederhana di klinik. Fitur utamanya adalah menghitung BMI secara otomatis dan mengurutkan pasien mana yang punya risiko obesitas paling tinggi.

**Alur program:**
1. User input jumlah pasien.
2. User input Nama, Berat (kg), dan Tinggi (cm).
3. Program otomatis menghitung BMI dan menentukan kategorinya (Kurus, Normal, Overweight, Obesitas).
4. Program menampilkan tabel laporan yang sudah diurutkan dari BMI terbesar ke terkecil.

## 🛠️ Konsep Kodingan
Sesuai syarat tugas, kode program ini menerapkan beberapa konsep dasar:

* **Array 1 Dimensi:** Dipakai untuk menyimpan `Nama Pasien`.
* **Array Multi Dimensi:** Dipakai untuk menyimpan angka `Berat`, `Tinggi`, dan `Hasil BMI`.
* **Procedure:** Dipakai untuk bagian Input Data dan Tampilan Laporan (method void).
* **Function:** Dipakai untuk rumus hitung BMI dan logika penentuan status kategori (method dengan return value).
* **Sorting Logic:** Menggunakan algoritma *Bubble Sort* untuk mengurutkan data secara manual (tanpa pakai function sort bawaan).

## 💻 Cara Menjalankan
1.  Download atau Clone repository ini.
2.  Buka file `.sln` pakai **Visual Studio 2022**.
3.  Pastikan settingan project pakai **.NET 8.0**.
4.  Klik tombol **Start** (atau tekan F5) untuk run program.

---
*Dibuat untuk keperluan tugas kuliah Semester 3.*
