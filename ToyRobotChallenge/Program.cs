using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotChallenge 
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("***********Welcome to Toy Robot Application************");
            Console.WriteLine("The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units");
            Console.WriteLine("RULES:");
            Console.WriteLine("1. The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command");
            Console.WriteLine("2. MOVE will move the toy robot one unit forward in the direction it is currently facing.");
            Console.WriteLine("3. LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.");
            Console.WriteLine("4. REPORT will announce the X,Y and F of the robot.");
            Console.WriteLine("5. A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.");
            Console.WriteLine("6. EXIT will exit the application");
            Console.WriteLine("Application takes following commands:");
            Console.WriteLine("PLACE X,Y,F\r\nMOVE\r\nLEFT\r\nRIGHT\r\nREPORT");
            Console.WriteLine("****************************************************");
            ToyRobot toyRobot = new ToyRobot();
            String input = Console.ReadLine();
            bool firstinput = true;
            List<String> command;
            while(input.ToUpper() != "EXIT")
            {
                if (firstinput)
                {
                    if (validateFirstInput(input, out command))
                    {
                        firstinput = false;
                        toyRobot.Command(command);

                    }
                }
                else
                {
                    if (validateInput(input, out command))
                    {
                        toyRobot.Command(command);
                    }
                }
                input = Console.ReadLine();
            }
        }

        internal static bool validateInput(String input, out List<String> command)
        {
            bool result = true;
            command = new List<string>();
            char[] delimiterChars = { ' ','\t' };
            int x, y;
            String[] inputs = input.Trim().Split(",");
            if (inputs.Length == 3)
            {
                command = inputs[0].Split(delimiterChars).ToList();
                command.Add(inputs[1]);
                command.Add(inputs[2]);
                if (command[0].Trim().ToUpper() == "PLACE")
                {
                    if (int.TryParse(command[1], out x) && int.TryParse(command[2], out y))
                    {
                        if ((x > 5 || x < 0) || (y < 0 || y > 5))
                        {
                            result = false;
                            Console.WriteLine("Cannot place robot at {0} {1}", x, y);
                        }
                    }
                    else

                    {
                        result = false;
                        Console.WriteLine("Please provide valid X,Y values");
                    }
                }
                else
                {
                    Console.WriteLine("Command should be PLACE X,Y,F");
                    result = false;
                }
                if (command[3].Trim().ToUpper() != "NORTH" && command[3].Trim().ToUpper() != "SOUTH"
                    && command[3].Trim().ToUpper() != "EAST" && command[3].Trim().ToUpper() != "WEST")
                {
                    result = false;
                    Console.WriteLine("Robot should face North, South, East or West");
                }
            }
            else if(inputs.Length == 1)
            {
                if (inputs[0].Trim().ToUpper() != "LEFT" && inputs[0].Trim().ToUpper() != "RIGHT" 
                    && inputs[0].Trim().ToUpper() != "MOVE" && inputs[0].Trim().ToUpper() != "REPORT")
                {
                    Console.WriteLine("Command should be Left, Right, Move or Report");
                    result = false;
                }
                else
                {
                    command.Add(inputs[0]);
                }
            }
            return result;
        }

        internal static bool validateFirstInput(String input, out List<String> command)
        {
            String[] inputs = input.Split(",");
            command = new List<string>();
            if(inputs.Length == 3)
            {
                return validateInput(input, out command);
            }
            else
            {
                Console.WriteLine("First Command should be a PLACE command i.e. PLACE X,Y,F");
                return false;
            }
        }
    }
}