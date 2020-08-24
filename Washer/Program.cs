#region Imports / Usings
using System;
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
                    case '1':
                        myWasher.TogglePower();
                        break;
                    case '2':
                        if (myWasher.RunningProgram == "nothing")
                            {
                            Console.WriteLine("What program do you want to run?\nYour options are:\n");
                            foreach (string program in Enum.GetNames(typeof(Washer.Program)))
                                {
                                Console.WriteLine("\"{0}\"", program);
                                }
                            Console.Write("Program: ");

                            if (!myWasher.Start(Console.ReadLine()))
                                {
                                Console.WriteLine("Make sure you plug the machine in, and check your spelling!");
                                System.Threading.Thread.Sleep(500);
                                }
                            }
                        else
                            {
                            Console.WriteLine("Already running {0}", myWasher.RunningProgram);
                            System.Threading.Thread.Sleep(500);
                            }
                        break;
                    case '3':
                        myWasher.Stop();
                        break;
                    case '4':
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
            Console.WriteLine("Press (4) to exit\n");
            Console.WriteLine("Power state is {0}", washer.PowerState);
            Console.WriteLine("Centrifuge state is {0}", washer.CentrifugeState);
            Console.WriteLine("Current program is {0}", washer.RunningProgram);
            Console.WriteLine("Temperature is {0}\u00B0", washer.Temperature);
            Console.WriteLine("Weight is {0} kg", washer.Weight);
            Console.WriteLine("The door is {0}", washer.DoorState);
            }

        }
    }
