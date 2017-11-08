using FieldOrganizer;
using ShipsOrganizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattleApp {
    class ScreenRender {
        //ascii 65 - A
        private static int firstLetter = 65;
        private static int whiteSpace = 32;
        private static int shipBlock = 35;
        private static BattleField battleField;
        private static int whiteSpaceAtStart = 3;
        private int fieldLength = 0;

        public ScreenRender(int cells) {
            fieldLength = cells;
            battleField = new BattleField();
            battleField.Cells = fieldLength;
        }

        public void DrawBattleField() {
            var ShipsCoordinate = GetShipsCoordinate();
            WriteLetters();
            DrawShips(ShipsCoordinate);
        }

        private void WriteLetters() {

            for (int iteration = 0; iteration < fieldLength + whiteSpaceAtStart; iteration++) {
                int symbol;
                if (iteration < whiteSpaceAtStart) {
                    symbol = whiteSpace;
                } else {
                    symbol = firstLetter + iteration - whiteSpaceAtStart;
                }
                Console.Write("{0}", (char)symbol);
            }
            Console.WriteLine();
        }

        private void DrawShips (List<Coordinate> ShipsCoordinate) {
            Coordinate coordinate;
            for (int Xcoordinate = 0; Xcoordinate < fieldLength; Xcoordinate++) {
                WriteNumber(Xcoordinate);

                for (int Ycoordinate = 0; Ycoordinate < fieldLength; Ycoordinate++) {
                    coordinate = new Coordinate();
                    coordinate.SetCoordinate(x: Xcoordinate, y: Ycoordinate);

                    if (ShipsCoordinate.Contains(coordinate)) {
                        Console.Write((char)shipBlock);
                    } else {
                        Console.Write((char)whiteSpace);
                    }
                }
                Console.WriteLine();
            }
        }

        private void WriteNumber(int increment) {
            int rowNumb = increment + 1;
            if (rowNumb < 10) {
                Console.Write("{0: 0})", rowNumb);
            } else {
                Console.Write("{0:0})", rowNumb);
            }
        }

        private List<Coordinate> GetShipsCoordinate() {
            List<Ship> ships = FleetBuilder.initFleet();
            List<Coordinate> coordinates = battleField.GetFieldCoordinates();

            //get coordinate in random order for every ship
            int[] randomCoordinate = ShipsPositionManager.DefineRandomPositionForShips(ships, coordinates.Count, coordinates);

            //put ships on the field based on coordinates 
            var ShipsCoordinates = new List<Coordinate>();
            for (int i = 0; i < randomCoordinate.Length; i++) {
                    int n = randomCoordinate[i];
                    Coordinate coordinate = coordinates.ElementAt(n);
                    ShipsCoordinates.Add(coordinate);
            }
            return ShipsCoordinates;
        }
    }
}