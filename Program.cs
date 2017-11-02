using System;
using static SeaBattleApp.GameProp;

namespace SeaBattleApp {
    class Program {
        static void Main(string[] args) {
            GameManager.DrawSeaFields(CELLS);
            Console.ReadLine();
        }
    }
}
