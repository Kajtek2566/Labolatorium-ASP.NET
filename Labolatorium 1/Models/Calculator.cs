using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_1.Models
{
    public class Calculator
    {
        public double A { get; set; }
        public double B { get; set; }

        public Operators? Operator { get; set; }

        public bool isValid()
        {
            return A != null & B != null && Operator != null;
        }

        public double Caluclate()
        {
            switch (Operator)
            {
                case Operators.add:
                    return (double)(A + B);
                case Operators.sub:
                    return (double)(A - B);
                case Operators.mul:
                    return (double)(A * B);
                case Operators.div:
                    return (double)(A / B);
                default: return double.NaN;
            }
        }
    }
}
