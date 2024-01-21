namespace delegates_events
{
    public class WithDictionary
    {
        public delegate string ChooseType();
        public Dictionary<int, ChooseType> Choices;

        public WithDictionary()
        {
            Choices = new()
            {
                { 1, Basic },
                { 2, Luxury },
                { 3, Sport },
            };
        }

        public string ChooseTypeCar(int typeCar)
        {
            var choice = Choices.FirstOrDefault(x => x.Key == typeCar);

            return choice.Value is null
                ? "Non-existent car type!"
                : choice.Value.Invoke();
        }

        public static string Basic()
        {
            return $"Congratulations! You just got a new car(basic).";
        }
        public static string Luxury()
        {
            return $"Congratulations! You just got a new car(luxurious).";
        }
        public static string Sport()
        {
            return $"Congratulations! You just got a new car(sporty).";
        }
    }
}
