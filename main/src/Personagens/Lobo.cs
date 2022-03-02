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
            itensAtivos.Add(Item.FrascoDeAcido);
        }
        public override void AntesDoTurno(EventoDeCombate e)
        {
            base.AntesDoTurno(e);
            int valor = new Random().Next(5);
            Mensageiro.Print(valor);
            if (valor == 0)
            {
                base.AntesDoTurno(e);
            }
            else
            {
                string l = "Lobo: ";
                switch (valor)
                {
                    case 1: l += "Grrr"; break;
                    case 2: l += "Au Aoooooo"; break;
                    case 3: l += "Gr...Grrrrr"; break;
                    case 4: l += "GRHAAAAAAAAh"; break;
                }
                e.Legendas.MudarLegenda(l);
                e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
                {
                    base.AntesDoTurno(e);
                }, 500));
            }
        }
    }
}
