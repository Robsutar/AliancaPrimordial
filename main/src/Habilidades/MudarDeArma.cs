﻿using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Habilidades
{
    public class MudarDeArma : Habilidade
    {
        public MudarDeArma() : base("Mudar de Arma")
        {
        }

        public override string Legenda(EventoDeCombate e)
        {
            return e.Jogador.Nome + " mudou de arma, agora está usando " + e.Jogador.ItemDeAtaque().Nome ;
        }

        public override int FatorFavoravel(EventoDeCombate e)
        {
            if (e.Jogador.ItensDeAtaque().Count < 2)
            {
                return -100;
            }
            return new Random().Next(15);
        }

        //Esse método serve somente para bots
        protected override void NoUso(EventoDeCombate e)
        {
            if (e.Jogador.ItensDeAtaque().Count < 2) { return;}
            List<ItemDeAtaque> itens = new List<ItemDeAtaque>(e.Jogador.ItensDeAtaque());
            itens.Remove(e.Jogador.ItemDeAtaque());
            int rnd = new Random().Next(itens.Count);
            e.Jogador.MudarItemDeAtaque(itens[rnd]);
        }
    }
}
