using Newtonsoft.Json;
using System.IO;

namespace MoveThing
{
    public static class ResourceGenerator
    {
        public static void Generate()
        {
            Resource resource;

            //terrain

            resource = new Resource();
            resource.MapId = "`";

            resource.Visibility = ResourceVisibility.Invisible;
            resource.Name = "";
            resource.Description = "";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "1";
            resource.MovementRestrictions.Add("stone");
            resource.Name = "stone wall";
            resource.Description = "A segment of wall made out of stone.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "2";
            resource.MovementRestrictions.Add("water");
            resource.Name = "water";
            resource.Description = "Liquid Water.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "3";
            resource.MovementRestrictions.Add("brass door");
            resource.MovementRestrictions.Add("brass door plate");            
            resource.Name = "brass door";
            resource.Description = "A strong, sturdy door with brass inlay.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));
            
            resource = new Resource();
            resource.MapId = "4";
            resource.Name = "dirt tile";
            resource.Description = "A segment of tile made out of dirt.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "5";
            resource.MovementRestrictions.Add("steel door");
            resource.Name = "steel door";
            resource.Description = "A strong, sturdy door with steel inlay.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "+";
            resource.MovementRestrictions.Add("stairs up");
            resource.Name = "stairs up";
            resource.Description = "Stairs going up.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "-";
            resource.MovementRestrictions.Add("stairs down");
            resource.Name = "stairs down";
            resource.Description = "Stairs going down.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "c";
            resource.MovementRestrictions.Add("chest");
            resource.Name = "chest";
            resource.Description = "A strong, sturdy chest with steel inlay.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "x";
            resource.ToggleMapId = "y";
            resource.CanUse = true;
            resource.IsTrap = true;
            resource.Name = "quicksand";
            resource.Description = "A pit of quicksand.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "y";
            resource.ToggleMapId = "x";
            resource.IsTrap = true;
            resource.Name = "fakedirt";
            resource.Description = "A pit of dirt that looks like quicksand.";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            // items

            resource = new Resource();
            resource.MapId = "`";

            resource.Visibility = ResourceVisibility.Invisible;
            resource.Name = "";
            resource.Description = "";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "a";
            resource.CanUse = true;
            resource.Name = "brass key";
            resource.CanPickup = true;
            resource.ToggleMapId = "b";
            resource.Description = "A brass key.";
            resource.MovementEnablers.Add("brass door");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "b";
            resource.CanUse = true;
            resource.ToggleMapId = "a";
            resource.Name = "steel sword";
            resource.CanPickup = true;
            resource.Description = "A sharp steel sword.";
            resource.DamageModifierDice = "d4-1";
            resource.DamageDice = "d6";
            resource.MovementEnablers.Add("resource");
            resource.DamageEnablers.Add("blade");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "c";
            resource.Name = "water walking potion";
            resource.CanPickup = true;
            resource.Description = "A potion of water walking.";
            resource.MovementEnablers.Add("water");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "h";
            resource.Name = "fly swatter";
            resource.CanPickup = true;
            resource.Description = "A swatter of flies.";
            resource.MovementEnablers.Add("water");
            resource.DamageEnablers.Add("blunt");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "d";
            resource.Name = "plate";
            resource.CanUse = true;
            resource.ToggleMapId = "e";
            resource.Description = "A very sensitive plate";
            resource.MovementEnablers.Add("brass door plate");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "e";
            resource.Name = "plate";
            resource.CanUse = true;
            resource.ToggleMapId = "d";
            resource.Description = "A very sensitive plate";
            resource.MovementEnablers.Add("brass door plate");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "f";
            resource.Name = "trophy";
            resource.CanPickup = true;
            resource.Description = "To the victor go the spoils!";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "g";
            resource.Name = "steel key";
            resource.CanPickup = true;
            resource.Description = "A steel key.";
            resource.MovementEnablers.Add("steel door");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            // monsters

            resource = new Resource();
            resource.MapId = "`";
            resource.Visibility = ResourceVisibility.Invisible;
            resource.Name = "";
            resource.Description = "";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monster-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "!";
            resource.Name = "green dragon";
            resource.CanMove = true;
            resource.SpeedDice = "10";
            resource.HealthDice = "2d6+3";
            resource.Alignment = "evil";
            resource.Readiness = 0;
            resource.CanBeDestroyed = true;
            resource.Description = "A green dragon.";
            resource.DamageRestrictions.Add("blade");
            resource.MovementRestrictions.Add("monster");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monster-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "@";
            resource.Name = "ugly little fly";
            resource.CanMove = true;
            resource.SpeedDice = "10";
            resource.HealthDice = "1d4";
            resource.Alignment = "evil";
            resource.Readiness = 0;
            resource.DamageRestrictions.Add("blunt");
            resource.CanBeDestroyed = true;
            resource.Description = "A hideous flying bug.";
            resource.MovementRestrictions.Add("monster");
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monster-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));
            
            // fog

            resource = new Resource();
            resource.MapId = "o";
            resource.Name = "";
            resource.IsFog = true;
            resource.ToggleMapId = "t";
            resource.Description = "opaque fog";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\fog-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));

            resource = new Resource();
            resource.MapId = "t";
            resource.IsFog = true;
            resource.Visibility = ResourceVisibility.Invisible;
            resource.Name = "";
            resource.Description = "transparent fog";
            File.WriteAllText(string.Format(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\fog-{0}.json", resource.MapId), JsonConvert.SerializeObject(resource));
        }
    }
}
