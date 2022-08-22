using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ThisKeywordSample
{
    class Program
    {
        static void Main(string[] args)
        {
        tekrar:
            Random random = new Random();

            //Kullanıcıdan random gelen tamsayı değeri yakalama
            int wolfArrayLength;
            do
            {
                Console.WriteLine("Dizi oluşturmak için bir tamsayı girin.");
                wolfArrayLength = catchArrayLength();
            }
            while (wolfArrayLength <= 5);


            // Kullanıcıdan gelen dizi boyutuna göre random 1,2,3,4,5 rakamlarından oluşan bir dizi oluşturma
            List<int> arrayList = new List<int>();

            for (int i = 0; i < wolfArrayLength; i++)
            {
                arrayList.Add(random.Next(1, 6));
            }
            // Oluşturduğum diziyi ekrana yazdırma
            Console.WriteLine($"WolfsID = [{String.Join(", ", arrayList.ToArray())}]\n");


            // Oluşan diziyi ID'lere gruplama işlemi için metoda gönderme
            var wolfList = CreateWolfList(arrayList);

            // Gruplanan ID leri konsola yazma
            foreach (var w in wolfList)
            {
                Console.WriteLine($"{w.Id} ID 'li eleman {w.Count} defa tekrar ediyor.");
            }

            // En çok tekrar eden ID 
            int MaxCount = wolfList.Max(m => m.Count);

            // Birden fazla olduğunda en çok tekrar eden ID'ler
            var MaxWolfList = wolfList.Where(w => w.Count == MaxCount).ToList();

            // En çok tekrar eden ID'lerden en düşük olan ID
            int result = MaxWolfList.Min(m => m.Id);

            Console.WriteLine($"\nEn düşük ID'li en çok tekrar eden ID: {result}\n");

            goto tekrar;
        }
        static public int catchArrayLength()
        {
            //Gelen değerin tamsayı olup olmadığnını kontrol etme
            int returnValue = 0;
            try
            {
                returnValue = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı işlem yaptınız tekrar deneyin.\n");
            }
            Console.Clear();
            return (returnValue <= 200000 ? returnValue : 0); // case de istenen dizi boyutunun max sınırı
        }


        static public List<Wolf> CreateWolfList(List<int> arrayList)
        {
            // 1,2,3,4,5 ID' lerine sahip Kurtları oluşturma
            List<Wolf> wolfs = new List<Wolf>();

            for (int i = 1; i <= 5; i++)
            {
                wolfs.Add(new Wolf(i, 0));
            }

            // Kurtların oluşturulan dizide kaç defa tekrar ettiğini yakalama
            foreach (var item in arrayList)
            {
                wolfs.Where(w => w.Id == item).First().Count++;
            }
            return wolfs;
        }
    }
    class Wolf
    {
        int id;
        int count;
        public Wolf(int id, int count)
        {
            Id = id;
            Count = count;
        }
        public int Id { get => id; set => id = value; }
        public int Count { get => count; set => count = value; }
    }
}





