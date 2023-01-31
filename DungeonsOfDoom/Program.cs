using DungeonsOfDoom.Core;

namespace DungeonsOfDoom
{
    class Program
    {
        const string PLAYER = "P";
        const string ITEM = "I";
        const string MONSTER = "M";
        const string EMPTY = ".";

        Room[,] rooms;
        Player player;
        
        static void Main(string[] args)
        {
            Program program = new();
            program.Play();
        }

        public void Play()
        {
            Console.CursorVisible = false;
            CreatePlayer();
            CreateRooms();
            DisplayRooms();

            do
            {
                DisplayStats();
                AskForMovement();
            } while (player.IsAlive);

            GameOver();
        }

        void CreatePlayer()
        {
            player = new Player(30, 0, 0);
        }

        void CreateRooms()
        {
            rooms = new Room[20, 5];
            for (int column = 0; column < rooms.GetLength(1); column++)
            {
                for (int row = 0; row < rooms.GetLength(0); row++)
                {
                    rooms[row, column] = new Room();

                    int ChanceOfSpawningMonsterOrItem = Random.Shared.Next(1, 100 + 1);
                    if (ChanceOfSpawningMonsterOrItem < 10)
                        rooms[row, column].MonsterInRoom = new Monster("Skeleton", 30);
                    else if (ChanceOfSpawningMonsterOrItem < 20)
                        rooms[row, column].ItemInRoom = new Item("Sword");
                }
            }
        }

        void DisplayRooms()
        {
            for (int column = 0; column < rooms.GetLength(1); column++)
            {
                for (int row = 0; row < rooms.GetLength(0); row++)
                {
                    Room room = rooms[row, column];
                    if (player.RowPosition == row && player.ColumnPosition == column)
                        Console.Write(PLAYER);
                    else if (room.MonsterInRoom != null)
                        Console.Write(MONSTER);
                    else if (room.ItemInRoom != null)
                        Console.Write(ITEM);
                    else
                        Console.Write(EMPTY);
                }
                Console.WriteLine();
            }
        }

        void DisplayStats()
        {
            Console.SetCursorPosition(0, rooms.GetLength(1));
            Console.WriteLine($"Health: {player.Health}");
        }

        void AskForMovement()
        {
            int newRowPositionX = player.RowPosition;
            int newColumnPositionY = player.ColumnPosition;
            bool isInputKeyDirectionValid = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newRowPositionX++; break;
                case ConsoleKey.LeftArrow: newRowPositionX--; break;
                case ConsoleKey.UpArrow: newColumnPositionY--; break;
                case ConsoleKey.DownArrow: newColumnPositionY++; break;
                default: isInputKeyDirectionValid = false; break;
            }

            if (isInputKeyDirectionValid && newRowPositionX >= 0 && newRowPositionX < rooms.GetLength(0) && newColumnPositionY >= 0 && newColumnPositionY < rooms.GetLength(1))
            {
                Console.SetCursorPosition(player.RowPosition, player.ColumnPosition);
                var room = rooms[player.RowPosition, player.ColumnPosition];
                if (room.MonsterInRoom != null)
                    Console.WriteLine(MONSTER);
                else if (room.ItemInRoom != null)
                    Console.WriteLine(ITEM);
                else
                    Console.WriteLine(EMPTY);

                player.RowPosition = newRowPositionX;
                player.ColumnPosition = newColumnPositionY;
                Console.SetCursorPosition(newRowPositionX, newColumnPositionY);
                Console.WriteLine(PLAYER);
            }
        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }
    }
}
