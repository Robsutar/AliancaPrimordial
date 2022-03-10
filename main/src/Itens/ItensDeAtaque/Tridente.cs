using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Itens.ItensDeAtaque
{
    public class Tridente : ItemDeAtaque
    {
        public Tridente() : base("Tridente", "Encontrado no fundo de um lago, esse tridente parece estar &4amaldiçoado," +
            " &2o usuário tem &7+4&2 em testes de ataque e aumenta o dano em &7+4", 4, 11, Assets.tridente)
        {
        }
        public override int Dano(EventoDeCombate e)
        {
            return base.Dano(e)+4;
        }
    }
}
