using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class ErvaDeCura : ItemAtivo
    {
        public ErvaDeCura() : base("Erva de Cura", "O usuário ingere a planta e instantaneamente se sente revigorado – " +
            "&2Rola &41d5 &2para o total de vida recuperada", Assets.erva_de_cura)
        {
        }
        public override void NoUso(EventoDeCombate e)
        {
            e.Jogador.Vida += Dado.UmDTantos(5);
            base.NoUso(e);
        }
        public override int FatorFavoravel(EventoDeCombate e)
        {
            return Dado.UmDTantos(15);
        }
    }
}
