using AliançaPrimordial.Janelas;
using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.main.src.Personagens;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.Janelas.Menus
{
    public abstract class BotaoDePersonagens : Button
    {
        public readonly string historia;
        protected readonly TelaInicial handler;
        private Panel panel;
        private Protagonistas jogador;
        private int xAdicional = 0;
        private int largura = 500, altura = 500;
        public BotaoDePersonagens(Protagonistas p, TelaInicial handler)
        {
            this.jogador = p;
            this.handler = handler;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new System.Drawing.Size(largura,altura);
            this.Image = p.Image;
            this.historia = p.MostrarHistoria();

            panel = new Panel();
            Label nome = new Label();
            nome.Text = p.Nome;
            nome.TextAlign = ContentAlignment.MiddleCenter;
            nome.Dock = DockStyle.Top;
            nome.Font = new Font("Arial", 16);
            Label l = new Label();
            l.MaximumSize = new Size(200, 300);
            l.AutoSize = true;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Text = p.MostrarHistoria();
            l.Dock = DockStyle.Top;
            panel.Controls.Add(l);
            panel.Controls.Add(nome);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Enabled = false;
            new Gerenciador(jogador);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            handler.MudarPainelCentral(panel);
            xAdicional = 50;
            Size = new Size(largura + xAdicional, altura);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            handler.MudarPainelCentral(null);
            xAdicional = 0;
            Size = new Size(largura+xAdicional, altura);
        }
    }
}
