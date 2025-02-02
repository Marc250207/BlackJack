namespace BlackJack {
    class Program {
        private static Stack<Card> cardstack = new();

        public static void Main(string[] args) {
            InitializeCardStack();
        }


        private static void InitializeCardStack() {
            List<Card> cards = new();
            foreach(string color in Card.colors) {
                foreach(string symbol in Card.symobls) {
                    if (!int.TryParse(symbol, out int value))
                    {
                        if (symbol == "Ace") value = 11;
                        else value = 10;
                    }

                    Card card = new(color, symbol, value);
                    cards.Add(card);
                }
            }
        }

        private static void PrintList<T>(List<T> list) {
            foreach(T item in list) Console.WriteLine(item);
        }
    }

    static class ListExtensions {
        private static readonly Random rng = new Random();

        public static void Shuffle<T>(this List<T> list) {
            list.Sort((a, b) => rng.Next(-1, 2));
        }
    }
}
