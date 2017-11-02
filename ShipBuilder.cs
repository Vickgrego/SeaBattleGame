using System.Collections.Generic;
using static SeaBattleApp.GameProp;

namespace SeaBattleApp {
    class ShipBuilder {
        //build ships' fleet based on the task requirement
        public static List<Ship> initShips() {
            var ships = new List<Ship>();

            for (int decksForShip = 1; decksForShip <= LARGEST_NUM_OF_SHIPS; decksForShip++) {
                for (int howManySuchShips = 0; howManySuchShips < decksForShip; howManySuchShips++) {
                    ships.Add(buildShip(decksForShip));
                }
            }

            return ships;
        }

        //based on param define which ship to build
        private static Ship buildShip(int howManyShips) {
            Ship mShip = null;

            int howMany = howManyShips;
            switch (howMany) {
                case SINGLESHIPSSUM:
                    mShip = new Ship((int)Deckers.singleDecker);
                    break;
                case DOUBLESHIPSSUM:
                    mShip = new Ship((int)Deckers.doubleDecker);
                    break;
                case THREESHIPSSUM:
                    mShip = new Ship((int)Deckers.threeDecker);
                    break;
                case FOURSHIPSSUM:
                    mShip = new Ship((int)Deckers.fourDecker);
                    break;
                default:
                    mShip = new Ship(howMany);
                    break;
            }
            return mShip;
        }
    }
}
