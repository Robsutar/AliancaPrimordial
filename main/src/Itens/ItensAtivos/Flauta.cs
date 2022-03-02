using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class Flauta : ItemAtivo
    {
        public Flauta() : base("Flauta", "Um instrumento musical comum, que como muitos outros podem ser enfeitiçados" +
            " &2 encanta os inimigos, reduzindo em -2 os testes de ataque por &92&2 turnos", Assets.flauta)
        {
        }

        public override void NoUso(EventoDeCombate e)
        {
            base.NoUso(e);
            e.Adversario.AdicionarEfeito(new Encantado());
        }
    }
}
