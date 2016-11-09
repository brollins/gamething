using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class Layer
    {

        // ready the sprites
        // draw similar to refresh
        // save the layers

        int height;
        int width;
        string file;
        string name;

        Dictionary<string, Resource> resources;
        Dictionary<string, Bitmap> sprites;

        public Layer(string file)
        {
            resources = new Dictionary<string, Resource>();
            sprites = new Dictionary<string, Bitmap>();
            LoadMap(file);
        }

        public string File
        {
            get
            {
                return file;
            }

            set
            {
                file = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public void LoadMap(string file)
        {
            string[] map = System.IO.File.ReadAllLines(file);
            this.file = file;
            string resourceType = Path.GetFileNameWithoutExtension(file).Split('-')[0];
            height = map.Length;
            width = map[0].Length;

            for (int row = 0; row < map.Length; row++)
            {
                for (int column = 0; column < map[row].Length; column++)
                {
                    string key = string.Format("{0}-{1}", row, column);
                    string resourcePath = Path.GetDirectoryName(file);
                    string resourceIdToLoad = map[row][column].ToString();
                    string resourceFileName = string.Format("{0}-{1}.json", resourceType, resourceIdToLoad);
                    string fullResourcePathFileName = Path.Combine(resourcePath, resourceFileName);

                    resources.Add(key, JsonConvert.DeserializeObject<Resource>(System.IO.File.ReadAllText(fullResourcePathFileName)));
                }
            }
        }

        public Resource GetResource(int row, int column)
        {
            return resources[string.Format("{0}-{1}", row, column)];
        }

        public void MoveResource(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            Resource fromResource = resources[string.Format("{0}, {1}", fromRow.ToString(), fromColumn.ToString())];
            resources[string.Format("{0}, {1}", toRow.ToString(), toColumn.ToString())] = fromResource;
        }

        public void DeleteResource(int row, int column)
        {
            Resource blankResource = new Resource();
            blankResource.MapId = "`";
            UpdateResource(row, column, blankResource);
        }

        public void UpdateResource(int row, int column, Resource updatedResource)
        {
            resources[string.Format("{0}-{1}", row.ToString(), column.ToString())] = updatedResource;
        }

        public void ToggleResource(int row, int column)
        {
            Resource currentResource = GetResource(row, column);
            if (currentResource.ToggleMapId != string.Empty)
            {
                string resourceType = Path.GetFileNameWithoutExtension(file).Split('-')[0];
                string resourcePath = Path.GetDirectoryName(file);
                string resourceIdToLoad = currentResource.ToggleMapId;
                string resourceFileName = string.Format("{0}-{1}.json", resourceType, resourceIdToLoad);
                string fullResourcePathFileName = Path.Combine(resourcePath, resourceFileName);

                UpdateResource(row, column, JsonConvert.DeserializeObject<Resource>(System.IO.File.ReadAllText(fullResourcePathFileName)));
            }
        }

        public void Draw(Bitmap bitmap, int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn)
        {
            for (int row = upperLeftRow; row < lowerRightRow; row++)
            {
                for (int column = upperLeftColumn; column < lowerRightColumn; column++)
                {
                    if (row > 0 && row < height && column > 0 && column < width)
                    {
                        Resource currentResource = resources[string.Format("{0}-{1}", row, column)];
                        if (currentResource.IsVisible)
                        {
                            if (!sprites.ContainsKey(currentResource.MapId))
                            {
                                string resourceType = Path.GetFileNameWithoutExtension(file).Split('-')[0];
                                string resourcePath = Path.GetDirectoryName(file);
                                string resourceFileName = string.Format("{0}-{1}.png", resourceType, currentResource.MapId);
                                string fullResourcePathFileName = Path.Combine(resourcePath, resourceFileName);

                                sprites.Add(currentResource.MapId, new Bitmap(fullResourcePathFileName));
                            }
                            Graphics graphics = Graphics.FromImage(bitmap);
                            graphics.DrawImageUnscaled(sprites[currentResource.MapId], (column - upperLeftColumn) * 32, (row - upperLeftRow) * 32);
                        }
                    }
                }
            }
        }
    }
}
