using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.Janelas
{
    public class Legendas : Panel
    {
        int index = 0;

        private Evento EventoAcabar, EventoIniciar;

        private readonly Control handler;

        int Index
        {
            get => index;
            set
            {
                index = value;
                index = Math.Max(0, index);
                if (index == 0)
                {
                    tick.Enabled = true;
                    AoIniciar();
                }
            }
        }

        Label legenda;

        string texto = "";

        Timer tick;

        public Legendas(Control c)
        {
            Size = new Size(600, 150);
            BackColor = Visual.backgroundColor1;
            Anchor = AnchorStyles.None;
            DoubleBuffered = true;
            this.handler = c;

            legenda = new Label();
            legenda.TextAlign = ContentAlignment.MiddleCenter;
            legenda.Dock = DockStyle.Fill;
            legenda.Font = new Font("Arial", 12);

            Controls.Add(legenda);

            tick = new Timer();
            tick.Interval = 10;
            tick.Tick += Tick_Tick;

            legenda.Paint += Legendas_Paint;
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            if (Index < texto.Length)
            {
                Index++;
                string s = "";
                char[] crs = texto.ToCharArray();
                for (int i = 0; i < Index; i++)
                {
                    s += crs[i];
                }
                legenda.Text = s;
                Invalidate();
            } else
            {
                tick.Enabled = false;
                AoAcabar();
            }
        }

        public void Abrir()
        {
            this.Location = new Point(
                handler.ClientSize.Width / 2 - this.Size.Width / 2,
                handler.ClientSize.Height / 2 - this.Size.Height / 2);
            handler.Controls.Add(this);
        }
        public void Fechar()
        {
            handler.Controls.Remove(this);
        }

        public void MudarLegenda(string legenda)
        {
            Index = 0;
            texto = legenda;
        }

        public void ConcatenarLegenda(string legenda)
        {
            texto += legenda;
            tick.Start();
        }

        public void AdicionarEventoAoAcabar(Evento e)
        {
            EventoAcabar = e;
        }
        public void AdicionarEventoAoIniciar(Evento e)
        {
            EventoIniciar = e;
        }

        private void AoAcabar()
        {
            if (EventoAcabar != null) { EventoAcabar.Invocar(); EventoAcabar = null; }
        }
        private void AoIniciar()
        {
            if (EventoIniciar != null) { EventoAcabar.Invocar(); EventoIniciar = null; }
        }

        private void Legendas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Brush p = new SolidBrush(Visual.menuColor2);
            gfx.FillRectangle(p, 0, 0, Width, 5);
            gfx.FillRectangle(p, 0,Height-5,Width,Height);
        }
    }
}
