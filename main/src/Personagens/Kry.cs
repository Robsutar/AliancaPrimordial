using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Invocadores;
using AliançaPrimordial.main.src.Items;
using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.Personagens
{
    public class Kry : Protagonistas
    {
        public Kry() : base("Kry", 36, 23,7,Item.Mangual, Assets.kry_normal)
        {
            itensDefensivos.Add(Item.CotaDeMalha);
            itensDefensivos.Add(Item.ConselhosDeTannaToh);
            itensAtivos.Add(Item.PocaoDeCura);
            itensAtivos.Add(Item.FrascoDeAcido);
        }

        public override string MostrarHistoria()
        {
            return "Kry sempre foi isolado da sociedade por ser de uma raça diferente, ele é uma espécie de"+
            " tartaruga e poderia ser facilmente um alvo caso fosse caçado. Seus pais foram"+
            " sequestrados e então ele passou a ser criado por um homem de um culto, seu nome era"+
            " Sr Sven, passariam a ter uma relação de pai e filho. O homem tartaruga teria abandonado"+
            " o templo em que morava para descobrir a razão de sua existência, afinal, como sua"+
            " Deusa sempre está em busca da verdade e sabedoria";
        }
        public override void Introducao(Gerenciador handler)
        {
            Legendas legenda = new Legendas(handler);
            legenda.Abrir();
            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    Padding padding = new Padding(50);

                    Panel panel = new Panel();
                    panel.Size = new Size(400, 100);
                    panel.BackColor = Visual.backgroundColor1;
                    panel.Anchor = AnchorStyles.None;
                    panel.Location = new Point(
                        handler.ClientSize.Width / 2 - panel.Size.Width / 2,
                        handler.ClientSize.Height / 2 - panel.Size.Height / 2 + legenda.Height / 2 + padding.All + padding.All / 2);

                    Button nadar = new Button();
                    nadar.Text = "Nadar para fora";
                    nadar.Dock = DockStyle.Left;
                    nadar.Size = new Size(panel.Width / 2, panel.Height);

                    nadar.Click += delegate (object sender, EventArgs e)
                    {
                        panel.Enabled = false;
                        Mensageiro.Print("Escolha de " + Kry + ": nadar");
                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                            {
                                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                {
                                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                    {
                                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                        {
                                            legenda.Fechar();

                                            Humano h = new Humano(Kry);
                                            Bot b = new Bot(BandidoA);

                                            JanelaDeCombate jdc = new JanelaDeCombate(h, b, handler);
                                            jdc.turno = false;

                                            AdicionarEventoNaJanelaDeCombate(jdc);

                                            handler.IniciarCombate(jdc);
                                        }, 1000));
                                        legenda.ConcatenarLegenda(" ele dá de cara com um grupo de bandidos, que pareciam interessados " +
                                            "nos pertences de " + Nome);
                                    }, 700));
                                    legenda.MudarLegenda("Entretanto...");
                                    Kry.itensDeAtaque.Add(Item.Tridente);
                                }, 2000));
                                legenda.MudarLegenda(Nome + " está cansado, mas encontra um brilhante " + Item.Tridente.Nome +
                                    " que pode ajudar em combate");
                            }, 1000));
                            legenda.ConcatenarLegenda(" E com muito esforço, acaba conseguindo");
                        }, 1500));
                        legenda.MudarLegenda(Nome + " tenta nadar...");
                    };

                    Button agarrar = new Button();
                    agarrar.Text = "Agarrar nas vinhas";
                    agarrar.Dock = DockStyle.Right;
                    agarrar.Size = new Size(panel.Width / 2, panel.Height);


                    agarrar.Click += delegate (object sender, EventArgs e)
                    {
                        panel.Enabled = false;
                        Mensageiro.Print("Escolha de " + Kry + ": nadar");
                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                            {
                                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                {
                                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                    {
                                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                        {
                                            legenda.Fechar();

                                            Humano h = new Humano(Kry);
                                            Bot b = new Bot(BandidoA);

                                            JanelaDeCombate jdc = new JanelaDeCombate(h, b, handler);
                                            jdc.turno = false;

                                            Kry.AdicionarEfeito(new Envenenamento());

                                            AdicionarEventoNaJanelaDeCombate(jdc);

                                            handler.IniciarCombate(jdc);
                                        }, 1000));
                                        legenda.MudarLegenda("Entretando... ele dá de cara com um grupo de bandidos, que pareciam interessados " +
                                            "nos pertences de " + Nome);
                                    }, 2000));
                                    legenda.MudarLegenda("Ao seguir seu caminho acaba encotrando um " + Item.Broquel.Nome + ", que pode ajudar na defesa");
                                    Kry.itensDefensivos.Add(Item.Broquel);
                                }, 2000));
                                legenda.MudarLegenda("Ele está envenenado, mas consegue sair do poço");
                            }, 2000));
                            legenda.ConcatenarLegenda(", e segue escalando... Mas acaba tocando em uma planta venenosa ");
                        }, 1500));
                        legenda.MudarLegenda(Nome + " tenta agarrar em vinhas próximas");
                    };

                    panel.Controls.Add(nadar);
                    panel.Controls.Add(agarrar);

                    Label info = new Label();
                    info.Text = Nome + " caiu em poço lodoso e denso que o puxava cada vez mais para dentro\no que deseja fazer?";
                    info.TextAlign = ContentAlignment.TopCenter;
                    info.Size = new Size(panel.Width, panel.Height / 2);
                    info.Anchor = AnchorStyles.None;

                    info.Location = new Point(
                        handler.ClientSize.Width / 2 - info.Size.Width / 2,
                        handler.ClientSize.Height / 2 - info.Size.Height / 2 - panel.Size.Height / 2 - padding.All);

                    handler.Controls.Add(info);
                    handler.Controls.Add(panel);
                }, 1000));
                legenda.MudarLegenda(Nome + " Caminhava por ali um pouco desatento com o chão e acabaria caindo em um " +
                    "poço lodoso e denso que o puxava cada vez mais para dentro");
            }, 2000));
            legenda.MudarLegenda("Kry foi criado em um templo que cultuava a deusa do conhecimento Tanna-Toh, " +
                "isso criou nele uma fissura e agonia em busca de sabedoria, teria descoberto em algum velho pergaminho " +
                "sobre um tal artefato que foi dado de uma antiga divindade para sua amante humana, que revelava tudo " +
                "sobre a existência. O homem então voltaria seus esforços para descobrir a real veracidade do objeto" +
                " e usaria o mesmo em busca de superar até mesmo a deusa que seguia");
        }

        private void AdicionarEventoNaJanelaDeCombate(JanelaDeCombate jdc)
        {
            jdc.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                if (jdc.aoAcabarCombate.Vencedor == this)
                {
                    jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            IniciarNovoCombate(jdc);
                        }, 3000));
                        jdc.legendas.ConcatenarLegenda(Nome + " é o vencedor desse combate");
                    }, 1000));
                    jdc.legendas.MudarLegenda(jdc.aoAcabarCombate.Adversario.Nome + " está desmaiando... ");
                }
                else
                {
                    jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                            {
                                jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                                {
                                    jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                                    {
                                        jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                                        {
                                            jdc.legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                                            {
                                                Program.Start(GerenciadorDeJanela.formPrincipal);
                                            }, 1000));
                                            jdc.legendas.ConcatenarLegenda(" é a verdade? ");
                                        }, 1000));
                                        jdc.legendas.MudarLegenda("O fim");
                                    }, 2000));
                                    jdc.legendas.ConcatenarLegenda(" Tanato");
                                }, 500));
                                jdc.legendas.MudarLegenda("Não consegui superar");
                            }, 2000));
                            jdc.legendas.ConcatenarLegenda("Eu falhei no meu destino...");
                        }, 1000));
                        jdc.legendas.MudarLegenda("Eu... ");
                    }, 1000));
                    jdc.legendas.MudarLegenda(Nome+" está desmaiando...");
                }

            }, 1000));
        }

        private void IniciarNovoCombate(JanelaDeCombate jdc)
        {
            Jogador adversario;
            Legendas legenda = jdc.legendas;
            if (jdc.aoAcabarCombate.Adversario is BandidoA)
            {
                adversario = Jogador.BandidoB;
                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            Humano h = new Humano(this);
                            Bot b = new Bot(adversario);
                            Gerenciador handler = jdc.gerenciador;
                            jdc = new JanelaDeCombate(h, b, jdc.gerenciador);
                            jdc.turno = false;

                            AdicionarEventoNaJanelaDeCombate(jdc);

                            handler.IniciarCombate(jdc);

                        }, 2000));
                        legenda.MudarLegenda(adversario.Nome + " vai para cima de " + Nome);
                    }, 2500));
                    legenda.ConcatenarLegenda(Nome+" vai para cima dos outros");
                }, 2000));
                legenda.MudarLegenda($"Após conseguir enfrentar o primeiro bandido");
            }

            if (jdc.aoAcabarCombate.Adversario is BandidoB)
            {
                adversario = Jogador.BandidoC;
                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            Humano h = new Humano(this);
                            Bot b = new Bot(adversario);
                            Gerenciador handler = jdc.gerenciador;
                            jdc = new JanelaDeCombate(h, b, jdc.gerenciador);
                            jdc.turno = false;

                            AdicionarEventoNaJanelaDeCombate(jdc);

                            handler.IniciarCombate(jdc);

                        }, 2000));
                        legenda.MudarLegenda(adversario.Nome + " vai para cima de " + Nome);
                    }, 2500));
                    legenda.ConcatenarLegenda("  aparentemente o líder");
                }, 2000));
                legenda.MudarLegenda($"{Nome} desmaiou dois bandidos, mas ainda resta mais um");
            }

            else if (jdc.aoAcabarCombate.Adversario is BandidoC)
            {
                adversario = Jogador.Lianna;
                Jogador.Lianna.loboAliado = true;
                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                            {
                                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                {
                                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                    {
                                        legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                        {
                                            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                                            {
                                                Humano h = new Humano(this);
                                                Bot b = new Bot(adversario);
                                                Gerenciador handler = jdc.gerenciador;
                                                jdc = new JanelaDeCombate(h, b, jdc.gerenciador);
                                                jdc.turno = false;

                                                AdicionarEventoNaJanelaDeCombate(jdc);

                                                handler.IniciarCombate(jdc);

                                            }, 2000));
                                            legenda.MudarLegenda(adversario.Nome + " vai para cima de " + Nome);

                                        }, 3000));
                                        legenda.ConcatenarLegenda(", assim o combate se inicia");

                                    }, 1500));
                                    legenda.MudarLegenda("Uma mulher de cabelos verdes, com um lobo a sua frente o encarava com uma feição de nojo");

                                }, 2000));
                                legenda.ConcatenarLegenda(" trancando-a completamente,");
                            }, 2500));
                            legenda.ConcatenarLegenda(", vinhas, raízes, plantas, galhos começavam a se espalhar rapidamente" +
                                " pelo espaço e indo em direção até a porta");
                        }, 2000));
                        legenda.ConcatenarLegenda("o, ele adentra a caverna e percebe que algo está errado");
                    }, 2500));
                    legenda.MudarLegenda("Tanna-Toh guia o homem até o local do tesouro,");
                }, 1000));
                legenda.MudarLegenda($"{Nome} se estabiliza, e continua seu caminho");
            }

            else if (jdc.aoAcabarCombate.Adversario is Lianna)
            {
                Mensageiro.Print("Jogo terminado com " + Nome);
                Program.Start(GerenciadorDeJanela.formPrincipal);
            }
        }

        public override void PoderEspecial(JanelaDeCombate janela, EventoDeCombate e)
        {
            Legendas l = e.Legendas;
            int rnd = new Random().Next(2);
            string str = Nome+" se comunica com a Deusa do Conhecimento e recebe " +
            "ajuda da mesma, como consequência, se sente motivado conseguindo temporariamente " +
            "o efeito: ";
            if (rnd == 0)
            {
                e.Jogador.AdicionarEfeito(new Vontade());
                str += "Vontade";
            } else if (rnd == 1)
            {
                e.Jogador.AdicionarEfeito(new Resiliencia());
                str += "Resiliência";
            }
            else if (rnd == 2)
            {
                e.Jogador.AdicionarEfeito(new Inspiracao());
                str += "Ispiração";
            }
             l.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                base.PoderEspecial(janela, e);
            }, 2000));
            l.MudarLegenda(str);
        }
    }
}
