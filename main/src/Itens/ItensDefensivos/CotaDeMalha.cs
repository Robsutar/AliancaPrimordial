using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.main.src.Items
{
    public class CotaDeMalha : ItemDefensivo
    {
        public CotaDeMalha() : base("Cota de Malha", "Uma armadura robusta para uma pessoa robusta - " +
            "&2Aumenta a defesa passiva do usuário em &7+3", Assets.cota_de_malha,3)
        {
        }
    }
}
