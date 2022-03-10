using AliançaPrimordial.Items;
using AliançaPrimordial.Janelas;
using AliançaPrimordial.main.src.Habilidades;
using AliançaPrimordial.main.src.Items;
using AliançaPrimordial.main.src.Itens.ItensAtivos;
using AliançaPrimordial.main.src.Itens.ItensDeAtaque;
using AliançaPrimordial.main.src.Itens.ItensDefensivos;
using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Personagens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AliançaPrimordial.main.src.Itens.ItensDeAtaque.ItensDeAtaqueSimples;

namespace AliançaPrimordial
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void Start(Form1 form)
        {
            IniciarObjetos();
            form.Controls.Clear();

            Legendas introducao = new Legendas(form);
            introducao.Abrir();
            introducao.AdicionarEventoAoAcabar(new main.src.NoJogo.Evento(delegate()
            {
                introducao.Fechar();
                TelaInicial telaInicial = new TelaInicial();
                form.Controls.Add(telaInicial);
            },200));
            introducao.MudarLegenda("É recomendado usar tela maximizada");
        }
        private static void IniciarObjetos()
        {

            Habilidade.Ataque = new Ataque();
            Habilidade.UsarItem = new UsarItem();
            Habilidade.MudarDeArma = new MudarDeArma();

            Item.Broquel = new Broquel();
            Item.CajadoDeMadeira = new CajadoDeMadeira();
            Item.CapuzDeLadino = new CapuzDeLadino();
            Item.CotaDeMalha = new CotaDeMalha();
            Item.ErvaDeCura = new ErvaDeCura();
            Item.Flauta = new Flauta();
            Item.FrascoDeAcido = new FrascoDeAcido();
            Item.Mangual = new Mangual();
            Item.Murro = new Murro("Murro", -2, 3);
            Item.PocaoDeCura = new PocaoDeCura();
            Item.Tacape = new Tacape();
            Item.OlharDeMonstro = new OlharDeMonstro();
            Item.ArvoreDeAllihanna = new ArvoreDeAllihanna();
            Item.CaixaVenenosa = new CaixaVenenosa();
            Item.Arco = new Arco();
            Item.Adaga = new Adaga();
            Item.Cimitarra = new Cimitarra();
            Item.Tridente = new Tridente();
            Item.ConselhosDeTannaToh = new ConselhosDeTannaToh();


            Jogador.Lianna = new main.src.Personagens.Lianna();
            Jogador.Lobo = new main.src.Personagens.Lobo();
            Jogador.Kry = new main.src.Personagens.Kry();
            Jogador.Orc = new main.src.Personagens.Orc();
            Jogador.BandidoA = new main.src.Personagens.BandidoA();
            Jogador.BandidoB = new main.src.Personagens.BandidoB();
            Jogador.BandidoC = new main.src.Personagens.BandidoC();
        }
    }
}
