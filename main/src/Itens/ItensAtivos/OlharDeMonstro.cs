using AliançaPrimordial.main.src.Efeitos;
using AliançaPrimordial.Motor;
using AlmaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Itens.ItensAtivos
{
    public class OlharDeMonstro : ItemAtivo
    {
        public OlharDeMonstro() : base("Olhar de Monstro", "Um olhar intimidador, &2deixa o adversário amendrontado por &96 &2turnos", Assets.olhar_de_monstro)
        {
        }

        public override string PrimeiraParteLegenda(EventoDeCombate e)
        {
            return e.Jogador.Nome+" olha de forma intimidadora para "+e.Adversario.Nome;
        }
        public override string SegundaParteLegenda(EventoDeCombate e)
        {
            return ", o indivíduo está amendrontado";
        }
        public override int FatorFavoravel(EventoDeCombate e)
        {
            return Dado.UmDTantos(15);
        }
        public override void NoUso(EventoDeCombate e)
        {
            e.Adversario.AdicionarEfeito(new Amendrontado());
            base.NoUso(e);
        }
    }
}
