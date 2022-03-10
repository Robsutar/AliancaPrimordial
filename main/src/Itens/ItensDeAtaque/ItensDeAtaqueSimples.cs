using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Itens.ItensDeAtaque
{
    public static class ItensDeAtaqueSimples
    {
        public class Arco : ItemDeAtaque
        {
            public Arco() : base("Arco", "Arco de madeira com detalhes enferrujados de aço", 0, 5, Assets.arco)
            {
            }
        }
        public class Adaga : ItemDeAtaque
        {
            public Adaga() : base("Adaga", "Adaga de bronze, popular entre os ladrões", 2, 7, Assets.adaga)
            {
            }
        }
        public class Cimitarra : ItemDeAtaque
        {
            public Cimitarra() : base("Cimitarra", "Espada longa e curvada, símbolo de líder", 0, 5, Assets.cimitarra)
            {
            }
        }
    }
}
