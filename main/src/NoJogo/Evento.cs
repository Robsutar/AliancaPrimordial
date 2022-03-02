using System;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.NoJogo
{
    public class Evento
    {
        public readonly Action acao;

        private int delay = 0;

        public Evento(Action a)
        {
            this.acao = a;
        }
        public Evento(Action a,int delay)
        {
            this.acao = a;
            this.delay = delay;
        }

        public void Invocar()
        {
            if (delay == 0) { acao(); }
            else
            {
                Timer t = new Timer();
                t.Interval = delay;
                t.Enabled = true;
                t.Tick += (s, e) =>
                {
                    t.Stop();
                    acao();
                };
            }
        }
    }
    /*
    Exemplo de contrutor:
        new Evento(delegate ()
            {
                //Codigo aqui
            }));
    */
}
