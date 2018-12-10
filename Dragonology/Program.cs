using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dragonology
{
    class Program
    {
        /***************************************/
        // Title: Dragonology
        // Application Type: Console App (.NET Framework)
        // Description: This menu can be used to display dragons, their information, add your own dragon,
        // delete a dragon, and also write and read from a dragon file. 
        // Author: Jade Kranick
        // Date Created: 12/1/2018
        // Date Last Modified: 12/9/2018
        /***************************************/
        static void Main(string[] args)
        {
            string dataPath = @"Data\Data.csv";

            DisplayOpeningScreen();
            DisplayMenu(dataPath);
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
            RedDragon.Breath = "Fire";
            RedDragon.Located = "Mountains and Islands";
            RedDragon.Age = 5;
            RedDragon.Color = "red";
            dragons.Add(RedDragon);

            Dragon BlackDragon = new Dragon("Black Dragon");
            BlackDragon.Breath = "Acid";
            BlackDragon.Located = "Swamps and Jungles";
            BlackDragon.Age = 10;
            BlackDragon.Color = "black";
            dragons.Add(BlackDragon);

            Dragon BlueDragon = new Dragon("Blue Dragon");
            BlueDragon.Breath = "Lightning Bolt";
            BlueDragon.Located = "Sandy Deserts";
            BlueDragon.Age = 2;
            BlueDragon.Color = "blue";
            dragons.Add(BlueDragon);

            Dragon GreenDragon = new Dragon("Green Dragon");
            GreenDragon.Breath = "Poisonous Gas";
            GreenDragon.Located = "Waterfalls and Lakes";
            GreenDragon.Age = 8;
            GreenDragon.Color = "green";
            dragons.Add(GreenDragon);

            Dragon WhiteDragon = new Dragon("White Dragon");
            WhiteDragon.Breath = "Frost";
            WhiteDragon.Located = "Snowy Plains";
            WhiteDragon.Age = 1;
            WhiteDragon.Color = "white";
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
            string dragonName = Console.ReadLine();
            Console.WriteLine(new string('-', 120));
            Console.WriteLine();

            //
            // get dragon - display all properties
            //
            bool found = false;
            foreach (Dragon dragon in dragons)
            {
                if (dragon.Name.ToUpper() == dragonName.ToUpper())
                {
                    switch (dragon.Color)

                    {
                        case "red":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case "black":
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case "blue":
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        case "green":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                        case "white":
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("Name".PadRight(30) + "Age".PadRight(30) + "Breath".PadRight(30) + "Located In".PadRight(30));
                    Console.WriteLine(new string('_', 120));
                    Console.Write(dragon.Name.PadRight(30) + dragon.Age.ToString().PadRight(30) + dragon.Breath.PadRight(30) + dragon.Located.PadRight(30));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Black;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Unable to locate dragon named {dragonName}.");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display add dragon
        /// </summary>
        /// <param name="dragons"></param>
        static void DisplayAddDragon(List<Dragon> dragons)
        {
            Dragon userDragon = new Dragon();
            int age;

            DisplayHeader("Add A Dragon");

            Console.Write("Enter Name: ");
            userDragon.Name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter Age: ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Please enter a number.");
                Console.Write("Enter Age: ");
            }
            userDragon.Age = age;
            Console.WriteLine();

            Console.Write("Enter Breath: ");
            userDragon.Breath = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter Location: ");
            userDragon.Located = Console.ReadLine();
            Console.WriteLine();

            dragons.Add(userDragon);
            Console.WriteLine("Dragon has been successfully added.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display delete dragon
        /// </summary>
        /// <param name="dragons"></param>
        static void DisplayDeleteDragon(List<Dragon> dragons)
        {
            {
                DisplayHeader("Delete A Dragon");

                foreach (Dragon dragon in dragons)
                {
                    Console.WriteLine(dragon.Name);
                }
                Console.WriteLine();

                Console.Write("Enter Name: ");
                string dragonName = Console.ReadLine();
                Console.WriteLine();
                //
                // get dragon and delete
                //
                bool found = false;
                {

                }
                foreach (Dragon dragon in dragons)
                {
                if (dragon.Name.ToUpper() == dragonName.ToUpper())
                    {   
                        dragons.Remove(dragon);
                        Console.WriteLine("Dragon successfully deleted");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Unable to locate dragon named {dragonName}.");
                }

                DisplayContinuePrompt();
            }
        }

        /// <summary>
        /// display all dragons info
        /// </summary>
        /// <param name="dragons"></param>
        static void DisplayAllDragonsInfo(List<Dragon> dragons)
        {
            DisplayHeader("Display All Dragons");

            Console.WriteLine("Name".PadRight(30) + "Age".PadRight(30) + "Breath".PadRight(30) + "Located In".PadRight(30));
            Console.WriteLine(new string('_', 120));
            foreach (Dragon dragon in dragons)
            {
                Console.WriteLine(dragon.Name.PadRight(30) + dragon.Age.ToString().PadRight(30) + dragon.Breath.PadRight(30) + dragon.Located.PadRight(30));
                Console.WriteLine();
            }

            DisplayContinuePrompt();
        }
        
        static void DisplayMenu(string dataPath)
        {
            List<Dragon> dragons = InitializeAllDragons();

            string menuChoice;
            bool exiting = false;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Dragons");
                Console.WriteLine("\tB) Display Dragon Information For Specific Dragon");
                Console.WriteLine("\tC) Add a Dragon");
                Console.WriteLine("\tD) Delete a Dragon");
                Console.WriteLine("\tE) Display All Dragon Information");
                //Console.WriteLine("\tF) Read From Dragon File");
                Console.WriteLine("\tF) Write To Dragon File");
                Console.WriteLine("\tG) Exit");

                Console.WriteLine();
                Console.Write("\tEnter Choice: ");
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
                        DisplayAddDragon(dragons);
                        break;

                    case "D":
                    case "d":
                        DisplayDeleteDragon(dragons);
                        break;

                    case "E":
                    case "e":
                        DisplayAllDragonsInfo(dragons);
                        break;

                    //case "F":
                    //case "f":
                    //    dragons = DisplayLoadDragonsFromFile(dataPath);
                        break;

                    case "F":
                    case "f":
                        DisplaySaveDragonsToFile(dataPath, dragons);
                        break;

                    case "G":
                    case "g":
                        exiting = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter from the menu choice.");

                        DisplayContinuePrompt();
                        break;
                }
            }
        }

        /// <summary>
        /// save dragons to file
        /// </summary>
        /// <param name="dataPath"></param>
        /// <param name="dragons"></param>
        private static void DisplaySaveDragonsToFile(string dataPath, List<Dragon> dragons)
        {
            DisplayHeader("Save Dragons to File");

            Console.WriteLine($"\tThe list of dragons will be saved to '{dataPath}'.");
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
            //
            // try to write the list of dragons to the file
            //
            try
            {
                WriteDragonsToCsvFile(dataPath, dragons);
                Console.WriteLine("\tThe dragons were successfully saved to the file.");
            }
            catch (Exception e)// catch any exception thrown by the write method
            {
                Console.WriteLine("\tThe following error occurred when writing to the file.");
                Console.WriteLine(e.Message);
            }

            DisplayContinuePrompt();
        }

        ///// <summary>
        ///// load dragons from file
        ///// </summary>
        ///// <param name="dataPath"></param>
        ///// <returns></returns>
        //private static List<Dragon> DisplayLoadDragonsFromFile(string dataPath)
        //{
        //    List<Dragon> dragons = new List<Dragon>();

        //    DisplayHeader("Load Dragons from File");

        //    Console.WriteLine($"\tThe list of dragons will be loaded from '{dataPath}'.");
        //    Console.WriteLine("\t\tPress any key to continue.");
        //    Console.ReadKey();
        //    Console.WriteLine(new string('_', 100));            
        //    //
        //    // try to read the dragons from the data file into a list
        //    //
        //    try
        //    {
        //        dragons = ReadDragonsFromCsvFile(dataPath);
        //        Console.WriteLine("\tThe dragons were successfully loaded from the file.");
        //    }
        //    catch (Exception e) // catch any exception thrown by the read method
        //    {
        //        Console.Write("The following error occurred when reading from the file: ");
        //        Console.WriteLine(e.Message);
        //    }

        //    DisplayContinuePrompt();

        //    return dragons;
        //}

        /// <summary>
        /// write dragons to file
        /// </summary>
        /// <param name="dataPath"></param>
        /// <param name="dragons"></param>
        static void WriteDragonsToCsvFile(string dataPath, List<Dragon> dragons)
        {
            string dragonString;

            List<string> dragonStringList = new List<string>();

            //
            // build the list to write to the text file line by line
            //
            foreach (Dragon dragon in dragons)
            {
                dragonString =
                    dragon.Name + ", " +
                    dragon.Breath + ", " +
                    dragon.Age + ", " +
                    dragon.Located;

                dragonStringList.Add(dragonString);
            }

            //
            // write the list of strings (dragons) to the data file
            //
            try
            {
                File.WriteAllLines(dataPath, dragonStringList);
            }
            catch (Exception) // throw any exception up to the calling method
            {
                throw;
            }

        }

        ///// <summary>
        ///// read dragons from file
        ///// </summary>
        ///// <param name="dataFile"></param>
        ///// <returns></returns>
        //static List<Dragon> ReadDragonsFromCsvFile(string dataFile)
        //{
        //    const char delineator = ',';

        //    List<string> dragonStringList = new List<string>();
        //    List<Dragon> dragonObjectList = new List<Dragon>();
        //    Dragon tempDragon = new Dragon();

        //    //
        //    // read each line and put it into an array and convert the array to a list
        //    //
        //    try
        //    {
        //        dragonStringList = File.ReadAllLines(dataFile).ToList();
        //    }
        //    catch (Exception) // throw any exception up to the calling method
        //    {
        //        throw;
        //    }

        //    //
        //    // create dragon object for each line of data read and fill in the property values
        //    //
        //    foreach (string dragonString in dragonStringList)
        //    {
        //        tempDragon = new Dragon();

        //        // use the Split method and the delineator on the array to separate each property into an array of properties
        //        string[] properties = dragonString.Split(delineator);
                
        //        tempDragon.Name = properties[0];
        //        tempDragon.Breath = properties[1];
        //        tempDragon.Age = Convert.ToInt32(properties[2]);

        //        dragonObjectList.Add(tempDragon);
        //        Console.WriteLine();
        //    }

        //    return dragonObjectList;
        //}

        #region HELPER METHODS

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Dragonology");
            Console.WriteLine();
            Console.WriteLine("In this application you will be able to discover certain dragons as well as adding");
            Console.WriteLine("and deleting your own dragons. Let's explore the world of dragons together!"); 
            Console.WriteLine();
            Console.WriteLine("INSTRUCTIONS: Use the menu to nagivate between choices.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
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