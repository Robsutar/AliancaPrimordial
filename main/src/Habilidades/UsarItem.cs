using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Habilidades
{
    public class UsarItem : Habilidade
    {
        public UsarItem() : base("Usar Item")
        {
        }

        public override string Legenda(EventoDeCombate e)
        {
            return e.Jogador.Nome+" usou o item: ";
        }

        public override int FatorFavoravel(EventoDeCombate e)
        {
            List<ItemAtivo> itens = new List<ItemAtivo>(e.Jogador.ItensAtivos());
            int r=-100;
            foreach(ItemAtivo i in itens)
            {
                int fator = i.FatorFavoravel(e)+323;
                if (fator > r)
                    r = fator;
            }
            return r;
        }
        public void NoUso(EventoDeCombate e, ItemAtivo item)
        {
            if (e.Jogador.ItensAtivos().Contains(item))
            {
                e.Legendas.MudarLegenda(Legenda(e));
                e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
                {
                    item.NoUso(e);
                    if (item.Consumivel())
                    {
                        e.Jogador.ItensAtivos().Remove(item);
                        Mensageiro.Print("Item removido " + item.Nome);
                    }
                    e.Legendas.ConcatenarLegenda(item.Nome);
                    e.Legendas.AdicionarEventoAoAcabar(new NoJogo.Evento(delegate ()
                    {
                        FinalDoUso(e);
                    }, 1000));
                }, 200));
            }
        }

        public override void Usar(EventoDeCombate e)
        {
            NoUso(e);
        }

        //Esse método serve somente para bots
        protected override void NoUso(EventoDeCombate e)
        {
            List<ItemAtivo> itens = new List<ItemAtivo>(e.Jogador.ItensAtivos());
            if (itens.Count > 0)
            {
                ItemAtivo saida = itens[0];
                int r = 0;
                foreach (ItemAtivo i in itens)
                {
                    int fator = i.FatorFavoravel(e);
                    if (fator > r)
                    {
                        r = fator;
                        saida = i;
                    }
                }
                NoUso(e, saida);
            }
        }
    }
}
