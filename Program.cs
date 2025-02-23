namespace BlackJack {
    static class Program {
        private static readonly Card[] cards = new Card[7];
        private static readonly char[] symbols = [
            'A', '2', '3', '4', '5', '6', '7'
        ];

        private static Stack<Card> cardStack = new Stack<Card>();


        public static void Main(string[] args) {
            Console.Clear();
            InitializeCards();
            InitializeCards();
            Console.WriteLine("Cards has been shuffled");

            Console.WriteLine("Press any key to recieve your cards...");
            Console.ReadKey();
            int playerTotal = PlayersTurn();
            if(playerTotal > 21) {
                Console.WriteLine("Dealer won.");
                return;
            }

            Console.Clear();
            Console.WriteLine("Dealers turn...");
            int dealerTotal = DealersTurn(playerTotal);
            if(dealerTotal > 21) {
                Console.WriteLine("Player won.");
                return;
            }

            CheckWin(playerTotal, dealerTotal);
        }

        private static int PlayersTurn() {
            int total = 0;
            List<Card> cardsOnHand = new List<Card>();
            Card card1 = cardStack.Pop();
            Card card2 = cardStack.Pop();
            total += card1.Value + card2.Value;
            cardsOnHand.Add(card1);
            cardsOnHand.Add(card2);
            DisplayCardsOnHand(cardsOnHand);


            while(total < 21) {
                Console.Write("Press enter to get another card:  ");

                ConsoleKey key = Console.ReadKey().Key;
                if(key != ConsoleKey.Enter) break;

                Card card = cardStack.Pop();
                total += card.Value;
                cardsOnHand.Add(card);
                DisplayCardsOnHand(cardsOnHand);
            }

            return total;
        }

        private static int DealersTurn(int playerTotal) {
            int total = 0;
            List<Card> cardsOnHand = new List<Card>();
            Card card1 = cardStack.Pop();
            Card card2 = cardStack.Pop();
            total += card1.Value + card2.Value;
            cardsOnHand.Add(card1);
            cardsOnHand.Add(card2);
            DisplayCardsOnHand(cardsOnHand);

            Thread.Sleep(1000);
            while(total < 21) {
                Console.Write("Waiting for dealer...");
                Thread.Sleep(2500);

                if(total > playerTotal || (total == playerTotal && total >= 18)) break;

                Card card = cardStack.Pop();
                total += card.Value;
                cardsOnHand.Add(card);
                DisplayCardsOnHand(cardsOnHand);
            }

            Thread.Sleep(2500);
            return total;
        }


        private static void InitializeCards() {
            for(int i = 0; i < cards.Length; i++) {
                cards[i] = new Card(symbols[i], i+1);
            }

            Random random = new Random();
            List<int> usedIndexes = new List<int>();
            for(int i = 0; i < cards.Length; i++) {
                int index;
                do {
                    index = random.Next(cards.Length);
                }
                while(usedIndexes.Contains(index));

                usedIndexes.Add(index);
                cardStack.Push(cards[index]);
            }
        }


        private static void CheckWin(int playerTotal, int dealerTotal) {
            Console.Clear();

            if(dealerTotal < playerTotal) {
                Console.WriteLine("Player won");
                return;
            }
            if(dealerTotal > playerTotal) {
                Console.WriteLine("Dealer won");
                return;
            }


            Console.WriteLine("Draw");
        }


        private static void DisplayCardsOnHand(List<Card> cardsOnHand) {
            Console.Clear();

            int totalValue = 0;
            foreach(Card card in cardsOnHand) {
                Console.Write(card.Symbol + " ");
                totalValue += card.Value;
            }

            Console.WriteLine("\nTotal: " + totalValue);
        }
    }
}
