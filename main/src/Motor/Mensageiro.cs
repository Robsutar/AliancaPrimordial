using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.Motor
{
    static class Mensageiro
    {
        public static void Print(Object text)
        {
            string s = text.ToString();
            string time = DateTime.Now.ToString("h:mm:ss tt");
            Debug.WriteLine("[ "+time+"] "+s);
        }
        public static void Print(Object o, bool showToPlayer)
        {
            Print(o);
        }
    }
}
