using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MoveThing
{
    public class VisibleMap
    {
        Dictionary<string, Resource> inventory;
        Dictionary<string, string> environmentMovementEnablers;
        Collection<Layer> layers;
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

            inventory = new Dictionary<string, Resource>();
            environmentMovementEnablers = new Dictionary<string, string>();
            Layers = new Collection<Layer>();
            random = new Random();

            godMode = false;

            dungeon.CreateDungeon(70, 70, 400);
            dungeon.SaveDungeon(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\", "random");
            Tile[] tiles = dungeon.GetDungeon();

            CurrentRow = 35;
            currentColumn = 35;

            monsterMoveTimer = new Timer();
            monsterMoveTimer.Tick -= MonsterMoveTimer_Tick;
            monsterMoveTimer.Tick += MonsterMoveTimer_Tick;
            monsterMoveTimer.Interval = 200;
            monsterMoveTimer.Start();

            history = new StringBuilder();

            ResourceGenerator.Generate();
        }

        private void MonsterMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveResources();
            RefreshMap();
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

        public Collection<Layer> Layers
        {
            get
            {
                return layers;
            }

            set
            {
                layers = value;
            }
        }

        public void AddToHistory(string description)
        {
            history.Insert(0, description + Environment.NewLine);
        }

        public void MoveUp()
        {
            if (CanResourceMoveTo(currentRow - 1, currentColumn))
            {
                AddToHistory("The wizard moved north.");
                CurrentRow -= 1;
                RefreshMap();
            }
        }

        public void MoveDown()
        {
            if (CanResourceMoveTo(currentRow + 1, currentColumn))
            {
                AddToHistory("The wizard moved south.");
                CurrentRow += 1;
                RefreshMap();
            }
        }

        public void MoveRight()
        {
            if (CanResourceMoveTo(currentRow, currentColumn + 1))
            {
                AddToHistory("The wizard moved east.");
                CurrentColumn += 1;
                RefreshMap();
            }
        }

        public void MoveLeft()
        {
            if (CanResourceMoveTo(currentRow, currentColumn - 1))
            {
                AddToHistory("The wizard moved west.");
                CurrentColumn -= 1;
                RefreshMap();
            }
        }

        public bool CheckMovementByMap(Layer layer, Resource resource, int row, int column)
        {
            if (godMode)
                return true;
            bool canMoveTo = false;
            int movementEnablerCount = 0;
            foreach (var restriction in resource.MovementRestrictions)
            {
                foreach (var inventoryItem in inventory.Values)
                {
                    foreach (var movementEnabler in inventoryItem.MovementEnablers)
                    {
                        if (movementEnabler == restriction)
                        {
                            movementEnablerCount++;
                            AddToHistory(string.Format("The wizard used the {0} on the {1}.", inventoryItem.Name, resource.Name));
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

            if (resource.MovementRestrictions.Count == movementEnablerCount)
            {
                canMoveTo = true;
            }
            if (resource.MovementRestrictions.Count == 0)
            {
                canMoveTo = true;
            }
            if (canMoveTo == false)
            {
                if (resource.CanBeDestroyed)
                {
                    Collection<string> damageEnablers = new Collection<string>();
                    foreach (var restriction in resource.DamageRestrictions)
                    {
                        foreach (var inventoryItem in inventory.Values)
                        {
                            foreach (var damageEnabler in inventoryItem.DamageEnablers)
                            {
                                if (restriction == damageEnabler)
                                {
                                    if (!damageEnablers.Contains(damageEnabler))
                                    {
                                        damageEnablers.Add(damageEnabler);
                                    }
                                }
                            }
                        }
                    }
                    if (resource.DamageRestrictions.Count == damageEnablers.Count)
                    {
                        resource.Health -= 2;
                        AddToHistory(string.Format("You hit the {0} for 2 damage.", resource.Name));
                        if (resource.Health < 0)
                        {
                            layer.DeleteResource(row, column);

                        }
                    }           
                    else
                    {
                        AddToHistory(string.Format("The {0} resists your attack.", resource.Name));
                    }
                }
                else
                {
                    AddToHistory(string.Format("You shall not pass this {0}.", resource.Name));
                }

                RefreshMap();
            }
            return canMoveTo;
        }

        public bool CanResourceMoveTo(int row, int column)
        {
            bool canMoveTo = true;
            foreach (var layer in layers)
            {
                if (!CheckMovementByMap(layer,layer.GetResource(row, column),row,column))
                {
                    canMoveTo = false;
                    break;
                }
            }
            return canMoveTo;
        }

        public void Pickup()
        {
            foreach (var layer in layers)
            {
                Resource currentResource = layer.GetResource(currentRow, currentColumn);
                if (currentResource.CanPickup)
                {
                    inventory.Add(currentResource.MapId, currentResource);
                    AddToHistory(string.Format("The wizard picked up a {0}.", currentResource.Name));
                    layer.DeleteResource(currentRow, currentColumn);
                }
            }

            RefreshMap();

        }

        public void Drop()
        {
            foreach (var item in inventory.items)
            {
                inventory.remove(item)
             }
            foreach (var layer in layers)
            {
                
            }

        }

        public void Use()
        {
            foreach (var layer in layers)
            {
                Resource currentResource = layer.GetResource(currentRow, currentColumn);
                if (currentResource.CanUse)
                {
                    foreach (var enabler in currentResource.MovementEnablers)
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

                    layer.ToggleResource(currentRow, currentColumn);
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

        private void MoveResources()
        {
            foreach (var layer in layers)
            {
                Collection<KeyValuePair<string, Resource>> resourcesToMove = new Collection<KeyValuePair<string, Resource>>();

                foreach (KeyValuePair<string, Resource> item in layer.Resources)
                {
                    if (item.Value.CanMove)
                    {
                        resourcesToMove.Add(item);
                    }
                }

                foreach (var resource in resourcesToMove)
                {
                    if (resource.Value.Speed == resource.Value.Readiness)
                    {
                        int currentRow = Convert.ToInt32(resource.Key.Split('-')[0]);
                        int currentColumn = Convert.ToInt32(resource.Key.Split('-')[1]);
                        for (int i = 0; i < 150; i++)
                        {
                            int direction = random.Next(0, 4);

                            if (direction == 0)
                            {
                                if (CanResourceMoveTo(currentRow + 1, currentColumn))
                                {
                                    layer.MoveResource(currentRow, currentColumn, currentRow + 1, currentColumn);
                                    break;
                                }
                            }
                            if (direction == 1)
                            {
                                if (CanResourceMoveTo(currentRow - 1, currentColumn))
                                {
                                    layer.MoveResource(currentRow, currentColumn, currentRow - 1, currentColumn);

                                    break;
                                }
                            }
                            if (direction == 2)
                            {
                                if (CanResourceMoveTo(currentRow, currentColumn + 1))
                                {
                                    layer.MoveResource(currentRow, currentColumn, currentRow, currentColumn + 1);

                                    break;
                                }
                            }
                            if (direction == 3)
                            {
                                if (CanResourceMoveTo(currentRow, currentColumn - 1))
                                {
                                    layer.MoveResource(currentRow, currentColumn, currentRow, currentColumn - 1);

                                    break;
                                }
                            }
                        }
                        resource.Value.Readiness = 0;
                    }
                    else
                    {
                        resource.Value.Readiness++;
                    }
                }
            }
        }

        public void RefreshMap()
        {
            Bitmap visibleBitmap = new Bitmap(drawingContext.Width, drawingContext.Height);
            Graphics visibleGraphics = Graphics.FromImage(visibleBitmap);

            int numberOfVisibleRows = drawingContext.Height / 32;
            int numberOfVisibleColumns = drawingContext.Width / 32;

            foreach (var layer in layers)
            {
                layer.ClearFog(3, currentRow, currentColumn);
                layer.Draw(visibleBitmap, currentRow - numberOfVisibleRows / 2, currentColumn - numberOfVisibleColumns / 2, currentRow + numberOfVisibleRows / 2, currentColumn + numberOfVisibleColumns / 2);
            }
            int w = (int)Math.Truncate((double)(drawingContext.Width / 32) / 2) * 32;
            int h = (int)Math.Truncate((double)(drawingContext.Height / 32) / 2) * 32;

            visibleGraphics.DrawImageUnscaled(new Bitmap(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\wizard.png"), w, h);

            if (drawingContext.Image != null)
            {
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