using System;

namespace SeaBattleApp {
    internal class Game {

        private string exit = "exit";

        public void PlayGame() {
            ScreenRender render = new ScreenRender(cells: GameProp.CELLS);
            render.DrawBattleField();

            Console.WriteLine("Write exit to exit the game or any button to continue"); 
            string input = Console.ReadLine();
            if (input.Equals(exit)){
                return;
            } else {
                PlayGame();
            }
        }
    }
}