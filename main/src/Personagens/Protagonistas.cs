using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Personagens
{
    public abstract class Protagonistas : Jogador
    {
        protected Protagonistas(string nome, int idade, int vidaMaxima, int armadura,ItemDeAtaque atk, Bitmap image) : 
            base(nome, idade, vidaMaxima, armadura,atk, image)
        {

        }
        public abstract void Introducao(Gerenciador handler);
        protected abstract void PoderEspecial();
        public abstract string MostrarHistoria();
    }
}
