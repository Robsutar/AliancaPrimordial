using AliançaPrimordial.main.src.Items;
using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.main.src.NoJogo;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Personagens
{
    public class Kry : Protagonistas
    {
        public Kry() : base("Kry", 36, 23, 15,Item.Mangual, Assets.kry_normal)
        {
            itensDefensivos.Add(Item.CotaDeMalha);
            itensDefensivos.Add(Item.Broquel);
        }

        public override string MostrarHistoria()
        {
            return "Kry sempre foi isolado da sociedade por ser de uma raça diferente, ele é uma espécie de"+
            " tartaruga e poderia ser facilmente um alvo caso fosse caçado. Seus pais foram"+
            " sequestrados e então ele passou a ser criado por um homem de um culto, seu nome era"+
            " Sr Sven, passariam a ter uma relação de pai e filho. O homem tartaruga teria abandonado"+
            " o templo em que morava para descobrir a razão de sua existência, afinal, como sua"+
            " Deusa sempre está em busca da verdade e sabedoria.";
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
                legenda.MudarLegenda("Garotão bonito esse...");
                legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                {
                    legenda.ConcatenarLegenda(" Esse sapão esse...");
                    legenda.AdicionarEventoAoAcabar(new Evento(delegate ()
                    {
                        legenda.MudarLegenda("Bem charmoso uh?");
                    }, 1000));
                }, 1000));
            },1000));
            legenda.MudarLegenda("Kry né...");
        }
    }
}
