using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class Item
    {
        private Collection<string> movementEnablers;
        private string mapId;
        private string name;
        private string description;
        private bool canUse;
        private bool canPickup;
        private string toggleMapId;

        public Item()
        {
            MovementEnablers = new Collection<string>();
        }

        public Collection<string> MovementEnablers
        {
            get
            {
                return movementEnablers;
            }

            set
            {
                movementEnablers = value;
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

        public bool CanUse
        {
            get
            {
                return canUse;
            }

            set
            {
                canUse = value;
            }
        }

        public bool CanPickup
        {
            get
            {
                return canPickup;
            }

            set
            {
                canPickup = value;
            }
        }

        public string ToggleMapId
        {
            get
            {
                return toggleMapId;
            }

            set
            {
                toggleMapId = value;
            }
        }
    }
}

