using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.main.src.NoJogo;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaPrimordial.Motor
{
    public class EventoDeCombate
    {
        public readonly Jogador Jogador, Adversario;
        public readonly Legendas Legendas;

        private Evento eventoAoAcabar;
        public EventoDeCombate(Jogador jogador,Jogador adversario,Legendas legenda)
        {
            this.Jogador = jogador; this.Adversario = adversario;this.Legendas = legenda;
        }
        public void AdicionarEventoAoAcabar(Evento e)
        {
            eventoAoAcabar = e;
        }
        public void Terminar(EventoDeCombate e)
        {
            if (eventoAoAcabar != null)
            {
                eventoAoAcabar.Invocar();
            }
        }
    }
}
