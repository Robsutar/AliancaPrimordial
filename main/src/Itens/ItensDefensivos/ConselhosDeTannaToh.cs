using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Itens.ItensDefensivos
{
    public class ConselhosDeTannaToh : ItemDefensivo
    {
        public ConselhosDeTannaToh() : base("Conselhos de Tanna Toh", "O devoto se comunica com a Deusa do Conhecimento e recebe " +
            "ajuda da mesma, como consequência, se sente motivado &2conseguindo temporariamente " +
            "um dos 3 efeitos: &1Inspiração, &4Resiliência &2ou &9Vontade.", Assets.conselhos_de_tanna_toh, 0)
        {
        }
    }
}
