using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Items;
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
    public class Lobo : Jogador
    {
        public Lobo() : base("Lobo", 12, 32, 5,new Murro("Mordida",7,14), Assets.lobo_normal)
        {
            itensDeAtaque.Add(new Murro("Cabeçada", 3, 5));
            itensDeAtaque.Add(new Murro("Cortes Profundos", 4, 8));
        }

        public override void AntesDoTurno(EventoDeCombate e)
        {
            foreach(Efeito f in Efeitos())
            {
                if (f is Encantado&&e.Adversario==Lianna)
                {
                    ((Lianna)e.Adversario).loboAliado = true;
                    e.Vencedor = e.Adversario;
                    e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate()
                    {
                        e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
                        {
                            base.AntesDoTurno(e);
                        }, 1000));
                        e.Legendas.MudarLegenda(e.Adversario.Nome + " decide cuidar dele");
                    }, 1000));
                    e.Legendas.MudarLegenda(Nome + " está adormecendo tranquilamente... ");
                    return;
                }
            }
            base.AntesDoTurno(e);
        }
    }
}