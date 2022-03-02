using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.main.src.Personagens;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.NoJogo
{
    public class Gerenciador : UserControl
    {
        JanelaDeCombate combate;
        public Gerenciador(Protagonistas jogador)
        {
            Dock = DockStyle.Fill;

            GerenciadorDeJanela.formPrincipal.Controls.Clear();

            GerenciadorDeJanela.formPrincipal.Controls.Add(this);

            Jogador.protagonista = jogador;

            jogador.Introducao(this);
        }
        public void IniciarCombate(JanelaDeCombate jdc)
        {
            if (combate !=null) {
                Controls.Remove(combate);
            }
            combate = jdc;
            combate.Abrir(this);
        }
    }
}
