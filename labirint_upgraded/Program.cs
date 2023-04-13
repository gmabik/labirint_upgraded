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
            int width = 30;
            int height = 30;
            int wallDensity = 30;
            char[,] maze = new char[width, height];
            Position playerPosition = new Position();
            Position exitPosition = new Position();
            GetPlayerAndExitPositions(maze, out playerPosition, out exitPosition);
            GenerateMaze(maze, playerPosition, exitPosition, wallDensity);
            ShowMaze(maze);

            while (playerPosition.x != exitPosition.x || playerPosition.y != exitPosition.y)
            {
                Position newPlayerPosition = Input(playerPosition);
                Move(maze, playerPosition, newPlayerPosition, out playerPosition);
                Console.Clear();
                ShowMaze(maze);
            }
            Console.WriteLine("Nice, you did it!");
        }

        static void GenerateMaze(char[,] maze, Position playerPosition, Position exitPosition, int wallChance)
        {
            Random rnd = new Random();
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    if (rnd.Next(0, 100) <= wallChance)
                    {
                        maze[x, y] = '#';
                    }
                    else maze[x, y] = ' ';
                }
            }
            GenerateWallsOfMaze(maze);

            maze[exitPosition.x, exitPosition.y] = '?';
            maze[playerPosition.x, playerPosition.y] = '@';
        }

        static void GenerateWallsOfMaze(char[,] maze)
        {
            for(int y = 0; y < maze.GetLength(1); y+= maze.GetLength(1) - 1)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    maze[x, y] = '#';
                }
            }
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                for (int x = 0; x < maze.GetLength(0); x += maze.GetLength(0) - 1)
                {
                    maze[x, y] = '#';
                }
            }
        }

        static void GetPlayerAndExitPositions(char[,] maze, out Position playerPosition, out Position exitPosition)
        {
            playerPosition = GetRandomPosition(maze);
            exitPosition = GetRandomPosition(maze);
            while (playerPosition.x == exitPosition.x && playerPosition.y == exitPosition.y)
            {
                exitPosition = GetRandomPosition(maze);
            }
        }

        static Position GetRandomPosition(char[,] maze)
        {
            Random rnd = new Random();
            Position a = new Position();
            a.x = rnd.Next(1, maze.GetLength(0) - 2);
            a.y = rnd.Next(1, maze.GetLength(1) - 2);
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

        static void Move(char[,] maze, Position playerPosition, Position newPlayerPosition, out Position changedPlayerPosition)
        {
            if (maze[newPlayerPosition.x, newPlayerPosition.y] != '#')
            {
                maze[playerPosition.x, playerPosition.y] = ' ';
                maze[newPlayerPosition.x, newPlayerPosition.y] = '@';
                playerPosition = newPlayerPosition;
            }
            changedPlayerPosition = playerPosition;
        }

        static Position Input(Position playerPosition)
        {
            char answer = Console.ReadKey().KeyChar;
            switch (answer)
            {
                case 'W':
                case 'w':
                    playerPosition.y -= 1;
                    break;
                case 'A':
                case 'a':
                    playerPosition.x -= 1;
                    break;
                case 'S':
                case 's':
                    playerPosition.y += 1;
                    break;
                case 'D':
                case 'd':
                    playerPosition.x += 1;
                    break;
            }
            return playerPosition;
        }
    }
}
