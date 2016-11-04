using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public static class ResourceGenerator
    {
        public static void Generate()
        {
            Terrain terrain;
            Item item;
            Monster monster;

            //Terrain

            terrain = new Terrain();
            terrain.MapId = "1";
            terrain.MovementRestrictions.Add("stone");
            terrain.Name = "stone wall";
            terrain.Description = "A segment of wall made out of stone.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "2";
            terrain.MovementRestrictions.Add("water");
            terrain.Name = "water";
            terrain.Description = "Liquid Water.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "3";
            terrain.MovementRestrictions.Add("brass door");
            terrain.MovementRestrictions.Add("brass door plate");            
            terrain.Name = "brass door";
            terrain.Description = "A strong, sturdy door with brass inlay.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "4";
            terrain.Name = "stone tile";
            terrain.Description = "A segment of tile made out of stone.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "5";
            terrain.MovementRestrictions.Add("steel door");
            terrain.Name = "steel door";
            terrain.Description = "A strong, sturdy door with steel inlay.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "+";
            terrain.MovementRestrictions.Add("stairs up");
            terrain.Name = "stairs up";
            terrain.Description = "Stairs going up.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "-";
            terrain.MovementRestrictions.Add("stairs down");
            terrain.Name = "stairs down";
            terrain.Description = "Stairs going down.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));

            terrain = new Terrain();
            terrain.MapId = "c";
            terrain.MovementRestrictions.Add("chest");
            terrain.Name = "chest";
            terrain.Description = "A strong, sturdy chest with steel inlay.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", terrain.MapId), JsonConvert.SerializeObject(terrain));



            // Items

            item = new Item();
            item.MapId = "a";
            item.Name = "brass key";
            item.CanPickup = true;
            item.Description = "A brass key.";
            item.MovementEnablers.Add("brass door");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", item.MapId), JsonConvert.SerializeObject(item));

            item = new Item();
            item.MapId = "c";
            item.Name = "water walking potion";
            item.CanPickup = true;
            item.Description = "A potion of water walking.";
            item.MovementEnablers.Add("water");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", item.MapId), JsonConvert.SerializeObject(item));

            item = new Item();
            item.MapId = "d";
            item.Name = "plate";
            item.CanUse = true;
            item.ToggleMapId = "e";
            item.Description = "A very sensitive plate";
            item.MovementEnablers.Add("brass door plate");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", item.MapId), JsonConvert.SerializeObject(item));

            item = new Item();
            item.MapId = "e";
            item.Name = "plate";
            item.CanUse = true;
            item.ToggleMapId = "d";
            item.Description = "A very sensitive plate";
            item.MovementEnablers.Add("brass door plate");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", item.MapId), JsonConvert.SerializeObject(item));

            item = new Item();
            item.MapId = "f";
            item.Name = "trophy";
            item.CanPickup = true;
            item.Description = "To the victor go the spoils!";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", item.MapId), JsonConvert.SerializeObject(item));

            item = new Item();
            item.MapId = "g";
            item.Name = "steel key";
            item.CanPickup = true;
            item.Description = "A steel key.";
            item.MovementEnablers.Add("steel door");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", item.MapId), JsonConvert.SerializeObject(item));


            // Monster

            monster = new Monster();
            monster.MapId = "!";
            monster.Name = "green dragon";
            monster.Description = "A green dragon.";            
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monster-{0}.json", monster.MapId), JsonConvert.SerializeObject(monster));

            

        }
    }
}
