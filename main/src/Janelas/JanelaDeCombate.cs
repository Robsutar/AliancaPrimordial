using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Invocadores;
using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.main.src.Personagens;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public bool turno = true;

        public readonly Legendas legendas;

        PainelDeHabilidades habilidades;

        PainelDeStatus statusP1, statusP2;

        PictureBox p1Panel,p2Panel;

        private Evento aoAcabar;
        public EventoDeCombate aoAcabarCombate;
        public Gerenciador gerenciador;

        public JanelaDeCombate(Humano p1, Bot p2,Gerenciador handler)
        {
            this.gerenciador = handler;
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

            p2Panel = new PictureBox();
            p2Panel.BackgroundImage =Visual.RedimensionarImagem(p2.Personagem.Image,new Size(300,300));
            p2Panel.Dock = DockStyle.None;
            p2Panel.Size = p2Panel.BackgroundImage.Size;
            p2Panel.Anchor = AnchorStyles.None;
            p2Panel.Location = new Point(
               this.ClientSize.Width / 2 - p2Panel.Size.Width / 2,
               this.ClientSize.Height / 2 -p2Panel.Size.Height);

            p1Panel = new PictureBox();
            p1Panel.BackgroundImage = Visual.RedimensionarImagem(p1.Personagem.Image, new Size(300, 300));
            p1Panel.Dock = DockStyle.None;
            p1Panel.Size = p1Panel.BackgroundImage.Size;
            p1Panel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            p1Panel.Location = new Point(
              Padding.All,
              this.Height-p1Panel.Height-Padding.All);

            p1.Personagem.Efeitos().Clear();
            p2.Personagem.Efeitos().Clear();

            Controls.Add(habilidades);
            Controls.Add(p1Panel);
            Controls.Add(p2Panel);
            Controls.Add(statusP1);
            Controls.Add(statusP2);

            Invalidate();
        }
        public void Abrir() { gerenciador.Controls.Add(this); Turno(); }
        public void Fechar() { gerenciador.Controls.Remove(this); }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            foreach(Control c in Controls)
            {
                c.Invalidate();
            }
        }

        public void AdicionarEventoAoAcabar(Evento e) { this.aoAcabar = e; }

        private void Turno()
        {
            Jogador jogador, adversario;
            if (turno)
            {
                p1Panel.BackgroundImage = Visual.RedimensionarImagem(p1.Personagem.Image, new Size(300, 300));
                p2Panel.BackgroundImage = Visual.ParaEscalaCinza(Visual.RedimensionarImagem(p2.Personagem.Image, new Size(300, 300)));
                turno = false;
                legendas.MudarLegenda("Agora é o seu turno");
                legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    jogador = p1.Personagem;
                    adversario = p2.Personagem;

                    EventoDeCombate e = new EventoDeCombate(jogador, adversario,legendas);
                    e.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        if (!e.TemVencedor())
                        {
                            habilidades.Enabled = true;
                            habilidades.AdicionarEventoNaEcolha(new Evento(delegate ()
                            {
                                FinalDoTurno(e);
                            }), e);
                        } else
                        {
                            FinalDoTurno(e);
                            return;
                        }
                        Invalidate();
                    },500));
                    e.Jogador.AntesDoTurno(e);
                },100));
            } else
            {
                p1Panel.BackgroundImage = Visual.ParaEscalaCinza(Visual.RedimensionarImagem(p1.Personagem.Image, new Size(300, 300)));
                p2Panel.BackgroundImage = Visual.RedimensionarImagem(p2.Personagem.Image, new Size(300, 300));
                turno = true;
                legendas.MudarLegenda("Agora é turno de " + p2.Personagem.Nome) ;
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
                        if (!e.TemVencedor())
                        {
                            p2.TurnoAutomatico(e);
                        } else
                        {
                            FinalDoTurno(e);
                            return;
                        }
                        Invalidate();
                    },500));
                    e.Jogador.AntesDoTurno(e);
                }, 100));
            }
        }

        private void FinalDoTurno(EventoDeCombate e)
        {
            e.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                TurnoAoAcabar(e);
            }));
            e.Jogador.DepoisDoTurno(e);
        }

        private void TurnoAoAcabar(EventoDeCombate e)
        {
            if (e.TemVencedor())
            {
                if (e.Vencedor == e.Jogador) {
                    e = new EventoDeCombate(e.Vencedor,e.Adversario, e.Legendas);
                    e.Vencedor = e.Jogador;
                } else
                {
                    e = new EventoDeCombate(e.Vencedor,e.Jogador, e.Legendas);
                    e.Vencedor = e.Jogador;
                }
                Mensageiro.Print("Combate vencido por: " + e.Vencedor.Nome + " combate: " + e.Jogador.Nome + " <> " + e.Adversario.Nome);
                if (e.Vencedor == p1.Personagem)
                {
                    p1Panel.BackgroundImage = Visual.RedimensionarImagem(p1.Personagem.Image, new Size(300, 300));
                    p2Panel.BackgroundImage = Visual.ParaEscalaCinza(Visual.RedimensionarImagem(p2.Personagem.Image, new Size(300, 300)));
                } else
                {
                    p1Panel.BackgroundImage = Visual.ParaEscalaCinza(Visual.RedimensionarImagem(p1.Personagem.Image, new Size(300, 300)));
                    p2Panel.BackgroundImage = Visual.RedimensionarImagem(p2.Personagem.Image, new Size(300, 300));
                }
                Mensageiro.Print("Janela de combate com vencedor");
                aoAcabarCombate = e;
                if (aoAcabar != null)
                {
                    aoAcabar.Invocar();
                }
                else
                {
                    Mensageiro.Print("JANELA DE COMBATE FOI TERMINADA SEM EVENTO AO ACABAR!!");
                }
            }
            else
            {
                Turno();
            }
            Invalidate();
        }

        internal class PainelDeStatus : Panel
        {
            internal readonly Jogador jogador;

            internal readonly JanelaDeCombate handler;

            RichTextBox vida = new RichTextBox();

            FlowLayoutPanel efeitos = new FlowLayoutPanel();

            internal readonly bool Turno;

            internal PainelDeStatus( JanelaDeCombate handler,Jogador jogador,bool turno)
            {
                this.handler = handler;
                this.jogador = jogador;
                this.Turno = turno;
                DoubleBuffered = true;

                Size = new Size(100, 600);
                Dock = DockStyle.None;
                Padding = new Padding(20);
                BackColor = Visual.backgroundColor1;

                vida.Dock = DockStyle.Top;
                vida.Size = new Size(Width - Padding.All, 40);
                vida.ReadOnly = true;
                vida.BorderStyle = BorderStyle.None;
                vida.Enabled = false;
                vida.Multiline = true;

                efeitos.Dock = DockStyle.Fill;
                efeitos.Size = new Size(200, 0);
                efeitos.BackColor = Visual.backgroundColor1;

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
                Size size = efeitos.Size;
                size.Height = 0;
                foreach(Efeito f in jogador.Efeitos())
                {
                    BotaoDeEfeitos b = new BotaoDeEfeitos(this, f);
                    b.FlatAppearance.BorderColor = Color.Orange;
                    size.Height += b.Height+efeitos.Padding.Bottom;
                    efeitos.Controls.Add(b);
                }
                efeitos.Controls.Add(new Label());
                foreach (Item i in jogador.ItensDefensivos())
                {
                    BotaoDeItem b = new BotaoDeItem(this, i);
                    size.Height += b.Height + efeitos.Padding.Bottom;
                    efeitos.Controls.Add(b);
                }
                efeitos.Controls.Add(new Label());
                foreach (Item i in jogador.ItensAtivos())
                {
                    BotaoDeItem b = new BotaoDeItem(this, i);
                    b.FlatAppearance.BorderColor = Color.Green;
                    size.Height += b.Height + efeitos.Padding.Bottom;
                    efeitos.Controls.Add(b);
                }
                efeitos.Controls.Add(new Label());
                BotaoDeItem bAtaque = new BotaoDeItem(this, jogador.ItemDeAtaque());
                bAtaque.FlatAppearance.BorderColor = Color.Red;
                size.Height += bAtaque.Height + efeitos.Padding.Bottom;
                efeitos.Controls.Add(bAtaque);

                size.Height += 50;
                efeitos.Size = size;
            }
            protected override void OnInvalidated(InvalidateEventArgs e)
            {
                UpdateConfigs();
                base.OnInvalidated(e);
            }
            internal class BotaoDeEfeitos : BotaoPequeno
            {
                internal readonly Efeito efeito;
                internal BotaoDeEfeitos(PainelDeStatus handler, Efeito efeito):base(handler,efeito.origem.Image)
                {
                    this.efeito = efeito;
                }

                protected override string Descricao()
                {
                    string s = "&0  " + efeito.Nome + "\n" + efeito.Descricao+ "\n" + "&9Duração restante: &7";
                    if (efeito.TurnosRestantes < 100)
                    {
                        s += efeito.TurnosRestantes;
                    } else {
                        s += "Até o fim do combate";
                    }
                    return s;
                }
            }

            internal class BotaoDeItem : BotaoPequeno
            {
                internal readonly Item item;
                internal BotaoDeItem(PainelDeStatus handler, Item item) : base(handler, item.Image)
                {
                    this.item = item;
                }

                protected override string Descricao()
                {
                    return "&0  " + item.Nome + "\n" + item.Descricao ;
                }
            }

            internal abstract class BotaoPequeno : Button
            {
                internal readonly PainelDeStatus handler;
                internal Panel popupPanel;
                internal readonly Bitmap image;
                internal BotaoPequeno(PainelDeStatus handler, Bitmap image)
                {
                    this.handler = handler; this.image = image;
                    BackgroundImage = Visual.RedimensionarImagem(image, new Size(25, 25));
                    Size = BackgroundImage.Size;
                    Width += 4;Height += 4;
                    SetStyle(ControlStyles.Selectable, false);
                    FlatStyle = FlatStyle.Flat;
                    FlatAppearance.BorderColor = Color.Blue;
                    FlatAppearance.BorderSize = 2;
                    MouseDown += BotaoDeEfeitos_MouseDown;
                    MouseUp += BotaoDeEfeitos_MouseUp;
                }

                protected abstract string Descricao();

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

                        rtb.Text = Descricao();

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

            Evento naEscolha;
            EventoDeCombate combate;
            internal PainelDeHabilidades(JanelaDeCombate handler)
            {
                this.handler = handler;
                BackColor = Visual.backgroundColor1;
                Dock = DockStyle.Bottom;
                Size = new Size(100, 100);
                DoubleBuffered = true;

                Padding = new Padding(20);

                List<BotaoExemplar> buttons = new List<BotaoExemplar>();

                BotaoExemplar atk = new BotaoExemplar("Atacar");
                buttons.Add(atk);

                atk.Click += delegate (object sender, EventArgs e)
                {
                    if (combate != null) {
                        combate.Jogador.Ataque.Usar(combate);
                        combate.AdicionarEventoAoAcabar(new Evento(delegate ()
                       {
                           NaEscolha();
                       }));
                        this.Enabled = false;
                    }
                };

                BotaoExemplar poderEspecial = new BotaoExemplar("Poder Especial");
                buttons.Add(poderEspecial);

                poderEspecial.Click += delegate (object sender, EventArgs e)
                {
                    if (combate != null)
                    {
                        poderEspecial.Enabled = false;
                        combate.Jogador.PoderEspecial(handler, combate);
                        combate.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            NaEscolha();
                        }));
                        this.Enabled = false;
                    }
                };

                BotaoExemplar usarItem = new BotaoExemplar("Usar Item");
                buttons.Add(usarItem);

                usarItem.Click += delegate (object sender, EventArgs e)
                {
                    if (combate != null)
                    {
                        List<ItemAtivo> items = new List<ItemAtivo>(combate.Jogador.ItensAtivos());
                        if (items.Count > 0)
                        {
                            PainelDeItensAtivos pi = new PainelDeItensAtivos(items);

                            Point mouse = handler.PointToClient(Cursor.Position);
                            mouse.Y -= pi.Height;
                            pi.Location = mouse;
                            pi.AdicionarEventoAoClicar(delegate (ItemAtivo i)
                            {
                                handler.Controls.Remove(pi);
                                combate.AdicionarEventoAoAcabar(new Evento(delegate ()
                                {
                                    NaEscolha();
                                }));
                                combate.Jogador.UsarItem.Usar(combate, i);
                            });
                            handler.Controls.Add(pi);
                            pi.BringToFront();
                            this.Enabled = false;
                        }
                    }
                };

                BotaoExemplar mudarArma = new BotaoExemplar("Mudar de Arma");
                buttons.Add(mudarArma);

                mudarArma.Click += delegate (object sender, EventArgs e)
                {
                    if (combate != null)
                    {
                        List<ItemDeAtaque> items = new List<ItemDeAtaque>(combate.Jogador.ItensDeAtaque());
                        PainelDeItensDeAtaque pi = new PainelDeItensDeAtaque(items);

                        Point mouse = handler.PointToClient(Cursor.Position);
                        mouse.Y -= pi.Height;
                        pi.Location = mouse;
                        pi.AdicionarEventoAoClicar(delegate (ItemDeAtaque i)
                        {
                            handler.Controls.Remove(pi);
                            if (i != combate.Jogador.ItemDeAtaque())
                            {
                                combate.AdicionarEventoAoAcabar(new Evento(delegate ()
                                {
                                    NaEscolha();
                                }));
                                combate.Jogador.MudarDeArma.Usar(combate, i);
                            } else { this.Enabled = true; }
                        });
                        handler.Controls.Add(pi);
                        pi.BringToFront();
                        this.Enabled = false;
                    }
                };

                Paint += delegate (object sender, PaintEventArgs e)
                {
                    Graphics gfx = e.Graphics;
                    Brush p = new SolidBrush(Visual.menuColor2);
                    gfx.FillRectangle(p, 0, 0, Width, 5);
                    gfx.FillRectangle(p, 0, Height - 5, Width, Height);
                };

                foreach(Button b in buttons){
                    b.Dock = DockStyle.Left;
                    b.Size = Size;
                    Controls.Add(b);
                }
            }

            internal void NaEscolha()
            {
                if (naEscolha != null)
                {
                    naEscolha.Invocar();
                } else
                {
                    Mensageiro.Print("Habilidade escolhida sem evento!");
                }
            }
            internal void AdicionarEventoNaEcolha(Evento e,EventoDeCombate c)
            {
                this.naEscolha = e;this.combate = c;
            }
            internal class BotaoExemplar : Button
            {
                internal BotaoExemplar(string text)
                {
                    this.Text = text;
                    SetStyle(ControlStyles.Selectable, false);
                }
            }
        }
    }
}
