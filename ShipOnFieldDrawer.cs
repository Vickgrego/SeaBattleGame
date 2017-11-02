using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattleApp {
    class ShipOnFieldDrawer {
        public List<Coordinate> GetShipsCoordinate(List<Coordinate> coordinatesList) {
            List<Ship> ships = ShipBuilder.initShips();
            List<Coordinate> coordinates = coordinatesList;

            //get coordinate in random order for every ship
            int[] randomCoordinate = AllBugsAndMagicHere.DefineRandomPositionForShips(ships, coordinates.Count);

            //put ships on the field based on coordinates 
            var GameField = new List<Coordinate>();
            for (int i = 0; i < randomCoordinate.Length; i++) {
                try {
                    int n = randomCoordinate[i];
                    Coordinate coordinate = coordinates.ElementAt(n);
                    GameField.Add(coordinate);
                } catch (Exception e) {
                    Console.WriteLine(" Your code is fucked up on {0}", e);
                }
            }
            return GameField;
        }

    }
}
