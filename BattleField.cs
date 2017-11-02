using System;
using System.Collections.Generic;

namespace SeaBattleApp {
    internal class BattleField {
        //how many cells field has
        private int cells = 0;
        private static String cellsError = "No possible to have more than 25 cells";

        public int Cells {
            get {
                return cells;
            }

            set {
                if (value < 26) {
                    cells = value;
                } else {
                    Console.WriteLine(cellsError);
                }
            }
        }

        public List<Coordinate> GetFieldCoordinates() {
            var list = new List<Coordinate>();
            Coordinate c;
            for (int i = 0; i < cells; i++) {
                for (int j = 0; j < cells; j++) {
                    c = new Coordinate();
                    c.SetCoordinate(i, j);
                    list.Add(c);
                }
            }
            return list;
        }
    }
}