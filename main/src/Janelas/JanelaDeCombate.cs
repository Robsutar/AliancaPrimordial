using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Invocadores;
using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.Janelas
{
    public partial class JanelaDeCombate : UserControl
    {
        internal Humano p1;
        internal Bot p2;

        internal bool turno = true;

        public readonly Legendas legendas;

        PainelDeHabilidades habilidades;

        PainelDeStatus statusP1, statusP2;

        Panel p1Panel,p2Panel;

        public JanelaDeCombate(Humano p1, Bot p2)
        {

            this.p1 = p1;this.p2 = p2;
            InitializeComponent();
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
            Padding = new Padding(10);

            BackColor = Visual.backgroundColor1;

            legendas = new Legendas(this);
            legendas.Abrir();

            habilidades = new PainelDeHabilidades(this);
            habilidades.Enabled = false;

            statusP1 = new PainelDeStatus(this,p1.Personagem, true);
            statusP2 = new PainelDeStatus(this,p2.Personagem, false);

            p2Panel = new Panel();
            p2Panel.BackgroundImage =Visual.RedimensionarImagem(p2.Personagem.Image,new Size(300,300));
            p2Panel.Dock = DockStyle.None;
            p2Panel.Size = p2Panel.BackgroundImage.Size;
            p2Panel.Anchor = AnchorStyles.None;
            p2Panel.Location = new Point(
               this.ClientSize.Width / 2 - p2Panel.Size.Width / 2,
               this.ClientSize.Height / 2 -p2Panel.Size.Height);

            p1Panel = new Panel();
            p1Panel.BackgroundImage = Visual.RedimensionarImagem(p1.Personagem.Image, new Size(300, 300));
            p1Panel.Dock = DockStyle.None;
            p1Panel.Size = p1Panel.BackgroundImage.Size;
            p1Panel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            p1Panel.Location = new Point(
              Padding.All,
              this.Height-p1Panel.Height-Padding.All);

            Controls.Add(habilidades);
            Controls.Add(statusP1);
            Controls.Add(p1Panel);
            Controls.Add(p2Panel);
            Controls.Add(statusP2);

            Turno();
        }
        public void Abrir(Gerenciador handler){handler.Controls.Add(this); }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            foreach(Control c in Controls)
            {
                c.Invalidate();
            }
        }

        private void Turno()
        {
            Jogador jogador, adversario;
            if (turno)
            {

                turno = false;
                habilidades.Enabled = true;
                legendas.MudarLegenda("Agora é o seu turno");
                legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    jogador = p1.Personagem;
                    adversario = p2.Personagem;

                    EventoDeCombate e = new EventoDeCombate(jogador, adversario,legendas);

                    habilidades.AdicionarEventoNaEcolha(new Action<Habilidade>(delegate (Habilidade h)
                    {
                        e.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            e.AdicionarEventoAoAcabar(new Evento(delegate ()
                            {
                                FinalDoTurno(e);
                            }, 500));
                            h.Usar(e);
                            habilidades.Enabled = false;
                        },500));
                        e.Jogador.AntesDoTurno(e);
                    }));
                },100));
            } else
            {
                turno = true;
                legendas.MudarLegenda("Agora é turno de Lobo");
                legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    turno = true;
                    jogador = p2.Personagem;
                    adversario = p1.Personagem;

                    EventoDeCombate e = new EventoDeCombate(jogador, adversario,legendas);

                    e.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        e.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            FinalDoTurno(e);
                        }, 500));
                        p2.TurnoAutomatico(e);
                    },500));
                    e.Jogador.AntesDoTurno(e);
                }, 100));
            }
        }

        private void FinalDoTurno(EventoDeCombate e)
        {
            e.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                Turno();
                Invalidate();
            }));
            e.Jogador.DepoisDoTurno(e);
        }

        internal class PainelDeStatus : Panel
        {
            internal readonly Jogador jogador;

            internal readonly JanelaDeCombate handler;

            RichTextBox vida = new RichTextBox();

            Panel efeitos = new Panel();

            internal readonly bool Turno;

            internal PainelDeStatus( JanelaDeCombate handler,Jogador jogador,bool turno)
            {
                this.handler = handler;
                this.jogador = jogador;
                this.Turno = turno;
                BackColor = Visual.backgroundColor1;

                Size = new Size(100, 200);
                Dock = DockStyle.None;
                Padding = new Padding(20);

                vida.Dock = DockStyle.Top;
                vida.Size = new Size(Width - Padding.All, (Height - Padding.All*2)/4);
                vida.ReadOnly = true;
                vida.BorderStyle = BorderStyle.None;
                vida.Enabled = false;
                vida.Multiline = true;

                efeitos.Dock = DockStyle.Bottom;
                efeitos.Size = new Size(200, ((Height - Padding.All * 2) / 4)*3);

                Controls.Add(efeitos);
                Controls.Add(vida);

                if (turno)
                {
                    Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    Location = new Point(0, 0);
                }
                else
                {
                    Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                    Location = new Point(handler.Width - Width, 0);
                }

                UpdateConfigs();
            }
            private void UpdateConfigs()
            {
                vida.Text = "&0" + jogador.Nome;
                vida.AppendText("\n &0Vida: &4" + jogador.Vida);
                Visual.FormatRichTextBox(vida);

                efeitos.Controls.Clear();
                foreach(Efeito f in jogador.Efeitos())
                {
                    BotaoDeEfeitos b = new BotaoDeEfeitos(this, f);
                    efeitos.Controls.Add(b);
                }
            }
            protected override void OnInvalidated(InvalidateEventArgs e)
            {
                UpdateConfigs();
                base.OnInvalidated(e);
            }
            internal class BotaoDeEfeitos : Button
            {
                internal readonly PainelDeStatus handler;
                internal Panel popupPanel;
                internal readonly Efeito efeito;
                internal BotaoDeEfeitos(PainelDeStatus handler, Efeito efeito)
                {
                    this.handler = handler;this.efeito = efeito;
                    BackgroundImage = Visual.RedimensionarImagem(efeito.origem.Image, new Size(25,25));
                    Size = BackgroundImage.Size;
                    SetStyle(ControlStyles.Selectable, false);
                    FlatStyle = FlatStyle.Flat;
                    FlatAppearance.BorderColor = Visual.menuColor4;
                    FlatAppearance.BorderSize = 2;
                    BackColor = Color.Red;
                    MouseDown += BotaoDeEfeitos_MouseDown;
                    MouseUp += BotaoDeEfeitos_MouseUp;
                }

                private void BotaoDeEfeitos_MouseUp(object sender, MouseEventArgs e)
                {
                    if (popupPanel != null)
                    {
                        handler.handler.Controls.Remove(popupPanel);
                        popupPanel = null;
                    }
                }

                private void BotaoDeEfeitos_MouseDown(object sender, MouseEventArgs e)
                {
                    if (popupPanel == null)
                    {
                        popupPanel = new Panel();
                        RichTextBox rtb = new RichTextBox();
                        popupPanel.Size = new Size(150, 80);
                        popupPanel.Padding = new Padding(2);
                        popupPanel.BackColor = Visual.menuColor3;

                        rtb.ReadOnly = true;
                        rtb.BorderStyle = BorderStyle.None;
                        rtb.BackColor = Visual.backgroundColor1;
                        rtb.Multiline = true;
                        rtb.Dock = DockStyle.Fill;

                        Point mouse = handler.handler.PointToClient(Cursor.Position);
                        if (!handler.Turno)
                        {
                            mouse.X -= popupPanel.Width;
                        }
                        popupPanel.Location = mouse;

                        rtb.Text = "&0  "+efeito.Nome+"\n"+efeito.Descricao+"\n"+"&9Duração restante: &7"+efeito.TurnosRestantes;

                        Visual.FormatRichTextBox(rtb);

                        popupPanel.Controls.Add(rtb);
                        handler.handler.Controls.Add(popupPanel);
                        popupPanel.BringToFront();
                    }
                }
            }
        }

        internal class PainelDeHabilidades : Panel
        {
            private readonly JanelaDeCombate handler;

            Action<Habilidade> eventoNaEscolha;
            internal PainelDeHabilidades(JanelaDeCombate handler)
            {
                this.handler = handler;
                BackColor = Visual.backgroundColor1 ;
                Dock = DockStyle.Bottom;
                Size = new Size(100, 100);

                Padding = new Padding(20);

                foreach (Habilidade h in handler.p1.Personagem.Habilidades())
                {
                    BotaoDeHablidade b = new BotaoDeHablidade(h,this);
                    Controls.Add(b);
                }
                Paint += PainelDeHabilidades_Paint;
            }

            private void PainelDeHabilidades_Paint(object sender, PaintEventArgs e)
            {
                Graphics gfx = e.Graphics;
                Brush p = new SolidBrush(Visual.menuColor2);
                gfx.FillRectangle(p, 0, 0, Width, 5);
                gfx.FillRectangle(p, 0, Height - 5, Width, Height);
            }

            internal void NoCliqueDoBotao(BotaoDeHablidade b)
            {
                if (eventoNaEscolha != null)
                {
                    eventoNaEscolha(b.habilidade);
                }
            }

            internal void AdicionarEventoNaEcolha(Action<Habilidade> a)
            {
                eventoNaEscolha = a;
            }

            internal class BotaoDeHablidade : Button
            {
                internal readonly Habilidade habilidade;
                internal PainelDeHabilidades handler;
                internal BotaoDeHablidade(Habilidade h,PainelDeHabilidades handler)
                {
                    this.handler=handler;
                    habilidade = h;
                    Text = h.Name;
                    Dock = DockStyle.Left;
                    Size = new Size(Width * 2, Height);
                    SetStyle(ControlStyles.Selectable, false);
                    TabStop = false;
                    Click += BotaoDeHablidade_Click;

                }

                private void BotaoDeHablidade_Click(object sender, EventArgs e)
                {
                    handler.NoCliqueDoBotao(this);
                }
            }
        }
    }
}
