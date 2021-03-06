using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;

namespace AliançaPrimordial.Items
{
    public class PocaoDeCura : ItemAtivo
    {
        public PocaoDeCura() : base("Poção de Cura", "Uma poção feita por bruxas em uma congregação – " +
            "&2Rola &42d4&2 para o total de vida recuperada", Assets.pocao_de_cura)
        {
            consumivel = true;
        }
        public override void NoUso(EventoDeCombate e)
        {
            e.Jogador.Vida += Dado.TantosDTantos(2, 4);
            base.NoUso(e);
        }
        public override int FatorFavoravel(EventoDeCombate e)
        {
            return e.Jogador.VidaMaxima - e.Jogador.Vida ;
        }
    }
}
