using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: 
    // Application Type: Console
    // Author: Jacob Post
    // Dated Created: 
    // Last Modified: 
    //
    // **************************************************

    class Program
    {
        public enum Command
        {
            NONE,
            MOVEFORWARD,
            MOVEBACKWARD,
            STOPMOTORS,
            WAIT,
            TURNRIGHT,
            TURNLEFT,
            LEDON,
            LEDOFF,
            GETLIGHT,
            GETTEMP,
            DONE
        }
        static void Main(string[] args)
        {
            string userResponse;
            bool ValidResponse = false;

            DefaultTheme();

            DisplayScreenHeader("Ask About Theme");
            Console.WriteLine("Would you like to change theme? [yes or no]");
            userResponse = Console.ReadLine().Trim().ToUpper();
            do
            {
                switch (userResponse)
                {
                    case "YES":

                        UpdateForegroundTheme();

                        UpdateBackgroundTheme();

                        ValidResponse = true;
                        break;
                    case "NO":
                        ValidResponse = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This is not a valid option");
                        break;
                }
            } while (!ValidResponse);
            
                DisplayWelcomeScreen();

                DisplayMainMenu();

                DisplayClosingScreen();
            
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayMainMenu()
        {
            //++++++++++++++++++++++++++++//
            // Instantiate a Finch Object //
            //++++++++++++++++++++++++++++//

            Finch finchRobot = new Finch();
            
            bool finchRobotConnected = false;
            bool quitApplication = false;
            string menuChoice;

            do
            {
                finchRobot.setLED(0, 0, 0);
                finchRobot.setMotors(0,0);
                finchRobot.noteOff();
                DisplayScreenHeader("Main Menu");

                //+++++++++++++++++++++++++++//
                // Get Menu Choice from User //
                //+++++++++++++++++++++++++++//

                Console.WriteLine("a) Connect Finch Robot");
                Console.WriteLine("b) Talent Show");
                Console.WriteLine("c) Data Recorder");
                Console.WriteLine("d) Alarm System");
                Console.WriteLine("e) User Programming");
                Console.WriteLine("f) Disconnect Finch Robot");
                Console.WriteLine("q) Exit Program");
                Console.WriteLine("Enter Choice:");
                menuChoice = Console.ReadLine().ToUpper().Trim();

                //+++++++++++++++++++++//
                // Process Menu Choice //
                //+++++++++++++++++++++//

                switch (menuChoice)
                {
                    case "A":
                        if (finchRobotConnected)
                        {
                            Console.Clear();
                            Console.WriteLine("Finch Robot already connected, goober. Returning to menu.");
                            DisplayContinuePrompt();
                        }

                        else
                        {
                            finchRobotConnected = DisplayConnectFinchRobot(finchRobot);
                        }
                        
                        break;
                    case "B":
                        if (finchRobotConnected)
                        {
                            DisplayTalentShow(finchRobot);
                        }

                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch Robot not connected. Return to main menu and connect.");
                            DisplayContinuePrompt();
                        }

                        break;
                    case "C":
                        if (finchRobotConnected)
                        {
                            DisplayDataRecorder(finchRobot);
                        }

                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch Robot not connected. Return to main menu and connect.");
                            DisplayContinuePrompt();
                        }

                        break;
                    case "D":
                        if (finchRobotConnected)
                        {
                            DisplayAlarmSystem(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch Robot not connected. Return to main menu and connect.");
                            DisplayContinuePrompt();
                        }
                        break;
                    case "E":
                        if (finchRobotConnected)
                        {
                            DisplayUserProgramming(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch Robot not connected. Return to main menu and connect.");
                            DisplayContinuePrompt();
                        }
                        break;
                    case "F":
                        if (!finchRobotConnected)
                        {
                            Console.WriteLine("Your Finch bot is already disconnected, you goober.");
                        }
                        else
                        {
                            DisplayDisconnectFinchRobot(finchRobot);
                        }
                        break;
                    case "Q":
                        quitApplication = true;
                        break;
                    default:
                        Console.WriteLine("\t***************************");
                        Console.WriteLine("\tPlease Enter A Menu Choice.");
                        Console.WriteLine("\t***************************");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);

        }
        #region Background, Foreground, And Its Methods
        static void DefaultTheme()
        {
            string FdataPath = @"Data\FTheme.txt";
            string foregroundColorString;
            ConsoleColor foregroundColor;

            foregroundColorString = File.ReadAllText(FdataPath);
            Enum.TryParse(foregroundColorString, out foregroundColor);
            Console.ForegroundColor = foregroundColor;

            string BdataPath = @"Data\BTheme.txt";
            string backgroundColorString;
            ConsoleColor backgroundColor;

            backgroundColorString = File.ReadAllText(BdataPath);
            Enum.TryParse(backgroundColorString, out backgroundColor);
            Console.BackgroundColor = backgroundColor;
        }
        static void UpdateForegroundTheme()
        {
            string userResponse;
            string foregroundColorString;
            ConsoleColor foregroundColor;
            string dataPath = @"Data\FTheme.txt";
            bool ValidResponse = false;

            do
            {
                DisplayScreenHeader("Get Theme Foreground");
                Console.WriteLine("Enter The color you would like the text to be.");
                Console.WriteLine("Color Options: Red, Green, Yellow, White, Cyan, Black, Blue,");
                Console.WriteLine("DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta,");
                Console.WriteLine("DarkRed, DarkYellow, Gray, and Magenta. ");
                Console.WriteLine("IMPORTANT: Write Colors as written");
                Console.Write("Enter the Desired Text Color: ");
                userResponse = Console.ReadLine().Trim();
                switch (userResponse)
                {
                    case "Red":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Green":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Yellow":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "White":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Cyan":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Black":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Blue":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkBlue":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkCyan":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkGray":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkGreen":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkMagenta":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkRed":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkYellow":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Gray":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Magenta":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This is Not a Valid Color Option.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!ValidResponse);

            foregroundColorString = File.ReadAllText(dataPath);
            Enum.TryParse(foregroundColorString, out foregroundColor);
            Console.ForegroundColor = foregroundColor;

        }
        static void UpdateBackgroundTheme()
        {
            string userResponse;
            string foregroundColorString;
            ConsoleColor backgroundColor;
            string dataPath = @"Data\BTheme.txt";
            bool ValidResponse = false;

            do
            {                
                DisplayScreenHeader("Get Theme Background");
                Console.WriteLine("Enter The color you would like the Background to be.");
                Console.WriteLine("Color Options: Red, Green, Yellow, White, Cyan, Black, Blue,");
                Console.WriteLine("DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta,");
                Console.WriteLine("DarkRed, DarkYellow, Gray, and Magenta. ");
                Console.WriteLine("IMPORTANT: Write Colors as written");
                Console.Write("Enter the Desired Background Color: ");
                userResponse = Console.ReadLine().Trim();
                switch (userResponse)
                {
                    case "Red":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Green":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Yellow":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "White":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Cyan":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Black":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Blue":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkBlue":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkCyan":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkGray":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkGreen":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkMagenta":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkRed":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "DarkYellow":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Gray":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    case "Magenta":
                        ValidResponse = true;
                        File.WriteAllText(dataPath, userResponse);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This is Not a Valid Color Option.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!ValidResponse);

            foregroundColorString = File.ReadAllText(dataPath);
            Enum.TryParse(foregroundColorString, out backgroundColor);
            Console.BackgroundColor = backgroundColor;

        }
        #endregion

        #region Talent Show And Its Methods
        static void DisplayTalentShow(Finch finchRobot)
        {
            string TalentChoice;
            bool ValidInput = false;

            do
            {
                DisplayScreenHeader("Talent Show");
                Console.WriteLine("Finch robot is ready to perform!");
                Console.WriteLine("How would you like it to perform? [Normal or low pitch]");
                TalentChoice = Console.ReadLine().ToUpper().Trim();
                switch (TalentChoice)
                {
                    case "NORMAL":
                        DisplaySinging(finchRobot);
                        ValidInput = true;
                        break;

                    case "LOW":
                        DisplaySingingLow(finchRobot);
                        ValidInput = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid option");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!ValidInput);          

            Console.WriteLine("TA DA!");

            DisplayContinuePrompt();
        }

        static void DisplaySinging(Finch finchRobot)
        {
            finchRobot.noteOn(494);
            finchRobot.wait(500);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1760);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1975);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(988);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1760);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1975);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(988);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1760);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1975);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(2349);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(2349);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(1046);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(1318);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(2093);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);
            finchRobot.setMotors(0, 0);
        }

        static void DisplaySingingLow(Finch finchRobot)
        {
            finchRobot.noteOn(494);
            finchRobot.wait(500);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(440);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(494);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(247);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(440);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(494);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(247);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(440);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(494);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(587);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(587);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBL(finchRobot);
            DisplayLEDB(finchRobot);

            finchRobot.noteOn(262);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFR(finchRobot);
            DisplayLEDR(finchRobot);

            finchRobot.noteOn(330);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingFL(finchRobot);
            DisplayLEDG(finchRobot);

            finchRobot.noteOn(523);
            finchRobot.wait(250);
            finchRobot.noteOff();
            DisplayDancingBR(finchRobot);
            DisplayLEDB(finchRobot);
            finchRobot.setMotors(0, 0);
        }

        /// <summary>
        /// FR Foward Right, FL Foward Left, BR Backward Right, BL Backward Left
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayDancingFR(Finch finchRobot)
        {
            finchRobot.setMotors(0, 100);
        }
        static void DisplayDancingFL(Finch finchRobot)
        {
            finchRobot.setMotors(100, 0);
        }
        static void DisplayDancingBR(Finch finchRobot)
        {
            finchRobot.setMotors(0, -100);
        }
        static void DisplayDancingBL(Finch finchRobot)
        {
            finchRobot.setMotors(-100, 0);
        }

        /// <summary>
        /// LEDR Red, LEDG Green, LEDB Blue
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayLEDR(Finch finchRobot)
        {
            finchRobot.setLED(255, 0, 0);
        }
        static void DisplayLEDG(Finch finchRobot)
        {
            finchRobot.setLED(0, 255, 0);
        }
        static void DisplayLEDB(Finch finchRobot)
        {
            finchRobot.setLED(0, 0, 255);
        }

        //for (int i = 0; i < 3; i++)
        //{
        //    finchRobot.noteOn(1000);
        //    finchRobot.setLED(255, 0, 0);
        //    finchRobot.setMotors(255, 255);
        //    finchRobot.setLED(0, 0, 255);
        //    finchRobot.wait(500);
        //    finchRobot.noteOff();
        //    finchRobot.setLED(0, 255, 0);

        //    finchRobot.noteOn(750);
        //    finchRobot.setLED(255, 0, 0);
        //    finchRobot.setMotors(-100, 100);
        //    finchRobot.setLED(0, 0, 255);
        //    finchRobot.wait(500);
        //    finchRobot.noteOff();
        //    finchRobot.setLED(0, 255, 0);

        //    finchRobot.noteOn(1250);
        //    finchRobot.setLED(255, 0, 0);
        //    finchRobot.setMotors(100, -100);
        //    finchRobot.setLED(0, 0, 255);
        //    finchRobot.wait(500);
        //    finchRobot.noteOff();
        //    finchRobot.setLED(0, 255, 0);

        //    finchRobot.noteOn(1100);
        //    finchRobot.setLED(255, 0, 0);
        //    finchRobot.setMotors(-255, -255);
        //    finchRobot.setLED(0, 0, 255);
        //    finchRobot.wait(500);
        //    finchRobot.noteOff();
        //    finchRobot.setLED(0, 255, 0);
        //}
        //finchRobot.setMotors(0, 0);
        #endregion

        #region Data Recorder And Its Methods
        static void DisplayDataRecorder(Finch finchRobot)
        {
            double dataPointFrequency;
            int numberOfDataPoints;
            string DataType;

            DisplayScreenHeader("Data Recorder");

            //+++++++++++++++++//
            // Inform the user //
            //+++++++++++++++++//

            DataType = DisplayDataTypeSelection();
            dataPointFrequency = DisplayGetDataPointFrequency();
            numberOfDataPoints = DisplayGetNumberOfDataPoints();

            switch(DataType)
            { 
                case "TEMPERATURE":
                    double[] Temperatures = new double[numberOfDataPoints];

                    DisplayGetTemperatureData(numberOfDataPoints, dataPointFrequency, Temperatures, finchRobot);

                    DisplayTemperatureData(Temperatures);
                    break;
                case "LIGHT":            
                    double[] LightLevels = new double[numberOfDataPoints];

                    DisplayGetLightData(numberOfDataPoints, dataPointFrequency, LightLevels, finchRobot);

                    DisplayLightData(LightLevels);
                    break;
                default:
                    DisplayDataTypeSelection();
                    break;
            }
            
        }
        static string DisplayDataTypeSelection()
        {
            string menuChoice;
            bool ValidInput = false;
            
            do
            {
                DisplayScreenHeader("Get Data Type");
                Console.WriteLine("Would you like record light or temperature data?");
                menuChoice = Console.ReadLine().ToUpper().Trim();
                switch (menuChoice)
                {
                    case "TEMPERATURE":
                        ValidInput = true;
                        DisplayContinuePrompt();
                        break;
                    case "LIGHT":
                        ValidInput = true;
                        DisplayContinuePrompt();
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!ValidInput);

            DisplayContinuePrompt();
            return menuChoice;
        }
        static double DisplayGetDataPointFrequency()
        {
            //++++++++++++++++++++//
            // NEW PARSING METHOD //
            //++++++++++++++++++++//
            bool ValidInput = false;
            double dataPointFrequency;

            do
            {
                DisplayScreenHeader("Data Point Frequency");
                Console.Write("Enter Data Point Frequency in Seconds: ");
                ValidInput = double.TryParse(Console.ReadLine(), out dataPointFrequency);
                if (!ValidInput)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Value.");
                    Console.ReadKey();
                }
            } while (!ValidInput);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }
        static int DisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            bool ValidInput = false;

            do
            {
                DisplayScreenHeader("Number of Data points");
                Console.Write("Enter Number of Data Points: ");
                ValidInput = int.TryParse(Console.ReadLine(), out numberOfDataPoints);
                if (!ValidInput)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Value.");
                    Console.ReadKey();
                }
            } while (!ValidInput);

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }
        static void DisplayGetTemperatureData(int numberofDataPoints, double DataPointFrequency, double[] Temperatures, Finch finchRobot)
        {
            DisplayScreenHeader("Get Data");

            //++++++++++++++++++++++++++++++++++//
            // Provide The User Info and Prompt //
            //++++++++++++++++++++++++++++++++++//

            //+++++++++++++//
            // Record Data //
            //+++++++++++++//

            for (int index = 0; index < numberofDataPoints; index++)
            {
                Temperatures[index] = finchRobot.getTemperature() * (9 / 5) + 32;
                int milliSeconds = ((int)(DataPointFrequency * 1000));
                finchRobot.wait(milliSeconds);

                //+++++++++++//
                // Echo Data //
                //+++++++++++//

                Console.WriteLine($"Temperature {index + 1}: {Temperatures[index]}\u00B0F");
            }            
        }
        static void DisplayTemperatureData(double[] temperature)
        {
            DisplayScreenHeader("Temperature Data");

            for (int index = 0; index < temperature.Length; index++)
            {
                Console.WriteLine($"Temperature {index + 1}: {temperature[index]}\u00B0F");
            }
            DisplayContinuePrompt();
        }
        static void DisplayGetLightData(int numberofDataPoints, double DataPointFrequency, double[] Lightlevels, Finch finchRobot)
        {
            DisplayScreenHeader("Get Data");

            //++++++++++++++++++++++++++++++++++//
            // Provide The User Info and Prompt //
            //++++++++++++++++++++++++++++++++++//

            //+++++++++++++//
            // Record Data //
            //+++++++++++++//

            for (int index = 0; index < numberofDataPoints; index++)
            {
                Lightlevels[index] = finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor() / (2);
                int milliSeconds = ((int)(DataPointFrequency * 1000));
                finchRobot.wait(milliSeconds);

                //+++++++++++//
                // Echo Data //
                //+++++++++++//

                Console.WriteLine($"Light Level {index + 1}: {Lightlevels[index]}");
            }
        }
        static void DisplayLightData(double[] LightLevels)
        {
            DisplayScreenHeader("Light Level Data");

            for (int index = 0; index < LightLevels.Length; index++)
            {
                Console.WriteLine($"Light Level {index + 1}: {LightLevels[index]}");
            }
            DisplayContinuePrompt();
        }       
        #endregion

        #region Alarm System And Its Methods
        static void DisplayAlarmSystem(Finch finchrobot)
        {
            string alarmType;
            int maxseconds;
            double maxthreshold;
            bool thresholdExceeded;

            DisplayScreenHeader("Alarm System");

            alarmType = DisplayGetAlarmType();
            maxseconds = DisplayGetMaxSeconds();
            maxthreshold = DisplayGetThreshold(finchrobot, alarmType);

            if (alarmType == "LIGHT")
            {
                thresholdExceeded = MonitorCurrentLightLevel(finchrobot, maxthreshold, maxseconds);
            }
            else
            {
                thresholdExceeded = MonitorCurrentTemperature(finchrobot, maxthreshold, maxseconds);
            }


            if (thresholdExceeded)
            {
                if (alarmType == "LIGHT")
                {
                    finchrobot.setLED(255, 0, 0);
                    finchrobot.noteOn(100);
                    Console.WriteLine("Maximum Light Level Exceeded");
                }
                else
                {
                    finchrobot.setLED(255, 0, 0);
                    finchrobot.noteOn(100);
                    Console.WriteLine("Maximum Temperature Exceeded");
                }
            }
            else
            {
                Console.WriteLine("Maximum Monitoring Time Exceeded");
            }


            DisplayContinuePrompt();
        }
        static string DisplayGetAlarmType()
        {
            bool ValidInput = false;
            string AlarmType;
            do
            {
                DisplayScreenHeader("Get Alarm Type");
                Console.WriteLine("Alarm Type [light or temperature]");
                AlarmType = Console.ReadLine().ToUpper().Trim();
                switch (AlarmType)
                {
                    case "LIGHT":
                        ValidInput = true;
                        DisplayContinuePrompt();
                        break;
                    case "TEMPERATURE":
                        ValidInput = true;
                        DisplayContinuePrompt();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please choose either light or temperature");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!ValidInput);
            
            return AlarmType;
        }
        static int DisplayGetMaxSeconds()
        {
            int MaxSeconds;
            bool ValidInput;
            do
            {
                DisplayScreenHeader("Get Monitoring Time");
                Console.Write("Seconds to Monitor: ");
                ValidInput = int.TryParse(Console.ReadLine(), out MaxSeconds);
                if (!ValidInput)
                {
                    Console.WriteLine("Please Enter a Valid Input.");
                    DisplayContinuePrompt();
                }
            } while (!ValidInput);

            DisplayContinuePrompt();

            return MaxSeconds;
        }
        static bool MonitorCurrentLightLevel(Finch finchrobot, double threshold, int maxseconds)
        {
            bool thresholdExceeded = false;
            int currentLightLevel;
            double seconds = 0;

            while (!thresholdExceeded && seconds <= maxseconds)
            {
                finchrobot.setLED(0, 255, 0);
                DisplayScreenHeader("Monitoring Light Levels");
                currentLightLevel = finchrobot.getLeftLightSensor();
                Console.WriteLine($"Maximum Light Level: {threshold}");
                Console.WriteLine($"Current Light Level: {currentLightLevel}");

                if (currentLightLevel > threshold)
                {
                    thresholdExceeded = true;
                }

                finchrobot.wait(500);
                seconds += 0.5;
            }

            return thresholdExceeded;
        }
        static bool MonitorCurrentTemperature(Finch finchrobot, double maxthreshold, int maxseconds)
        {
            bool thresholdExceeded = false;
            double currentTemperature;
            double seconds = 0;

            while (!thresholdExceeded && seconds <= maxseconds)
            {
                finchrobot.setLED(0, 255, 0);
                DisplayScreenHeader("Monitoring Temperature");
                currentTemperature = finchrobot.getTemperature() * (9 / 5) + 32;
                Console.WriteLine($"Maximum Temperature: {maxthreshold}\u00B0F");
                Console.WriteLine($"Current Temperature: {currentTemperature}\u00B0F");

                if (currentTemperature > maxthreshold)
                {
                    thresholdExceeded = true;
                }

                finchrobot.wait(500);
                seconds += 0.5;
            }

            return thresholdExceeded;
        }
        static double DisplayGetThreshold(Finch finchRobot, string alarmType)
        {
            double maxthreshold = 0;
            bool ValidInput = false;
            
            do
            {
                DisplayScreenHeader("Threshold Value");

                switch (alarmType)
                {
                    case "LIGHT":
                        Console.WriteLine($"Current Light Level: {finchRobot.getLeftLightSensor()}");
                        Console.Write("Enter Maximum Light Level [0 - 255]:");
                        ValidInput = double.TryParse(Console.ReadLine(), out maxthreshold);
                        if (!ValidInput)
                        {
                            Console.WriteLine("Invalid input, you goober.");
                            DisplayContinuePrompt();
                        }
                        //Console.WriteLine($"Current Light Level: {finchRobot.getLeftLightSensor()}");
                        //Console.Write("Enter Minimum Light Level [0 - 255]:");
                        //ValidInput = double.TryParse(Console.ReadLine(), out minthreshold);
                        //if (!ValidInput)
                        //{
                        //    Console.WriteLine("Invalid input, you goober.");
                        //    DisplayContinuePrompt();
                        //}
                        break;
                    case "TEMPERATURE":
                        Console.WriteLine($"Current Temperature: {finchRobot.getTemperature() * (9 / 5) + 32}\u00B0F");
                        Console.Write("Enter Maximum Temperature:");
                        ValidInput = double.TryParse(Console.ReadLine(), out maxthreshold);
                        if (!ValidInput)
                        {
                            Console.WriteLine("Invalid input, you goober.");
                            DisplayContinuePrompt();
                        }
                        //Console.WriteLine($"Current Temperature: {finchRobot.getTemperature() * (9 / 5) + 32}\u00B0F");
                        //Console.Write("Enter Minimum Temperature:");
                        //ValidInput = double.TryParse(Console.ReadLine(), out minthreshold);
                        //if (!ValidInput)
                        //{
                        //    Console.WriteLine("Invalid input, you goober.");
                        //    DisplayContinuePrompt();
                        //}
                        break;
                    default:
                        break;
                }
            } while (!ValidInput);

            DisplayContinuePrompt();

            return maxthreshold;
        }
        #endregion

        #region User Programming And Its Methods
        static void DisplayUserProgramming(Finch finchRobot)
        {
            (int motorSpeed, int ledBrightness, int waitSeconds) CommandParameters;
            CommandParameters.motorSpeed = 0;
            CommandParameters.ledBrightness = 0;
            CommandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();

            string menuChoice;
            bool quitApplication = false;

            do
            {
                DisplayScreenHeader("Main Menu");

                //++++++++++++++++++++++//
                // Get User Menu Choice //
                //++++++++++++++++++++++//

                Console.WriteLine("a) Set Command Parameters");
                Console.WriteLine("b) Add Commands");
                Console.WriteLine("c) View Commands");
                Console.WriteLine("d) Execute Commands");
                Console.WriteLine("e) Save Commands To Text File");
                Console.WriteLine("f) Load Commands From Text File");
                Console.WriteLine("q) Quit");
                Console.Write("Enter Choice:");

                menuChoice = Console.ReadLine().ToUpper().Trim();



                //++++++++++++++++++++++++++//
                // Process User Menu Choice //
                //++++++++++++++++++++++++++//

                switch (menuChoice)
                {
                    case "A":
                        CommandParameters = DisplayGetFinchCommandParameters();
                        break;

                    case "B":
                        DisplayGetFinchCommands(commands);
                        break;

                    case "C":
                        DisplayFinchCommands(commands);
                        break;

                    case "D":
                        DisplayExecuteCommands(finchRobot, commands, CommandParameters);
                        break;

                    case "E":
                        DisplayWriteUserProgrammingData(commands);
                        break;

                    case "F":
                        commands = DisplayReadProgrammingData();
                        break;

                    case "Q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }
        static (int motorSpeed, int ledBrightness, int waitSeconds) DisplayGetFinchCommandParameters()
        {
            (int motorSpeed, int ledBrightness, int waitSeconds) CommandParameters;
            CommandParameters.motorSpeed = 0;
            CommandParameters.ledBrightness = 0;
            CommandParameters.waitSeconds = 0;
            bool ValidResponse = false;
            string userResponse;
            DisplayScreenHeader("Command Parameters");

            do
            {
                Console.Write("Enter Motor Speed [1-255]:");
                userResponse = Console.ReadLine();
                ValidResponse = int.TryParse(userResponse, out CommandParameters.motorSpeed);
                if (!ValidResponse)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Value");
                }
            } while (!ValidResponse);

            do
            {                
                Console.Write("Enter LED Brightness [1-255]:");
                userResponse = Console.ReadLine();
                ValidResponse = int.TryParse(userResponse, out CommandParameters.ledBrightness);
                if (!ValidResponse)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Value");
                }
            } while (!ValidResponse);

            do
            {
                Console.Write("Enter Seconds to wait for command:");
                userResponse = Console.ReadLine();
                ValidResponse = int.TryParse(userResponse, out CommandParameters.waitSeconds);
                if (!ValidResponse)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter a Valid Value");
                }
            } while (!ValidResponse);          

            DisplayContinuePrompt();
            return CommandParameters;
        }
        static void DisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;
            string userResponse;
            bool FinalResponse = false;

            DisplayScreenHeader("Finch Robot Commands");
            Console.WriteLine("The commands: " +
                "Moveforward, " +
                "Movebackward, " +
                "Stopmotors, " +
                "Wait, " +
                "Turnright, ");
            Console.WriteLine("Turnleft, " +
                "LEDon, " +
                "LEDoff, " +
                "Done (use this when you are done entering commands.)");
            Console.WriteLine();

            do
            {
                Console.Write("Enter Command:");
                userResponse = Console.ReadLine().ToUpper();
                switch (userResponse)
                {
                    case "MOVEFORWARD":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "MOVEBACKWARD":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "STOPMOTORS":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "WAIT":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "TURNRIGHT":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "TURNLEFT":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "LEDON":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;

                    case "LEDOFF":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;
                    case "GETLIGHT":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;
                    case "GETTEMP":
                        Enum.TryParse(userResponse, out command);
                        commands.Add(command);
                        break;
                    case "DONE":
                        FinalResponse = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This is not a valid Command.");
                        DisplayContinuePrompt();
                        Console.WriteLine();
                        break;
                }               
            } while (!FinalResponse);

            //+++++++++++++++//
            // Echo Commands //
            //+++++++++++++++//

            DisplayContinuePrompt();
        }
        static void DisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Display Finch Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine(command);
            }

            DisplayContinuePrompt();
        }
        static void DisplayExecuteCommands(Finch finchRobot, List<Command> commands, (int motorSpeed, int ledBrightness, int waitSeconds) CommandParameters)
        {
            DisplayScreenHeader("Execute Finch Commands");

            int motorSpeed = CommandParameters.motorSpeed;
            int ledBrightness = CommandParameters.ledBrightness;
            int waitMilliSeconds = CommandParameters.waitSeconds * 1000;

            //++++++++++++++++//
            // Info and Pause //
            //++++++++++++++++//

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;
                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        finchRobot.wait(waitMilliSeconds);
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        finchRobot.wait(waitMilliSeconds);
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        break;
                    case Command.TURNRIGHT:
                        finchRobot.setMotors(0, motorSpeed);
                        finchRobot.wait(waitMilliSeconds);
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.TURNLEFT:
                        finchRobot.setMotors(motorSpeed, 0);
                        finchRobot.wait(waitMilliSeconds);
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        break;
                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        break;
                    case Command.GETLIGHT:
                        Console.WriteLine($"Light Levels:{finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor() / (2)}");
                        break;
                    case Command.GETTEMP:
                        Console.WriteLine($"Temperature:{finchRobot.getTemperature() * (9 / 5) + 32}\u00B0F");
                        break;
                    case Command.DONE:
                        break;
                    default:
                        break;
                }
            }

            DisplayContinuePrompt();
        }
        static void DisplayWriteUserProgrammingData(List<Command> commands)
        {
            string dataPath = @"Data\Data.txt";
            List<string> commandsString = new List<string>();

            DisplayScreenHeader("Write Commands to Data File");

            //++++++++++++++++++++++++++++++++++//
            // Create a list of command strings //
            //++++++++++++++++++++++++++++++++++//

            foreach (Command command in commands)
            {
                commandsString.Add(command.ToString());
            }

            Console.WriteLine("Ready to write to the data file");
            DisplayContinuePrompt();

            File.WriteAllLines(dataPath, commandsString.ToArray());

            Console.WriteLine();
            Console.WriteLine("Commands written to the data file.");

            DisplayContinuePrompt();
        }
        static List<Command> DisplayReadProgrammingData()
        {
            string dataPath = @"Data\Data.txt";
            List<Command> commands = new List<Command>();
            string[] commandsString;

            DisplayScreenHeader("Read Commands From Data File");

            Console.WriteLine("Ready to Read Commands from the Data File.");
            Console.WriteLine();

            commandsString = File.ReadAllLines(dataPath);

            Command command;
            foreach (string commandString in commandsString)
            {
                Enum.TryParse(commandString, out command);

                commands.Add(command);
            }

            Console.WriteLine("Data from file successfully read.");


            DisplayContinuePrompt();

            return commands;
        }       
        #endregion

        #region Finch Robot Management
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Disconnect Finch Robot.");

            Console.WriteLine();
            Console.WriteLine("Ready to disconnect the Finch robot.");
            DisplayContinuePrompt();
            
            finchRobot.noteOn(1000);
            finchRobot.wait(333);
            finchRobot.noteOff();
            finchRobot.noteOn(666);
            finchRobot.wait(333);
            finchRobot.noteOff();
            finchRobot.noteOn(333);
            finchRobot.wait(334);
            finchRobot.noteOff();

            finchRobot.disConnect();
            Console.WriteLine();
            Console.WriteLine("Finch robot is now disconnected.");

            DisplayContinuePrompt();
        }
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            bool finchRobotConnected;

            DisplayScreenHeader("Connect To Finch Robot");

            Console.WriteLine("Ready to connect to the Finch robot. Be sure to connect the USB cable to the robot and computer.");
            DisplayContinuePrompt();

            finchRobotConnected = finchRobot.connect();

            if (finchRobotConnected)
            {

                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(333);
                finchRobot.wait(333);
                finchRobot.noteOff();
                finchRobot.noteOn(666);
                finchRobot.wait(333);
                finchRobot.noteOff();
                finchRobot.noteOn(1000);
                finchRobot.wait(334);
                finchRobot.noteOff();

                Console.WriteLine();
                Console.WriteLine("Finch robot is now connected.");
                DisplayContinuePrompt();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to connect to the Finch robot.");
                DisplayContinuePrompt();
            }
            return finchRobotConnected;
        }
        #endregion        
            
        #region Helper Methods
        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        /// <summary>
        /// Display Closing Screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }
        #endregion
    }
}
