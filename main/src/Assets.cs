using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliançaPrimordial.Motor
{
    static class Assets
    {
        public static readonly string resourcesFolder = string.Format("{0}main\\resources", Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")))+"\\";
        public static readonly string itemsFolder = resourcesFolder + "items\\";

        public static Size JogadorTamanho { get => new Size(700, 700); }
        public static Size ItemTamanho { get => new Size(50, 50); }

        public static readonly Bitmap kry_normal = new Bitmap(Bitmap.FromFile(resourcesFolder + "kry_normal.png"),JogadorTamanho);
        public static readonly Bitmap lianna_normal = new Bitmap(Bitmap.FromFile(resourcesFolder + "lianna_normal.png"), JogadorTamanho);
        public static readonly Bitmap lobo_normal = new Bitmap(Bitmap.FromFile(resourcesFolder + "lobo_normal.png"), JogadorTamanho);

        public static readonly Bitmap broquel = new Bitmap(Bitmap.FromFile(itemsFolder + "broquel.png"),ItemTamanho);
        public static readonly Bitmap cajado_de_madeira = new Bitmap(Bitmap.FromFile(itemsFolder + "cajado_de_madeira.png"),ItemTamanho);
        public static readonly Bitmap capuz_de_ladino = new Bitmap(Bitmap.FromFile(itemsFolder + "capuz_de_ladino.png"),ItemTamanho);
        public static readonly Bitmap cota_de_malha = new Bitmap(Bitmap.FromFile(itemsFolder + "cota_de_malha.png"),ItemTamanho);
        public static readonly Bitmap erva_de_cura = new Bitmap(Bitmap.FromFile(itemsFolder + "erva_de_cura.png"),ItemTamanho);
        public static readonly Bitmap flauta = new Bitmap(Bitmap.FromFile(itemsFolder + "flauta.png"),ItemTamanho);
        public static readonly Bitmap frasco_de_acido = new Bitmap(Bitmap.FromFile(itemsFolder + "frasco_de_acido.png"),ItemTamanho);
        public static readonly Bitmap mangual = new Bitmap(Bitmap.FromFile(itemsFolder + "mangual.png"),ItemTamanho);
        public static readonly Bitmap murro = new Bitmap(Bitmap.FromFile(itemsFolder + "murro.png"), ItemTamanho);
        public static readonly Bitmap pocao_de_cura = new Bitmap(Bitmap.FromFile(itemsFolder + "pocao_de_cura.png"), ItemTamanho);
    }
}
