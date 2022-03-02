using AliançaPrimordial.Janelas;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Janelas.Menus
{
    public class BotaoLianna : BotaoDePersonagens
    {
        public BotaoLianna(TelaInicial handler) : base(Jogador.Lianna,handler)
        {
            Dock = System.Windows.Forms.DockStyle.Right;
        }

    }
}
