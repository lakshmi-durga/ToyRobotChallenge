using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge
{
    internal class ToyRobot
    {
        public int positionX;
        public int positionY;
        public String direction = String.Empty;
        Dictionary<String, String> LeftDic;
        Dictionary<String, String> RightDic;
        internal ToyRobot()
        {
            LeftDic = new Dictionary<String, String>() { 
                {"EAST", "NORTH"},
                {"WEST", "SOUTH"},
                {"NORTH", "WEST"},
                {"SOUTH", "EAST"}
            };

            RightDic = new Dictionary<String, String>()
            {
                {"EAST", "SOUTH"},
                {"WEST", "NORTH"},
                {"NORTH", "EAST"},
                {"SOUTH", "WEST"}
            };     
        }
        
        internal void Command(List<String> command)
        {     
            if (command.Count == 4)
            {
                Place(command);
            }
            else
            {
                switch (command[0].Trim().ToUpper())
                {
                    case "LEFT":
                        Left();
                        break;
                    case "RIGHT":
                        Right();
                        break;
                    case "MOVE":
                        Move();
                        break;
                    case "REPORT":
                        Report();
                        break;
                }
            }
        }

        internal void Place(List<String> command)
        {
            positionX = Convert.ToInt32(command[1].Trim());
            positionY = Convert.ToInt32(command[2].Trim());
            direction = command[3].Trim().ToUpper();
        }

        internal void Right()
        {
            direction = RightDic[direction];
            //switch (direction)
            //{
            //    case "NORTH":
            //        direction = "EAST";
            //        break;
            //    case "SOUTH":
            //        direction = "WEST";
            //        break;
            //    case "EAST":
            //        direction = "SOUTH"; 
            //        break;
            //    case "WEST":
            //        direction = "NORTH";
            //        break;
            //}

        }

        internal void Left()
        {
            direction = LeftDic[direction];
            //switch (direction)
            //{
            //    case "NORTH":
            //        direction = "WEST";
            //        break;
            //    case "SOUTH":
            //        direction = "EAST";
            //        break;
            //    case "EAST":
            //        direction = "NORTH";
            //        break;
            //    case "WEST":
            //        direction = "SOUTH";
            //        break;
            //}

        }

        internal void Move()
        {
            switch(direction)
            {
                case "NORTH":
                    if(positionY >= 0 && positionY < 5)
                        positionY = positionY + 1;
                    break;
                case "SOUTH":
                    if(positionY > 0 && positionY < 5)
                        positionY = positionY - 1;
                    break;
                case "EAST":
                    if (positionX >= 0 && positionX < 5)
                        positionX = positionX + 1;
                    break;
                case "WEST":
                    if (positionX > 0 && positionX < 5)
                        positionX = positionX - 1;
                    break;
            }
        }

        internal void Report()
        {
            Console.WriteLine("Current Position: " + positionX + " " + positionY + " " + direction);
        }
    }
}
