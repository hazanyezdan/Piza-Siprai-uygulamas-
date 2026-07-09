using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PizzaMatik.Models;

namespace PizzaMatik.Services
{
    public class SiparisYonetici
    {
        // Sepetteki pizzaları tutacağımız liste
        private List<Pizza> _sepet = new List<Pizza>();

        // Sepete pizza ekleme metodu
        public void SepeteEkle(Pizza pizza)
        {
            _sepet.Add(pizza);
        }

        // Sepetteki tüm pizzaların toplam tutarını hesaplayan metot
        public double ToplamTutarHesapla()
        {
            // LINQ kullanarak sepetteki tüm pizzaların fiyatlarını topluyoruz
            return _sepet.Sum(p => p.Fiyat);
        }

        // Faturayı hem konsola basan hem de dosyaya kaydeden metot
        public void FaturaYazdir()
        {
            string faturaYolu = "fatura.txt";

            // StreamWriter kullanarak projeyle aynı klasörde bir fatura.txt dosyası açıyoruz
            using (StreamWriter writer = new StreamWriter(faturaYolu))
            {
                writer.WriteLine("======================================");
                writer.WriteLine("        PIZZAMATIK SIPARIS FATURASI    ");
                writer.WriteLine("======================================");
                writer.WriteLine($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}");
                writer.WriteLine("--------------------------------------");

                foreach (var pizza in _sepet)
                {
                    writer.WriteLine($"- {pizza.Aciklama}");
                    writer.WriteLine($"  Boyut: {pizza.Boyut} | Hamur: {pizza.Hamur}");
                    writer.WriteLine($"  Fiyat: {pizza.Fiyat:N2} TL");
                    writer.WriteLine();
                }

                double sonTutar = ToplamTutarHesapla();

                writer.WriteLine("--------------------------------------");
                writer.WriteLine($"TOPLAM TUTAR: {sonTutar:N2} TL");
                writer.WriteLine("======================================");
                writer.WriteLine("Afiyet Olsun! PizzaMatik'i sectiginiz icin tesekkurler.");
            }

            // Dosyaya yazdıktan sonra faturayı konsol ekranında da gösteriyoruz
            Console.Clear();
            Console.WriteLine(File.ReadAllText(faturaYolu));
        }
    }
}