using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public class EnraizamentoDeAllihanna : Efeito
    {
        public EnraizamentoDeAllihanna() : base("Enraizamento de Allihanna", "Lianna se conecta com sua Deusa e assim conjura sua " +
            "magia, galhos e ramos saem da terra imobilizando e machucando seu alvo, &2recebendo &72d2 &2de dano e recebe -&72d2 &2 em testes de ataque", 
            500, Item.ArvoreDeAllihanna)
        {

        }
        public override void AntesDoTurno(EventoDeCombate e)
        {
            e.Jogador.modificadorDeDado -= Dado.TantosDTantos(2, 2);
            e.Jogador.Vida -= Dado.TantosDTantos(2,2);
            base.AntesDoTurno(e);
        }
    }
}
