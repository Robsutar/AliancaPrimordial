using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Habilidades
{
    public class Ataque : Habilidade
    {
        public Ataque() : base("Ataque")
        {
        }

        public override int FatorFavoravel(EventoDeCombate jogador)
        {
            return 10;
        }

        protected override void NoUso(EventoDeCombate e)
        {
            int dano = e.Jogador.RodarAtaque(e);

            e.Legendas.MudarLegenda(Legenda(e));
            e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
            {
                if (dano > 0)
                {
                    e.Legendas.ConcatenarLegenda(" causando " + dano + " de dano");
                    e.Adversario.Vida -= dano;
                } else
                {
                    e.Legendas.ConcatenarLegenda(" mas não causou nenhum dano");
                }
                e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
                {
                    FinalDoUso(e);
                }, 1000));
            }, 200));
        }

        public override string Legenda(EventoDeCombate e)
        {
            return e.Jogador.Nome+" atacou "+e.Adversario.Nome;
        }

        public override void Usar(EventoDeCombate e)
        {
            NoUso(e);
        }
    }
}
