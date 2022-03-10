using AliançaPrimordial.Items;
using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Invocadores;
using AliançaPrimordial.main.src.Items;
using AliançaPrimordial.main.src.Itens.ItensDefensivos;
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

namespace AliançaPrimordial.main.src.Personagens
{
    public class Lianna : Protagonistas
    {
        Flauta flauta = Item.Flauta;
        CapuzDeLadino capuzDeLadino = Item.CapuzDeLadino;
        ErvaDeCura ervaDeCura = Item.ErvaDeCura;
        ArvoreDeAllihanna arvoreDeAllihanna = Item.ArvoreDeAllihanna;

        public bool loboAliado = false;

        public Lianna() : base("Lianna", 23,23, 4, Item.CajadoDeMadeira, Assets.lianna_normal)
        {
            itensDefensivos.Add(capuzDeLadino);
            itensDefensivos.Add(arvoreDeAllihanna);

            itensAtivos.Add(flauta);
            itensAtivos.Add(ervaDeCura);
        }

        public override string MostrarHistoria()
        {
            return "Lianna nasceu em um vilarejo de dríades que foi dizimado por Orcs, sua mãe conseguiu"+
            "salvá - la enquanto segurava os bárbaros e a garota fugia para a floresta. Ela cresceu sem"+
             "outras pessoas ao seu redor, suas únicas companhias eram seu cavalo Bolinhas e a"+
            "natureza.Sua motivação é a luta pela liberdade da floresta e a busca por sua mãe.";
        }

        public override void Introducao(Gerenciador handler)
        {
            Legendas legenda = new Legendas(handler);
            legenda.Abrir();
            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                legenda.Fechar();

                Humano h = new Humano(Lianna);
                Bot b = new Bot(Lobo);

                JanelaDeCombate jdc = new JanelaDeCombate(h,b,handler);

                AdicionarEventoNaJanelaDeCombate(jdc);

                handler.IniciarCombate(jdc);
            }, 2000));
            legenda.MudarLegenda("Lianna escutou boatos sobre uma relíquia que revela a verdade " +
                "sobre tudo o que seu usuário desejar, a mulher se sentiu tentada a descobrir sobre seu povo e " +
                "saber se existe ainda outra driade viva");
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
                        jdc.legendas.ConcatenarLegenda(Nome + " é a vencedora desse combate");
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
                                            }, 2000));
                                            jdc.legendas.ConcatenarLegenda(".");
                                        }, 1000));
                                        jdc.legendas.ConcatenarLegenda(".");
                                    }, 1000));
                                    jdc.legendas.ConcatenarLegenda(".");
                                }, 1000));
                                jdc.legendas.ConcatenarLegenda(" Mãe");
                            }, 1000));
                            jdc.legendas.MudarLegenda("Me perdôe...");
                        }, 1000));
                        jdc.legendas.MudarLegenda("Não fui capaz...");
                    }, 2000));
                    jdc.legendas.MudarLegenda(Nome+" está desmaiando...");
                }

            }, 1000));
        }

        private void IniciarNovoCombate(JanelaDeCombate jdc)
        {
            Jogador adversario;
            Legendas legenda = jdc.legendas;
            if (jdc.aoAcabarCombate.Adversario is Lobo)
            {
                adversario = Jogador.Orc;
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
                            }, 3500));
                            legenda.ConcatenarLegenda($", um {adversario.Nome}. Segurava um enorme {adversario.ItemDeAtaque().Nome} estava a sua frente");
                        }, 2500));
                        legenda.ConcatenarLegenda(", uma figura esverdeada surgia e ela estava cara a cara com seu maior medo e inimigo");
                    }, 2500));
                    legenda.ConcatenarLegenda(" e se assusta com uma enorme sombra saindo de trás de uma grande rocha");
                },2500));
                legenda.MudarLegenda($"Após conseguir enfrentar o animal, {Nome} segue o caminho ainda um pouco ferida da batalha");
            }
            else if (jdc.aoAcabarCombate.Adversario is Orc)
            {
                adversario = Jogador.Kry;
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
                                        legenda.ConcatenarLegenda(", após esse gesto, ele sacava seu mangual e seguia com uma expressão serena");

                                    }, 1500));
                                    legenda.ConcatenarLegenda(", ele abria seus braços e sua expressão facial mostrava pureza");

                                }, 2000));
                                legenda.ConcatenarLegenda(", o homem tartaruga se revela enquanto coloca um colar em seu pescoço");
                            }, 2500));
                            legenda.ConcatenarLegenda($" porém ao acordar, {Nome} vê uma grande figura redonda de costas");
                        }, 2000));
                        legenda.MudarLegenda("Ela encontra uma caverna, e passa o final da tarde em repouso por lá");
                    }, 2500));
                    legenda.ConcatenarLegenda(", e vai atrás de um lugar para descansar");
                }, 1000));
                legenda.MudarLegenda($"{Nome} está muito cansada");
            }
            else if (jdc.aoAcabarCombate.Adversario is Kry)
            {
                Mensageiro.Print("Jogo terminado com " + Nome);
                Program.Start(GerenciadorDeJanela.formPrincipal);
            }
        }

        public override void PoderEspecial(JanelaDeCombate janela, EventoDeCombate e)
        {
            Legendas l = e.Legendas;
            e.Adversario.AdicionarEfeito(new EnraizamentoDeAllihanna());
            l.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                 base.PoderEspecial(janela, e);
            }, 2000));
            l.MudarLegenda(Nome+" se conecta com sua Deusa e assim conjura sua magia, " +
                "galhos e ramos saem da terra imobilizando seu alvo, assim deixando - o vulnerável e debilitado.");
        }

        public override void AntesDoTurno(EventoDeCombate e)
        {
            if (loboAliado)
            {
                int rnd = Dado.UmDTantos(5);
                if (rnd > 1)
                {
                    string l = e.Legendas.Texto;
                    int dano = Dado.UmDTantos(7);
                    e.Legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        e.Legendas.AdicionarEventoAoAcabar(new Evento(delegate ()
                        {
                            e.Legendas.MudarLegenda(l);
                            base.AntesDoTurno(e);
                        }, 500));
                        e.Adversario.Vida -= dano;
                        e.Legendas.ConcatenarLegenda(", ataca o adversário, causando " + dano + " de dano");
                    }, 500));
                    e.Legendas.MudarLegenda("Lobo decide ajudar " + Nome);
                } else
                {
                    base.AntesDoTurno(e);
                }
            }
            else
            {
                base.AntesDoTurno(e);
            }
        }
    }
}
