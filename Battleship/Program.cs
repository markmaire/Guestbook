using BattleshipLibrary;
using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel player1 = CreatePlayer("Player 1");
            PlayerInfoModel player2 = CreatePlayer("Player 2");

            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to BATTLESHIP");
            Console.WriteLine("Created by Mark Maire");
            Console.WriteLine();
        }
        

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for {playerTitle}: ");

            //ask user for their name
            output.UsersName = AskForUsersName();

            //load up shot grid
            GameLogic.InitializeGrid(output);


            //ask user for ship placements
            PlaceShips(output);

            //clear console
            Console.Clear();

            return output;
        }

        private static string AskForUsersName()
        {
            Console.WriteLine("What is your name?");
            string output = Console.ReadLine();
            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Where do you want to place your ship number {model.ShipLocations.Count + 1}?");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if(isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location, please try again.");
                }

            } while (model.ShipLocations.Count < 5);
        }

    }
}
