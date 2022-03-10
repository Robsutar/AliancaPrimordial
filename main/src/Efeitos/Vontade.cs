using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class Vontade : Efeito
    {
        public Vontade() : base("Vontade", "Conselho de Tanna-Toh: &9Vontade - &2o indivíduo cura 30% da vida perdida por turno"
            , 100, Item.ConselhosDeTannaToh)
        {
        }
        public override void AntesDoTurno(EventoDeCombate e)
        {
            int valor = (int)((e.Jogador.VidaMaxima - e.Jogador.Vida) * 0.3);
            Mensageiro.Print("Vontade de TannaToh: " + e.Jogador.Nome + " curou "+valor);
            e.Jogador.Vida += valor;
            base.AntesDoTurno(e);
        }
    }
}
