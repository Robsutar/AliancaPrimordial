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
    public class BotaoKry : BotaoDePersonagens
    {
        public BotaoKry(TelaInicial handler) : base(Jogador.Kry, handler)
        {
            Dock = System.Windows.Forms.DockStyle.Left;
        }
    }
}
