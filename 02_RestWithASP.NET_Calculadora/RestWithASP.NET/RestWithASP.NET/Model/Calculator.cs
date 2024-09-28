namespace RestWithASPNET.Model
{
    public class Calculator
    {

        public static decimal Sum(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public static decimal Subtraction(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public static decimal Multiplication(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public static decimal Division(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public static decimal Mean(decimal firstNumber, decimal secondNumber)
        {
            return (firstNumber + secondNumber) / 2;
        }

        public static decimal SquareRoot(decimal firstNumber)
        {
            return (decimal)Math.Sqrt((double)firstNumber);
        }
    }
}
