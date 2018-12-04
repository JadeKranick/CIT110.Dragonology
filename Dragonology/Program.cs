using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonology
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// initialize all dragons
        /// </summary>
        /// <returns></returns>
        static List<Dragon> InitializeAllDragons()
        {
            List<Dragon> dragons = new List<Dragon>();

            Dragon RedDragon = new Dragon("Red Dragon");
            RedDragon.Breath = "fire";
            RedDragon.Located = "mountains and islands";
            dragons.Add(RedDragon);

            Dragon BlackDragon = new Dragon("Black Dragon");
            BlackDragon.Breath = "acid";
            BlackDragon.Located = "swamps and jungles";
            dragons.Add(BlackDragon);

            Dragon BlueDragon = new Dragon("Blue Dragon");
            BlueDragon.Breath = "lightning bolt";
            BlueDragon.Located = "sandy deserts";
            dragons.Add(BlueDragon);

            Dragon GreenDragon = new Dragon("Green Dragon");
            GreenDragon.Breath = "poisonous gas";
            GreenDragon.Located = "waterfalls and lakes";
            dragons.Add(GreenDragon);

            Dragon WhiteDragon = new Dragon("White Dragon");
            WhiteDragon.Breath = "frost";
            WhiteDragon.Located = "snowy plains";
            dragons.Add(WhiteDragon);

            return dragons;
        }

        /// <summary>
        /// display all dragons
        /// </summary>
        /// <param name="dragons"></param>
        static void DisplayAllDragons(List<Dragon> dragons)
        {
            DisplayHeader("List of Dragons");

            foreach (Dragon dragon in dragons)
            {
                Console.WriteLine(dragon.Name);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display dragon information
        /// </summary>
        /// <param name="dragons"></param>
        static void DisplayDragonInformation(List<Dragon> dragons)
        {
            DisplayHeader("Dragon Information");

            foreach (Dragon dragon in dragons)
            {
                Console.WriteLine(dragon.Name);
            }
            Console.WriteLine();

            Console.Write("Enter Name: ");
            string seaMonsterName = Console.ReadLine();
            Console.WriteLine(new string('-', 95));
            Console.WriteLine();

            //
            // get dragon - display all properties
            //
            bool found = false;
            foreach (Dragon dragon in dragons)
            {
                if (dragon.Name.ToUpper() == seaMonsterName.ToUpper())
                {
                    Console.WriteLine("Name:".PadRight(30) + "Breath".PadRight(30) + "Located In".PadRight(30));
                    Console.WriteLine(new string('_', 95));
                    Console.Write(dragon.Name.PadRight(30) + dragon.Breath.PadRight(30) + dragon.Located.PadRight(30));
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Unable to locate sea monster named {seaMonsterName}.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayMenu()
        {
            List<Dragon> dragons = InitializeAllDragons();

            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Dragons");
                Console.WriteLine("\tB) Display Dragon Information For Specific Dragon");
                Console.WriteLine("\tC) Add a Dragon");
                Console.WriteLine("\tD) Delete a Dragon");
                Console.WriteLine("\tE) Display All Dragon Information");
                Console.WriteLine("\tF) Read From Dragon File");
                Console.WriteLine("\tG) Write To Dragon File");
                Console.WriteLine("\tH) Exit");

                Console.Write("Enter Choice: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllDragons(dragons);
                        break;

                    case "B":
                    case "b":
                        DisplayDragonInformation(dragons);
                        break;

                    case "C":
                    case "c":
                        break;

                    case "D":
                    case "d":

                        break;

                    case "E":
                    case "e":

                        break;

                    case "F":
                    case "f":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }
        #region HELPER METHODS

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Dragonology");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using our Drangonology program.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }

        #endregion
    }
}

//public enum Personality
//{
//    angry,
//    greedy,
//    vain,
//    cruel,
//    intelligent
//}