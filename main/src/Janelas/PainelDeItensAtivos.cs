using AliançaPrimordial.Motor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.main.src.Janelas
{
    public class PainelDeItensAtivos : Panel
    {
        private List<ItemAtivo> items;

        private List<ItemButton> buttons = new List<ItemButton>();

        private Panel itemsInfo;
        private Panel listItems;

        private RichTextBox textBox;

        private Action<ItemAtivo> aoAcabar;
        public PainelDeItensAtivos(List<ItemAtivo> items)
        {
            BackColor = Visual.backgroundColor2;
            this.items = items;
            Height = 0;
            Width = Assets.ItemTamanho.Width * 8;
            listItems = new Panel();
            listItems.BackColor = Visual.backgroundColor2;
            listItems.Dock = DockStyle.Left;

            itemsInfo = new Panel();
            itemsInfo.BackColor = Visual.backgroundColor1;
            itemsInfo.Dock = DockStyle.Right;
            itemsInfo.Padding = new Padding(10);

            foreach (ItemAtivo i in items)
            {
                ItemButton b = new ItemButton(i, this);
                buttons.Add(b);
                b.Dock = DockStyle.Top;
                b.Width = Width / 2;

                listItems.Controls.Add(b);
                Height += b.Height;
            }
            Controls.Add(listItems);
            Controls.Add(itemsInfo);
        }

        internal void EnterButton(Item i)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.BorderStyle = BorderStyle.None;
            rtb.Enabled = false;
            rtb.Multiline = true;
            rtb.ReadOnly = true;
            rtb.Dock = DockStyle.Fill;

            rtb.SelectionColor = Color.Black;
            rtb.AppendText("&0" + i.Nome);
            rtb.SelectionColor = Color.DarkGray;
            rtb.AppendText("\n   " + i.Descricao);

            Visual.FormatRichTextBox(rtb);

            if (textBox != null)
            {
                itemsInfo.Controls.Remove(textBox);
            }
            textBox = rtb;
            itemsInfo.Controls.Add(textBox);

        }
        internal void LeaveButton()
        {

        }

        public void AdicionarEventoAoClicar(Action<ItemAtivo> a)
        {
            aoAcabar = a;
        }

        internal class ItemButton : Button
        {
            ItemAtivo item;

            PainelDeItensAtivos handler;
            internal ItemButton(ItemAtivo item, PainelDeItensAtivos handler)
            {
                this.handler = handler;
                this.item = item;
                Image = item.Image;
                Text = item.Nome;
                Height = Assets.ItemTamanho.Height + 20;
                SetStyle(ControlStyles.Selectable, false);
                Padding = new Padding(10, 0, 10, 0);

                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                Click += ItemButton_Click;
            }

            private void ItemButton_Click(object sender, EventArgs e)
            {
                if (handler.aoAcabar != null)
                {
                    handler.aoAcabar(item);
                    handler.aoAcabar = null;
                }
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                handler.EnterButton(item);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                handler.LeaveButton();
            }
        }
    }


    public class PainelDeItensDeAtaque : Panel
    {
        private List<ItemDeAtaque> items;

        private List<ItemButton> buttons = new List<ItemButton>();

        private Panel itemsInfo;
        private Panel listItems;

        private RichTextBox textBox;

        private Action<ItemDeAtaque> aoAcabar;
        public PainelDeItensDeAtaque(List<ItemDeAtaque> items)
        {
            BackColor = Visual.backgroundColor2;
            this.items = items;
            Height = 0;
            Width = Assets.ItemTamanho.Width * 8;
            listItems = new Panel();
            listItems.BackColor = Visual.backgroundColor2;
            listItems.Dock = DockStyle.Left;

            itemsInfo = new Panel();
            itemsInfo.BackColor = Visual.backgroundColor1;
            itemsInfo.Dock = DockStyle.Right;
            itemsInfo.Padding = new Padding(10);

            foreach (ItemDeAtaque i in items)
            {
                ItemButton b = new ItemButton(i, this);
                buttons.Add(b);
                b.Dock = DockStyle.Top;
                b.Width = Width / 2;

                listItems.Controls.Add(b);
                Height += b.Height;
            }
            Controls.Add(listItems);
            Controls.Add(itemsInfo);
        }

        internal void EnterButton(Item i)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.BorderStyle = BorderStyle.None;
            rtb.Enabled = false;
            rtb.Multiline = true;
            rtb.ReadOnly = true;
            rtb.Dock = DockStyle.Fill;

            rtb.SelectionColor = Color.Black;
            rtb.AppendText("&0" + i.Nome);
            rtb.SelectionColor = Color.DarkGray;
            rtb.AppendText("\n   " + i.Descricao);

            Visual.FormatRichTextBox(rtb);

            if (textBox != null)
            {
                itemsInfo.Controls.Remove(textBox);
            }
            textBox = rtb;
            itemsInfo.Controls.Add(textBox);

        }
        internal void LeaveButton()
        {

        }

        public void AdicionarEventoAoClicar(Action<ItemDeAtaque> a)
        {
            aoAcabar = a;
        }

        internal class ItemButton : Button
        {
            ItemDeAtaque item;

            PainelDeItensDeAtaque handler;
            internal ItemButton(ItemDeAtaque item, PainelDeItensDeAtaque handler)
            {
                this.handler = handler;
                this.item = item;
                Image = item.Image;
                Text = item.Nome;
                Height = Assets.ItemTamanho.Height + 20;
                SetStyle(ControlStyles.Selectable, false);
                Padding = new Padding(10, 0, 10, 0);

                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                Click += ItemButton_Click;
            }

            private void ItemButton_Click(object sender, EventArgs e)
            {
                if (handler.aoAcabar != null)
                {
                    handler.aoAcabar(item);
                    handler.aoAcabar = null;
                }
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                handler.EnterButton(item);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                handler.LeaveButton();
            }
        }
    }
}
