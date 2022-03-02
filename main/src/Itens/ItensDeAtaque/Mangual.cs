using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class Mangual : ItemDeAtaque
    {
        public Mangual() : base("Mangual", "Uma arma difícil de manusear, é necessário anos de treinamento para enfim chegar a sua maestria – " +
            "&2Diminui em &7-2&2 o teste de ataque e aumenta o dano em &7+5",-2,9, Assets.mangual)
        {
        }

        public override int Dano(EventoDeCombate e)
        {
            return base.Dano(e) + 5;
        }
    }
}
