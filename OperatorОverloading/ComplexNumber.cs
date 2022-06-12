namespace OperatorОverloading
{
    public class ComplexNumber
    {
        private readonly double _real;
        private readonly double _imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            if (real == 0 && imaginary == 0)
                throw new ArgumentException("Реальная и мнимай часть равны 0.");
            _real = real;
            _imaginary = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                throw new ArgumentNullException("Комплексное(ые) число(а) пусты.");
            if ((firstNumber._real == 0 && secondNumber._imaginary == 0) || (secondNumber._real == 0 && secondNumber._imaginary == 0))
                throw new ArgumentException("Значение комплексного числа не верное.");
            var real = firstNumber._real + secondNumber._real;
            var imaginary = firstNumber._imaginary + secondNumber._imaginary;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                throw new ArgumentNullException("Комплексное(ые) число(а) пусты.");
            if ((firstNumber._real == 0 && secondNumber._imaginary == 0) || (secondNumber._real == 0 && secondNumber._imaginary == 0))
                throw new ArgumentException("Значение комплексного числа не верное.");
            var real = firstNumber._real - secondNumber._real;
            var imaginary = firstNumber._imaginary - secondNumber._imaginary;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                throw new ArgumentNullException("Комплексное(ые) число(а) пусты.");
            if ((firstNumber._real == 0 && secondNumber._imaginary == 0) || (secondNumber._real == 0 && secondNumber._imaginary == 0))
                throw new ArgumentException("Значение комплексного числа не верное.");
            var real = firstNumber._real * secondNumber._real - firstNumber._imaginary * secondNumber._imaginary;
            var imaginary = firstNumber._real * secondNumber._real + firstNumber._imaginary * secondNumber._imaginary;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator /(ComplexNumber firstNumber, ComplexNumber secondNumber)
        {
            if (firstNumber == null || secondNumber == null)
                throw new ArgumentNullException("Комплексное(ые) число(а) пусты.");
            if ((firstNumber._real == 0 && secondNumber._imaginary == 0) || (secondNumber._real == 0 && secondNumber._imaginary == 0))
                throw new ArgumentException("Значение комплексного числа не верное.");
            var realNumerator = firstNumber._real * secondNumber._real + firstNumber._imaginary * secondNumber._imaginary;
            var imaginaryNumerator = secondNumber._real * firstNumber._imaginary - firstNumber._real * secondNumber._imaginary;

            var denominator = secondNumber._real * secondNumber._real + secondNumber._imaginary * secondNumber._imaginary;

            var real = realNumerator / denominator;

            var imaginary = imaginaryNumerator / denominator;

            return new ComplexNumber(real, imaginary);
        }

        public bool Equals(ComplexNumber number)
        {
            return number._real == _real && number._imaginary == _imaginary;
        }

        public override string ToString()
        {
            return $"z = {_real} + i*{_imaginary}";
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
