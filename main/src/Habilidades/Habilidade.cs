using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Habilidades
{
    public abstract class Habilidade
    {
        public readonly string Name;
        public Habilidade(string name)
        {
            this.Name = name;
        }

        public static Ataque Ataque;
        public static UsarItem UsarItem;
        public static MudarDeArma MudarDeArma;

        protected abstract void NoUso(EventoDeCombate e);

        public virtual void Usar(EventoDeCombate e)
        {
            NoUso(e);

            e.Legendas.MudarLegenda(Legenda(e));
            e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
            {
                FinalDoUso(e);
            }, 1000));
        }
        protected virtual void FinalDoUso(EventoDeCombate e)
        {
            e.Terminar(e);
        }
        public virtual string Legenda(EventoDeCombate e)
        {
            return e.Jogador.Nome+" usou a habilidade "+Name;
        }
        public abstract int FatorFavoravel(EventoDeCombate e);
    }
}
