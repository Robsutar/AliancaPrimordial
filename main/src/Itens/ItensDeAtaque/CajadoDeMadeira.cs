using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class CajadoDeMadeira : ItemDeAtaque
    {
        public CajadoDeMadeira() : base("Cajado de Madeira","Um cajado normal a primeira vista, porém Lianna sentiu algo a mais," +
            " quando tomou posse do objeto, o mesmo começou a pulsar como um coração em suas mãos, como se fosse vivo – " +
            "&2Aumenta em &7+3&2 nas rolagens de ataque",3,8, Assets.cajado_de_madeira)
        {
            
        }
    }
}
