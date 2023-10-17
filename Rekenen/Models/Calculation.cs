namespace Rekenen.Models
{
    public class Calculation
    {
        public int Num1 { get; set; } = 0;
        public int Num2 { get; set; } = 0;
        public char Operator { get; set; } = '+';

        public Calculation(int num1 = 0, int num2 = 0, char @operator = '+')
        {
            Num1 = num1;
            Num2 = num2;
            Operator = @operator;
        }

        public Calculation()
        {

        }

        public Calculation(string level = "Simple" , char operation = '+')
        {
            Random rnd = new Random();
            switch(level)
            {
                case "Simple":
                    Num1 = rnd.Next(1,11);
                    Num2 = rnd.Next(1,11);
                    Operator = operation;
                    break;
                case "Average":
                    Num1 = rnd.Next(1, 101);
                    Num2 = rnd.Next(1, 101);
                    Operator = operation;
                    break;
                case "Hard":
                    Num1 = rnd.Next(-100, 101);
                    Num2 = rnd.Next(-100, 101);
                    Operator = operation;
                    break;
            }
        }

        public int Result
        {
            get
            {
                switch (Operator)
                {
                    case '+':
                        return Num1 + Num2;

                    case '-':
                        return Num1 - Num2; ;

                    case 'x':
                        return Num1 * Num2;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public override string ToString()
        {
            switch (Operator)
            {
                case '+':
                    return $"{Num1} + {Num2} = ";

                case '-':
                    return $"{Num1} - {Num2} = ";

                case 'x':
                    return $"{Num1} x {Num2} = ";
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
