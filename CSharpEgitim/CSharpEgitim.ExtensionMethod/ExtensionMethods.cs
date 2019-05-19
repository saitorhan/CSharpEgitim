using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitim.ExtensionMethod
{
    public static class ExtensionMethods
    {
        public static bool In(this int a, int b, int c)
        {
            return a > b && a < c;
        }

        public static string GetFirst3Char(this string s)
        {
            return s.Substring(0, 3);
        }
    }
}
