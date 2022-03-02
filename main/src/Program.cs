using AliançaPrimordial.Janelas;
using AliançaPrimordial.main.src.Janelas;
using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
