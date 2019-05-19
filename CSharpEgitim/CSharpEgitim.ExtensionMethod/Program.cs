using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitim.ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int sayi = 35, sayi1 = 34, sayi2 = 76;

            if (sayi.In(sayi1, sayi2))
            {
                Console.WriteLine("Arasında");
            }
            else
            {
                Console.WriteLine("Arasında değil");
            }

            string cumle = "abcçdef";

            Console.WriteLine(cumle.GetFirst3Char());

            Console.ReadLine();
        }
    }
}
