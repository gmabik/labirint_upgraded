using System;

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
            GetPlayerAndExitPositions(out playerPosition, out exitPosition);
            GenerateMaze(maze, playerPosition, exitPosition);
            ShowMaze(maze);

            while (playerPosition.x != exitPosition.x || playerPosition.y != exitPosition.y)
            {
                Move(maze, playerPosition, out playerPosition);
                ShowMaze(maze);
            }
            Console.Clear();
            Console.WriteLine("Nice, you did it!");
        }

        static void GenerateMaze(char[,] maze, Position playerPosition, Position exitPosition)
        {
            Random rnd = new Random();
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    if (x == 0 || x == 29 || y == 0 || y == 29 || rnd.Next(1, 10) <= 3)
                    {
                        maze[x, y] = '#';
                    }
                }
            }

            maze[exitPosition.x, exitPosition.y] = '?';
            maze[playerPosition.x, playerPosition.y] = '@';
        }

        static void GetPlayerAndExitPositions(out Position playerPosition, out Position exitPosition)
        {
            playerPosition = GetRandomPosition();
            exitPosition = GetRandomPosition();
            while (playerPosition.x == exitPosition.x && playerPosition.y == exitPosition.y)
            {
                exitPosition = GetRandomPosition();
            }
        }

        static Position GetRandomPosition()
        {
            Random rnd = new Random();
            Position a = new Position();
            a.x = rnd.Next(1, 28);
            a.y = rnd.Next(1, 28);
            return a;
        }

        static void ShowMaze(char[,] maze)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }

        static void Move(char[,] maze, Position playerPosition, out Position changedPlayerPosition)
        {
            char answer = Console.ReadKey().KeyChar;
            Position newPlayerPosition = new Position();
            newPlayerPosition = playerPosition;
            Console.Clear();
            switch (answer)
            {
                case 'W':
                case 'w':
                    newPlayerPosition.y -= 1;
                    break;
                case 'A':
                case 'a':
                    newPlayerPosition.x -= 1;
                    break;
                case 'S':
                case 's':
                    newPlayerPosition.y += 1;
                    break;
                case 'D':
                case 'd':
                    newPlayerPosition.x += 1;
                    break;
            }

            if (maze[newPlayerPosition.x, newPlayerPosition.y] != '#')
            {
                maze[playerPosition.x, playerPosition.y] = ' ';
                maze[newPlayerPosition.x, newPlayerPosition.y] = '@';
                playerPosition = newPlayerPosition;
            }
            changedPlayerPosition = playerPosition;
        }

    }
}
