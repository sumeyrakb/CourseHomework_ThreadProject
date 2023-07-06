using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHomework.ThreadProject
{
    internal class ThreadProject
    {
        // Console uygulaması yapalım
        //  -Bizden bir parametre alsın(int) örneğin 5.Bu şu anlama geliyor, 5 adet Thread oluşturulacak ve bu thread'ler queue'dan okuma yapacaklar.
        //  - Diğer bir thread(6.thread), bizim ona verdiğimiz bir dosyadan okuma yapıp kelimeleri queue'ya ekleyecek
        //  - Diğer 5 thread'de bu kelimeleri queue'dan alıp ekrana şu şekilde yazdıracak
        //    Araba:5
        //    Kar  :3   ... 



        static string textFile = @"C:\Temp\words.txt";
        static Queue<string> wordQueue = new Queue<string>();

        static void Main(string[] args)
        {


            new Thread(ReadFromFileAndAddToQueue).Start();

            Console.Write("Lütfen Thread sayısını giriniz:  ");

            int threadCount;

            while (!int.TryParse(Console.ReadLine(), out threadCount))
            {
                Console.WriteLine("Geçersiz giriş! Bir tam sayı girmeniz gerekiyor..! ");
                Console.WriteLine("\nLütfen Thread sayısını giriniz:  ");
            }

            for (int i = 0; i < threadCount; i++)
            {
                new Thread(PrintWordsFromQueue).Start();
            }

        }


        //Kelimeleri dosyadan okuyan ardından queue'ye yazdıran metot
        public static void ReadFromFileAndAddToQueue()
        {
            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                foreach (string line in lines)
                {
                    wordQueue.Enqueue(line);
                }
            }
        }


        //Kelimeleri queue'den alıp ekrana yazdıran metot
        public static void PrintWordsFromQueue()
        {
            while (wordQueue.Count > 0)
            {
                string word = wordQueue.Dequeue();
                Console.WriteLine(word + ":" + word.Length);
            }
        }
    }
}
