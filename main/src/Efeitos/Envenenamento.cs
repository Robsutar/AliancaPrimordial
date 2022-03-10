using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Envenenamento : Efeito
    {
        public Envenenamento() : base("Envenenamento", "A pele do indivíduo está esverdeada, sofrendo de dor interna, " +
            "&2 o alvo sofre &4quantidade de turnos restantes &2de dano por turno.", 4, Item.FrascoDeAcido)
        {

        }
        public override void DepoisDoTurno(EventoDeCombate e)
        {
            base.DepoisDoTurno(e);
            int dano = turnosRestantes;
            e.Jogador.Vida -= dano;
            Mensageiro.Print(dano + " alvo machucado pelo veneno " + e.Jogador.Nome);
        }
    }
}
