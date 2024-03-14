using System.Drawing;
using System.Drawing.Imaging;

namespace Overerving
{
    internal class Program
    {

        static void Main()
        {
            //overerving demo
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.DarkBlue, 5);

            Cirkel c = new Cirkel(new Punt(100, 100), 25);
            c.G = graphics;
            RechtHoek r = new RechtHoek(new Punt(400, 400), 100, 150);
            r.G = graphics;
            c.Teken();
            r.Teken();
            for (int x = 10, y = 10; x < 100; x += 10, y += 10)
            {
                c.VerplaatsNaarRelatief(x, y);
                c.Teken();
            }

            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string imgPad = dir + @"\afbeeldingen\overerving.bmp";
            Console.WriteLine(imgPad);
            bitmap.Save(imgPad, ImageFormat.Bmp);

            //polymorfisme demo

            Kat pruts = new Kat("pruts");
            Hond bobby = new Hond("bobby");
            Hond jefke = new Hond("jefke");
            Dier onbekend = new Dier("molly");

            Dier[] dierentuin = { pruts, bobby, jefke, onbekend };

            foreach (Dier d in dierentuin)
            {
                Console.WriteLine(d.Geluid());
            }
        }
    }
}
