using static delegates_events.WithEvents;

namespace delegates_events
{
    public class Program
    {
        private delegate void Choices();

        private static readonly Dictionary<int, Choices> ListOfChoices = new()
        {
            { 1, DelegateWithDictionary },
            { 2, DelegateWithBuilder },
            { 3, DelegateWithEvents }
        };

        static void Main()
        {
            Console.Clear();
            Console.WriteLine("1 - With Dictionary \n2 - With Builder \n3 - With Event \n0 - Exit");
            var choice = int.Parse(Console.ReadLine());

            if (ListOfChoices.ContainsKey(choice))
                ListOfChoices[choice].Invoke();

            if (choice != 0)
                Main();
        }

        public static void DelegateWithBuilder()
        {
            string response;
            do
            {
                Console.Clear();
                Console.WriteLine("How many numbers do you want calculate?");
                var length = int.Parse(Console.ReadLine());

                var numbers = new List<int>();

                for (int i = 1; i <= length; i++)
                {
                    Console.WriteLine($"Choose the {i}º number:");
                    numbers.Add(int.Parse(Console.ReadLine()));
                }

                WithBuilder.RealizeOperation(numbers.ToArray());

                Console.WriteLine("\nDo you wanna realize another operation? Y(yes) Enter(Exit)");
                response = Console.ReadLine();

            } while (!string.IsNullOrWhiteSpace(response));
        }

        public static void DelegateWithDictionary()
        {
            string response;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose the type of car:\n 1 - Basic\n 2 - Luxury\n 3 - Sport \nChoice:");

                var type = int.Parse(Console.ReadLine());
                var choice = new WithDictionary().ChooseTypeCar(type);
                Console.WriteLine(choice);

                Console.WriteLine("\nMake another purchase? Y(yes) Enter(exit)");
                response = Console.ReadLine();

            } while (!string.IsNullOrWhiteSpace(response));
        }

        public static void DelegateWithEvents()
        {
            var figure = new GeometricFigure
            {
                Height = 10,
                Width = 10,
                Depth = 10,
            };

            figure.OnCalculation += CalculateSqareArea;
            figure.OnCalculation += CalculateTotalArea;

            figure.EventHandler();
            Console.ReadKey();
        }
    }
}