using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Encantado : Efeito
    {
        public Encantado() : base("Encantado", "O indivíduo está &4encantado&2 terá &7-2 &2em testes de ataque", 2, Item.Flauta)
        {

        }
        public override void AntesDoTurno(EventoDeCombate e)
        {
            base.AntesDoTurno(e);
            e.Jogador.modificadorDeDado -= 2;
            Mensageiro.Print("Jogador encantado: " + e.Jogador.Nome) ;
        }
    }
}
