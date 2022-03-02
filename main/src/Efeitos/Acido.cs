using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Acido : Efeito
    {
        public Acido() : base("Acido","A carne do indivíduo está queimando,&2 o alvo sofre &41d6 &2por turno.",3,Item.FrascoDeAcido)
        {

        }
        public override void DepoisDoTurno(EventoDeCombate e)
        {
            base.DepoisDoTurno(e);
            e.Adversario.Vida -= Dado.UmDTantos(6);
        }
    }
}
