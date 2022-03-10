using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Inspiracao : Efeito
    {
        public Inspiracao() : base("Inspiração", "Conselho de Tanna-Toh: &1Inspiração - &2o indivíduo recebe &7+5 &2em testes de ataque"
            , 100,Item.ConselhosDeTannaToh)
        {
        }
        public override void AntesDoTurno(EventoDeCombate e)
        {
            e.Jogador.modificadorDeDado += 5;
            base.AntesDoTurno(e);
        }
    }
}
