using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Efeitos
{
    public abstract class Efeito
    {
        public readonly string Nome,Descricao;
        protected int turnosRestantes;
        public bool Ativo = false;
        public readonly ItemAtivo origem;

        public Efeito(string nome,string descicao,int quantidadeDeTurnos, ItemAtivo origem)
        {
            Nome = nome;Descricao=descicao;
            this.TurnosRestantes = quantidadeDeTurnos;
            this.origem = origem;
        }

        public int TurnosRestantes { get => turnosRestantes;set { turnosRestantes = Math.Max(0, value); } }
        public virtual void AntesDoTurno(EventoDeCombate e) { 
        }
        public virtual void DepoisDoTurno(EventoDeCombate e)
        {
            if (turnosRestantes < 100)
            {
                TurnosRestantes--;
            }
            if (TurnosRestantes <= 0)
            {
                AoAcabar(e);
            }
        }

        public virtual void AoIniciar()
        {
            Ativo = true;
        }
        protected virtual void AoAcabar(EventoDeCombate e)
        {
            Ativo = false;
        }
    }
}
