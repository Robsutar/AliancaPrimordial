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
    public abstract class Bandido : Jogador
    {
        internal Bandido(string nome, ItemDeAtaque atk, Bitmap image) : base(nome,24,14,8, atk, image)
        {
            itensAtivos.Add(Item.CaixaVenenosa);
        }
    }
    public class BandidoA : Bandido
    {
        public BandidoA() : base("Zardo", Item.Arco, Assets.bandido_a_normal)
        {
        }
    }
    public class BandidoB : Bandido
    {
        public BandidoB() : base("Giren", Item.Adaga, Assets.bandido_b_normal)
        {
        }
    }
    public class BandidoC : Bandido
    {
        public BandidoC() : base("Robiti", Item.Cimitarra, Assets.bandido_c_normal)
        {
        }
    }
}
