namespace delegates_events
{
    public static class WithBuilder
    {
        public delegate int Calculate(params int[] numbers);

        public static void RealizeOperation(params int[] numbers)
        {
            Calculate operation = new(Sum);

            var resultSum = operation(numbers);
            Console.WriteLine("Result of the sum is:" + resultSum);

            operation = new(Multiply);

            var resultMultiply = operation(numbers);
            Console.WriteLine("Result of the multiply is:" + resultMultiply);
        }

        public static int Sum(params int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            return result;
        }

        public static int Multiply(params int[] numbers)
        {
            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                result *= numbers[i];
            }

            return result;
        }
    }
}