using System;

namespace Design_Pattern_Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RoundHole role = new RoundHole(5.0);
            RoundPeg rpeg = new RoundPeg(5.0);
            role.fits(rpeg);

            SquarePeg small_sqpeg = new SquarePeg(5.0);
            SquarePeg large_sqpeg = new SquarePeg(10.0);

            // role.fits(small_sqpeg);

            SquarePegAdapter small_sqpeg_adapter = new SquarePegAdapter(small_sqpeg);
            SquarePegAdapter large_sqpeg_adapter = new SquarePegAdapter(large_sqpeg);

            Console.WriteLine(role.fits(small_sqpeg_adapter));  //true
            Console.WriteLine(role.fits(large_sqpeg_adapter)); //false

        }
    }

    public class RoundHole
    {
        public double Radius { get; set; }
        public RoundHole(double radius)
        {
            Radius = radius;
        }

        public double getRadius()
        {
            return Radius;
        }

        public bool fits(RoundPeg peg)
        {
            return this.getRadius() >= peg.getRadius();
        }
    }
    public class RoundPeg
    {
        public double Radius { get; set; }

        public RoundPeg()
        {

        }
        public RoundPeg(double radius)
        {
            Radius = radius;
        }

        public double getRadius()
        {
            return this.Radius;
        }
    }

    public class SquarePegAdapter : RoundPeg {

        private SquarePeg Peg { get; set; }

        public SquarePegAdapter(SquarePeg peg)
        {
            this.Peg = peg;
        }
        
        public double getRadius (){


            return Peg.getWidth() * Math.Sqrt(2) / 2;
        }
        
    }

    public class SquarePeg
    {
        public double Width { get; set; }
        public SquarePeg(double width)
        {
            Width = width;
        }

        public double getWidth()
        {
            return Width;
        }
    }

}
