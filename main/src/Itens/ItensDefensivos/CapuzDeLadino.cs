using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class CapuzDeLadino : ItemDefensivo
    {
        public CapuzDeLadino() : base("Capuz de Ladino","É roubo se o dono já estiver morto? Um achado bom para muitas situações," +
            " camuflagem e o cheiro de sangue seco são presentes ali, assim acabam por ajudar na furtividade - " +
            "&2Aumenta a defesa passiva do usuário em &7+1", Assets.capuz_de_ladino,1)
        {
        }
    }
}
