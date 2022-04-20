using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint_upgraded
{
    public struct Position
    {
        public int x;
        public int y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[30, 30];
            Position playerPosition = new Position();
            Position exitPosition = new Position();
            playerPosition = GetRandomPosition();
            exitPosition = GetRandomPosition();
            GenerateMaze(maze, playerPosition, exitPosition);
            ShowMaze(maze);
        }

        static void GenerateMaze(char[,] maze, Position playerPosition, Position exitPosition)
        {
            Random rnd = new Random();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for(int y = 0; y < maze.GetLength(1); y++)
                {
                    if(i == 0 || i == 29 || y == 0 || y == 29 || rnd.Next(1, 10) <= 3)
                    {
                        maze[i, y] = '#';
                    }
                }
            }
            
            maze[playerPosition.x, playerPosition.y] = '@';
            maze[exitPosition.x, exitPosition.y] = '?';
        }

        static Position GetRandomPosition()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 28);
            int y = rnd.Next(1, 28);
            Position a = new Position();
            a.x = x;
            a.y = y;
            return a;
        }

        static void ShowMaze(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[i, y]);
                }
                Console.WriteLine();
            }
        }

        static void Move()
        {
            string answer = Console.ReadLine();
        }
    }
}
