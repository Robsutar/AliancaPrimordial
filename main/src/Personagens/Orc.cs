using AliançaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Personagens
{
    public class Orc : Jogador
    {
        public Orc() : base("Orc", 46, 50, 8, Item.Tacape, Assets.orc_normal)
        {
            itensAtivos.Add(Item.OlharDeMonstro);
        }
    }
}
