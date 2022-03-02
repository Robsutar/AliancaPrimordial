using AliançaPrimordial.main.src.Janelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GerenciadorDeJanela.formPrincipal = this;

            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.Start(this);
        }
    }
}
