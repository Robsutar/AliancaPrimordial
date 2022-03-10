using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Resiliencia : Efeito
    {
        public Resiliencia() : base("Resiliência","Conselho de Tanna-Toh: &4Resiliência - &2o indivíduo recebe &71d5 &2de cura por turno"
            , 100, Item.ConselhosDeTannaToh)
        {
        }
        public override void AntesDoTurno(EventoDeCombate e)
        {
            e.Jogador.Vida += Dado.UmDTantos(5);
            base.AntesDoTurno(e);
        }
    }
}
