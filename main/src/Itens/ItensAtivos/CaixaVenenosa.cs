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
    public class CaixaVenenosa : ItemAtivo
    {
        public CaixaVenenosa() : base("CaixaVenenosa", "O usuário atira a caixa no adversário, quebrando-a no impacto,  " +
            "liberando um veneno brilhante – &2causa&4 quantidade de turnos restantes &2de dano por &94&2 turnos", Assets.caixa_venenosa)
        {
            consumivel = true;
        }

        public override int FatorFavoravel(EventoDeCombate e)
        {
            return Dado.UmDTantos(20);
        }
        public override void NoUso(EventoDeCombate e)
        {
            e.Adversario.AdicionarEfeito(new Envenenamento());
            base.NoUso(e);
        }
    }
}
