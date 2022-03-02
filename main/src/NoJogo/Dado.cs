using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaPrimordial.Motor
{
    static class Dado
    {
        public static int TantosDTantos(int quantidade, int range)
        {
            int saida = 0;
            for(int i = 0; i < quantidade; i++) {
                saida += UmDTantos(range);
            }
            return saida;
        }
        public static int UmDTantos(int range)
        {
            Random rnd = new Random();
            int valor = rnd.Next(range) + 1;
            Mensageiro.Print("Um dado foi rodado: "+valor+" <valor : range> "+range);
            
            return valor;
        }
    }
}
