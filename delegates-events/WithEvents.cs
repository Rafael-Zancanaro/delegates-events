namespace delegates_events
{
    public static class WithEvents
    {
        public delegate void Calculation(double height, double widht, double depth);

        public class GeometricFigure
        {
            public double Height { get; set; }
            public double Width { get; set; }
            public double Depth { get; set; }

            public event Calculation OnCalculation;

            public void EventHandler()
            {
                OnCalculation(Height, Width, Depth);
            }
        }

        public static void CalculateSqareArea(double heigth, double width, double depth)
        {
            var area = heigth * width;

            Console.WriteLine($"Event fired from the class {nameof(CalculateSqareArea)}");
            Console.WriteLine("Square area:" + area);
        }

        public static void CalculateTotalArea(double heigth, double width, double depth)
        {
            var area = heigth * width * depth;

            Console.WriteLine($"Event fired from the class {nameof(CalculateTotalArea)}");
            Console.WriteLine("Total area" + area);
        }
    }
}