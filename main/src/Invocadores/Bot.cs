using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.main.src.NoJogo;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Invocadores
{
    public class Bot : Invocador
    {
        public Bot(Jogador personagem) : base(personagem)
        {
        }

        public void TurnoAutomatico(EventoDeCombate e)
        {
            int melhor = -1;
            Habilidade saida=null;
            foreach(Habilidade h in e.Adversario.Habilidades())
            {
                int fator = h.FatorFavoravel(e);
                if (fator > melhor)
                {
                    melhor = fator;
                    saida = h;
                }
            }
            if (saida != null)
            {
                new Evento(delegate ()
                {
                    saida.Usar(e);
                },1000).Invocar();
            }
        }
    }
}
