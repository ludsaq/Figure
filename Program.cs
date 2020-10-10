using System;
using System.Collections.Generic;

namespace Figure
{
    public abstract class Figure
    {
        public double Area { get; protected set; }
        public double Perimeter { get; protected set; }
    }

    public class Trapec : Figure
    {
        public double SmallBasis { get; private set; }
        public double BigBasis { get; private set; }
        public double RightSide { get; private set; }
        public double LeftSide { get; private set; }
        public double Height { get; private set; }

        public Trapec(double SmallBasis, double RightSide, double BigBasis, double LeftSide,double Height)
        {
            this.SmallBasis = SmallBasis.CheckSide();
            this.BigBasis = BigBasis.CheckSide();
            this.RightSide = RightSide.CheckSide();
            this.LeftSide = LeftSide.CheckSide();
            this.Height = Height.CheckSide();

            CheckFigure.CheckSumSide(SmallBasis, BigBasis + RightSide + LeftSide);
            CheckFigure.CheckSumSide(BigBasis, SmallBasis + RightSide + LeftSide);
            CheckFigure.CheckSumSide(RightSide, BigBasis + SmallBasis + LeftSide);
            CheckFigure.CheckSumSide(LeftSide, BigBasis + RightSide + SmallBasis);

            Perimeter = CalculatePerimetr.Trapec(BigBasis, SmallBasis, RightSide, LeftSide);
            Area = CalculateArea.Trapec(BigBasis, SmallBasis, Height);
        }
    }
    public class Rectangle : Figure
    {
        public double SmallBasis { get; private set; }
        public double BigBasis { get; private set; }

        public Rectangle(double SmallBasis, double BigBasis)
        {
            this.SmallBasis = SmallBasis.CheckSide();
            this.BigBasis = BigBasis.CheckSide();

            Perimeter = CalculatePerimetr.Rectangle(SmallBasis, BigBasis);
            Area = CalculateArea.Rectangle(SmallBasis, BigBasis);
        }
    }
    public class Square : Figure
    {
        public double Side { get; private set; }

        public Square(double Side)
        {
            this.Side = Side.CheckSide();

            Perimeter = CalculatePerimetr.Square(Side);
            Area = CalculateArea.Square(Side);
        }
    }
    public class Round : Figure
    {
        public double Radius { get; private set; }
        public Round(double Radius)
        {
            this.Radius = Radius.CheckSide();

            Perimeter = CalculatePerimetr.Round(Radius);
            Area = CalculateArea.Round(Radius);
        }
    }
    public class Treangle : Figure
    {
        public double Basis { get; private set; }
        public double RightSide { get; private set; }
        public double LeftSide { get; private set; }

        public Treangle(double Basis, double RightSide, double LeftSide)
        {
            this.Basis = Basis.CheckSide();
            this.LeftSide = LeftSide.CheckSide();
            this.RightSide = RightSide.CheckSide();

            CheckFigure.CheckSumSide(Basis, LeftSide + RightSide);
            CheckFigure.CheckSumSide(LeftSide, Basis + RightSide);
            CheckFigure.CheckSumSide(RightSide, LeftSide + Basis);

            Perimeter = CalculatePerimetr.Treangle(Basis, RightSide, LeftSide);
            Area = CalculateArea.Treangle(Basis, RightSide, LeftSide);
        }
    }
    public static class CalculatePerimetr 
    {
        public static double Trapec(double BigBasis, double SmallBasis, double RightSide, double LeftSide) 
        {
            return BigBasis + SmallBasis + RightSide + LeftSide;
        }
        public static double Treangle(double Basis, double RightSide, double LeftSide)
        {
            return Basis + RightSide + LeftSide;
        }
        public static double Round(double Radius)
        {
            return 2 * Math.PI * Radius;
        }
        public static double Square(double Side)
        {
            return 4 * Side;
        }
        public static double Rectangle(double SmallBasis, double BigBasis)
        {
            return (SmallBasis + BigBasis) * 2;
        }
        public static double SumPerimetrFigure(List<Figure> Shapes) 
        {
            double SumPerimetrFigure = 0;

            foreach (var Shape in Shapes) 
            {
                SumPerimetrFigure += Shape.Perimeter;
            }

            return SumPerimetrFigure;
        }
    }
    public static class CalculateArea 
    {
        public static double Trapec(double BigBasis, double SmallBasis, double Height)
        {
            return ((BigBasis + SmallBasis)/2)* (Height);
        }
        public static double Treangle(double Basis, double RightSide, double LeftSide)
        {
            double PolSum = (Basis + RightSide + LeftSide) / 2;
            return Math.Sqrt(PolSum * (PolSum - Basis) 
                * (PolSum - RightSide) * (PolSum - LeftSide)); 
        }
        public static double Round(double Radius)
        {
            return Math.PI * Radius * Radius;
        }
        public static double Square(double Side)
        {
            return Side * Side;
        }
        public static double Rectangle(double SmallBasis, double BigBasis)
        {
            return SmallBasis * BigBasis;
        }
        public static double SumAreaFigure(List<Figure> Shapes)
        {
            double SumAreaFigure = 0;

            foreach (var Shape in Shapes)
            {
                SumAreaFigure += Shape.Area;
            }

            return SumAreaFigure;
        }
    }

    public static class CheckFigure 
    {
        public static double CheckSide(this double Side) 
        {
            if (Side <= 0)
            {
                throw new Exception();
            }
            else 
            {
                return Side;
            }
        }

        public static void CheckSumSide(double Side,double SumAnotherSids) 
        {
            if (Side < SumAnotherSids) 
            {
                throw new Exception();
            }
        }
    } 
}
