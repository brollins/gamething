using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveThing
{
    public class VisibleMap
    {
        string[] terrainMap;
        string[] itemMap;
        string[] monsterMap;
        Dictionary<string, Terrain> terrainTypes;
        Dictionary<string, Item> itemTypes;
        Dictionary<string, Monster> monsterTypes;
        Dictionary<string, Item> inventory;
        Dictionary<string, Bitmap> sprites;
        Dictionary<string, string> environmentMovementEnablers;
        private PictureBox drawingContext;
        private TextBox txtHistory;
        private TextBox txtInventory;
        int currentRow;
        int currentColumn;
        int spriteSize = 32;
        bool godMode;
        Timer monsterMoveTimer;
        Random random;
        Dungeon dungeon = new Dungeon(new Random(), null);

        StringBuilder history;


        public VisibleMap(PictureBox drawingContext, TextBox txtHistory, TextBox txtInventory)
        {
            this.drawingContext = drawingContext;
            this.txtHistory = txtHistory;
            this.txtInventory = txtInventory;

            terrainTypes = new Dictionary<string, Terrain>();
            itemTypes = new Dictionary<string, Item>();
            monsterTypes = new Dictionary<string, Monster>();
            inventory = new Dictionary<string, Item>();
            environmentMovementEnablers = new Dictionary<string, string>();
            random = new Random();


            sprites = new Dictionary<string, Bitmap>();
            sprites.Add("wizard", new Bitmap(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\Sprites\wizard.png"));

            LoadTerrainResources();
            LoadItemResources();
            LoadMonsterResources();

            godMode = false;

            dungeon.CreateDungeon(101, 101, 400);
            dungeon.SaveDungeon(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\", "random");
            Tile[] tiles = dungeon.GetDungeon();

            monsterMoveTimer = new Timer();
            monsterMoveTimer.Tick -= MonsterMoveTimer_Tick;
            monsterMoveTimer.Tick += MonsterMoveTimer_Tick;
            monsterMoveTimer.Interval = 1500;
            monsterMoveTimer.Start();

            history = new StringBuilder();
            
            ResourceGenerator.Generate();

        }

        private void MonsterMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveMonster();
            RefreshMap();
        }

        private void MoveMonster()
        {
            string[] monsterMapSnapshot = (string[])monsterMap.Clone();
            for (int row = 0; row < monsterMapSnapshot.Length; row++)
            {
                for (int column = 0; column < monsterMapSnapshot[row].Length; column++)
                {
                    if (monsterMapSnapshot[row][column] != '`')
                    {
                        string currentMonsterId = monsterMapSnapshot[row][column].ToString();
                        for (int i = 0; i < 150; i++)
                        {
                            int direction = random.Next(0, 4);

                            if (direction == 0)
                            {
                                if (CanMoveTo(terrainMap[row + 1][column].ToString()))
                                {
                                    ReplaceItemOnMap(monsterMap, row, column, "`");
                                    ReplaceItemOnMap(monsterMap, row + 1, column, currentMonsterId);
                                    break;
                                }
                            }
                            if (direction == 1)
                            {
                                if (CanMoveTo(terrainMap[row - 1][column].ToString()))
                                {
                                    ReplaceItemOnMap(monsterMap, row, column, "`");
                                    ReplaceItemOnMap(monsterMap, row - 1, column, currentMonsterId);
                                    break;
                                }
                            }
                            if (direction == 2)
                            {
                                if (CanMoveTo(terrainMap[row][column - 1].ToString()))
                                {
                                    ReplaceItemOnMap(monsterMap, row, column, "`");
                                    ReplaceItemOnMap(monsterMap, row, column - 1, currentMonsterId);
                                    break;
                                }
                            }
                            if (direction == 3)
                            {
                                if (CanMoveTo(terrainMap[row][column + 1].ToString()))
                                {
                                    ReplaceItemOnMap(monsterMap, row, column, "`");
                                    ReplaceItemOnMap(monsterMap, row, column + 1, currentMonsterId);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            monsterMoveTimer.Stop();
            monsterMoveTimer.Start();
        }

        public Dictionary<string, Terrain> TerrainTypes
        {
            get
            {
                return terrainTypes;
            }

            set
            {
                terrainTypes = value;
            }
        }

        public int CurrentRow
        {
            get
            {
                return currentRow;
            }

            set
            {
                currentRow = value;
            }
        }

        public int CurrentColumn
        {
            get
            {
                return currentColumn;
            }

            set
            {
                currentColumn = value;
            }
        }

        public StringBuilder History
        {
            get
            {
                return history;
            }

            set
            {
                history = value;
            }
        }

        public int SpriteSize
        {
            get
            {
                return spriteSize;
            }

            set
            {
                spriteSize = value;
            }
        }

        public void LoadTerrainResources()
        {
            string[] resources = Directory.GetFiles(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\", "terrain-*.json");
            foreach (var file in resources)
            {
                Terrain currentTerrain = JsonConvert.DeserializeObject<Terrain>(File.ReadAllText(file));
                terrainTypes.Add(currentTerrain.MapId, currentTerrain);
            }
        }

        public void LoadItemResources()
        {
            string[] resources = Directory.GetFiles(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\", "item-*.json");
            foreach (var file in resources)
            {
                Item currentItem = JsonConvert.DeserializeObject<Item>(File.ReadAllText(file));
                itemTypes.Add(currentItem.MapId, currentItem);
            }
        }

        public void LoadMonsterResources()
        {
            string[] resources = Directory.GetFiles(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\", "monster-*.json");
            foreach (var file in resources)
            {
                Monster currentMonster = JsonConvert.DeserializeObject<Monster>(File.ReadAllText(file));
                monsterTypes.Add(currentMonster.MapId, currentMonster);
            }
        }

        public void LoadTerrainMap(string file)
        {
            terrainMap = File.ReadAllLines(file);           
            
        }
    

        public void LoadItemMap(string file)
        {
            itemMap = File.ReadAllLines(file);

            for (int row = 0; row < itemMap.Length; row++)
            {
                for (int column = 0; column < itemMap[row].Length; column++)
                {
                    if (itemMap[row][column].ToString() == "a")
                    {
                        currentRow = row;
                        currentColumn = column;
                    }
                }
            }
        }

        public void LoadMonsterMap(string file)
        {
            monsterMap = File.ReadAllLines(file);
        }

        public void AddToHistory(string description)
        {
            history.Insert(0, description + Environment.NewLine);
        }

        public void MoveUp()
        {
            if (CanMoveTo(terrainMap[currentRow - 1][currentColumn].ToString()))
            {
                AddToHistory("The wizard moved north.");
                CurrentRow -= 1;
                RefreshMap();
            }
        }

        public void MoveDown()
        {
            if (CanMoveTo(terrainMap[currentRow + 1][currentColumn].ToString()))
            {
                AddToHistory("The wizard moved south.");

                CurrentRow += 1;
                RefreshMap();

            }
        }

        public void MoveRight()
        {
            if (CanMoveTo(terrainMap[currentRow][currentColumn + 1].ToString()))
            {
                AddToHistory("The wizard moved east.");

                CurrentColumn += 1;
                RefreshMap();


            }
        }

        public void MoveLeft()
        {
            if (CanMoveTo(terrainMap[currentRow][currentColumn - 1].ToString()))
            {
                AddToHistory("The wizard moved west.");

                CurrentColumn -= 1;
                RefreshMap();


            }
        }

        public bool CanMoveTo(string terrainType)
        {
            if (godMode)
                return true;
            bool canMoveTo = false;
            int movementEnablerCount = 0;
            foreach (var restriction in terrainTypes[terrainType].MovementRestrictions)
            {
                foreach (var inventoryItem in inventory.Values)
                {
                    foreach (var movementEnabler in inventoryItem.MovementEnablers)
                    {
                        if (movementEnabler == restriction)
                        {
                            movementEnablerCount++;
                            AddToHistory(string.Format("The wizard used the {0} on the {1}.", inventoryItem.Name, terrainTypes[terrainType].Name));
                        }
                    }
                }
                foreach (var enabler in environmentMovementEnablers)
                {
                    if (enabler.Value == restriction)
                    {
                        movementEnablerCount++;
                    }
                }
            }

            if (terrainTypes[terrainType].MovementRestrictions.Count == movementEnablerCount)
            {
                canMoveTo = true;
            }
            if (terrainTypes[terrainType].MovementRestrictions.Count == 0)
            {
                canMoveTo = true;
            }
            if (canMoveTo == false)
            {
                AddToHistory(string.Format("You shall not pass this {0}.", terrainTypes[terrainType].Name));
                RefreshMap();
            }
            return canMoveTo;
        }

        public void Pickup()
        {
            if (itemTypes.ContainsKey(itemMap[currentRow][currentColumn].ToString()))
            {
                Item item = itemTypes[(itemMap[currentRow][currentColumn].ToString())];
                if (item.CanPickup)
                {
                    inventory.Add(item.MapId, item);
                    AddToHistory(string.Format("The wizard picked up a {0}.", item.Name));

                    ReplaceItemOnMap(itemMap, currentRow, currentColumn, "`");
                }
                else
                {
                    AddToHistory("That can't be picked up.");
                }
                RefreshMap();
            }
        }

        public void Use()
        {
            if (itemTypes.ContainsKey(itemMap[currentRow][currentColumn].ToString()))
            {
                Item item = itemTypes[(itemMap[currentRow][currentColumn].ToString())];
                if (item.CanUse)
                {
                    foreach (var enabler in item.MovementEnablers)
                    {
                        if (environmentMovementEnablers.ContainsKey(enabler))
                        {
                            environmentMovementEnablers.Remove(enabler);
                            AddToHistory("Something has changed...again?");
                        }
                        else
                        {
                            environmentMovementEnablers.Add(enabler, enabler);
                            AddToHistory("Something has changed...");
                        }
                    }
                    ReplaceItemOnMap(itemMap, currentRow, currentColumn, item.ToggleMapId);
                }
                else
                {
                    AddToHistory("There is nothing to use here.");
                }
                RefreshMap();
            }
        }

        public void ReplaceItemOnMap(string[] map, int row, int column, string newItem)
        {
            var aStringBuilder = new StringBuilder(map[row]);
            aStringBuilder.Remove(column, 1);
            aStringBuilder.Insert(column, newItem);
            map[row] = aStringBuilder.ToString();
        }


        public void DrawMap(string[] map, Graphics visibleGraphics, string mapType)
        {

            for (int row = 0; row < map.Length; row++)
            {
                for (int column = 0; column < map[row].Length; column++)
                {
                    if (!sprites.ContainsKey(string.Format("{0}-{1}", mapType, map[row][column].ToString())) && map[row][column] != '`')
                    {
                        Bitmap currentSprite = new Bitmap(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\Sprites\{0}-{1}.png", mapType, map[row][column]));
                        sprites.Add(string.Format("{0}-{1}", mapType, map[row][column].ToString()), currentSprite);
                    }
                    if (map[row][column] != '`')
                    {
                        visibleGraphics.DrawImageUnscaled(sprites[string.Format("{0}-{1}", mapType, map[row][column].ToString())], column * spriteSize - (CurrentColumn * spriteSize) + drawingContext.Width / 2, row * spriteSize - (CurrentRow * spriteSize) + drawingContext.Height / 2);
                    }
                }
            }
        }


        public void RefreshMap()
        {
            Bitmap visibleBitmap = new Bitmap(terrainMap[0].Length * spriteSize, terrainMap.Length * spriteSize);
            Graphics visibleGraphics = Graphics.FromImage(visibleBitmap);

            DrawMap(terrainMap, visibleGraphics, "terrain");
            DrawMap(itemMap, visibleGraphics, "item");
            DrawMap(monsterMap, visibleGraphics, "monster");

           
            visibleGraphics.DrawImageUnscaled(sprites["wizard"], drawingContext.Width / 2, drawingContext.Height / 2);
            if (drawingContext.Image != null) {
                drawingContext.Image.Dispose();
            }
            drawingContext.Image = visibleBitmap;
            Application.DoEvents();
            txtHistory.Text = history.ToString();
            txtInventory.Text = "";
            foreach (var inventoryItem in inventory.Values)
            {
                txtInventory.Text += inventoryItem.Name + Environment.NewLine;
            }
        }
    }
}
