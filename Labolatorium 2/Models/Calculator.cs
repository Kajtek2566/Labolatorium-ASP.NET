namespace Labolatorium_2.Models
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
        public String Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.add:
                        return "+";
                       
                    case Operators.sub:
                        return "-";
                    case Operators.mul:
                        return "*";
                    case Operators.div:
                        return "/";
                    default:
                        return "";
                }
            }
        }
    }
}
