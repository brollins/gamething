using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class Terrain
    {
        // row and column of spritesheet
        // subclasses determine rulesets 
        // collection of restrictions (10ft tall. if you can get over 10ft, no restriction. water restriction, etc. {enumeration}) restrictions will need "antidotes"
        // field containing ID based on mapID
             
        private Collection<string> movementRestrictions;
        private string mapId;
        private string name;
        private string description;

        public Terrain()
        {
            movementRestrictions = new Collection<string>();
        }


        public Collection<string> MovementRestrictions
        {
            get
            {
                return movementRestrictions;
            }

            set
            {
                movementRestrictions = value;
            }
        }

        public string MapId
        {
            get
            {
                return mapId;
            }

            set
            {
                mapId = value;
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
    }
}
