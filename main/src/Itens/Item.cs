using AliançaPrimordial.Items;
using AliançaPrimordial.main.src.Items;
using AliançaPrimordial.main.src.Itens.ItensAtivos;
using AliançaPrimordial.main.src.Itens.ItensDeAtaque;
using AliançaPrimordial.main.src.Itens.ItensDefensivos;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AliançaPrimordial.main.src.Itens.ItensDeAtaque.ItensDeAtaqueSimples;

namespace AliançaPrimordial.Motor
{
    public abstract class Item
    {
        public static Broquel Broquel;
        public static CajadoDeMadeira CajadoDeMadeira;
        public static CapuzDeLadino CapuzDeLadino;
        public static CotaDeMalha CotaDeMalha;
        public static ErvaDeCura ErvaDeCura;
        public static Flauta Flauta;
        public static FrascoDeAcido FrascoDeAcido;
        public static Mangual Mangual;
        public static Murro Murro;
        public static Tacape Tacape;
        public static PocaoDeCura PocaoDeCura;
        public static OlharDeMonstro OlharDeMonstro;
        public static ArvoreDeAllihanna ArvoreDeAllihanna;
        public static CaixaVenenosa CaixaVenenosa;
        public static Arco Arco;
        public static Cimitarra Cimitarra;
        public static Adaga Adaga;
        public static Tridente Tridente;
        public static ConselhosDeTannaToh ConselhosDeTannaToh;

        protected bool consumivel = false;
        public readonly string Nome,Descricao;
        protected readonly Bitmap image;

        public Bitmap Image { get => image; }
        public Item(string nome, string descricao, Bitmap image)
        {
            Nome = nome;Descricao = descricao;this.image = image;
        }
        public override string ToString()
        {
            return Nome;
        }
    }
    public abstract class ItemAtivo : Item
    {
        protected ItemAtivo(string nome, string descricao, Bitmap image) : base(nome, descricao, image)
        {
        }

        public virtual int FatorFavoravel(EventoDeCombate e)
        {
            return 0;
        }

        public virtual void NoUso(EventoDeCombate e)
        {

        }
        public virtual string PrimeiraParteLegenda(EventoDeCombate e)
        {
            return e.Jogador.Nome + " usou o item: ";
        }
        public virtual string SegundaParteLegenda(EventoDeCombate e)
        {
            return Nome;
        }
        public bool Consumivel() { return consumivel; }
    }
    public abstract class ItemDeAtaque : Item
    {
        public readonly int ModificadorDeDado,DadoDeDano;
        protected ItemDeAtaque(string nome, string descricao,int modificadorDeDado,int dadoDeDano, Bitmap image) 
            : base(nome, descricao, image)
        {
            ModificadorDeDado = modificadorDeDado;DadoDeDano = dadoDeDano;
        }

        public virtual bool PassaNaArmadura(EventoDeCombate e)
        {
            if (e.Adversario.DefesaTotal() < TesteDeDano(e))
            {
                return true;
            }
            return false;
        }
        public virtual int Dano(EventoDeCombate e)
        {
            if (PassaNaArmadura(e))
            {
                return Dado.UmDTantos(DadoDeDano);
            }
            return 0;
        }
        protected virtual int TesteDeDano(EventoDeCombate e)
        {
            return Dado.UmDTantos(20)+e.Jogador.modificadorDeDado+ModificadorDeDado;
        }
    }
    public abstract class ItemDefensivo : Item
    {
        public readonly int Defesa;
        protected ItemDefensivo(string nome, string descricao, Bitmap image, int defesa) : base(nome, descricao, image)
        {
            Defesa = defesa;
        }
        public virtual void NoEvento(EventoDeCombate e)
        {

        }
    }
}
