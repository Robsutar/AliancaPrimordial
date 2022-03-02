using AliançaPrimordial.main.src.Janelas.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.Janelas
{
    public partial class TelaInicial : UserControl
    {
        BotaoKry kryButton;
        BotaoLianna liannaButton;
        Panel painelCentral;
        Panel painelAtual;
        public TelaInicial()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            painelCentral = new Panel();

            Label painelCMensagem = new Label();
            painelCMensagem.AutoSize = false;
            painelCMensagem.TextAlign = ContentAlignment.MiddleCenter;
            painelCMensagem.Dock = DockStyle.Fill;
            painelCMensagem.Text = "Escolha seu personagem";

            painelCentral.Controls.Add(painelCMensagem);

            kryButton = new BotaoKry(this);
            liannaButton = new BotaoLianna(this);

            Controls.Add(kryButton);
            Controls.Add(liannaButton);
            painelAtual = painelCentral;
            Controls.Add(painelAtual);
            MudarPainelCentral(null);
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }
        public void MudarPainelCentral(Panel panel)
        {
             Controls.Remove(painelAtual);
            if (panel != null)
            {
                painelAtual = panel;
            } else
            {
                painelAtual = painelCentral;
            }
            Controls.Add(painelAtual);
            painelAtual.Dock = DockStyle.None;
            painelAtual.Anchor = AnchorStyles.None;
            painelAtual.Size = new Size(200, 300);
            painelAtual.Location = new Point(
                this.ClientSize.Width / 2 - painelAtual.Size.Width / 2,
                this.ClientSize.Height / 2 - painelAtual.Size.Height / 2);
            painelAtual.BringToFront();
        }
    }
}
