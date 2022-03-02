using AliançaPrimordial.main.src.Janelas;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Invocadores
{
    public abstract class Invocador
    {

        public readonly Jogador Personagem;
        public Invocador(Jogador personagem)
        {
            this.Personagem = personagem;
        }
    }
}
