namespace OperatorОverloading
{
    public class ComplexNumber
    {
        double _real;
        double _imaginary;

        public double Real => _real;
        public double Imaginary => _imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            if (real == 0 && imaginary == 0)
                throw new ArgumentException("Реальная и мнимай часть равны 0!");
            _real = real;
            _imaginary = imaginary;
        }

        static public ComplexNumber Add(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            var real = firstNumber.Real + secondNumber.Real;
            var imaginary = firstNumber.Imaginary + secondNumber.Imaginary;
            return new ComplexNumber(real, imaginary);
        }

        static public ComplexNumber Substract(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            var real = firstNumber.Real - secondNumber.Real;
            var imaginary = firstNumber.Imaginary - secondNumber.Imaginary;
            return new ComplexNumber(real, imaginary);
        }

        static public ComplexNumber Multiply(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            var real = firstNumber.Real * secondNumber.Real - firstNumber.Imaginary * secondNumber.Imaginary;
            var imaginary = firstNumber.Real * secondNumber.Real + firstNumber.Imaginary * secondNumber.Imaginary;
            return new ComplexNumber(real, imaginary);
        }

        static public ComplexNumber Division(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            var realNumerator = firstNumber.Real * secondNumber.Real + firstNumber.Imaginary * secondNumber.Imaginary;
            var imaginaryNumerator = secondNumber.Real * firstNumber.Imaginary - firstNumber.Real * secondNumber.Imaginary;

            var denominator = secondNumber.Real * secondNumber.Real + secondNumber.Imaginary * secondNumber.Imaginary;

            var real = realNumerator / denominator;

            var imaginary = imaginaryNumerator / denominator;

            return new ComplexNumber(real, imaginary);
        }
        public static ComplexNumber operator +(ComplexNumber firstNumber, ComplexNumber secondNumber) => Add(firstNumber, secondNumber);
        public static ComplexNumber operator -(ComplexNumber firstNumber, ComplexNumber secondNumber) => Substract(firstNumber, secondNumber);
        public static ComplexNumber operator *(ComplexNumber firstNumber, ComplexNumber secondNumber) => Multiply(firstNumber, secondNumber);
        public static ComplexNumber operator /(ComplexNumber firstNumber, ComplexNumber secondNumber) => Division(firstNumber, secondNumber);

        public bool Equals(ComplexNumber number)
        {
            return number.Real == Real && number.Imaginary == Imaginary;
        }

        public override string ToString()
        {
            return $"z = {Real} + i*{Imaginary}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ComplexNumber number)
                return Equals(number);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_real, _imaginary);
        }
    }
}
