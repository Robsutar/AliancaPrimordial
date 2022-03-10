using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliançaPrimordial.Motor
{
    static class Visual
    {
        public static readonly Color backgroundColor1 = Color.FromArgb(236, 240, 241);
        public static readonly Color backgroundColor2 = Color.FromArgb(189, 195, 199);
        public static readonly Color backgroundColor3 = Color.FromArgb(175, 180, 184);
        public static readonly Color menuColor1 = Color.FromArgb(26, 188, 156);
        public static readonly Color menuColor2 = Color.FromArgb(22, 160, 133);
        public static readonly Color menuColor3 = Color.FromArgb(41, 128, 185);
        public static readonly Color menuColor4 = Color.FromArgb(52, 152, 219);
        public static Color CorPorNumero(int n)
        {
            switch (n)
            {
                case 1: return Color.White;
                case 2: return Color.Blue;
                case 3: return Color.Cyan;
                case 4: return Color.Red;
                case 5: return Color.Orange;
                case 6: return Color.Yellow;
                case 7: return Color.Purple;
                case 8: return Color.DimGray;
                case 9: return Color.Green;
                default: return Color.Black;
            }
        }

        public static void FormatRichTextBox(RichTextBox r)
        {
            string texto = r.Text;
            string[] array = texto.Split("&");
            r.ResetText();
            foreach (string s in array)
            {
                if (s.Length > 1)
                {
                    char first = s[0];
                    if (char.IsNumber(first))
                    {
                        r.SelectionColor = CorPorNumero(first-'0');
                    }
                    r.AppendText(s.Substring(1,s.Length-1));
                }
            }
        }

        public static Bitmap RedimensionarImagem(Bitmap origem,Size newSize)
        {
            return new Bitmap(origem,newSize);
        }

        // código fonte: https://web.archive.org/web/20130111215043/http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
        public static Bitmap ParaEscalaCinza(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }
    }
}
