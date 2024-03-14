using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Overerving
{


    public abstract class Vorm
    {
        public Punt Locatie { get; set; }
        public Graphics G { get; set; }

        // constructor
        public Vorm(Punt punt)
        {
            this.Locatie = punt;
        }

        // move the x & y coordinates
        public void VerplaatsNaarAbsoluut(Punt punt)
        {
            this.Locatie = punt;
        }
        public void VerplaatsNaarRelatief(double deltax, double deltay)
        {
            Locatie.X += deltax;
            Locatie.Y += deltay;
            VerplaatsNaarAbsoluut(Locatie);
        }

        // virtual routine - draw the shape
        public abstract void Teken();
        public abstract double OpperVlakte();
        public abstract double Omtrek();

    }

    public class Cirkel : Vorm
    {
        private double straal;
        public Cirkel(Punt punt,double straal) : base(punt)
        {
            this.straal = straal;
        }

        public double Straal
        {
            get { return straal; }
            set { straal = (value >= 0) ? value : straal;}
        }
        public override void Teken()
        {//error
            Pen p = new Pen(Color.Red);
            G.DrawEllipse(p, (float)Locatie.X, (float)Locatie.Y, (float)(2 * straal), (float)(2 * straal));
            Console.WriteLine($"Cirkel met straal {this.straal} getekend op positie x = {this.Locatie.Y:F2}, y = {this.Locatie.X:F2}");
        }
        public override double OpperVlakte()
        {//error
            return Math.Pow( straal,2 ) * Math.PI;
        }
        public override double Omtrek()
        {
            return 2 * straal * Math.PI;
        }
    }

    public class RechtHoek  :Vorm
    {
        private double hoogte;
        private double breedte;

        public RechtHoek (Punt punt,double hoogte,double breedte) : base(punt) 
        {
            this.hoogte = hoogte;
            this.breedte = breedte;
        }

        public double Breedte
        {
            get { return breedte; }
            set { breedte = (value > 0) ? value : breedte; }
        }
        public double Hoogte
        {
            get { return hoogte; }
            set { hoogte = (value > 0) ? value : hoogte; }
        }
        public override void Teken()
        {
            Point p = new Point((int)Locatie.X, (int)Locatie.Y);
            Size s = new Size((int)breedte, (int)hoogte);
            Rectangle r = new Rectangle(p, s);
            Pen pen = new Pen(Color.Red);
            G.DrawRectangle(pen, r);
            Console.WriteLine($"Rechthoek met hoogte {this.hoogte} en breedte {this.breedte} getekend op positie x = {this.Locatie.X:F2}, y = {this.Locatie.Y:F2}");
        }

        public override double OpperVlakte()
        {
            return hoogte * breedte;
        }

        public override double Omtrek()
        {
            return 2 * hoogte + 2 * breedte;
        }
    }

    public class Punt
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Punt(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
