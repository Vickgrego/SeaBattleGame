using System;
using System.Collections.Generic;

namespace SeaBattleApp {
    class GameManager {
        //ascii 65 - A
        private static int firstLetter = 65;
        private static int whiteSpace = 32;
        private static int shipPart = 35;
        private static BattleField battleField;
        private static ShipOnFieldDrawer drawer;
        private static GameManager GM;
        private static int howManyWhiteSpaceAtStart = 3;

        private GameManager() {
            battleField = new BattleField();
            drawer = new ShipOnFieldDrawer();
        }

        private static GameManager instance;
        public static GameManager Instance {
            get {
                if (instance == null) {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public static void DrawSeaFields(int cells) {
            GM = new GameManager();
            battleField.Cells = cells;

            WriteFirstRowWithLetters();
            var field = drawer.GetShipsCoordinate(battleField.GetFieldCoordinates());

            WriteRowsAndShips(field);
        }

        private static void WriteFirstRowWithLetters() {
            int cells = battleField.Cells;
            for (int iteration = 0; iteration < cells + howManyWhiteSpaceAtStart; iteration++) {

                int letter;
                if (iteration < howManyWhiteSpaceAtStart) {
                    letter = whiteSpace;//just whitespace
                } else {
                    letter = firstLetter + iteration - howManyWhiteSpaceAtStart;
                }
                Console.Write("{0}", (char)letter);
            }
            Console.WriteLine();
        }
        private static void WriteRowsAndShips(List<Coordinate> coordinates) {
            int cells = battleField.Cells;
            var gameField = coordinates;
            Coordinate coordinate;

            for (int Xcoordinate = 0; Xcoordinate < cells; Xcoordinate++) {
                writeNumber(Xcoordinate);

                for (int Ycoordinate = 0; Ycoordinate < cells; Ycoordinate++) {
                    coordinate = new Coordinate();
                    coordinate.SetCoordinate(x: Xcoordinate, y: Ycoordinate);

                    if (gameField.Contains(coordinate)) {
                        Console.Write((char)shipPart);
                    } else {
                        Console.Write((char)whiteSpace);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void writeNumber(int increment) {
            int rowNumb = increment + 1;
            if (rowNumb < 10) {
                Console.Write("{0: 0})", rowNumb);
            } else {
                Console.Write("{0:0})", rowNumb);
            }
        }

    }
}
