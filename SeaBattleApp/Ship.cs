using System;

namespace ShipsOrganizer {
    internal class Ship {
        private int length;
        private int direction; 
        private static Random rand = new Random();

        public Ship(int shipLength) {
            this.length = shipLength;
            direction = rand.Next(0, 2);
        }

        public int Length {
            get {
                return length;
            }
        }

        public int Direction {
            get {
                return direction;
            }
        }
    }
}