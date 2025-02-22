namespace X {
    class Card {
        public char Symbol { get; set; }
        public int Value { get; set; }

        public Card(char symbol, int value) {
            Symbol = symbol;
            Value = value;
        }

        public override string ToString()
        {
            return Symbol + " - " + Value;
        }
    }
}
