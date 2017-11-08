using System;
//need to implement IEquatable for to use Contains on the List

namespace FieldOrganizer {
    class Coordinate : IEquatable<Coordinate> {
        private int coordinateX = 0;
        private int coordinateY = 0;

        public void SetCoordinate(int x, int y) {
            coordinateX = x;
            coordinateY = y;
        }

        public void GetCoordinate(out int x, out int y) {
            x = coordinateX;
            y = coordinateY;
        }

        public bool Equals(Coordinate other) {
            int x, y;
            other.GetCoordinate(out x, out y);

            if (this.coordinateX == x && this.coordinateY == y) {
                return true;
            }
            return false;
        }
    }
}