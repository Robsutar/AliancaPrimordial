using AliançaPrimordial.Items;
using AliançaPrimordial.main.src.Items;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.Motor
{
    public abstract class Item
    {
        public static readonly Broquel Broquel = new Broquel();
        public static readonly CajadoDeMadeira CajadoDeMadeira = new CajadoDeMadeira();
        public static readonly CapuzDeLadino CapuzDeLadino = new CapuzDeLadino();
        public static readonly CotaDeMalha CotaDeMalha = new CotaDeMalha();
        public static readonly ErvaDeCura ErvaDeCura = new ErvaDeCura();
        public static readonly Flauta Flauta = new Flauta();
        public static readonly FrascoDeAcido FrascoDeAcido = new FrascoDeAcido();
        public static readonly Mangual Mangual = new Mangual();
        public static readonly Murro Murro = new Murro("Murro",-2,3);
        public static readonly PocaoDeCura PocaoDeCura = new PocaoDeCura();

        protected bool consumivel = false;
        public readonly string Nome,Descricao;
        protected readonly Bitmap image;

        public Bitmap Image { get => image; }
        public Item(string nome, string descricao, Bitmap image)
        {
            Nome = nome;Descricao = descricao;this.image = image;
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
