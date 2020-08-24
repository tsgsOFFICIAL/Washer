#region Imports / Usings
using System;
using System.Threading.Tasks;
#endregion

namespace Washer
    {
    class Program
        {
        /// <summary>
        /// Main method, start here!
        /// </summary>
        /// <param name="args">Passed arguments will be treated as parameters under Main method</param>
        static void Main(string[] args)
            {
            Console.Title = "EZ Washer by tsgs"; //Change the title
            ReadAsciiMessage(@"Messages/WelcomeMsg.tsgs"); //Read and display ascii welcome message

            System.Threading.Thread.Sleep(750); //Wait for 0.75 seconds

            Washer myWasher = new Washer(); //Initialize/Generate a new instance of a Washer, called myWasher

            bool runLoop = true;
            while (runLoop)
                {
                Display(myWasher); //Update the display
                switch (Console.ReadKey(true).KeyChar)
                    {
                    case '1': //Toggle the power on and off
                        myWasher.TogglePower();
                        break;
                    case '2': //Set the program, and start the centrifuge
                        if (myWasher.RunningProgram == "nothing")
                            {
                            if (myWasher.PowerState == "off")
                                {
                                Console.WriteLine("Make sure you plug the machine in first!");
                                }
                            else if (myWasher.DoorState == "open")
                                {
                                Console.WriteLine("Please close the door before washing!");
                                }
                            else if (myWasher.Weight == "0")
                                {
                                Console.WriteLine("You need to load some clothes into the machine!");
                                }
                            else
                                {

                                Console.WriteLine("What program do you want to run?\nYour options are:\n");
                                foreach (string program in Enum.GetNames(typeof(Washer.Program)))
                                    {
                                    Console.WriteLine("\"{0}\"", program);
                                    }
                                Console.Write("Program: ");

                                if (!myWasher.Start(Console.ReadLine()))
                                    {
                                    Console.WriteLine("Check your spelling!");
                                    }
                                }
                            }
                        else
                            {
                            Console.WriteLine("Already running {0}", myWasher.RunningProgram);
                            }
                        System.Threading.Thread.Sleep(500);
                        break;
                    case '3': //Stop the centrifuge
                        myWasher.Stop();
                        break;
                    case '4': //Open/Close the door
                        myWasher.ToggleDoor();
                        break;
                    case '5': //Load clothes into the machine
                        if (myWasher.DoorState == "open")
                            {

                            Console.Clear();
                            Console.WriteLine("Enter the color and how much your clothes weigh in grams");
                            Console.Write("\nColor: ");
                            string _color = Console.ReadLine();
                            int _weight = 0;
                            Console.Write("\nWeight in grams: ");
                            try
                                {
                                _weight = Convert.ToInt32(Console.ReadLine());
                                if (_weight > 0 && _weight <= 2000)
                                    {
                                    myWasher.LoadClothes(_color, _weight);
                                    }
                                else
                                    {
                                    Console.WriteLine("This machine can only handle 2000 gr. please enter a lower value!");
                                    System.Threading.Thread.Sleep(750);
                                    }
                                }
                            catch (Exception)
                                {
                                Console.WriteLine("The weight you entered is not in grams! Please use ONLY numbers!");
                                }
                            }
                        else
                            {
                            Console.WriteLine("Please open the door before you load your clothes!");
                            System.Threading.Thread.Sleep(500);
                            }
                        break;
                    case '6': //Unload clothes
                        myWasher.UnloadClothes();
                        break;
                    case '7': //Exit the program
                        Console.Clear(); //Clear the console window
                        runLoop = false;
                        break;
                    }
                }


            //Exit
            ReadAsciiMessage(@"Messages/ExitMsg.tsgs");
            Console.ReadKey(true);
            Environment.Exit(0); //Exit with error code '0'
            }

        /// <summary>
        /// Read Ascii Message 
        /// </summary>
        /// <param name="filePath"></param>
        private static void ReadAsciiMessage(string filePath)
            {
            string[] msg = System.IO.File.ReadAllLines(filePath);
            foreach (string line in msg)
                {
                Console.WriteLine(line);
                }
            }

        private static void Display(Washer washer)
            {
            Console.Clear();
            Console.WriteLine("Controls:");
            Console.WriteLine("Press (1) to toggle power");
            Console.WriteLine("Press (2) to toggle the centrifuge running");
            Console.WriteLine("Press (3) to stop the centrifuge");
            Console.WriteLine("Press (4) to open/close the door");
            Console.WriteLine("Press (5) to load your clothes into the machine");
            Console.WriteLine("Press (6) unload your clothes from the machine");
            Console.WriteLine("Press (7) to exit\n");
            Console.WriteLine("Power state is {0}", washer.PowerState);
            Console.WriteLine("Centrifuge state is {0}", washer.CentrifugeState);
            Console.WriteLine("Current program is {0}", washer.RunningProgram);
            Console.WriteLine("Temperature is {0}\u00B0", washer.Temperature);
            Console.WriteLine("Weight is {0} kg", washer.Weight);
            Console.WriteLine("The door is {0}", washer.DoorState);
            Console.WriteLine("The clothes are {0}", washer.ClothesState);
            }

        }
    }
