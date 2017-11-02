using System.Collections.Generic;


namespace SeaBattleApp {
    internal class Ship {
        private int decks;

        public Ship(int howManyDecks) {
            this.decks = howManyDecks;
        }

        public int Decks {
            get {
                return decks;
            }
        }

    }
}