using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;


namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight - 10);
            Console.SetBufferSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight - 10);
            Console.SetWindowSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight - 10);


            Console.CursorVisible = false;

            Lane[] lanes = new Lane[5];
            lanes[0] = new Lane(2, false, ConsoleColor.DarkBlue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[1] = new Lane(3, true, ConsoleColor.Green, false, true, 0.08f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[2] = new Lane(4, false, ConsoleColor.DarkBlue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());
            lanes[3] = new Lane(5, true, ConsoleColor.Green, false, true, 0.08f, Utils.charLogs, Utils.colorsLogs.ToList());
            lanes[4] = new Lane(6, false, ConsoleColor.DarkBlue, true, false, 0.03f, Utils.charCars, Utils.colorsLogs.ToList());

            Player player = new Player();

            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;
            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                foreach (var lane in lanes)
                {
                    lane.Update();
                }
                player.Draw();
              
                Vector2Int pulsado = Utils.Input();
                gameState = player.Update(pulsado, lanes.ToList());
                
                Console.Clear();
                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                }

                player.Draw();
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Green;
                //otro
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, Utils.MAP_HEIGHT);
                Console.Write("Tiempo: {0:0.00}", TimeManager.time);

                TimeManager.NextFrame();
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
          
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(gameState == Utils.GAME_STATE.WIN ? "You won!" : "You lost...");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }

}





