namespace BlackJack {
    class Program {
        private static List<Card> cards = new();

        public static void Main(string[] args) {
            InitializeCardStack();
        }


        private static void InitializeCardStack() {
            foreach(string color in Card.colors) {
                foreach(string symbol in Card.symobls) {
                    if (!int.TryParse(symbol, out int value))
                    {
                        if (symbol == "Ace") value = 11;
                        else value = 10;
                    }

                    Card card = new Card(color, symbol, value);
                    cards.Add(card);
                }
            }
        }


        private Stack<Card> GetShuffledCardStack() {
            cards.Shuffle();

            Stack<Card> stack = new();
            foreach(Card card in cards) stack.Push(card);


            return stack;
        }
    }



    static class ListExtensions {
        private static readonly Random rng = new Random();

        public static void Shuffle<T>(this List<T> list) {
            list.Sort((a, b) => rng.Next(-1, 2));
        }

        public static void Print<T>(this List<T> list) {
            foreach(T item in list) Console.WriteLine(item);
        }
    }
}
