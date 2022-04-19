using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ant
{
    public enum direction
    {
        left,
        right,
    }

    class location
    {
        private int x;
        public location(int x)
        {
            this.x = x;
        }
        public void moveLeft()
        {
            this.x = this.x - 1;
        }
        public void moveRight()
        {
            this.x = this.x + 1;
        }
        public int getLocation()
        {
            return this.x;
        }
    }
    class board
    {
        // create a 2d array to store the island
        public int island = 21;
        public location ant = new location(21);
        public board(int islandLength)
        {
            this.island = islandLength;
        }
        public bool isOnEdge()
        {
            if (ant.getLocation() == 0 || ant.getLocation() == this.island)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            // devlares local variables
            int tries = 0;
            int fails = 0;
            int islandLength = 0;
            bool validuserInput = false;
            string timesinput = "";
            int loops = 1;
            int totalTries = 0;
            int i = 0;

            // tries to get the island width from the user and checks if it is valid

            Console.WriteLine("Please enter in the length of the island");
            while (validuserInput == false)
            {
                try
                {
                    islandLength = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many times would you like to run the simulation?");
                    timesinput = Convert.ToString(Console.ReadLine());
                    try
                    {
                        loops = Convert.ToInt32(timesinput);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input, please try again");
                    }
                    validuserInput = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again");
                    fails++;
                    if (fails == 3)
                    {
                        Console.WriteLine("Too many tries");
                        Console.WriteLine("Defualting to standard (21)");
                        Console.WriteLine("------------------------------------------");
                        islandLength = 21;
                    }
                    else
                    {
                        // pass and repeat
                    }
                }
            }

            // creates the island

            board island = new board(Convert.ToInt32(islandLength / 2));

            // moves the ant

            while (loops >= i)
            {
                Console.WriteLine(loops);
                Console.WriteLine(tries);
                Console.WriteLine(i);
                Console.WriteLine(island.ant.getLocation());

                while (tries > 1000)
                {
                    if (island.isOnEdge() == true)
                    {
                        break;
                    }

                    // randomly gets a direction from the enum
                    Array values = Enum.GetValues(typeof(direction));
                    Random random = new Random();
                    direction randomDirection = (direction)values.GetValue(random.Next(values.Length));

                    // if it's left move the ant left else move the ant right

                    if (randomDirection == direction.left)
                    {
                        island.ant.moveLeft();
                    }
                    else
                    {
                        island.ant.moveRight();
                    }

                    // write the ant's current location add 1 to tries and wait to generate a new random number

                    Console.WriteLine(island.ant.getLocation());
                    tries = tries + 1;
                    totalTries = totalTries + tries;
                    Thread.Sleep(10);
                }
                i++;
            }

            // repeats back to the user if the ant made it off the island

            if (tries > 1000)
            {
                Console.WriteLine("The ant did not find a way off the island :(");
            }
            else
            {
                Console.WriteLine("The ant made it off the island in " + tries + " tries 🎉");
            }

            // if the user wants to repeat 100 times and take the average

            if (loops > 1)
            {
                int average = totalTries / loops;
                Console.WriteLine("The average number of tries to get off the island is " + average);
            }
        }
    }
}
