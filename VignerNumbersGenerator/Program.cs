using System;
using System.Collections.Generic;
using System.IO;

namespace VignerNumbersGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand1 = new Random();
            Random rand2 = new Random();

            List<double> result = new List<double>();

            while (result.Count < 1000)
            {
                double x = Convert(rand1.NextDouble(),0,1,7.6,8.4);
                double y = Convert(rand2.NextDouble(), 0, 1, 0, 2 / (Math.PI * 4));

                double fx = (2/(Math.PI*16))*Math.Sqrt(0.16-(x-8)*(x-8));

                if (y < fx)
                {
                    result.Add(Math.Round(x,3));
                    Console.WriteLine(Math.Round(x,3));
                }
                  
            }
            Console.WriteLine("Done generation");

            string stringResult = 0.ToString()+"\n";
            foreach (var number in result)
            {
                stringResult += number.ToString().Replace(",",".") + "\n";
            }

            string path = "1.txt";
            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(stringResult);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
            Console.ReadKey();
        }

        static double Convert(double value, double from1, double from2, double to1, double to2)
        {
            return (value - from1) / (from2 - from1) * (to2 - to1) + to1;
        }
    }
}
