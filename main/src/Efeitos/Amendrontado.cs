using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Amendrontado : Efeito
    {
        public Amendrontado() : base("Amendrontado", "Após uma intimidação assutadora, o indivíduo está amendrontado, " +
            "&2 o alvo tem &7-4 &2em testes de dano", 6, Item.OlharDeMonstro)
        {
        }

        public override void AntesDoTurno(EventoDeCombate e)
        {
            base.AntesDoTurno(e);
            e.Jogador.modificadorDeDado -= 4;
            Mensageiro.Print("Jogador amendrontado: " + e.Jogador.Nome+" "+e.Jogador.modificadorDeDado);
        }
    }
}
