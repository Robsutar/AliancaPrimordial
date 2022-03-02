using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class Broquel : ItemDefensivo
    {
        public Broquel() : base("Broquel", "Um velho e desgastado escudo de madeira redondo – " +
            "&2Aumenta a defesa do usuário em &7+1"
            , Assets.broquel,1)
        {
        }
    }
}
