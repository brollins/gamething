using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class DungeonGenerator
    {
        private int dungeonHeight;
        private int dungeonWidth;
        private int maxRoomSize;
        private int minRoomSize;
        private int minFillPercentage;
        private int maxFillPercentage;
        private int maxTriesToFillDungeon;
        private int maxTriesToPlaceRoom;
        private bool canRoomsTouch;
        private char wallCharacter;
        private char floorCharacter;
        private char fogCharacter;
        private char nonResourceCharacter;
        private char[,] dungeonMap;
        private int randomSeed;
        Random random;



        public DungeonGenerator() : this(100, 100, 12, 4, 45)
        {

        }

        public DungeonGenerator(int dungeonHeight, int dungeonWidth) : this(dungeonHeight, dungeonWidth, 20, 3, 50)
        {

        }

        public DungeonGenerator(int dungeonHeight, int dungeonWidth, int maxRoomSize, int minRoomSize, int minFillPercentage)
        {
            this.dungeonHeight = dungeonHeight;
            this.dungeonWidth = dungeonWidth;
            this.maxRoomSize = maxRoomSize;
            this.minRoomSize = minRoomSize;
            this.minFillPercentage = minFillPercentage;

            maxTriesToFillDungeon = 1000;
            maxTriesToPlaceRoom = 10;
            canRoomsTouch = true;
            wallCharacter = '1';
            floorCharacter = '4';
            fogCharacter = 'o';
            nonResourceCharacter = '`';
            dungeonMap = new char[dungeonHeight, dungeonWidth];
        }

        #region Properties
        public int DungeonHeight
        {
            get
            {
                return dungeonHeight;
            }

            set
            {
                dungeonHeight = value;
            }
        }

        public int DungeonWidth
        {
            get
            {
                return dungeonWidth;
            }

            set
            {
                dungeonWidth = value;
            }
        }

        public int MinFillPercentage
        {
            get
            {
                return minFillPercentage;
            }

            set
            {
                minFillPercentage = value;
            }
        }

        public int MaxFillPercentage
        {
            get
            {
                return maxFillPercentage;
            }

            set
            {
                maxFillPercentage = value;
            }
        }

        public int MaxTriesToPlaceRoom
        {
            get
            {
                return maxTriesToPlaceRoom;
            }

            set
            {
                maxTriesToPlaceRoom = value;
            }
        }

        public int MaxTriesToFillDungeon
        {
            get
            {
                return maxTriesToFillDungeon;
            }

            set
            {
                maxTriesToFillDungeon = value;
            }
        }

        public bool CanRoomsTouch
        {
            get
            {
                return canRoomsTouch;
            }

            set
            {
                canRoomsTouch = value;
            }
        }

        public char FloorCharacter
        {
            get
            {
                return floorCharacter;
            }

            set
            {
                floorCharacter = value;
            }
        }

        public char WallCharacter
        {
            get
            {
                return wallCharacter;
            }

            set
            {
                wallCharacter = value;
            }
        }

        public char[,] DungeonMap
        {
            get
            {
                return dungeonMap;
            }

            set
            {
                dungeonMap = value;
            }
        }

        public int RandomSeed
        {
            get
            {
                if (randomSeed == 0)
                {
                    randomSeed = DateTime.UtcNow.Millisecond;
                }
                return randomSeed;
            }

            set
            {
                randomSeed = value;
            }
        }


        #endregion

        private void SaveDungeon(string fileName)
        {
            string[] dungeonArray = new string[dungeonHeight];

            for (int row = 0; row < dungeonHeight; row++)
            {
                string rowString = "";
                for (int column = 0; column < dungeonWidth; column++)
                {
                    rowString += dungeonMap[row, column];
                }
                dungeonArray[row] = rowString;
            }
            File.WriteAllLines(fileName, dungeonArray);            
        }

        public void GenerateTerrain(string fileName)
        {
            CreateBlankDungeon(wallCharacter);
            random = new Random(RandomSeed);

            for (int j = 0; j < maxTriesToFillDungeon; j++)
            {

                int numberOfWalls = 0;
                int numberOfFloors = 0;

                for (int row = 0; row < dungeonHeight; row++)
                {
                    for (int column = 0; column < dungeonWidth; column++)
                    {
                        if (dungeonMap[row, column] == wallCharacter)
                        {
                            numberOfWalls++;
                        }
                        else
                        {
                            numberOfFloors++;
                        }
                    }
                }

                if (((double)numberOfFloors / (double)(dungeonHeight * dungeonWidth) * 100) > minFillPercentage)
                {
                    break;
                }

                DungeonLocation dungeonLocation = new DungeonLocation(random.Next(1, dungeonHeight), random.Next(1,dungeonWidth));
                bool isAlreadyARoom = false;

                int randomRoomHeight = random.Next(minRoomSize, maxRoomSize + 1);
                int randomRoomWidth = random.Next(minRoomSize, maxRoomSize + 1);
                
                dungeonLocation.Row -= 1;
                dungeonLocation.Column -= 1;
                randomRoomHeight += 2;
                randomRoomWidth += 2;

                for (int i = 0; i < maxTriesToPlaceRoom; i++)
                {
                    int height = dungeonLocation.Row + randomRoomHeight;
                    if (height < dungeonHeight)
                    {
                        for (int row = dungeonLocation.Row; row < height; row++)
                        {
                            int width = dungeonLocation.Column + randomRoomWidth;
                            if (width < dungeonWidth)
                            {
                                for (int column = dungeonLocation.Column; column < width; column++)
                                {
                                    char currentLocation = dungeonMap[row, column];
                                    if (currentLocation == floorCharacter)
                                    {
                                        isAlreadyARoom = true;
                                        break;
                                    }
                                }

                                if (isAlreadyARoom) break;
                            }
                            else
                            {
                                isAlreadyARoom = true;
                                break;
                            }
                            //if (!isAlreadyARoom)
                            //{
                            //    break;
                            //}
                        }
                    }
                    else
                    {
                        isAlreadyARoom = true;
                        break;
                    }
                }

                dungeonLocation.Row += 1;
                dungeonLocation.Column += 1;
                randomRoomHeight -= 2;
                randomRoomWidth -= 2;


                if (!isAlreadyARoom)
                {
                    for (int row = dungeonLocation.Row; row < dungeonLocation.Row + randomRoomHeight; row++)
                    {
                        int width = dungeonLocation.Column + randomRoomWidth;

                        for (int column = dungeonLocation.Column; column < width; column++)
                        {
                            dungeonMap[row, column] = floorCharacter;
                        }
                    }
                }
            }

            AddHallways(1,10,2);
            AddHallways(10, 1,4);

            SaveDungeon(fileName);


        }

        public void GenerateFog(string fileName)
        {
            CreateBlankDungeon(fogCharacter);
            SaveDungeon(fileName);
        }

        public void GenerateResources(string fileName)
        {
            CreateBlankDungeon(nonResourceCharacter);





            SaveDungeon(fileName);

        }

        private void AddHallways(int randomRoomHeight, int randomRoomWidth, int additionalFillPercentage)
        {
            for (int j = 0; j < maxTriesToFillDungeon; j++)
            {
               

                DungeonLocation dungeonLocation = new DungeonLocation(random.Next(dungeonHeight + 1), random.Next(dungeonWidth + 1));
                bool isAlreadyARoom = false;

                int numberOfWalls = 0;
                int numberOfFloors = 0;

                for (int row = 0; row < dungeonHeight; row++)
                {
                    for (int column = 0; column < dungeonWidth; column++)
                    {
                        if (dungeonMap[row, column] == wallCharacter)
                        {
                            numberOfWalls++;
                        }
                        else
                        {
                            numberOfFloors++;
                        }
                    }
                }

                if ((((double)numberOfFloors / (double)(dungeonHeight * dungeonWidth)) * 100) > minFillPercentage + additionalFillPercentage)
                {
                    break;
                }

                for (int i = 0; i < maxTriesToPlaceRoom; i++)
                {
                    int height = dungeonLocation.Row + randomRoomHeight;
                    if (height < dungeonHeight)
                    {
                        for (int row = dungeonLocation.Row; row < height; row++)
                        {
                            int width = dungeonLocation.Column + randomRoomWidth;
                            if (width < dungeonWidth)
                            {
                                for (int column = dungeonLocation.Column; column < width; column++)
                                {
                                    string currentLocation = dungeonMap[row, column].ToString();
                                    if (currentLocation == "4")
                                    {
                                        //isAlreadyARoom = true;
                                        //break;
                                    }
                                }

                                if (isAlreadyARoom) break;
                            }
                            else
                            {
                                isAlreadyARoom = true;
                                break;
                            }
                            if (!isAlreadyARoom)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        isAlreadyARoom = true;
                        break;
                    }
                }

                if (!isAlreadyARoom)
                {
                    for (int row = dungeonLocation.Row; row < dungeonLocation.Row + randomRoomHeight; row++)
                    {
                        int width = dungeonLocation.Column + randomRoomWidth;

                        for (int column = dungeonLocation.Column; column < width; column++)
                        {
                            dungeonMap[row, column] = floorCharacter;
                        }
                    }
                }
            }
        }

        private void CreateBlankDungeon(char defaultCharacter)
        {
            for (int row = 0; row < dungeonHeight; row++)
            {
                for (int column = 0; column < dungeonWidth; column++)
                {
                    dungeonMap[row, column] = defaultCharacter;
                }
            }
        }






        // create method to return width/height
        // create method to loop through 
        // replace on 

    }
}
