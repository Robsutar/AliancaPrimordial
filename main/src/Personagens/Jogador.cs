using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Janelas;
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
        public static Lianna Lianna;
        public static Kry Kry;
        public static Lobo Lobo;
        public static Orc Orc;
        public static BandidoA BandidoA;
        public static BandidoB BandidoB;
        public static BandidoC BandidoC;


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

        public int VidaMaxima
        {
            get => vidaMaxima;
        }

        protected List<ItemDefensivo> itensDefensivos = new List<ItemDefensivo>();

        protected List<ItemAtivo> itensAtivos = new List<ItemAtivo>();

        protected List<Habilidade> habilidades = new List<Habilidade>();

        protected List<Efeito> efeitos = new List<Efeito>();

        protected List<ItemDeAtaque> itensDeAtaque = new List<ItemDeAtaque>();

        public readonly Ataque Ataque = Habilidade.Ataque;

        public readonly UsarItem UsarItem = Habilidade.UsarItem;

        public readonly MudarDeArma MudarDeArma = Habilidade.MudarDeArma;

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
            foreach(Efeito f in efeitos)
            {
                if (f.Nome == e.Nome)
                {
                    efeitos.Remove(f);
                    break;
                }
            }
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
            if (e.Adversario.Vida <= 0)
            {
                e.Vencedor = e.Jogador;
            } 
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
            foreach(Item i in ItensDefensivos())
            {
                l.Add(i);
            }
            foreach (Item i in ItensAtivos())
            {
                l.Add(i);
            }
            foreach (Item i in ItensDeAtaque())
            {
                l.Add(i);
            }
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

        public virtual void PoderEspecial(JanelaDeCombate janela, EventoDeCombate e)
        {
            e.Terminar(e);
        }
    }
}
