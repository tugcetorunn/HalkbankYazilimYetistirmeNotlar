using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "ornek.txt";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== DOSYA İŞLEMLERİ ===");
            Console.WriteLine("1. Dosya Oluştur");
            Console.WriteLine("2. Dosyaya Yaz");
            Console.WriteLine("3. Dosyaya Ekle");
            Console.WriteLine("4. Dosya İçeriğini Oku");
            Console.WriteLine("5. Dosyayı Satır Satır Oku");
            Console.WriteLine("6. Dosya Kopyala");
            Console.WriteLine("7. Dosya Taşı");
            Console.WriteLine("8. Dosya Sil");
            Console.WriteLine("9. Dosya Bilgisi Göster");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");
            var secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    CreateFile(filePath);
                    break;
                case "2":
                    WriteToFile(filePath);
                    break;
                case "3":
                    AppendToFile(filePath);
                    break;
                case "4":
                    ReadFromFile(filePath);
                    break;
                case "5":
                    ReadLinesFromFile(filePath);
                    break;
                case "6":
                    CopyFile(filePath);
                    break;
                case "7":
                    MoveFile(filePath);
                    break;
                case "8":
                    DeleteFile(filePath);
                    break;
                case "9":
                    ShowFileInfo(filePath);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    static void CreateFile(string path)
    {
        using (FileStream fs = File.Create(path))
        {
            Console.WriteLine("Dosya oluşturuldu: " + path);
        }
    }

    static void WriteToFile(string path)
    {
        Console.Write("Yazılacak metni girin: ");
        string text = Console.ReadLine();
        File.WriteAllText(path, text);
        Console.WriteLine("Metin dosyaya yazıldı.");
    }

    static void AppendToFile(string path)
    {
        Console.Write("Eklenecek metni girin: ");
        string text = Console.ReadLine();
        File.AppendAllText(path, text + Environment.NewLine);
        Console.WriteLine("Metin dosyaya eklendi.");
    }

    static void ReadFromFile(string path)
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Console.WriteLine("Dosya içeriği:\n" + content);
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı.");
        }
    }

    static void ReadLinesFromFile(string path)
    {
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine("Dosya Satırları:");
            foreach (var line in lines)
                Console.WriteLine("- " + line);
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı.");
        }
    }

    static void CopyFile(string sourcePath)
    {
        Console.Write("Kopya dosya adı girin: ");
        string destPath = Console.ReadLine();
        try
        {
            File.Copy(sourcePath, destPath, true);
            Console.WriteLine("Dosya başarıyla kopyalandı.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }

    static void MoveFile(string sourcePath)
    {
        Console.Write("Yeni dosya yolu girin: ");
        string destPath = Console.ReadLine();
        try
        {
            File.Move(sourcePath, destPath);
            Console.WriteLine("Dosya taşındı.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }

    static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine("Dosya silindi.");
        }
        else
        {
            Console.WriteLine("Dosya zaten yok.");
        }
    }

    static void ShowFileInfo(string path)
    {
        if (File.Exists(path))
        {
            Console.WriteLine("Dosya Oluşturulma Tarihi: " + File.GetCreationTime(path));
            Console.WriteLine("Son Yazılma Tarihi: " + File.GetLastWriteTime(path));
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı.");
        }
    }
}

