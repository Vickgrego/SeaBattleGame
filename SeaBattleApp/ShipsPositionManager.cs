using FieldOrganizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipsOrganizer {
    class ShipsPositionManager {

        private static int range;
        private static int cellsInRow;
        private static Random rand = new Random();

        //returns array of unique random coordinates
        public static int[] DefineRandomPositionForShips(List<Ship> ships, int FieldRange, List<Coordinate> coordinates) {
            var Fleet = ships;
            range = FieldRange;
            cellsInRow = (int)Math.Sqrt(range);

            var ShipsPositions = new List<int>();
            var AvailableCoordinates = Get100Int();

            //for each ship add positions
            int direction;
            int shipLength;
            int[] tempPositions;
            foreach (Ship ship in Fleet) {

                int positionTemp = 0;
                shipLength = ship.Length;
                direction = ship.Direction == 0? cellsInRow : 1;

                //check if there are already such coordinates
                //repeat while coordinates are already in the list
                do {
                    tempPositions = new int[shipLength];
                    int position = rand.Next(AvailableCoordinates.First(), AvailableCoordinates.Last());

                    for (int shipPart = 0; shipPart < shipLength; shipPart++) {

                        positionTemp = position + direction * shipPart;

                        //for first deck check if all ship fit a column
                        if (shipPart == 0) {
                            int relativePos = positionTemp >= cellsInRow ? positionTemp % cellsInRow : positionTemp;
                            int ShipNeedsCells = relativePos + (direction * shipLength);
                            if (ShipNeedsCells >= cellsInRow)
                                positionTemp += direction*shipLength;

                            ShipNeedsCells = positionTemp + shipLength * direction;
                            if (ShipNeedsCells >= range)
                                positionTemp = ShipNeedsCells - range;

                            position = positionTemp;
                        }
                        tempPositions[shipPart] = positionTemp;
                    }                  
                } while (IsCoordinatesValid(ListToAdd: ShipsPositions, ListToRemove: AvailableCoordinates, arrayToCheck: tempPositions));
                SetMarginAroundShip(tempPositions, AvailableCoordinates);
            }
            return ShipsPositions.ToArray();
        }

        private static bool IsCoordinatesValid(List<int> ListToAdd, List<int> ListToRemove, int[] arrayToCheck) {
            foreach (int intToCheck in arrayToCheck) {
                if (ListToAdd.Contains(intToCheck) || (!ListToRemove.Contains(intToCheck))) {
                    return true;
                }
            }
            ListToAdd.AddRange(arrayToCheck);
            return false;
        }

        private static void SetMarginAroundShip(int[] positions, List<int> AllCoordinates) {
            List<int> ListAfterRemove = AllCoordinates;

            foreach (int currentCoordinate in positions) {
                int[] coordinatesToRemove = {
                    currentCoordinate,
                    currentCoordinate + 1,
                    currentCoordinate + 1 + cellsInRow,
                    currentCoordinate + 1 - cellsInRow,
                    currentCoordinate - 1,
                    currentCoordinate - 1 + cellsInRow,
                    currentCoordinate - 1 - cellsInRow,
                    currentCoordinate + cellsInRow,
                    currentCoordinate - cellsInRow
                };

                foreach (int coordinatetoRemove in coordinatesToRemove) {
                    try {
                        AllCoordinates.Remove(coordinatetoRemove);
                    } catch (Exception e) {
                        //if such coordinate doesn't exist - just skip it
                        continue;
                    }
                }
            }
        }

        private static List<int> Get100Int (){
            var List = new List<int>();
            for (int i = 0; i<range; i++)
                List.Add(i);
            return List;
        }
    }
}