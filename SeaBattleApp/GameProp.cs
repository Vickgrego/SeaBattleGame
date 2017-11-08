/**1 ship – a row/column of 4 cells("four-decker")
2 ships – a row/column of 3 cells("three-decker")
3 ships – a row/column of 2 cells("double-decker")
4 ships – 1 cell("single-decker")
*/

namespace SeaBattleApp {
    class GameProp {
        public const int CELLS = 10;

        //how many ships
        public const int SINGLESHIPSSUM = 4;
        public const int DOUBLESHIPSSUM = 3;
        public const int THREESHIPSSUM = 2;
        public const int FOURSHIPSSUM = 1;

        //the biggest amount of ships
        public static readonly int LARGEST_NUM_OF_SHIPS = SINGLESHIPSSUM;

        public static readonly int HOW_MANY_SHIPS = SINGLESHIPSSUM + DOUBLESHIPSSUM + THREESHIPSSUM + FOURSHIPSSUM;
    }
}