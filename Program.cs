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
                    int value;
                    if(!int.TryParse(symbol, out value)) {
                        if(symbol == "Ace") value = 11;
                        else value = 10;
                    }

                    Card card = new(color, symbol, value);
                    cardstack.Push(card);
                }
            }
        }
    }
}
