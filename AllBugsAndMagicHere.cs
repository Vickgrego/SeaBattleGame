using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattleApp {
    class AllBugsAndMagicHere {
        /**returns array of unique random coordinates
        /@param List<Ship>, range = all cells on the battlefield
        */
        protected internal static int[] DefineRandomPositionForShips(List<Ship> ships, int range) {
            var mShips = ships;
            var RandomArray = new List<int>();

            //1 find start position for first ship
            int decks = mShips.ElementAt(0).Decks;
            int position = GetStartCoordinate(decks, range);

            //2 get available coordinates
            var AvailableCoordinates = new List<int>();
            for (int i = 0; i < range; i++) {
                AvailableCoordinates.Add(i);
            }

            //root of range
            int cellsInRow = (int)Math.Sqrt(range);

            //3 for each ship add positions
            int ShipInWhichDirection = cellsInRow;
            int[] tempArrayPositions;
            foreach (Ship ship in mShips) {

                int positionTemp = 0;
                decks = ship.Decks;

                //check if there are already such coordinates
                //repeat while coordinates are already in the list
                bool repeatIteration = false;
                do {
                    //override array for each iteration
                    tempArrayPositions = new int[decks];

                    //if needs to repeat iteration - try another position
                    if (repeatIteration == true)
                        position += 1;

                    if (ShipInWhichDirection == cellsInRow) {
                        ShipInWhichDirection = 1;
                    } else {
                        ShipInWhichDirection = cellsInRow;
                    }
                    
                    for (int deck = 0; deck < decks; deck++) {

                        positionTemp = position + ShipInWhichDirection * deck;

                        //for first deck check if all decks fit a column
                        if (deck == 0) {
                            //cells in row = 10 but the position is betwenn 0 and 9
                            int ShipNeedscells = (positionTemp % (cellsInRow - 1)) + decks;
                            if (ShipNeedscells >= cellsInRow)
                                positionTemp += decks;

                            int isPositionHigherThanRange = positionTemp + (decks * (cellsInRow - 1));

                            if (isPositionHigherThanRange >= range)
                                positionTemp = isPositionHigherThanRange - range;

                            position = positionTemp;
                        }
                        tempArrayPositions[deck] = positionTemp;
                    }
                    position = positionTemp;
                } while (repeatIteration = NotValidCoordinates(ListToAdd: RandomArray, ListToRemove: AvailableCoordinates, arrayToCheck: tempArrayPositions));

                //remove ints after while is over
                RemoveCoordinatesAroundShip(positions: tempArrayPositions, AllCoordinates: AvailableCoordinates, cellsInRow: cellsInRow);
                position = positionTemp + cellsInRow;
            }

            return RandomArray.ToArray();
        }

        private static bool NotValidCoordinates(List<int> ListToAdd, List<int> ListToRemove, int[] arrayToCheck) {

            foreach (int intToCheck in arrayToCheck) {
                if (ListToAdd.Contains(intToCheck) || (!ListToRemove.Contains(intToCheck))) {
                    return true;
                }
            }

            ListToAdd.AddRange(arrayToCheck);
            return false;
        }

        private static int GetStartCoordinate(int decks, int range) {
            int position;
            int margin = (int)Math.Sqrt(range);
            Random randNum = new Random();

            //if start position is not enough to put whole ship find new random
            do {
                position = randNum.Next(0, range);
                if (position == 0) {
                    break;
                }
            } while ((margin % position + decks) < 0);
            return position;
        }

        private static List<int> RemoveCoordinatesAroundShip(int[] positions, List<int> AllCoordinates, int cellsInRow) {
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

            return ListAfterRemove;
        }

    }
}
