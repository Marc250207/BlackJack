namespace BlackJack {
    class Card {
        public static string[] colors = ["Hearts", "Spades", "Clubs", "Diamonds"];
        public static string[] symobls = ["Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];

        public string Color { get; }
        public string Symbol { get; }
        public int Value { get; }

        public Card(string color, string symbol, int value) {
            Color = color;
            Symbol = symbol;
            Value = value;
        }
        

        public override string ToString()
        {
            return Symbol + " of " + Color + " ("+Value+")";
        }
    }
}
