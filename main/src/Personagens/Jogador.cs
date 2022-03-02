using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Personagens;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaPrimordial.Personagens
{
    public abstract class Jogador
    {
        public static readonly Lianna Lianna = new Lianna();
        public static readonly Kry Kry = new Kry();
        public static readonly Lobo Lobo = new Lobo();


        public static Protagonistas protagonista;

        public readonly string Nome;
        private readonly int vidaMaxima;
        private readonly int armadura;
        private readonly int idade;

        public int modificadorDeDado = 0;
        protected int vida;
        public int Vida
        {
            get=>vida;
            set
            {
                int val = value;
                val = Math.Max(0, val);
                val = Math.Min(vidaMaxima, val);
                vida = val;
            }
        }

        protected List<ItemDefensivo> itensDefensivos = new List<ItemDefensivo>();

        protected List<ItemAtivo> itensAtivos = new List<ItemAtivo>();

        protected List<Habilidade> habilidades = new List<Habilidade>();

        protected List<Efeito> efeitos = new List<Efeito>();

        protected List<ItemDeAtaque> itensDeAtaque = new List<ItemDeAtaque>();

        protected readonly Ataque Ataque = Habilidade.Ataque;

        protected readonly UsarItem UsarItem = Habilidade.UsarItem;

        protected readonly MudarDeArma MudarDeArma = Habilidade.MudarDeArma;

        protected ItemDeAtaque itemDeAtaque;

        public readonly Bitmap Image;

        public Jogador(string nome,int idade,int vidaMaxima,int armadura,ItemDeAtaque atk,Bitmap image)
        {
            this.Nome=nome;this.armadura = armadura;this.idade = idade;
            this.Image = image;this.vidaMaxima = vidaMaxima;Vida = vidaMaxima;

            habilidades.Add(Ataque);
            habilidades.Add(UsarItem);
            habilidades.Add(MudarDeArma);

            if (atk == null)
            {
                itemDeAtaque = Item.Murro;
            } else
            {
                itemDeAtaque = atk;
            }

            itensDeAtaque.Add(itemDeAtaque);
        }

        public void AdicionarEfeito(Efeito e)
        {
            efeitos.Add(e);
            e.AoIniciar();
        }

        public virtual int DefesaTotal()
        {
            int d = armadura;

            foreach(ItemDefensivo i in ItensDefensivos())
            {
                d += i.Defesa;
            }

            return d;
        }

        public ItemDeAtaque ItemDeAtaque() { return itemDeAtaque; }

        public void MudarItemDeAtaque(ItemDeAtaque item) { itemDeAtaque = item; }

        public virtual int RodarAtaque(EventoDeCombate e)
        {
            return ItemDeAtaque().Dano(e);
        }
        public virtual void AntesDoTurno(EventoDeCombate e)
        {
            List<Efeito> effs = new List<Efeito>(this.efeitos);
            foreach (Efeito f in effs)
            {
                f.AntesDoTurno(e);
            }
            e.Terminar(e);
        }

        public virtual void DepoisDoTurno(EventoDeCombate e)
        {
            List<Efeito> effs = new List<Efeito>(this.efeitos);
            foreach (Efeito f in effs)
            {
                f.DepoisDoTurno(e);
                if (!f.Ativo)
                {
                    this.efeitos.Remove(f);
                }
                Mensageiro.Print("Efeito pos turno " + f.Nome + " : " + f.Ativo);
            }
            modificadorDeDado = 0;
            e.Terminar(e);
        }
        public virtual List<ItemDefensivo> ItensDefensivos()
        {
            return itensDefensivos;
        }
        public virtual List<ItemAtivo> ItensAtivos()
        {
            return itensAtivos;
        }
        public virtual List<Item> TodosOsItens()
        {
            List<Item> l = new List<Item>();
            l.Add(ItemDeAtaque());
            l.Concat(ItensDefensivos());
            l.Concat(ItensAtivos());
            l.Concat(ItensDeAtaque());
            return l;
        }
        public virtual List<ItemDeAtaque> ItensDeAtaque() { return itensDeAtaque; }
        public virtual List<Habilidade> Habilidades()
        {
            return habilidades;
        }

        public virtual List<Efeito> Efeitos()
        {
            return efeitos;
        }
    }
}
