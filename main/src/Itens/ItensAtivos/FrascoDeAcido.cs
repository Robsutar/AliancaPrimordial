using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class FrascoDeAcido : ItemAtivo
    {
        public FrascoDeAcido() : base("Frasco de Acido", "O usuário arremessa um frasco de mistura química nos inimigos que " +
            "ao contato queima gravemente sua carne – &2causa&4 1d6 &2de dano por &93&2 turnos", Assets.frasco_de_acido)
        {
            consumivel = true;
        }
        public override void NoUso(EventoDeCombate e)
        {
            e.Adversario.AdicionarEfeito(new Acido());
            base.NoUso(e);
        }
        public override int FatorFavoravel(EventoDeCombate e)
        {
            return Dado.UmDTantos(15);
        }
    }
}
