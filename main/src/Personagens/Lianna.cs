using AliançaPrimordial.Items;
using AliançaPrimordial.main.src.Invocadores;
using AliançaPrimordial.main.src.Items;
using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Personagens
{
    public class Lianna : Protagonistas
    {
        Flauta flauta = Item.Flauta;
        CapuzDeLadino capuzDeLadino = Item.CapuzDeLadino;
        ErvaDeCura ervaDeCura = Item.ErvaDeCura;
        public Lianna() : base("Lianna", 23,15, 10, Item.CajadoDeMadeira, Assets.lianna_normal)
        {
            itensDefensivos.Add(capuzDeLadino);

            itensAtivos.Add(flauta);
            itensAtivos.Add(ervaDeCura);
        }

        public override string MostrarHistoria()
        {
            return "Lianna nasceu em um vilarejo de dríades que foi dizimado por Orcs, sua mãe conseguiu"+
            "salvá - la enquanto segurava os bárbaros e a garota fugia para a floresta.Ela cresceu sem"+
             "outras pessoas ao seu redor, suas únicas companhias eram seu cavalo Bolinhas e a"+
            "natureza.Sua motivação é a luta pela liberdade da floresta e a busca por sua mãe.";
        }

        protected override void PoderEspecial()
        {

        }
        public override void Introducao(Gerenciador handler)
        {
            Legendas legenda = new Legendas(handler);
            legenda.Abrir();
            legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
            {
                legenda.Fechar();

                Humano h = new Humano(Lianna);
                Bot b = new Bot(Lobo);

                JanelaDeCombate jdc = new JanelaDeCombate(h,b);

                handler.IniciarCombate(jdc);
            }, 10));
            /*
            legenda.MudarLegenda("Lianna por conta de lendas e boatos que teria ouvido, " +
                "tem como motivação conferir se tal tesouro realmente existe, finalmente " +
                "poderia descobrir a verdade sobre a sua família. ");
            */
            legenda.MudarLegenda("A");
        }
    }
}
