using System;
using System.Collections.Generic;
using static SeaBattleApp.GameProp;

namespace ShipsOrganizer {
    class FleetBuilder {
        
        public static List<Ship> initFleet() {
            var ships = new List<Ship>();
            Ship ship;

            for (int shipLenght = LARGEST_NUM_OF_SHIPS; shipLenght > 0; shipLenght--) {
                for (int shipsAmount = shipLenght; shipsAmount < LARGEST_NUM_OF_SHIPS+1; shipsAmount++) {
                    ship = new Ship(shipLenght);
                    ships.Add(ship);
                }
            }
            return ships;
        }
    }
}